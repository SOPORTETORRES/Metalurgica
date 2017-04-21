using System;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary2;
using System.Text;

namespace Metalurgica
{
    public partial class frmCrudCamion : Form
    {
        public frmCrudCamion()
        {
            InitializeComponent();
            this.Text += " - versión: " + Application.ProductVersion;
            this.dgvDetalle.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvDetalle_RowPostPaint);
        }

        private void dgvDetalle_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDetalle.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void tlbNuevo_Click(object sender, EventArgs e)
        {
            tlbDesactivar.Enabled = false;
            txtPatente.Clear();
            txtTransportista.Clear();
            txtObs.Clear();
            chkActivo.Checked = true;
            txtPatente.Focus();
        }

        private string eliminarCaracteresEspeciales(string entrada)
        {
            StringUtility stringUtility = new StringUtility();
            string salida = entrada;
            if (!salida.Trim().Equals(""))
                salida = stringUtility.removeInvalidCharacters(salida, stringUtility.RegexPattern_Address);
            return salida;
        }

        private string validarControlesRequeridos()
        {
            StringBuilder sb = new StringBuilder();

            if (txtPatente.Text.Trim().Equals(""))
                sb.Append("- Patente\n");
            if (txtTransportista.Text.Trim().Equals(""))
                sb.Append("- Transportista\n");

            if (txtPatente.Text.Trim().LastIndexOf ("-")>-1)
                sb.Append("- No puede ingresar el caracter -  en el campo Patente\n");

            if (txtPatente.Text.Trim().LastIndexOf(" ") > -1)
                sb.Append("- No puede ingresar espacios en el campo Patente\n");



            return sb.ToString();
        }

        private void tlbGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = validarControlesRequeridos();
            if (mensaje.Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
                WsCrud.Camion camion = new WsCrud.Camion();

                camion.Patente = txtPatente.Text;
                camion.Transportista = txtTransportista.Text;
                camion.Obs = txtObs.Text;
                camion.Activo = (chkActivo.Checked ? "S" : "N");

                camion = wsCrud.GuardarCamion(camion);
                if (camion.MensajeError.Equals(""))
                {
                    tlbActualizar.PerformClick();
                    MessageBox.Show("Registro guardado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(camion.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

                Cursor.Current = Cursors.Default;
            }
            else
                MessageBox.Show("Debe ingresar los siguientes datos requeridos:\n\n" + mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tlbEliminar_Click(object sender, EventArgs e)
        {

        }

        private void tlbDesactivar_Click(object sender, EventArgs e)
        {
            if (!txtPatente.Text.Trim().Equals(""))
            { 
                if (MessageBox.Show("¿Esta seguro que desea desactivar este camion?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
                    WsCrud.Camion camion = new WsCrud.Camion();

                    camion = wsCrud.DesactivarCamion(txtPatente.Text);
                    if (camion.MensajeError.Equals(""))
                    {
                        tlbActualizar.PerformClick();
                        MessageBox.Show("Camion desactivado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(camion.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void tlbActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();

            listaDataSet = wsCrud.ListarCamion();
            if (listaDataSet.MensajeError.Equals(""))
            {
                dgvDetalle.DataSource = listaDataSet.DataSet.Tables[0];
                //tlbNuevo.PerformClick();
                tlbNuevo_Click(sender, e);
                Forms forms = new Forms();
                forms.dataGridViewAutoSizeColumnsMode(dgvDetalle, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                tlbEstado.Text = "Registro(s): " + dgvDetalle.Rows.Count;
            }
            else
                MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            Cursor.Current = Cursors.Default;
        }

        private void tlbImprimir_Click(object sender, EventArgs e)
        {

        }

        private void tlbExportar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                new Excel().exportar(dgvDetalle);
                Cursor.Current = Cursors.Default;
            }
            else
                MessageBox.Show("No existen registros a exportar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlbSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvDetalle_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvDetalle.CurrentRow;
            if (currentRow != null)
            {
                tlbDesactivar.Enabled = true;
                txtPatente.Text = currentRow.Cells[0].Value.ToString();
                txtTransportista.Text = currentRow.Cells[1].Value.ToString();
                txtObs.Text = currentRow.Cells[2].Value.ToString();
                chkActivo.Checked = (currentRow.Cells[3].Value.ToString().Equals("S") ? true : false);
                txtPatente.Focus();
            }
        }

        private void frmCrudCamion_Shown(object sender, EventArgs e)
        {
            tlbActualizar_Click(sender, e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    //e.SuppressKeyPress = true;
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }

        private void txtPatente_Leave(object sender, EventArgs e)
        {
            txtPatente.Text = eliminarCaracteresEspeciales(txtPatente.Text.Trim()).ToUpper();
        }

        private void txtTransportista_Leave(object sender, EventArgs e)
        {
            txtTransportista.Text = eliminarCaracteresEspeciales(txtTransportista.Text.Trim());
        }

        private void txtObs_Leave(object sender, EventArgs e)
        {
            txtObs.Text = eliminarCaracteresEspeciales(txtObs.Text.Trim());
        }
    }
}
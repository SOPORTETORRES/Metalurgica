using System;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary2;
using System.Text;

namespace Metalurgica
{
    public partial class frmCrudMaquina : Form
    {
        public frmCrudMaquina()
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
            lblId.Text = "0";
            txtNombre.Clear();
            txtDescripcion.Clear();
            chkActiva.Checked = true;
            txtNombre.Focus();
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

            //if (txtPatente.Text.Trim().Equals(""))
            //    sb.Append("- Patente\n");
            if (txtNombre.Text.Trim().Equals(""))
                sb.Append("- Nombre\n");
            
            return sb.ToString();
        }

        private void tlbGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = validarControlesRequeridos();
            if (mensaje.Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
                WsCrud.Maquina maquina = new WsCrud.Maquina();

                maquina.Id = Convert.ToInt32(lblId.Text);
                maquina.Nombre = txtNombre.Text;
                maquina.Descripcion = txtDescripcion.Text;
                maquina.Activa = (chkActiva.Checked ? "S" : "N");

                maquina = wsCrud.GuardarMaquina(maquina);
                if (maquina.MensajeError.Equals(""))
                {
                    tlbActualizar.PerformClick();
                    MessageBox.Show("Registro guardado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(maquina.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            if (!lblId.Text.Trim().Equals("0"))
            { 
                if (MessageBox.Show("¿Esta seguro que desea desactivar este Maquina?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
                    WsCrud.Maquina maquina = new WsCrud.Maquina();

                    maquina = wsCrud.DesactivarMaquina(Convert.ToInt32(lblId.Text));
                    if (maquina.MensajeError.Equals(""))
                    {
                        tlbActualizar.PerformClick();
                        MessageBox.Show("Maquina desactivada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(maquina.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void tlbActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();

            listaDataSet = wsCrud.ListarMaquina();
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
                lblId.Text = currentRow.Cells[0].Value.ToString();
                txtNombre.Text = currentRow.Cells[1].Value.ToString();
                txtDescripcion.Text = currentRow.Cells[2].Value.ToString();
                chkActiva.Checked = (currentRow.Cells[3].Value.ToString().Equals("S") ? true : false);
                txtNombre.Focus();
            }
        }

        private void frmCrudMaquina_Shown(object sender, EventArgs e)
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

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            txtNombre.Text = eliminarCaracteresEspeciales(txtNombre.Text.Trim());
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            txtDescripcion.Text = eliminarCaracteresEspeciales(txtDescripcion.Text.Trim());
        }
    }
}
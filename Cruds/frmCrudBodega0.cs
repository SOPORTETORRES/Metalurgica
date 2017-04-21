using System;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary2;
using System.Text;

namespace Metalurgica
{
    public partial class frmCrudBodega0 : Form
    {
        public frmCrudBodega0()
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
            cboTipo.SelectedIndex = 0;
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
                WsCrud.Bodega bodega = new WsCrud.Bodega();

                bodega.Id = Convert.ToInt32(lblId.Text);
                bodega.Tipo = cboTipo.SelectedIndex.ToString();
                bodega.Nombre = txtNombre.Text;
                bodega.Descripcion = txtDescripcion.Text;
                bodega.Activa = (chkActiva.Checked ? "S" : "N");

                bodega = wsCrud.GuardarBodega(bodega);
                if (bodega.MensajeError.Equals(""))
                {
                    tlbActualizar.PerformClick();
                    MessageBox.Show("Registro guardado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(bodega.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (MessageBox.Show("¿Esta seguro que desea desactivar este Bodega?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
                    WsCrud.Bodega bodega = new WsCrud.Bodega();

                    bodega = wsCrud.DesactivarBodega(Convert.ToInt32(lblId.Text));
                    if (bodega.MensajeError.Equals(""))
                    {
                        tlbActualizar.PerformClick();
                        MessageBox.Show("Bodega desactivada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(bodega.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void tlbActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
            WsCrud.ListaDataSet listaDataSet = new WsCrud.ListaDataSet();

            listaDataSet = wsCrud.ListarBodega();
            if (listaDataSet.MensajeError.Equals(""))
            {
                dgvDetalle.DataSource = listaDataSet.DataSet.Tables[0];
                //tlbNuevo.PerformClick();
                tlbNuevo_Click(sender, e);
                Forms forms = new Forms();
                forms.dataGridViewHideColumns(dgvDetalle, new string[] {"BOD_TIPO"});
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
                cboTipo.SelectedIndex = Convert.ToInt32(currentRow.Cells[1].Value.ToString());
                txtNombre.Text = currentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = currentRow.Cells[3].Value.ToString();
                chkActiva.Checked = (currentRow.Cells[4].Value.ToString().Equals("S") ? true : false);
                txtNombre.Focus();
            }
        }

        private void frmCrudBodega0_Shown(object sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;
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
using System;
using System.Windows.Forms;
using CommonLibrary2;
using System.Text;
using System.Data;
using System.Drawing;

namespace Metalurgica
{
    public partial class frmDespachoBodegaAcopio : Form
    {
        private const string COLUMNNAME_ETIQUETA_PIEZA = "ETIQUETA_PIEZA";

        public frmDespachoBodegaAcopio()
        {
            InitializeComponent();
            this.dgvEtiquetasPiezas.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvEtiquetasPiezas_RowPostPaint);
            this.dgvDespachosBodegaAcopio.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvDespachosBodegaAcopio_RowPostPaint);
        }

        private void dgvEtiquetasPiezas_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvEtiquetasPiezas.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDespachosBodegaAcopio_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDespachosBodegaAcopio.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void tlbNuevo_Click(object sender, EventArgs e)
        {
            txtBodegaAcopio.Clear();
            txtObs.Clear();
            txtEtiquetaPieza.Clear();
            dgvEtiquetasPiezas.DataSource = null;
            lblCantidadEtiquetasPiezas.Text = "Registro(s): 0";
            txtBodegaAcopio.Focus();
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

            if (txtBodegaAcopio.Text.Trim().Equals(""))
                sb.Append("- Bodega Acopio\n");
            if (!txtBodegaAcopio.Text.Trim().Equals("") && !new CommonLibrary2.Information().isNumber(txtBodegaAcopio.Text))
                sb.Append("- Bodega Acopio (valor numérico)\n");
            if (dgvEtiquetasPiezas.Rows.Count == 0)
                sb.Append("- Pieza(s)\n");

            return sb.ToString();
        }

        private void tlbGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = validarControlesRequeridos();
            if (mensaje.Equals(""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.Despacho_Bodega_Acopio despacho_Bodega_Acopio = new WsOperacion.Despacho_Bodega_Acopio();

                    despacho_Bodega_Acopio.Id = 0;
                    despacho_Bodega_Acopio.Bodega_Id = Convert.ToInt32(txtBodegaAcopio.Text);
                    despacho_Bodega_Acopio.Usuario = Program.currentUser.Login;
                    //despacho_Bodega_Acopio.Fecha = ""; 
                    despacho_Bodega_Acopio.Obs = txtObs.Text;

                    despacho_Bodega_Acopio = wsOperacion.GuardarDespachoPiezaBodegaAcopio(despacho_Bodega_Acopio, Program.currentUser.ComputerName);
                    if (despacho_Bodega_Acopio.MensajeError.Equals(""))
                    {
                        int idDespacho = despacho_Bodega_Acopio.Id;

                        foreach (DataGridViewRow row in dgvEtiquetasPiezas.Rows)
                        {
                            despacho_Bodega_Acopio = wsOperacion.AsociarEtiquetaPiezaaBodegaAcopio(idDespacho, row.Cells[COLUMNNAME_ETIQUETA_PIEZA].Value.ToString(), Program.currentUser.Login, Program.currentUser.ComputerName);
                            if (despacho_Bodega_Acopio.MensajeError.Equals(""))
                            {
                                //tlbActualizar.PerformClick();
                                //MessageBox.Show("Registro(s) guardado(s).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(despacho_Bodega_Acopio.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //tlbNuevo.PerformClick();
                        tlbNuevo_Click(sender, e);
                        MessageBox.Show("Registro(s) guardado(s).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(despacho_Bodega_Acopio.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        }

        private void tlbActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                switch (tabOperaciones.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        if (!txtBodegaAcopio.Text.Trim().Equals(""))
                        {
                            lblBodegaAcopio.Text = txtBodegaAcopio.Text;
                            listaDataSet = wsOperacion.ListarDespachoBodegaAcopio(Convert.ToInt32(txtBodegaAcopio.Text));
                            if (listaDataSet.MensajeError.Equals(""))
                            {
                                dgvDespachosBodegaAcopio.DataSource = listaDataSet.DataSet.Tables[0];
                                Forms forms = new Forms();
                                //forms.dataGridViewHideColumns(dgvDespachosBodegaMP, new string[] { "ID", "REC_ESTADO" });
                                forms.dataGridViewAutoSizeColumnsMode(dgvDespachosBodegaAcopio, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                                //tlbEstado.Text = "Registro(s): " + dgvDespachosBodegaMP.Rows.Count;
                                lblCantidadDespachosBodegaAcopio.Text = "Registro(s): " + dgvDespachosBodegaAcopio.Rows.Count;
                            }
                            else
                                MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        private void tlbImprimir_Click(object sender, EventArgs e)
        {

        }

        private void tlbExportar_Click(object sender, EventArgs e)
        {
            DataGridView dgvActiva = null;

            switch (tabOperaciones.SelectedIndex)
            {
                case 0:
                    dgvActiva = dgvEtiquetasPiezas;
                    break;
                case 1:
                    dgvActiva = dgvDespachosBodegaAcopio;
                    break;
            }
            if (dgvActiva != null)
            {
                if (dgvActiva.Rows.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    new Excel().exportar(dgvActiva);
                    Cursor.Current = Cursors.Default;
                }
                else
                    MessageBox.Show("No existen registros a exportar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tlbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtBodegaAcopio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!txtBodegaAcopio.Text.Trim().Equals(""))
            {
                if (new CommonLibrary2.Information().isNumber(txtBodegaAcopio.Text))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        //lblTransportista.Text = ".";

                        WsCrud.CrudSoapClient wsCrud = new WsCrud.CrudSoapClient();
                        WsCrud.Bodega bodega = new WsCrud.Bodega();

                        bodega = wsCrud.ObtenerBodega(Convert.ToInt32(txtBodegaAcopio.Text)); //Bodega
                        if (bodega.MensajeError.Equals(""))
                        {
                            if (bodega.Activa.Equals("S") && bodega.Tipo.Equals("1"))
                            {
                                //    lblTransportista.Text = camion.Transportista;
                            }
                            else
                            {
                                MessageBox.Show("La bodega '" + txtBodegaAcopio.Text + "' no existe, esta inactiva o no es una bodega de Acopio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(bodega.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Debe ingresar un valor numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }

        private void txtBodegaAcopio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnCrudBodega_Click(object sender, EventArgs e)
        {
            new frmCrudBodega0().ShowDialog();
            txtBodegaAcopio.Focus();
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

        private void txtEtiquetaPieza_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Forms forms = new Forms();

            if (!txtEtiquetaPieza.Text.Trim().Equals(""))
            {
                if (forms.dataGridViewSearchText(dgvEtiquetasPiezas, COLUMNNAME_ETIQUETA_PIEZA, txtEtiquetaPieza.Text) == -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                        WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                        listaDataSet = wsOperacion.ObtenerPiezaProduccion(txtEtiquetaPieza.Text);
                        if (listaDataSet.MensajeError.Equals(""))
                        {
                            if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                            {
                                if (dgvEtiquetasPiezas.DataSource == null)
                                    dgvEtiquetasPiezas.DataSource = listaDataSet.DataSet.Tables[0];
                                else
                                {
                                    DataTable dataTable = (DataTable)dgvEtiquetasPiezas.DataSource;
                                    DataRow row = dataTable.NewRow();

                                    foreach (DataGridViewColumn column in dgvEtiquetasPiezas.Columns)
                                    {
                                        row[column.Index] = listaDataSet.DataSet.Tables[0].Rows[0][column.Index];
                                    }
                                    dataTable.Rows.Add(row);
                                }
                                //tlbNuevo.PerformClick();
                                //Forms forms = new Forms();
                                forms.dataGridViewHideColumns(dgvEtiquetasPiezas, new string[] { "BODEGA_ACOPIO", "ACO_USUARIO", "ACO_FECHA", "ACO_OBSERVACION", "CAMION", "OBRA_DESTINO", "CAM_USUARIO", "CAM_FECHA", "CAM_OBSERVACION", "CAM_USUARIO_VB", "CAM_FECHA_VB", "CAM_OBSERVACION_VB", "PIE_ESTADO", "DES_ACO_ID", "DES_CAM_ID" });
                                forms.dataGridViewAutoSizeColumnsMode(dgvEtiquetasPiezas, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                                //tlbEstado.Text = "Registro(s): " + dgvRecepciones.Rows.Count;
                                lblCantidadEtiquetasPiezas.Text = "Registro(s): " + dgvEtiquetasPiezas.Rows.Count;
                            }
                            else
                                MessageBox.Show("La etiqueta '" + txtEtiquetaPieza.Text + "' no existe.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Cursor.Current = Cursors.Default;
                }
                else
                {

                }
                txtEtiquetaPieza.Clear();
                txtEtiquetaPieza.Focus();
            }
        }

        private void frmDespachoBodegaAcopio_Shown(object sender, EventArgs e)
        {
            txtBodegaAcopio.Focus();
        }

        private void txtBodegaAcopio_Leave(object sender, EventArgs e)
        {
            txtBodegaAcopio.Text = eliminarCaracteresEspeciales(txtBodegaAcopio.Text.Trim());
        }

        private void txtObs_Leave(object sender, EventArgs e)
        {
            txtObs.Text = eliminarCaracteresEspeciales(txtObs.Text.Trim());
        }

        private void txtEtiquetaPieza_Leave(object sender, EventArgs e)
        {
            txtEtiquetaPieza.Text = eliminarCaracteresEspeciales(txtEtiquetaPieza.Text.Trim());
        }

        private void txtBodegaAcopio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                CommonHelp.frmHelp frmHelp = new CommonHelp.frmHelp();
                frmHelp.setShowHelp("Busca: Bodegas de Acopio", "nombre", "", "Muestra un listado de las bodegas de Acopio activas.", "SELECT id, nombre, descripcion FROM vw_bodega WHERE bod_tipo=1 and activa='S'", "");
                frmHelp.ShowDialog();
                if (frmHelp.getResultRow() != null)
                {
                    txtBodegaAcopio.Text = frmHelp.getResultRow()[0].ToString();
                    txtObs.Focus();
                }
                frmHelp.Dispose();
            }
        }

        private void btnHlpBodega_Click(object sender, EventArgs e)
        {
            txtBodegaAcopio_KeyUp(sender, new KeyEventArgs(Keys.F1));
        }

        private void tabOperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            tlbGuardar.Visible = tabOperaciones.SelectedIndex == 0;
            tlbActualizar.Visible = tabOperaciones.SelectedIndex == 1;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            lblPiezasPendientesDespacho.Text = "0";
            try
            {
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                listaDataSet = wsOperacion.ListarPiezasNoDespachadasBodegaAcopio(Convert.ToInt32(Metalurgica.Program.currentUser.Machine));
                if (listaDataSet.MensajeError.Equals(""))
                {
                    lblPiezasPendientesDespacho.Text = listaDataSet.DataSet.Tables[0].Rows.Count.ToString();
                }
                else
                    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;

        }
    }
}
using System;
using System.Windows.Forms;
using CommonLibrary2;
using System.Drawing;

namespace Metalurgica
{
    public partial class frmVbDespachoCamion : Form
    {
        private const string COLUMNNAME_MARCA = "MARCA";
        private const string COLUMNNAME_ETIQUETA_COLADA = "ETIQUETA_COLADA";
        private const string COLUMNNAME_ETIQUETA_PIEZA = "ETIQUETA_PIEZA";

        public frmVbDespachoCamion()
        {
            InitializeComponent();
            this.dgvDespachos.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvDespachos_RowPostPaint);
            this.dgvEtiquetasPiezas.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvEtiquetasPiezas_RowPostPaint);
        }

        private void dgvDespachos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDespachos.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvEtiquetasPiezas_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvEtiquetasPiezas.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void tlbNuevo_Click(object sender, EventArgs e)
        {
            lblPatente.Text = ".";
            lblTransportista.Text = ".";
            lblObraDestino.Text = ".";
            txtObs.Clear();
            txtObsVb.Clear();
            dgvDespachos.DataSource = null;
            dgvEtiquetasPiezas.DataSource = null;
            lblIdDespacho.Text = ".";

        }

        private void tlbGuardar_Click(object sender, EventArgs e)
        {
            int counter = 0;

            txtObsVb.Focus();
            switch (tabOperaciones.SelectedIndex)
            {
                case 0:
                    counter = new Forms().dataGridViewCountRowsChecked(dgvDespachos, COLUMNNAME_MARCA);
                    if (counter > 0)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        try
                        {
                            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                            WsOperacion.Despacho_Camion despacho_Camion = new WsOperacion.Despacho_Camion();

                            foreach (DataGridViewRow row in dgvDespachos.Rows)
                            {
                                if (row.Cells[COLUMNNAME_MARCA].Value != null)
                                {
                                    if ((bool)row.Cells[COLUMNNAME_MARCA].Value == true)
                                    {
                                        despacho_Camion.Id = Convert.ToInt32(row.Cells[1].Value.ToString());
                                        despacho_Camion.Usuario = Program.currentUser.Login;
                                        //despacho_Camion.Fecha = ""; 
                                        despacho_Camion.Obs = txtObsVb.Text.Trim();

                                        despacho_Camion = wsOperacion.VbDespachoCamion(despacho_Camion.Id, despacho_Camion.Usuario, despacho_Camion.Obs, Program.currentUser.ComputerName);
                                        if (despacho_Camion.MensajeError.Equals(""))
                                            row.Cells[0].Value = false;
                                        else
                                            MessageBox.Show(despacho_Camion.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            tlbNuevo_Click(sender, e);
                            tlbActualizar.PerformClick();
                            MessageBox.Show("Proceso finalizado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Cursor.Current = Cursors.Default;
                    }
                    else
                        MessageBox.Show("No existen registros seleccionados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    counter = new Forms().dataGridViewCountRowsChecked(dgvEtiquetasPiezas, COLUMNNAME_MARCA);
                    if (counter > 0)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        try
                        {
                            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                            WsOperacion.Despacho_Camion despacho_Camion = new WsOperacion.Despacho_Camion();

                            foreach (DataGridViewRow row in dgvEtiquetasPiezas.Rows)
                            {
                                if (row.Cells[COLUMNNAME_MARCA].Value != null)
                                {
                                    if ((bool)row.Cells[COLUMNNAME_MARCA].Value == true)
                                    {
                                        despacho_Camion.Id = Convert.ToInt32(lblIdDespacho.Text);
                                        despacho_Camion.Usuario = Program.currentUser.Login;
                                        //despacho_Camion.Fecha = ""; 
                                        despacho_Camion.Obs = txtObsVb.Text.Trim();

                                        despacho_Camion = wsOperacion.VbDespachoPiezaCamion(despacho_Camion.Id, row.Cells[COLUMNNAME_ETIQUETA_COLADA].Value.ToString(), row.Cells[COLUMNNAME_ETIQUETA_PIEZA].Value.ToString(), despacho_Camion.Usuario, despacho_Camion.Obs, Program.currentUser.ComputerName);
                                        if (despacho_Camion.MensajeError.Equals(""))
                                            row.Cells[0].Value = false;
                                        else
                                            MessageBox.Show(despacho_Camion.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            tabOperaciones.SelectedIndex = 0;
                            tlbNuevo_Click(sender, e);
                            tlbActualizar.PerformClick();
                            MessageBox.Show("Proceso finalizado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        Cursor.Current = Cursors.Default;
                    }
                    else
                        MessageBox.Show("No existen registros seleccionados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void tlbEliminar_Click(object sender, EventArgs e)
        {

        }

        private void tlbDesactivar_Click(object sender, EventArgs e)
        {

        }

        private void BloquearColumnas(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Index > 0)
                    column.ReadOnly = true;
            }
        }

        private void tlbActualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                tlbNuevo_Click(sender, e);
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                listaDataSet = wsOperacion.ListarDespachoCamion(dtpFechaDespacho.Value);
                if (listaDataSet.MensajeError.Equals(""))
                {
                    dgvDespachos.DataSource = listaDataSet.DataSet.Tables[0];
                    if (!new Forms().dataGridViewExistsColumn(dgvDespachos, COLUMNNAME_MARCA))
                    {
                        DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                        check.Name = COLUMNNAME_MARCA;
                        dgvDespachos.Columns.Insert(0, check);
                    }
                    BloquearColumnas(dgvDespachos);
                    //tlbNuevo.PerformClick();
                    //tlbNuevo_Click(sender, e);
                    Forms forms = new Forms();
                    forms.dataGridViewHideColumns(dgvDespachos, new string[] { "USUARIO_VB", "FECHA_VB" });
                    forms.dataGridViewAutoSizeColumnsMode(dgvDespachos, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    tlsEstado.Text = "Registro(s): " + dgvDespachos.Rows.Count;
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

        private void tlbImprimir_Click(object sender, EventArgs e)
        {

        }

        private void tlbExportar_Click(object sender, EventArgs e)
        {
            DataGridView dgvActiva = null;

            switch (tabOperaciones.SelectedIndex)
            {
                case 0:
                    dgvActiva = dgvDespachos;
                    break;
                case 1:
                    dgvActiva = dgvEtiquetasPiezas;
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

        private void btnCrudBodega_Click(object sender, EventArgs e)
        {
            new frmCrudBodega0().ShowDialog();
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

        private void frmVbDespachoCamion_Load(object sender, EventArgs e)
        {
            tlbActualizar.PerformClick();
        }

        private void dgvDespachos_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dgvDespachos.CurrentRow;
            if (currentRow != null)
            {
                lblPatente.Text = currentRow.Cells["CAMION"].Value.ToString();
                lblTransportista.Text = "";
                lblObraDestino.Text = currentRow.Cells["OBRA_DESTINO"].Value.ToString();
                txtObs.Text = currentRow.Cells["OBSERVACION"].Value.ToString();
            }
            else
                tlbNuevo_Click(sender, e);
        }

        private void frmVbDespachoCamion_Shown(object sender, EventArgs e)
        {
            txtObsVb.Focus();
        }

        private string eliminarCaracteresEspeciales(string entrada)
        {
            StringUtility stringUtility = new StringUtility();
            string salida = entrada;
            if (!salida.Trim().Equals(""))
                salida = stringUtility.removeInvalidCharacters(salida, stringUtility.RegexPattern_Address);
            return salida;
        }

        private void txtObsVb_Leave(object sender, EventArgs e)
        {
            txtObsVb.Text = eliminarCaracteresEspeciales(txtObsVb.Text.Trim());
        }

        private void dtpFechaDespacho_ValueChanged(object sender, EventArgs e)
        {
            tlbActualizar.PerformClick();
        }

        private void dgvDespachos_DoubleClick(object sender, EventArgs e)
        {
            //Carga las piezas del packing list/manifiesto
            DataGridViewRow currentRow = dgvDespachos.CurrentRow;
            if (currentRow != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    int idDespacho = Convert.ToInt32(currentRow.Cells[1].Value.ToString());
                    lblIdDespacho.Text = idDespacho.ToString();

                    WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                    WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

                    listaDataSet = wsOperacion.ObtenerPiezasDespachoCamion(idDespacho);
                    if (listaDataSet.MensajeError.Equals(""))
                    {
                        dgvEtiquetasPiezas.DataSource = listaDataSet.DataSet.Tables[0];
                        if (!new Forms().dataGridViewExistsColumn(dgvEtiquetasPiezas, COLUMNNAME_MARCA))
                        {
                            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                            check.Name = COLUMNNAME_MARCA;
                            dgvEtiquetasPiezas.Columns.Insert(0, check);
                        }
                        BloquearColumnas(dgvEtiquetasPiezas);
                        //tlbNuevo.PerformClick();
                        //tlbNuevo_Click(sender, e);
                        Forms forms = new Forms();
                        forms.dataGridViewHideColumns(dgvEtiquetasPiezas, new string[] { "DES_ACO_ID", "DES_CAM_ID", "PIE_ESTADO" });
                        forms.dataGridViewAutoSizeColumnsMode(dgvEtiquetasPiezas, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                        tabOperaciones.SelectedIndex = 1;
                        txtEtiquetaPieza.Focus();
                        tlsEstado.Text = "Registro(s): " + dgvEtiquetasPiezas.Rows.Count;
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

        private void txtEtiquetaPieza_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Forms forms = new Forms();
            int position = -1;

            if (!txtEtiquetaPieza.Text.Trim().Equals(""))
            {
                position = forms.dataGridViewSearchText(dgvEtiquetasPiezas, COLUMNNAME_ETIQUETA_PIEZA, txtEtiquetaPieza.Text);
                if (position != -1)
                {
                    //Marcar
                    dgvEtiquetasPiezas.Rows[position].Cells[COLUMNNAME_MARCA].Value = true;
                    dgvEtiquetasPiezas.Rows[position].Selected = true;
                }
                else
                {

                }
                txtEtiquetaPieza.Clear();
                txtEtiquetaPieza.Focus();
            }
        }

        private void txtEtiquetaPieza_Leave(object sender, EventArgs e)
        {
            txtEtiquetaPieza.Text = eliminarCaracteresEspeciales(txtEtiquetaPieza.Text.Trim());
        }

        private void tabOperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            tlbActualizar.Enabled = tabOperaciones.SelectedIndex == 0;
        }
    }
}
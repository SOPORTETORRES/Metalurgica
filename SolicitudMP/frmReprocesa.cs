using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CommonLibrary2;
using System.Windows.Forms;

namespace Metalurgica.SolicitudMP
{
    public partial class frmReprocesa : Form
    {
        private Forms forms = new Forms();


        public frmReprocesa()
        {
            InitializeComponent();
        }

        private void dtpFechaRecepcion_ValueChanged(object sender, EventArgs e)
        {
            tlbActualizar.PerformClick();
        }

        private void tlbActualizar_Click(object sender, EventArgs e)
        {
            string lsql = ""; DateTime  lFecha = dtpFechaRecepcion.Value   ;
            string lErrorWS = this.cboCriterio .Text.Substring(0, 1);
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                Ws_TO.Ws_ToSoapClient Ws_To=new Ws_TO.Ws_ToSoapClient ();
                DataSet lDts = new DataSet();

                //lsql = string.Concat("EXEC SP_SOLICITUD_MATERIAL 0, '', '', 0, 'N', '', '', '', '', '', 0, '', '" , lFecha , "', 0, '', '', '', '', '', '', '" , lErrorWS , "', '', '', 309");

                //lDts = Ws_To.ObtenerDatos(lsql);

                ////listaDataSet = wsOperacion.ListarSolicitudMaterial_Cierre(dtpFechaRecepcion.Value, Program.currentUser.IdTotem, cboCriterio.Text.Substring(0, 1));

                //if (listaDataSet.MensajeError.Equals(""))
                //{
                //    dgvProductos.DataSource = listaDataSet.DataSet.Tables[0];
                //    if (!forms.dataGridViewExistsColumn(dgvProductos, COLUMNNAME_MARCA))
                //    {
                //        DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();
                //        check.Name = COLUMNNAME_MARCA;
                //        dgvProductos.Columns.Insert(0, check);
                //    }

                //    BloquearColumnas(dgvProductos);
                //    //tlbNuevo.PerformClick();
                //    //tlbNuevo_Click(sender, e);
                //    //ID, USUARIO, FECHA, TOTEM, COMPLETA, SOL_ID, PRODUCTO, DIAMETRO, LARGO, ORIGEN, TIPO CANTIDAD, USUARIO_RECEP, FECHA_RECEP, CANTIDAD_RECEP, OBS_RECEP, USUARIO_CIERRE, FECHA_CIERRE, INET_MSG, INET_FECHA
                //    forms.dataGridViewHideColumns(dgvProductos, new string[] { "ID", "USUARIO", "FECHA", "TOTEM", "COMPLETA", "CANTIDAD", "USUARIO_RECEP", "OBS_RECEP", "FECHA_RECEP", "USUARIO_CIERRE", "FECHA_CIERRE" });
                //    forms.dataGridViewAutoSizeColumnsMode(dgvProductos, DataGridViewAutoSizeColumnsMode.DisplayedCells);
                //    tlsEstado.Text = "Registro(s): " + dgvProductos.Rows.Count;
                //}
                //else
                //    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default; 
        }

        private void BloquearColumnas(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Index > 0)
                    column.ReadOnly = true;
            }
        }

    }
}

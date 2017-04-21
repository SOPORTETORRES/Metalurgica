using System;
using System.Drawing;
using System.Windows.Forms;
using CommonLibrary2;

namespace Metalurgica
{
    public partial class frmLogProducto : Form
    {
        public int sol_id = 0;
        public string producto = "";

        public frmLogProducto()
        {
            InitializeComponent();
            this.dgvLog.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgvProductos_RowPostPaint);
        }

        private void dgvProductos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvLog.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void frmLogProducto_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Text += " (ID: " + sol_id + ", Producto: " + producto + ")";  

            try
            {
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
                WsOperacion.Solicitud_Material_Detalle solicitud_Material_Detalle = new WsOperacion.Solicitud_Material_Detalle();

                solicitud_Material_Detalle.Id = sol_id;
                solicitud_Material_Detalle.Producto = producto;

                listaDataSet = wsOperacion.ListarLogProducto(solicitud_Material_Detalle);
                if (listaDataSet.MensajeError.Equals(""))
                {
                    dgvLog.DataSource = listaDataSet.DataSet.Tables[0];
                    Forms forms = new Forms();
                    forms.dataGridViewHideColumns(dgvLog, new string[] { "SOL_ID", "PRODUCTO", "ID_TRX" });
                    forms.dataGridViewAutoSizeColumnsMode(dgvLog, DataGridViewAutoSizeColumnsMode.DisplayedCells);
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

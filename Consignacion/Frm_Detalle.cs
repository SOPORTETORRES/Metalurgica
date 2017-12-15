using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Consignacion
{
    public partial class Frm_Detalle : Form
    {
        public string mTipoConsulta = "";
        public Frm_Detalle()
        {
            InitializeComponent();
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public  void CargaTrazabilidad(string iId)
        {
            DataTable mTblDatos = new DataTable();
            string lSql = ""; DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            lSql = String.Concat("Exec SP_CRUD_ConsignacionGerdau ",iId ,",'','','','','','','','','','','','','','','','','','','','','','',9");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                mTblDatos = lDts.Tables[0].Copy();
                Dtg_Datos.DataSource = mTblDatos;
            }
        }

        public void CargaMaquinas(string iTitulo, DataTable iTBl )
        {
            this.Text = iTitulo;
            Dtg_Datos.DataSource = iTBl;
            mTipoConsulta = "MAQUINA";
        }

        public void CargaTotems(string iTitulo, DataTable iTBl)
        {
            this.Text = iTitulo;
            Dtg_Datos.DataSource = iTBl;
            mTipoConsulta = "TOTEM";
            Dtg_Datos.Columns[0].Visible = false;
            Dtg_Datos.Columns[1].Width = 150;
            Dtg_Datos.Columns[2].Width = 250;
            Dtg_Datos.Columns[3].Width = 120;

        }




        private void Dtg_Datos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string lIdSeleccionado = "";
            switch (mTipoConsulta.ToUpper ())
            {
                case "MAQUINA":
                    lIdSeleccionado = Dtg_Datos.Rows[e.RowIndex].Cells["Maq_Id"].Value.ToString();
                    AppDomain.CurrentDomain.SetData("IdMaquina", lIdSeleccionado);
                    break;
                case "TOTEM":
                    lIdSeleccionado = Dtg_Datos.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                     AppDomain.CurrentDomain.SetData("IdTotem", lIdSeleccionado);
                    break;                
            }

            
            this.Close();
        }


    }
}

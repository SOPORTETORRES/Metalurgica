using CommonLibrary2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Bascula
{
    public partial class Frm_VerBascula : Form
    {
        private DataTable mTblDatos = new DataTable();
        public Frm_VerBascula()
        {
            InitializeComponent();
        }

        private void Frm_VerBascula_Load(object sender, EventArgs e)
        {
            VerDatosINET_Bascula("2018","8");
        }


        private void VerDatosINET_Bascula(string iYear, string iMes )
        {
              string lSql = "";   Ws_TO.Ws_ToSoap wsOperacion = new Ws_TO.Ws_ToSoapClient();
           DataSet  lDts = new DataSet(); Clases.ClsComun lCom = new Clases.ClsComun();
            DataTable lTbl = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            int i = 0; string lTmp = "";
            
             lSql = String.Concat("Exec Sp_ConsultasGenerales 108,'", iYear,"','", iMes,"','','',''");
            lDts = wsOperacion.ObtenerDatos(lSql);
            if ((lDts .Tables .Count >0 ) && (lDts.Tables[0].Rows .Count >0 ))
            {
                mTblDatos = lDts.Tables[0].Copy();

                for (i = 0; i < mTblDatos.Rows.Count; i++)
                {
                    mTblDatos.Rows[i]["Diferencia"] = lCom.Val(mTblDatos.Rows[i]["KsgBascula"].ToString()) - lCom.Val(mTblDatos.Rows[i]["KgsINET"].ToString());
                }

                    this.Dtg_BAscula.DataSource = mTblDatos ;
            }


            for (i = 0; i < Dtg_BAscula.Rows.Count; i++)
            {
                if (lCom.Val(Dtg_BAscula.Rows[i].Cells["KsgBascula"].Value.ToString()) < lCom.Val(Dtg_BAscula.Rows[i].Cells["KgsINET"].Value.ToString()))
                {
                    Dtg_BAscula.Rows[i].Cells["KsgBascula"].Style.BackColor = Color.LightSalmon;
                    Dtg_BAscula.Rows[i].Cells["KgsINET"].Style.BackColor = Color.LightSalmon;
                }
                else
                {
                    Dtg_BAscula.Rows[i].Cells["KsgBascula"].Style.BackColor = Color.LightGreen;
                    Dtg_BAscula.Rows[i].Cells["KgsINET"].Style.BackColor = Color.LightGreen;
                }
            }


        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            VerDatosINET_Bascula("2018", "8");
        }
    }
}

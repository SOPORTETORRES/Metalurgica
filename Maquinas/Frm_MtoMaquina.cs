using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Maquinas
{
    public partial class Frm_MtoMaquina : Form
    {
        public Frm_MtoMaquina()
        {
            InitializeComponent();
        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            GrabarDatos();
        }

        public  void  CargaDatos()
        {
            //    ALTER PROCEDURE [dbo].[SP_CRUD_MAQUINA]
            //       @ID INT,               //@NOMBRE VARCHAR(100),     //@DESCRIPCION VARCHAR(50),
            //      @ACTIVA VARCHAR(10),          //@IdTotem int,             //@IdTipoMaq int,
            //      @PARAM1 VARCHAR(50),          //@PARAM2 VARCHAR(50),      //@OPCION INT
             int i = 0; string lSql = ""; DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
             string lIdWsINET = ""; int j = 0; DataTable lTblTipoMaq = new DataTable();
            lSql = " SP_CRUD_MAQUINA 0,'','','',0,'0','','',10";
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblTipoMaq = lDts.Tables[0].Copy();
                Cmb_TipoMaq .DisplayMember = "Par1";
                Cmb_TipoMaq .ValueMember = "Id";
                Cmb_TipoMaq.DataSource = lTblTipoMaq;
            }


        }

        private void GrabarDatos()
        {         
          
             int i = 0; string lSql = ""; DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lIdWsINET = ""; int j = 0;

            if (DatosOKParaGrabar() == true)
            {
                lSql = string.Concat (" SP_CRUD_MAQUINA " , Tx_Id .Text ,",'",Tx_Nombre .Text ,"','",Tx_Descripcion .Text ,"','S',0,'",Cmb_TipoMaq.SelectedValue, "' ,'','',1");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    Tx_Id .Text  = lDts.Tables[0].Rows[0][0].ToString();
                }


            }
        }


        private bool DatosOKParaGrabar()
        {
            bool lRes = true ; string lMsg = "";
            if (Tx_Nombre.Text.Trim().Length < 3)
            {
                lMsg = string.Concat("Debe Ingresar un Nombre de más de 3 caracteres",Environment .NewLine );
                lRes = false;
            }
            if (Tx_Descripcion.Text.Trim().Length < 3)
            {
                lMsg = string.Concat("Debe Ingresar una Descripción de más de 3 caracteres", Environment.NewLine);
                lRes = false;
            }

            if (lMsg.ToString().Trim().Length > 0)
            {
                MessageBox.Show(lMsg, " Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return lRes;
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            Tx_Id.Text = "0";
            Tx_Descripcion.Text = "";
            Tx_Nombre.Text = "";

        }

        private void CargaDatosPorId(string iIdMaquina)
        {
            string lSql = ""; DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            DataTable lTbl = new DataTable(); Clases.ClsComun lComun = new Clases.ClsComun();       
            lSql = string.Concat(" SP_CRUD_MAQUINA ", iIdMaquina ,",'','','S',0,'0' ,'','',13");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                Tx_Id.Text = lTbl.Rows[0]["Maq_Id"].ToString();
                Tx_Descripcion.Text = lTbl.Rows[0]["Maq_Descripcion"].ToString();
                Tx_Nombre.Text = lTbl.Rows[0]["Maq_Nombre"].ToString();
                if (lComun.EsNumero(lTbl.Rows[0]["Maq_Tipo"].ToString()) == true)
                {
                    Cmb_TipoMaq.SelectedValue = lTbl.Rows[0]["Maq_Tipo"].ToString();
                }
                if (lComun.EsNumero(lTbl.Rows[0]["Maq_Id_Totem"].ToString()) == true)
                {
                    Cmb_TotemAsociado.SelectedValue = lTbl.Rows[0]["Maq_Id_Totem"].ToString();
                }              
            }       
        }

        private void Btn_VerMaq_Click(object sender, EventArgs e)
        {
            Consignacion.Frm_Detalle lFrm = new Consignacion.Frm_Detalle(); DataTable lTbl = new DataTable();
            string lSql = ""; DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            lSql = "";                                   
                lSql = string.Concat(" SP_CRUD_MAQUINA 0,'','','S',0,'0' ,'','',12");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                }

                lFrm.CargaMaquinas("Detalle de Máquinas Vigentes", lTbl);
            lFrm.ShowDialog();

            if ( AppDomain.CurrentDomain.GetData("IdMaquina") != null) 
            {
                 string lIdMaq = AppDomain.CurrentDomain.GetData("IdMaquina").ToString();
                 if ((lIdMaq != null) && (lIdMaq.ToString ().Length >0))
                        CargaDatosPorId(lIdMaq);
            }
           

        }


    }
}

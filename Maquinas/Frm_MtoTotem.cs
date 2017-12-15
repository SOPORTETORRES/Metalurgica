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
    public partial class Frm_MtoTotem : Form
    {
        public Frm_MtoTotem()
        {
            InitializeComponent();
        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            GrabarDatos();
        }

        private void GrabarDatos()
        {
            //    ALTER PROCEDURE [dbo].[SP_CRUD_MAQUINA]
            //       @ID INT,               //@NOMBRE VARCHAR(100),     //@DESCRIPCION VARCHAR(50),
            //      @ACTIVA VARCHAR(10),          //@IdTotem int,             //@IdTipoMaq int,
            //      @PARAM1 VARCHAR(50),          //@PARAM2 VARCHAR(50),      //@OPCION INT

            int i = 0; string lSql = ""; DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lIdWsINET = ""; int j = 0; Clases .ClsComun lCom=new Clases.ClsComun ();

            if (DatosOKParaGrabar() == true)
            {
                lSql = string.Concat(" SP_CRUD_MAQUINA ", Tx_Id.Text, ",'", Tx_Nombre.Text, "','','',0,'' ,'",Cmb_TipoTotem .SelectedValue  ,"','",Tx_Obs .Text,"',11");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    if (lCom.Val(lDts.Tables[0].Rows[0][0].ToString()) > 0)
                    {
                        Tx_Id.Text = lDts.Tables[0].Rows[0][0].ToString();
                        MessageBox.Show("Los datos fueron grabados Correctamente", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Los datos NO se grabados Correctamente, Repita la Operación ", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }


            }
        }
        private bool DatosOKParaGrabar()
        {
            bool lRes = true; string lMsg = "";
            if (Tx_Nombre.Text.Trim().Length < 3)
            {
                lMsg = string.Concat("Debe Ingresar un Nombre de más de 3 caracteres", Environment.NewLine);
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
            Limpiar();
        }

        private void Limpiar()
        {

            Tx_Id.Text = "0";
            Tx_Nombre.Text = "";
            Tx_Obs.Text = "";
        }

        private void CargaDesplagables()
        { 
          string lSql = ""; DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
          DataTable lTbl = new DataTable();
                lSql = " SP_CRUD_MAQUINA 0,'','','',0,'0','','',14";
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                    Cmb_TipoTotem.DisplayMember = "Par1";
                    Cmb_TipoTotem.ValueMember = "Id";
                    Cmb_TipoTotem.DataSource = lTbl;
                }
        }

        private void Frm_MtoTotem_Load(object sender, EventArgs e)
        {
            CargaDesplagables();
        }

        private void CargaDatosPorId(string iIdTotem)
        {
            string lSql = ""; DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            DataTable lTbl = new DataTable(); Clases.ClsComun lComun = new Clases.ClsComun();
            lSql = string.Concat(" SP_CRUD_MAQUINA ", iIdTotem, ",'','','S',0,'0' ,'','',16");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                Tx_Id.Text = lTbl.Rows[0]["Id"].ToString();                
                Tx_Nombre.Text = lTbl.Rows[0]["Nombre"].ToString();
                Tx_Obs.Text = lTbl.Rows[0]["Obs"].ToString();
                if (lComun.EsNumero(lTbl.Rows[0]["IdTipo"].ToString()) == true)
                {
                    Cmb_TipoTotem.SelectedValue = lTbl.Rows[0]["Id"].ToString();
                }
               
            }
        }

        private void Btn_VerMaq_Click(object sender, EventArgs e)
        {
            try
            {
                Consignacion.Frm_Detalle lFrm = new Consignacion.Frm_Detalle(); DataTable lTbl = new DataTable();
                string lSql = ""; DataSet lDts = new DataSet(); Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
                lSql = "";
                lSql = string.Concat(" SP_CRUD_MAQUINA 0,'','','S',0,'0' ,'','',15");
                lDts = lPx.ObtenerDatos(lSql);
                if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
                {
                    lTbl = lDts.Tables[0].Copy();
                }

                lFrm.CargaTotems("Detalle de Tótems  Vigentes", lTbl);
                lFrm.ShowDialog();
                if (AppDomain.CurrentDomain.GetData("IdTotem") != null)
                {
                    string lIdMaq = AppDomain.CurrentDomain.GetData("IdTotem").ToString();
                    CargaDatosPorId(lIdMaq);
                }
                
            }
             catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}

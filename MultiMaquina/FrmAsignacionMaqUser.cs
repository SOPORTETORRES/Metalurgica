using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using CommonLibrary2;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Metalurgica.MultiMaquina
{
    public partial class FrmAsignacionMaqUser : Form
    {
        private DataTable mTblUser = new DataTable();
        private Boolean mCargandoForm = true;
        public FrmAsignacionMaqUser()
        {
            InitializeComponent();
        }


        #region Metodos Publicos de la Clase

        public void  IniciaForm()
        {
            DataTable lTbl = new DataTable();DataRow lFila = null; string lSql = "";
            DataSet lDts = new DataSet();
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); 
            lTbl = ObtenerSucursales();
            if (lTbl.Rows.Count > 0)
            {
                if (lTbl.Rows.Count > 0)
                {
                    lFila = lTbl.NewRow();
                    lFila["IdSucursal"] = 0; lFila["NombreSucursal"] = "Seleccionar";
                    lTbl.Rows.Add(lFila);

                    new Forms().comboBoxFill(Cmb_Sucursal, lTbl, "IdSucursal", "NombreSucursal", 0);
                    Cmb_Sucursal.SelectedIndex = lTbl.Rows.Count - 1;
                }
            }

          
            //Obtenemos todos los usuarios del sistema
            lSql = string.Concat("SP_ConsultasGenerales 72,'','','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                mTblUser = lDts.Tables[0].Copy();
            }
            mCargandoForm = false;

        }

        #endregion

        #region Metodos Privados  de la Clase

        private DataTable ObtenerSucursales()
        {
      
                  DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            string lEmpresa= ConfigurationManager.AppSettings["Empresa"];
            string lSucursal = ConfigurationManager.AppSettings["Sucursal"];
            string lIdSucursal = ConfigurationManager.AppSettings["IdSucursal"];

            if (lEmpresa.ToUpper().Equals("TOSOL"))
            {
                lSql = string.Concat("SP_ConsultasGenerales 71,'','','','',''");
            }
            else
            {
                if (lSucursal.ToUpper().Equals("CALAMA"))
                {
                    lSql = string.Concat("SP_ConsultasGenerales 81,'", lIdSucursal,"','','','',''");
                }
            }
           
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0)
                lTbl = lDts.Tables[0].Copy();

            return lTbl;

        }

        private void CargaMaquinasPorSucursal(string IdUscursal)
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataTable lTblFinal = new DataTable();
            DataRow lFila = null; int i = 0;
            string lEmpresa = ConfigurationManager.AppSettings["Empresa"];
            string lSucursal = ConfigurationManager.AppSettings["Sucursal"];
            string lIdSucursal = ConfigurationManager.AppSettings["IdSucursal"];

            lTblFinal.Columns.Add("IdMaq", Type.GetType("System.String"));
            lTblFinal.Columns.Add("Nombre", Type.GetType("System.String"));
            lTblFinal.Columns.Add("UsuariosAsignados", Type.GetType("System.String"));

            
            if (lEmpresa.ToUpper().Equals("TOSOL"))
            {
                lSql = string.Concat("SP_ConsultasGenerales 73,'", IdUscursal, "','','','',''");
            }
            else
            {
                if (lSucursal.ToUpper().Equals("CALAMA"))
                {
                    lSql = string.Concat("SP_ConsultasGenerales 82,'", lIdSucursal, "','','','',''");
                }
            }


          
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                for (i = 0; i < lTbl.Rows.Count; i++)
                {
                    lFila = lTblFinal.NewRow();
                    lFila["IdMaq"] = lTbl.Rows[i]["Maq_Nro"].ToString () ;
                    lFila["Nombre"] =lTbl.Rows[i]["Maq_Nombre"].ToString ();
                    lFila["UsuariosAsignados"] = ObtenerUsuariosAsigandos(lTbl.Rows[i]["Maq_Nro"].ToString());
                    lTblFinal.Rows.Add(lFila);
                }
                Dtg_Maquinas.DataSource = lTblFinal;
                Dtg_Maquinas.Columns[0].Width = 60;
                Dtg_Maquinas.Columns[1].Width = 100;
                Dtg_Maquinas.Columns[2].Width = 250;
                for (i = 0; i < Dtg_Maquinas.Rows.Count; i++)
                {
                    Dtg_Maquinas.Rows[i].Height = 50;
                }
            }            
        }

        private string ObtenerUsuariosAsigandos(string iNroMaq)
        {
            Clases.ClsComun lCnn = new Clases.ClsComun(); DataTable lTbl = new DataTable();             
            string lRes = ""; int i = 0;            

                 lTbl = lCnn.CargaTablaUsuariosAsignadosAUnaMaquina(iNroMaq);
                 for (i = 0; i < lTbl.Rows.Count; i++)
                 {
                     lRes = string.Concat(lRes,lTbl.Rows[i]["Usuario"].ToString(), " -");

                 }
            return lRes;
        }



        private Boolean ValidaDatosParaAsignacion()
        {
            Boolean lRes = true; string lMgs = "";
            //Debe Seleccionar una Máquina
            //Debe Seleccionar un Usuario

            if (Lbl_MaquinaSel.Text.Equals("Debe Seleccionar una Máquina"))
            {
                lMgs = "Debe Seleccionar una Máquina";
                lRes = false;
            }

            if (this.Lbl_UsuarioSel.Text.Equals("Debe Seleccionar un Usuario"))
            {
                lMgs = string.Concat(lMgs, Environment.NewLine, " Debe Seleccionar un Usuario ");
                lRes = false;
            }

            if (lRes == false)
            {
                MessageBox.Show(lMgs, "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return lRes;
        }

        private void AsignarUsuariosMaquinas(string iNroMaquina, string iIdUser)
        { 
              DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); string lResp = "";

            lSql = string.Concat("SP_ConsultasGenerales 75,'",iNroMaquina,"','",iIdUser,"','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lResp = lDts.Tables[0].Rows[0][0].ToString();
                if (lResp.ToUpper().Equals("OK"))                
                    MessageBox.Show("La Asignación realiazada fue Satisfactoria. ", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("NO se ha podido realizar la Asignación, repita la operación. ", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            CargaMaquinasPorSucursal(Cmb_Sucursal.SelectedValue.ToString());
        
        }

        #endregion


        private void Cmb_Sucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            string  lIdSucursal = Cmb_Sucursal.SelectedValue.ToString();
            if (mCargandoForm != true)
            {
                CargaMaquinasPorSucursal(lIdSucursal);
            }
        }

        private void Tx_BuscaUser_TextChanged(object sender, EventArgs e)
        {
            DataView lVista = null; string lWheres = "";
            if (Tx_BuscaUser.Text.Length > 0)
            {
                lWheres = string.Concat(" (nombre like '%", Tx_BuscaUser.Text, "%' or Apellidos like '%", Tx_BuscaUser.Text, "%'");
                lWheres = string.Concat(lWheres, " or usuario like '%", Tx_BuscaUser.Text, "%')");

                lVista = new DataView(mTblUser, lWheres, "", DataViewRowState.CurrentRows );
                Dtg_Usuarios.DataSource = lVista;
                Dtg_Usuarios.Columns["Id"].Width = 50;
                Dtg_Usuarios.Columns["Vigente"].Width = 50;
            }

        }

        private void Btn_Asignar_Click(object sender, EventArgs e)
        {
            if (ValidaDatosParaAsignacion() == true)
            { 
            //Hacemos la asignación
                AsignarUsuariosMaquinas(Lbl_MaquinaSel.Tag.ToString (), Lbl_UsuarioSel.Tag.ToString ());
            }
        }

        private void Dtg_Maquinas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int lFila = e.RowIndex;
            string lNroMaq = Dtg_Maquinas.Rows[lFila].Cells["IdMaq"].Value.ToString();
            string lNombreMaq = Dtg_Maquinas.Rows[lFila].Cells["Nombre"].Value.ToString();

            Lbl_MaquinaSel.Text = lNombreMaq;
            Lbl_MaquinaSel.Tag = lNroMaq;

        }

        private void Dtg_Usuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int lFila = e.RowIndex;
            string lIdUser = Dtg_Usuarios.Rows[lFila].Cells["Usuario"].Value.ToString();
            string lUsuario = Dtg_Usuarios.Rows[lFila].Cells["id"].Value.ToString();

            this.Lbl_UsuarioSel  .Text = lIdUser;
            Lbl_UsuarioSel.Tag = lUsuario;
        }

        private void Dtg_Maquinas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int lFila = e.RowIndex;string lNroMaq=Dtg_Maquinas.Rows [lFila ].Cells ["IdMaq"].Value.ToString ();
            string lNombre = Dtg_Maquinas.Rows[lFila].Cells["Nombre"].Value.ToString();
            MultiMaquina.FrmVisualizar lFrm = new FrmVisualizar();
            lFrm.IniciaForm(lNroMaq, lNombre,"VA");
            lFrm.ShowDialog(this);
            CargaMaquinasPorSucursal(Cmb_Sucursal.SelectedValue.ToString());

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAsignacionMaqUser_Load(object sender, EventArgs e)
        {

        }
    }
}

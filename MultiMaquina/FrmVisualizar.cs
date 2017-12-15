using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.MultiMaquina
{
    public partial class FrmVisualizar : Form
    {
        private string mNroMaquinaSel = "";
        private string mNombreMaquinaSel = "";
        private string mOrigenLLamada= "";

        public FrmVisualizar()
        {
            InitializeComponent();
        }

        #region Metodos Privados  de la Clase

        private void QuitarUsuariosMaquinas(string iNroMaquina, string iIdUser)
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); string lResp = "";

            lSql = string.Concat("SP_ConsultasGenerales 76,'", iNroMaquina, "','", iIdUser, "','','',''");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lResp = lDts.Tables[0].Rows[0][0].ToString();
                if (lResp.ToUpper().Equals("OK"))
                    MessageBox.Show("El Usuario Seleccionado ya NO esta Vinculado a la Máquina. ", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("NO se ha podido realizar la desvinculación del usuario a la máquina, repita la operación. ", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            IniciaForm(mNroMaquinaSel, mNombreMaquinaSel,"VA");

        }

        
        #endregion


        #region Metodos Publicos  de la Clase


        public void IniciaForm(string iNroMaquina, string iNombreMaq, string iOrigen)
        {
            Clases.ClsComun lCnn = new Clases.ClsComun(); DataTable lTbl = new DataTable();
            int i = 0;
            mNroMaquinaSel = iNroMaquina;
            mNombreMaquinaSel = iNombreMaq;
            mOrigenLLamada = iOrigen;
            if (iOrigen.ToUpper().Equals("VA"))   //Ver asignaciones
            {
               
                lTbl = lCnn.CargaTablaUsuariosAsignadosAUnaMaquina(iNroMaquina);
                Dtg_Asignaciones.DataSource = lTbl;               
                this.Text = string.Concat("Formulario para eliminación de usuarios asignados a la Máquina ", iNombreMaq.ToUpper().ToString());
                Btn_QuitarAsignacion.Visible = true;
                Btn_SeleccionarUser.Visible = false;
            }

            if (iOrigen.ToUpper().Equals("VU"))  //Ver Usuarios
            {
                
                lTbl = lCnn.CargaTablaUsuariosAsignadosAUnaMaquina(iNroMaquina);

                if (lTbl.Rows.Count == 0)
                {
                    MessageBox.Show("El Sistema no Registra usuarios asignados a la Máquina seleccionada. Debe realizar el proceso de Asignación de Usuario", "Avisos Sistema", MessageBoxButtons.OK);
                    //this.Close();
                    this.Text = string.Concat("Formulario para la Selección del usuario que registra la producción ");
                    Lbl_Msg.Text = "El Sistema no Registra usuarios asignados a la Máquina seleccionada. Debe realizar el proceso de Asignación de Usuario";
                }
                else
                {
                    Dtg_Asignaciones.DataSource = lTbl;
                    //Dtg_Asignaciones.Columns[0].Width = 60;
                    //Dtg_Asignaciones.Columns[1].Width = 150;
                    this.Text = string.Concat("Formulario para la Selección del usuario que registra la producción ", iNombreMaq.ToUpper().ToString());
                    Lbl_Msg.Text = "Para Seleccionar un usuario, debe hacer click sobre el nombre del usuario y luego presionar el botón Seleccionar  Usuario";
                    Btn_QuitarAsignacion.Visible = false;
                    Btn_SeleccionarUser.Visible = true;
                    Btn_SeleccionarUser.Enabled = true;
                }

                
            }
        
        }

        #endregion

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dtg_Asignaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string lIdUser = Dtg_Asignaciones.Rows[e.RowIndex].Cells[0].Value.ToString();
            string lNombreUser = Dtg_Asignaciones.Rows[e.RowIndex].Cells[1].Value.ToString();

            Lbl_Usuario.Text = lNombreUser;
            Lbl_Usuario.Tag = lIdUser;
            Btn_QuitarAsignacion.Enabled = true;

        }

        private void Btn_QuitarAsignacion_Click(object sender, EventArgs e)
        {
            QuitarUsuariosMaquinas(mNroMaquinaSel, Lbl_Usuario.Tag.ToString ());
            Btn_QuitarAsignacion.Enabled = false;
        }

        private void FrmVisualizar_Load(object sender, EventArgs e)
        {
            int i = 0;
            if (mOrigenLLamada == "VU")
            {
                if (Dtg_Asignaciones.Columns.Count > 0)
                {

                    Dtg_Asignaciones.Columns[0].Width = 80;
                    Dtg_Asignaciones.Columns[1].Width = 300;
                    for (i = 0; i < Dtg_Asignaciones.Rows.Count; i++)
                    {
                        Dtg_Asignaciones.Rows[i].Height = 55;
                    }
                }
            }
        }

        private void Dtg_Asignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_SeleccionarUser_Click(object sender, EventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun();
            if (lCom.EsNumero(Lbl_Usuario.Tag.ToString()) == true)
            {
                AppDomain.CurrentDomain.SetData("IdUserSel", Lbl_Usuario.Tag.ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un usuario, repita la operación. ", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}

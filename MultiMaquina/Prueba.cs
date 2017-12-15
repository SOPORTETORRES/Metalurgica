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
    public partial class Prueba : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        public Prueba()
        {
            InitializeComponent();
        }
        #region Metodos Privados de la Clases

        private string ObtenerUsuarioPorId(string iIdUser)
        {
            string lSql = ""; Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); DataSet lData = new DataSet();
            string lRes = "";

            lSql = string.Concat("Select usuario from to_usuarios where id=", iIdUser);
            lData = lDal.ObtenerDatos(lSql);
            if ((lData .Tables .Count >0 ) && ( lData .Tables[0].Rows .Count >0))
            {
                lRes = lData.Tables[0].Rows[0][0].ToString(); 
            }

            return lRes;
        }

        private void CargarMaquinas()
        {
            Clases.ClsComun lDal = new Clases.ClsComun(); DataTable lTbl = new DataTable();
            int i = 0; string lVersion = lDal.ObtenerVersionProduccion();

            this.Text = string.Concat("Formulario de registro de producción multi máquina (Versión ", lVersion, ")");

            lTbl = lDal.CargaTabla_Maquinas();
            for (i = 0; i < lTbl.Rows.Count ;  i++)
            {
                switch (i)
                {
                    case 0:
                        Btn_Maquina1.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina1.Visible = true;Btn_Maquina1.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQ_NOMBRE"].ToString().ToUpper().Equals("B"))
                            Btn_Maquina1.BackColor = Color.LightSalmon;
                        else
                            Btn_Maquina1.BackColor = Color.LightGreen ;

                        break;
                    case 1:
                        Btn_Maquina2.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina2.Visible = true;Btn_Maquina2.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQ_NOMBRE"].ToString().ToUpper().Equals("B"))
                            Btn_Maquina2.BackColor = Color.LightSalmon;
                        else
                            Btn_Maquina2.BackColor = Color.LightGreen;

                        break;
                    case 2:
                        Btn_Maquina3.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina3.Visible = true;Btn_Maquina3.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();;

                        if (lTbl.Rows[i]["MAQ_NOMBRE"].ToString().ToUpper().Equals("B"))
                            Btn_Maquina3.BackColor = Color.LightSalmon;
                        else
                            Btn_Maquina3.BackColor = Color.LightGreen;

                        break;
                    case 3:
                        Btn_Maquina4.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina4.Visible = true;Btn_Maquina4.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQ_NOMBRE"].ToString().ToUpper().Equals("B"))
                            Btn_Maquina4.BackColor = Color.LightSalmon;
                        else
                            Btn_Maquina4.BackColor = Color.LightGreen;

                        break;
                    case 4:
                        Btn_Maquina5.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina5.Visible = true;Btn_Maquina5.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQ_NOMBRE"].ToString().ToUpper().Equals("B"))
                            Btn_Maquina5.BackColor = Color.LightSalmon;
                        else
                            Btn_Maquina5.BackColor = Color.LightGreen;

                        break;
                    case 5:
                        Btn_Maquina6.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina6.Visible = true;Btn_Maquina6.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQ_NOMBRE"].ToString().ToUpper().Equals("B"))
                            Btn_Maquina6.BackColor = Color.LightSalmon;
                        else
                            Btn_Maquina6.BackColor = Color.LightGreen;

                        break;
                    case 6:
                        Btn_Maquina7.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina7.Visible = true; Btn_Maquina7.Tag = lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQ_NOMBRE"].ToString().ToUpper().Equals("B"))
                            Btn_Maquina7.BackColor = Color.LightSalmon;
                        else
                            Btn_Maquina7.BackColor = Color.LightGreen;

                        break;
                } 

            }


        
        }

        private void HabilitaBotones_De_Bloqueo(int NroMaq)
        {
            DataTable lTbl = new DataTable(); DataSet lDts = new DataSet(); string lSql = "";
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            lSql = string.Concat(" SP_CRUD_BloqueosMaquinas  0,", NroMaq, ",0,0,'',0,3");
            lDts = lPx.ObtenerDatos(lSql);
            if (lDts.Tables.Count > 0 && lDts.Tables[0].Rows.Count > 0)
            {
                lTbl = lDts.Tables[0].Copy();
                if (lTbl.Rows[0]["MaqBloqueada"].ToString().ToUpper().Equals("B"))
                {
                    Btn_Bloquear.Enabled = false;
                    Btn_DesBloquear  .Enabled = true;
                }
                else
                {
                    Btn_Bloquear.Enabled = true;
                    Btn_DesBloquear.Enabled = false;
                }

            }

        
        }

        private void HabilitaControlParaLectura(Boolean iHabilitado)
        {
            string lIdUser = ""; Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            
            //Mostramos el formulario para que se seleccione el usuario que realiza la produccion
            MultiMaquina.FrmVisualizar lFrm = new FrmVisualizar();
            lFrm.IniciaForm(Btn_MaquinaActiva.Tag.ToString(), Btn_MaquinaActiva.Text, "VU");
            lFrm.ShowDialog(this);
            if (AppDomain.CurrentDomain.GetData("IdUserSel") != null)
            {
                lIdUser = AppDomain.CurrentDomain.GetData("IdUserSel").ToString();
                mUserLog.Login = ObtenerUsuarioPorId(lIdUser);
                Btn_UsuarioActiva.Text = string.Concat(  mUserLog.Login , "-", lIdUser);
                mUserLog.Iduser = lIdUser;
                mUserLog.IdMaquina = int.Parse(Btn_MaquinaActiva.Tag.ToString());
                ctlProduccion1.CargaUsuarioActual(mUserLog);
                ctlProduccion1.HabilitaControl(iHabilitado);
                Lbl_Mensaje.Text = " Ahora puede Registrar la Producción, para esto lea el código de Barras de Etiquetas";
                ctlProduccion1.VerificaEstadoMaquina(mUserLog.IdMaquina.ToString());
                ctlProduccion1.EstablecerFocoEtiqueta();
            }
            HabilitaBotones_De_Bloqueo(mUserLog.IdMaquina);
            


        }

        #endregion


        #region Metodos Publicos  de la Clases

        public void IniciaFormulario( CurrentUser iUserLog)
        {
            mUserLog = iUserLog;
            CargarMaquinas();
            ctlProduccion1.IniciaFormulario(iUserLog);
        }

        #endregion

        private void Prueba_Load(object sender, EventArgs e)
        {
           
        }

        private void Btn_Maquina1_Click(object sender, EventArgs e)
        {
            Btn_MaquinaActiva.Text = String.Concat (Btn_Maquina1.Text, " - " , Btn_Maquina1.Tag.ToString  ())   ;
            Btn_MaquinaActiva.Tag = Btn_Maquina1.Tag;
            HabilitaControlParaLectura(true );
        }

        private void Btn_Maquina2_Click(object sender, EventArgs e)
        {
            Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina2.Text, " - ", Btn_Maquina2.Tag.ToString());
            Btn_MaquinaActiva.Tag = Btn_Maquina2.Tag;
            HabilitaControlParaLectura(true);
        }

        private void Btn_Maquina3_Click(object sender, EventArgs e)
        {
            Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina3.Text, " - ", Btn_Maquina3.Tag.ToString());
            Btn_MaquinaActiva.Tag = Btn_Maquina3.Tag;
            HabilitaControlParaLectura(true);
        }

        private void Btn_Maquina4_Click(object sender, EventArgs e)
        {
            Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina4.Text, " - ", Btn_Maquina4.Tag.ToString());
            Btn_MaquinaActiva.Tag = Btn_Maquina4.Tag;
            HabilitaControlParaLectura(true);
        }

        private void Btn_Maquina5_Click(object sender, EventArgs e)
        {
            Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina5.Text, " - ", Btn_Maquina5.Tag.ToString());
            Btn_MaquinaActiva.Tag = Btn_Maquina5.Tag;
            HabilitaControlParaLectura(true);
        }

        private void Btn_Maquina6_Click(object sender, EventArgs e)
        {
            Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina6.Text, " - ", Btn_Maquina6.Tag.ToString());
            Btn_MaquinaActiva.Tag = Btn_Maquina6.Tag;
            HabilitaControlParaLectura(true);
        }

        private void Btn_Asignar_Click(object sender, EventArgs e)
        {
            MultiMaquina.FrmAsignacionMaqUser lForm = new FrmAsignacionMaqUser();
            lForm.IniciaForm();
            lForm.ShowDialog(this);

        }






    }
}

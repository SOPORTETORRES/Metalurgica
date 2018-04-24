using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private string mIdMaqSel = "";
        private string mNombre_MaqSel = "";
        private CurrentUser mUserLog_Frm = new CurrentUser();
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
            string lMultiMaq = ConfigurationManager.AppSettings["MultiMaq"].ToString();

            if (lMultiMaq.ToUpper().Equals("S"))
                lTbl = lDal.CargaTabla_MUltiMaquinas();
            else
                lTbl = lDal.CargaTabla_Maquinas();


            for (i = 0; i < lTbl.Rows.Count ;  i++)
            {
                switch (i)
                {
                    case 0:
                        Btn_Maquina1.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina1.Visible = true;Btn_Maquina1.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if ((lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))  )
                        {
                            Btn_Maquina1.BackColor = Color.LightSalmon;
                            Btn_Maquina1.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }
                            else
                            Btn_Maquina1.BackColor = Color.LightGreen ;

                        break;
                    case 1:
                        Btn_Maquina2.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina2.Visible = true;Btn_Maquina2.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))
                        {
                            Btn_Maquina2.BackColor = Color.LightSalmon;
                            Btn_Maquina2.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }
                            
                        else
                            Btn_Maquina2.BackColor = Color.LightGreen;

                        break;
                    case 2:
                        Btn_Maquina3.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina3.Visible = true;Btn_Maquina3.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();;

                        if (lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))
                        {
                            Btn_Maquina3.BackColor = Color.LightSalmon;
                            Btn_Maquina3.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }
                           
                        else
                            Btn_Maquina3.BackColor = Color.LightGreen;

                        break;
                    case 3:
                        Btn_Maquina4.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina4.Visible = true;Btn_Maquina4.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))
                        {
                            Btn_Maquina4.BackColor = Color.LightSalmon;
                            Btn_Maquina4.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }
                        else
                            Btn_Maquina4.BackColor = Color.LightGreen;

                        break;
                    case 4:
                        Btn_Maquina5.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina5.Visible = true;Btn_Maquina5.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))
                        {
                            Btn_Maquina5.BackColor = Color.LightSalmon;
                            Btn_Maquina5.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }
                        else
                            Btn_Maquina5.BackColor = Color.LightGreen;

                        break;
                    case 5:
                        Btn_Maquina6.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina6.Visible = true;Btn_Maquina6.Tag =lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))
                        {
                            Btn_Maquina6.BackColor = Color.LightSalmon;
                            Btn_Maquina6.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }
                        else
                            Btn_Maquina6.BackColor = Color.LightGreen;

                        break;
                    case 6:
                        Btn_Maquina7.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina7.Visible = true; Btn_Maquina7.Tag = lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))
                        {
                            Btn_Maquina7.BackColor = Color.LightSalmon;
                            Btn_Maquina7.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }
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
                ctlProduccion1.CargaUsuarioActual(mUserLog);
                ctlProduccion1.CargaMaqActual (mIdMaqSel ,mNombre_MaqSel );
                Lbl_Mensaje.Text = " Ahora puede Registrar la Producción, para esto lea el código de Barras de Etiquetas";
                ctlProduccion1.VerificaEstadoMaquina_MM(mUserLog.IdMaquina.ToString());
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
            if (Btn_Maquina1.BackColor == Color.LightSalmon)
            {
                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina1.Text, " - ", Btn_Maquina1.Tag.ToString());
                mIdMaqSel = Btn_Maquina1.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina1.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina1.Tag;
                string lMsg = "La Máquina Seleccionada se encuentra Bloqueda por  Averia.  No se puede Registrar la Producción. ";
                lMsg = string.Concat(lMsg, Environment.NewLine, "¿ Desea Reparar/Desbloquear la Máquina Seleccionada?");
                if (MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ctlProduccion1.Visible  = false;
                    Pnl_Login.Visible = true;
                    Pnl_Login.Enabled = true;
                    txtUsuario.Focus();
                }
            }

            else
            {
                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina1.Text, " - ", Btn_Maquina1.Tag.ToString());
                mIdMaqSel = Btn_Maquina1.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina1.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina1.Tag;
                HabilitaControlParaLectura(true);
                CargarMaquinas();
            }
            
        }

        private void Btn_Maquina2_Click(object sender, EventArgs e)
        {
            if (Btn_Maquina2.BackColor == Color.LightSalmon)
            {
                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina2.Text, " - ", Btn_Maquina2.Tag.ToString());
                mIdMaqSel = Btn_Maquina2.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina2.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina2.Tag;
                string lMsg = "La Máquina Seleccionada se encuentra Bloqueda por  Averia.  No se puede Registrar la Producción. ";
                lMsg = string.Concat(lMsg, Environment.NewLine, "¿ Desea Reparar/Desbloquear la Máquina Seleccionada?");
                if (MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ctlProduccion1.Visible = false;
                    Pnl_Login.Visible = true;
                    Pnl_Login.Enabled = true;
                    txtUsuario.Focus();
                }
            }

            else
            {
                ctlProduccion1.Visible = true;
                Pnl_Login.Visible = false;
                Pnl_Login.Enabled = false;

                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina2.Text, " - ", Btn_Maquina2.Tag.ToString());
                mIdMaqSel = Btn_Maquina2.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina2.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina2.Tag;
                HabilitaControlParaLectura(true);
                CargarMaquinas();
            }
        }

        private void Btn_Maquina3_Click(object sender, EventArgs e)
        {
            if (Btn_Maquina3.BackColor == Color.LightSalmon)
            {
                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina3.Text, " - ", Btn_Maquina3.Tag.ToString());
                mIdMaqSel = Btn_Maquina3.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina3.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina3.Tag;
                string lMsg = "La Máquina Seleccionada se encuentra Bloqueda por  Averia.  No se puede Registrar la Producción. ";
                lMsg = string.Concat(lMsg, Environment.NewLine, "¿ Desea Reparar/Desbloquear la Máquina Seleccionada?");
                if (MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ctlProduccion1.Visible = false;
                    Pnl_Login.Visible = true;
                    Pnl_Login.Enabled = true;
                    txtUsuario.Focus();
                }
            }

            else
            {
                ctlProduccion1.Visible = true;
                Pnl_Login.Visible = false;
                Pnl_Login.Enabled = false;

                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina3.Text, " - ", Btn_Maquina3.Tag.ToString());
                mIdMaqSel = Btn_Maquina3.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina3.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina3.Tag;
                HabilitaControlParaLectura(true);
                CargarMaquinas();
            }
        }

        private void Btn_Maquina4_Click(object sender, EventArgs e)
        {
            if (Btn_Maquina4.BackColor == Color.LightSalmon)
            {
                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina4.Text, " - ", Btn_Maquina4.Tag.ToString());
                mIdMaqSel = Btn_Maquina4.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina4.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina4.Tag;
                string lMsg = "La Máquina Seleccionada se encuentra Bloqueda por  Averia.  No se puede Registrar la Producción. ";
                lMsg = string.Concat(lMsg, Environment.NewLine, "¿ Desea Reparar/Desbloquear la Máquina Seleccionada?");
                if (MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ctlProduccion1.Visible = false;
                    Pnl_Login.Visible = true;
                    Pnl_Login.Enabled = true;
                    txtUsuario.Focus();
                }
            }

            else
            {
                ctlProduccion1.Visible = true;
                Pnl_Login.Visible = false;
                Pnl_Login.Enabled = false;

                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina4.Text, " - ", Btn_Maquina4.Tag.ToString());
                mIdMaqSel = Btn_Maquina4.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina4.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina4.Tag;
                HabilitaControlParaLectura(true);
                CargarMaquinas();
            }
        }

        private void Btn_Maquina5_Click(object sender, EventArgs e)
        {
            if (Btn_Maquina5.BackColor == Color.LightSalmon)
            {
                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina5.Text, " - ", Btn_Maquina5.Tag.ToString());
                mIdMaqSel = Btn_Maquina5.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina5.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina1.Tag;
                string lMsg = "La Máquina Seleccionada se encuentra Bloqueda por  Averia.  No se puede Registrar la Producción. ";
                lMsg = string.Concat(lMsg, Environment.NewLine, "¿ Desea Reparar/Desbloquear la Máquina Seleccionada?");
                if (MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ctlProduccion1.Visible = false;
                    Pnl_Login.Visible = true;
                    Pnl_Login.Enabled = true;
                    txtUsuario.Focus();
                }
            }

            else
            {
                ctlProduccion1.Visible = true;
                Pnl_Login.Visible = false;
                Pnl_Login.Enabled = false;

                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina5.Text, " - ", Btn_Maquina5.Tag.ToString());
                mIdMaqSel = Btn_Maquina5.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina5.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina5.Tag;
                HabilitaControlParaLectura(true);
                CargarMaquinas();
            }
        }

        private void Btn_Maquina6_Click(object sender, EventArgs e)
        {
            if (Btn_Maquina6.BackColor == Color.LightSalmon)
            {
                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina6.Text, " - ", Btn_Maquina6.Tag.ToString());
                mIdMaqSel = Btn_Maquina6.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina6.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina6.Tag;
                string lMsg = "La Máquina Seleccionada se encuentra Bloqueda por  Averia.  No se puede Registrar la Producción. ";
                lMsg = string.Concat(lMsg, Environment.NewLine, "¿ Desea Reparar/Desbloquear la Máquina Seleccionada?");
                if (MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ctlProduccion1.Visible = false;
                    Pnl_Login.Visible = true;
                    Pnl_Login.Enabled = true;
                    txtUsuario.Focus();
                }
            }

            else
            {
                ctlProduccion1.Visible = true;
                Pnl_Login.Visible = false;
                Pnl_Login.Enabled = false;

                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina6.Text, " - ", Btn_Maquina6.Tag.ToString());
                mIdMaqSel = Btn_Maquina6.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina6.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina6.Tag;
                HabilitaControlParaLectura(true);
                CargarMaquinas();
            }
        }

        private void Btn_Asignar_Click(object sender, EventArgs e)
        {
            MultiMaquina.FrmAsignacionMaqUser lForm = new FrmAsignacionMaqUser();
            lForm.IniciaForm();
            lForm.ShowDialog(this);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ctlProduccion1.Visible = true;
            Pnl_Login.Visible = false;
            Pnl_Login.Enabled = false;
        }

        private Boolean PuedeIngresarReparacion(string iPerfilUsuario)
        {
            Boolean lPuedeSeguir = true;
            // Si es cambio de Rollo No requiere validacion del perfil del mecanico.

            //if (mTipoAveria.Equals("AV"))
            //{
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = ""; string lPerfil = iPerfilUsuario; string lMsg = "";

            //Verificamos el estado de la averia
           // lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA ", mIdAveriaSeleccionada, ",0,'','','',0,'',", iIdElemento, ",'',7 ");
            lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA 0,0,'','','',0,'',", mUserLog.IdMaquina, ",'',3 ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                if (lDts.Tables[0].Rows[0]["Estado"].ToString().Equals("DET"))
                   { 
                    if (lDts.Tables[0].Rows[0]["EstadoSup"].ToString().Equals("NOOK") && lDts.Tables[0].Rows[0]["EstadoMaq"].ToString().Equals("OP"))
                {
                    if (lPerfil.ToString().ToUpper().Equals("SUPERVISOR"))
                    {
                        //*****************************************
                        Pnl_Login.Visible = false;
                        AppDomain.CurrentDomain.SetData("IdUser", mUserLog_Frm.Iduser);
                        AppDomain.CurrentDomain.SetData("User", mUserLog_Frm.Login);
                        //******************************************+
                    }
                    else
                    {
                        lMsg = String.Concat(" Solamente los Usuarios con Perfil de SUPERVISOR puedes Ingresar las liberaciones de  reparaciones ", Environment.NewLine, " No esta autorizado realizar la liberación de Reparaciones ");
                        MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                        lPuedeSeguir = false;
                    }
                }
                else
                {
                    if (lPerfil.ToString().ToUpper().Equals("MECANICO"))
                    {
                        //Se deben listar las Notificaciones que estan Abiertas, el debe seleccionar 
                        //cual desea solucionar, Se debe listar todas pero solo puede liberar las pendientes
                        Pnl_Login.Visible = false;
                        AppDomain.CurrentDomain.SetData("IdUser", mUserLog_Frm.Iduser);
                        AppDomain.CurrentDomain.SetData("User", mUserLog_Frm.Login);
                    }
                    else
                    {
                        lMsg = String.Concat(" Solamente los Usuarios con Perfil de Mecanicos puedes Ingresar las reparaciones ", Environment.NewLine, " No esta autorizado a ingresar Reparaciones ");
                        MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                        lPuedeSeguir = false;
                    }
                    }
                }
            }
            return lPuedeSeguir;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Registry registry = new Registry();
            Cursor.Current = Cursors.WaitCursor;
            WsSesion.WS_SesionSoapClient wsSesions = new WsSesion.WS_SesionSoapClient();
            WsSesion.ListaDataSet listaDataSet = new WsSesion.ListaDataSet();Boolean lPuedeSeguir = false;
            listaDataSet = wsSesions.ObtenerUsuario(txtUsuario.Text, txtClave.Text);
            DataSet Ldts = new DataSet(); string lPerfilUser = ""; string lIdUser = "";
            Cursor.Current = Cursors.Default;

            try
            {
                if (listaDataSet.MensajeError.Equals(""))
                {
                    DataTable dt = listaDataSet.DataSet.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Vigente"].ToString().Equals("S"))
                        {
                            //Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina1.Text, " - ", Btn_Maquina1.Tag.ToString());
                            //mIdMaqSel = Btn_Maquina1.Tag.ToString();
                            //mNombre_MaqSel = Btn_Maquina1.Text;
                            //Btn_MaquinaActiva.Tag = Btn_Maquina1.Tag;
                            lPerfilUser = dt.Rows[0]["DescPerfil"].ToString();
                         //   HabilitaControlParaLectura(true);

                            ctlProduccion1.Visible = true;
                            Pnl_Login.Visible = false;
                            Pnl_Login.Enabled = false;

                            lIdUser = dt.Rows[0]["id"].ToString();
                            mUserLog.Login = ObtenerUsuarioPorId(lIdUser);
                            //Btn_UsuarioActiva.Text = string.Concat(mUserLog.Login, "-", lIdUser);
                            mUserLog.Iduser = lIdUser;
                            mUserLog.PerfilUsuario = lPerfilUser;
                            mUserLog.IdMaquina = int.Parse(Btn_MaquinaActiva.Tag.ToString());
                            //ctlProduccion1.CargaUsuarioActual(mUserLog);
                            //ctlProduccion1.HabilitaControl(iHabilitado);
                            //ctlProduccion1.CargaUsuarioActual(mUserLog);
                            //ctlProduccion1.CargaMaqActual(mIdMaqSel, mNombre_MaqSel);
                            //Lbl_Mensaje.Text = " Ahora puede Registrar la Producción, para esto lea el código de Barras de Etiquetas";
                            //ctlProduccion1.VerificaEstadoMaquina(Btn_Maquina1.Tag.ToString());
                            //ctlProduccion1.EstablecerFocoEtiqueta();
                            txtClave.Text = "";
                            txtUsuario.Text = "";
                            lPuedeSeguir= PuedeIngresarReparacion(lPerfilUser);
                            if (lPuedeSeguir ==true )
                            {
                                AppDomain.CurrentDomain.SetData("TipoAveria", "MM");
                                ctlProduccion1.PuedeIngresarReparacion();
                                AppDomain.CurrentDomain.SetData("TipoAveria", "");
                            }
                                    

                        }
                        else
                            MessageBox.Show("El usuario " + txtUsuario.Text + " esta inactivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("El usuario " + txtUsuario.Text + " no existe o la contraseña es incorrecta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }           
             catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 
             }
}

        private void ctlProduccion1_Load(object sender, EventArgs e)
        {

        }
    }
}

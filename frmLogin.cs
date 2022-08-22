using System;
using System.Windows.Forms;
using CommonLibrary2;
using System.Data;
using System.Configuration;

namespace Metalurgica
{
    public partial class frmLogin : Form
    {
        public bool logon = false;
        public int mTipoTotem = 0;
        public string mLoginPorTarjeta = "";

        public frmLogin()
        {
            InitializeComponent();
            Clases.ClsComun lCom = new Clases.ClsComun();
            this.Text += " - " + lCom.ObtenerVersion();  //Application.ProductVersion;
            mLoginPorTarjeta = lCom.ObtenerLoginPorTarjeta();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private  DataSet ObtenerUsuario(string  iUser)
        {
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            Ws_TO .Ws_ToSoapClient  PxWS = new  Ws_TO .Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = ""; DataSet DtsFinal = new DataSet(); DataTable lTbl2 = new DataTable();
            lSql = string.Concat(" exec SP_Consultas_WS  39,'", iUser, "','','','','','',''");
            try
            {
                listaDataSet.MensajeError = "";
                lDts = PxWS.ObtenerDatos(lSql);
                if (lDts.Tables.Count > 0)
                {
                    lTbl = lDts.Tables[0].Copy();
                    DtsFinal.Tables.Add(lTbl.Copy());
                    lSql = string.Concat(" exec SP_Consultas_WS  40,'", lTbl.Rows [0]["Id"].ToString (), "','','','','','',''");
                    lDts = PxWS.ObtenerDatos(lSql);
                    if (lDts.Tables.Count > 0)
                    {
                        lTbl2 = lDts.Tables[0].Copy();
                        lTbl2.TableName = "OtraTabla";
                        DtsFinal.Tables.Add(lTbl2.Copy());
                    }
                }
               // lDts.Tables.Add(lTbl.Copy());

                listaDataSet.DataSet = DtsFinal;
            }           
             catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listaDataSet.MensajeError = exc.Message.ToString();                  
             }
            return listaDataSet.DataSet .Copy() ;

        }


        private string ObtenerDescripcionMaquina(string iIdMaq)
        {
    // ALTER PROCEDURE [dbo].[SP_CRUD_MAQUINA]
    //@ID INT,                      //@NOMBRE VARCHAR(100),                     //@DESCRIPCION VARCHAR(250),
    //@ACTIVA VARCHAR(10),          //@IdTotem int,                             //@IdTipoMaq VARCHAR(50),
    //@PARAM1 VARCHAR(50),          //@PARAM2 VARCHAR(50),                      //@OPCION INT
            Ws_TO.Ws_ToSoapClient PxWS = new Ws_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lRes = "   "; string lSql = " exec SP_CRUD_MAQUINA ";
            lSql = string.Concat(lSql, " '','','','',0,'',",iIdMaq,",'','',17");

            lDts = PxWS.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) &&  (lDts.Tables[0].Rows.Count > 0))
            {
                lRes = lDts.Tables[0].Rows[0]["Maq_nombre"].ToString();
            }
            return lRes;
        }

        private string ObtenerPerfilUsuario(string iIdPerfil)
        {
            // ALTER PROCEDURE [dbo].[SP_CRUD_MAQUINA]
            //@ID INT,                      //@NOMBRE VARCHAR(100),                     //@DESCRIPCION VARCHAR(250),
            //@ACTIVA VARCHAR(10),          //@IdTotem int,                             //@IdTipoMaq VARCHAR(50),
            //@PARAM1 VARCHAR(50),          //@PARAM2 VARCHAR(50),                      //@OPCION INT
            Ws_TO.Ws_ToSoapClient PxWS = new Ws_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            string lRes = "   "; string lSql = string.Concat (" Select * from to_parametros where id=",iIdPerfil );            

            lDts = PxWS.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lRes = lDts.Tables[0].Rows[0]["Par1"].ToString();
            }
            return lRes;
        }


        private void SoloMP()
        {
            try
            {
                Registry registry = new Registry();
                Cursor.Current = Cursors.WaitCursor;
                WsSesion.WS_SesionSoapClient wsSesions = new WsSesion.WS_SesionSoapClient();
                Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
                WsSesion.ListaDataSet listaDataSet = new WsSesion.ListaDataSet();
                listaDataSet = wsSesions.ObtenerUsuario(txtUsuario.Text, txtClave.Text);
                DataSet Ldts = new DataSet(); string lPerfilUser = "";
                DataView lVista = null;DataTable lTblUser = new DataTable();
                Cursor.Current = Cursors.Default;

                if (listaDataSet.MensajeError.Equals(""))
                {
                    DataTable dt = listaDataSet.DataSet.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["Vigente"].ToString().Equals("S"))
                        {
                            lTblUser = dt.Copy();
                            Ldts = lPx.ObtenerUsuario(txtUsuario.Text, txtClave.Text);
                            if (Ldts.Tables["Accesos"].Rows.Count > 0)
                            {
                                dt = Ldts.Tables["Accesos"].Copy();
                                lVista = new DataView(dt, String.Concat("Codigo='I.MP'"), "", DataViewRowState.CurrentRows);
                                if (lVista.Count == 0)
                                {
                                    MessageBox.Show("El Usuario Ingresado No tiene Permiso para Ingresar al Módulo de Ingreso de Materia Prima", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Close();
                                }
                                else
                                {
                                    if (chkRecordarUsuario.Checked)
                                        registry.SetValue(Program.regeditKeyName, "Usuario", txtUsuario.Text);
                                    registry.SetValue(Program.regeditKeyName, "Recordar", (chkRecordarUsuario.Checked ? "1" : "0"));

                                    lPerfilUser = lTblUser.Rows[0]["Perfil"].ToString();
                                    Program.currentUser.Login = lTblUser.Rows[0]["Usuario"].ToString(); ;
                                    Program.currentUser.Name = lTblUser.Rows[0]["Nombre"].ToString() + " " + lTblUser.Rows[0]["Apellidos"].ToString();
                                    //Program.currentUser.Machine = 2;
                                    Program.currentUser.Iduser = lTblUser.Rows[0]["Id"].ToString();
                                    Program.currentUser.ComputerName = System.Environment.MachineName;
                                    Program.currentUser.DescripcionTotem = (string)registry.GetValue(Program.regeditKeyName, "Descrición", "");
                                    Program.currentUser.Machine = int.Parse(registry.GetValue(Program.regeditKeyName, "Maquina", "0").ToString());
                                    Program.currentUser.IdMaquina = Convert.ToInt16(new Registry().GetValue(Program.regeditKeyName, "IdMaquina", -1));
                                    Program.currentUser.IdTotem = Convert.ToInt16(new Registry().GetValue(Program.regeditKeyName, "IdTotem", -1));

                                    Program.currentUser.DescripcionMaq = ObtenerDescripcionMaquina(Program.currentUser.IdMaquina.ToString());

                                    Program.currentUser.PerfilUsuario = ObtenerPerfilUsuario(lPerfilUser);
                                    if (Program.currentUser.Machine == 2)
                                    {
                                        string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();
                                        //if (lEmpresa.ToUpper().Equals("TO"))
                                        //    ValidaAccesoProduccion(Program.currentUser.Iduser.ToString(), Program.currentUser.IdMaquina.ToString(), Program.currentUser.ComputerName.ToString());
                                    }
                                    //ObtenerPerfilUsuario
                                    logon = true;
                                    this.Hide();
                                    IniciaApp(1, Program.currentUser);
                                }
                            }
                        }
              



                        //if (dt.Rows.Count > 0)
                        //{
                        //    if (dt.Rows[0]["Vigente"].ToString().Equals("S"))
                        //    {

                               


                        //    }
                        //    else
                        //        MessageBox.Show("El usuario " + txtUsuario.Text + " esta inactivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        //else
                        //    MessageBox.Show("El usuario " + txtUsuario.Text + " no existe o la contraseña es incorrecta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            Application.Exit();

        }

        private void IngresoNormal()
        {
            try
            {
                Registry registry = new Registry();
                Cursor.Current = Cursors.WaitCursor;
                WsSesion.WS_SesionSoapClient wsSesions = new WsSesion.WS_SesionSoapClient();
                WsSesion.ListaDataSet listaDataSet = new WsSesion.ListaDataSet();
                listaDataSet = wsSesions.ObtenerUsuario(txtUsuario.Text, txtClave.Text);
                DataSet Ldts = new DataSet(); string lPerfilUser = "";
                Cursor.Current = Cursors.Default;

                if (listaDataSet.MensajeError.Equals(""))
                {
                    DataTable dt = listaDataSet.DataSet.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        // Por nuevo requerimiento, para los usuarios de produccion deben poder ingresar solo con
                        // el RUT.
                        if ((dt.Rows.Count == 0) && (mTipoTotem == 2))
                        {
                            Ldts = ObtenerUsuario(txtUsuario.Text);
                            if (Ldts.Tables.Count > 0)
                            {
                                dt = Ldts.Tables[0].Copy();
                            }
                        }


                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["Vigente"].ToString().Equals("S"))
                            {

                                if (chkRecordarUsuario.Checked)
                                    registry.SetValue(Program.regeditKeyName, "Usuario", txtUsuario.Text);
                                registry.SetValue(Program.regeditKeyName, "Recordar", (chkRecordarUsuario.Checked ? "1" : "0"));

                                lPerfilUser = dt.Rows[0]["Perfil"].ToString();
                                Program.currentUser.Login = dt.Rows[0]["Usuario"].ToString(); ;
                                Program.currentUser.Name = dt.Rows[0]["Nombre"].ToString() + " " + dt.Rows[0]["Apellidos"].ToString();
                                //Program.currentUser.Machine = 2;
                                Program.currentUser.Iduser = dt.Rows[0]["Id"].ToString();
                                Program.currentUser.ComputerName = System.Environment.MachineName;
                                Program.currentUser.DescripcionTotem = (string)registry.GetValue(Program.regeditKeyName, "Descrición", "");
                                Program.currentUser.Machine = int.Parse(registry.GetValue(Program.regeditKeyName, "Maquina", "0").ToString());
                                Program.currentUser.IdMaquina = Convert.ToInt16(new Registry().GetValue(Program.regeditKeyName, "IdMaquina", -1));
                                Program.currentUser.IdTotem = Convert.ToInt16(new Registry().GetValue(Program.regeditKeyName, "IdTotem", -1));

                                Program.currentUser.DescripcionMaq = ObtenerDescripcionMaquina(Program.currentUser.IdMaquina.ToString());

                                Program.currentUser.PerfilUsuario = ObtenerPerfilUsuario(lPerfilUser);
                                if (Program.currentUser.Machine == 2)
                                {
                                    string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();
                                    if (lEmpresa.ToUpper().Equals("TO"))
                                        ValidaAccesoProduccion(Program.currentUser.Iduser.ToString(), Program.currentUser.IdMaquina.ToString(), Program.currentUser.ComputerName.ToString());
                                }
                                //ObtenerPerfilUsuario
                                logon = true;
                                this.Hide();
                                IniciaApp(Program.currentUser.Machine, Program.currentUser);


                            }
                            else
                                MessageBox.Show("El usuario " + txtUsuario.Text + " esta inactivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("El usuario " + txtUsuario.Text + " no existe o la contraseña es incorrecta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            Application.Exit();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                string lSoloMP = ConfigurationManager.AppSettings["SoloMP"].ToString();

                if (lSoloMP.ToUpper().Equals("S"))
                    SoloMP();
                else
                    IngresoNormal();

                //    Registry registry = new Registry();
                //    Cursor.Current = Cursors.WaitCursor;
                //    WsSesion.WS_SesionSoapClient wsSesions = new WsSesion.WS_SesionSoapClient();
                //    WsSesion.ListaDataSet listaDataSet = new WsSesion.ListaDataSet();
                //    listaDataSet = wsSesions.ObtenerUsuario(txtUsuario.Text, txtClave.Text);
                //    DataSet Ldts = new DataSet(); string lPerfilUser = "";
                //    Cursor.Current = Cursors.Default;

                //    if (listaDataSet.MensajeError.Equals(""))
                //    {
                //        DataTable dt = listaDataSet.DataSet.Tables[0];

                //        if (dt.Rows.Count > 0)
                //        {
                //            // Por nuevo requerimiento, para los usuarios de produccion deben poder ingresar solo con
                //            // el RUT.
                //            if ((dt.Rows.Count == 0) && (mTipoTotem == 2))
                //            {
                //                Ldts = ObtenerUsuario(txtUsuario.Text);
                //                if (Ldts.Tables.Count > 0)
                //                {
                //                    dt = Ldts.Tables[0].Copy();
                //                }
                //            }


                //            if (dt.Rows.Count > 0)
                //            {
                //                if (dt.Rows[0]["Vigente"].ToString().Equals("S"))
                //                {

                //                    if (chkRecordarUsuario.Checked)
                //                        registry.SetValue(Program.regeditKeyName, "Usuario", txtUsuario.Text);
                //                    registry.SetValue(Program.regeditKeyName, "Recordar", (chkRecordarUsuario.Checked ? "1" : "0"));

                //                    lPerfilUser = dt.Rows[0]["Perfil"].ToString();
                //                    Program.currentUser.Login = dt.Rows[0]["Usuario"].ToString(); ;
                //                    Program.currentUser.Name = dt.Rows[0]["Nombre"].ToString() + " " + dt.Rows[0]["Apellidos"].ToString();
                //                    //Program.currentUser.Machine = 2;
                //                    Program.currentUser.Iduser = dt.Rows[0]["Id"].ToString();
                //                    Program.currentUser.ComputerName = System.Environment.MachineName;
                //                    Program.currentUser.DescripcionTotem = (string)registry.GetValue(Program.regeditKeyName, "Descrición", "");
                //                    Program.currentUser.Machine = int.Parse(registry.GetValue(Program.regeditKeyName, "Maquina", "0").ToString());
                //                    Program.currentUser.IdMaquina = Convert.ToInt16(new Registry().GetValue(Program.regeditKeyName, "IdMaquina", -1));
                //                    Program.currentUser.IdTotem = Convert.ToInt16(new Registry().GetValue(Program.regeditKeyName, "IdTotem", -1));

                //                    Program.currentUser.DescripcionMaq = ObtenerDescripcionMaquina(Program.currentUser.IdMaquina.ToString());

                //                    Program.currentUser.PerfilUsuario = ObtenerPerfilUsuario(lPerfilUser);
                //                    if (Program.currentUser.Machine == 2)
                //                    {
                //                        string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();
                //                        if (lEmpresa.ToUpper().Equals("TO"))
                //                            ValidaAccesoProduccion(Program.currentUser.Iduser.ToString(), Program.currentUser.IdMaquina.ToString(), Program.currentUser.ComputerName.ToString());
                //                    }
                //                    //ObtenerPerfilUsuario
                //                    logon = true;
                //                    this.Hide();
                //                    IniciaApp(Program.currentUser.Machine, Program.currentUser);


                //                }
                //                else
                //                    MessageBox.Show("El usuario " + txtUsuario.Text + " esta inactivo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            }
                //            else
                //                MessageBox.Show("El usuario " + txtUsuario.Text + " no existe o la contraseña es incorrecta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //        }
                //        else
                //            MessageBox.Show("El usuario " + txtUsuario.Text + " no existe o la contraseña es incorrecta.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    }
                //    else
                //        MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
        }

        private void ValidaAccesoProduccion(string iIdUsuario, string iNroMaquina, string iPcAccede)
        {
            DataTable lTbl = new DataTable(); string lIdAccesoUser = "";
            WsSesion.WS_SesionSoapClient wsSesions = new WsSesion.WS_SesionSoapClient();
            WsSesion.ListaDataSet listaDataSet = new WsSesion.ListaDataSet();
            DataTable lTblUser = new DataTable(); int i = 0; string lMsg = "";

            listaDataSet = wsSesions.ObtenerDatosUsuarioLogeado(iIdUsuario, iNroMaquina);
            if (listaDataSet.MensajeError.ToString().Trim().Length == 0)
            {
                if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    listaDataSet = new WsSesion.ListaDataSet();
                    if (lTbl.Rows.Count > 0)  // ya estaba logeado en el Pc
                    {
                        lTblUser = lTbl.Copy();
                        for (i = 0; i < lTbl.Rows.Count; i++)
                        {
                            //NroMaquina  , FechaEntrada, PC_Accede
                            if (lTbl.Rows[i]["NroMaquina"].ToString() != iNroMaquina)
                            {
                                lMsg = string .Concat (lMsg, " El Usuario ya ha iniciado Sesion en el Totem: ", lTbl.Rows[i]["PC_accede"].ToString(), Environment .NewLine ) ;
                                lIdAccesoUser = "";
                            }
                            lIdAccesoUser = lTbl.Rows[0]["id"].ToString();
                        }
                        
                    }
                     
                    else   //no estaba logeado
                        lIdAccesoUser = wsSesions.RegistraLogin(iIdUsuario, iNroMaquina, iPcAccede);

                }
                else
                {
                    lIdAccesoUser = wsSesions.RegistraLogin(iIdUsuario, iNroMaquina, iPcAccede);
                }

                if (lMsg.Trim().Length > 0)
                {
                    MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                    Application.Exit();
                }
                else
                {
                    Program.currentUser.IdAccesoTotem = int.Parse(lIdAccesoUser);
                }
               
            
            }
            else
                MessageBox.Show(string.Concat ("Ha Ocurrido el Siguiente Error: ",listaDataSet .MensajeError ), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void IniciaApp(int iIdTipoTotem,CurrentUser iUserLog)
        {
            if (iIdTipoTotem == 1)
            {
                 frmRecepcionColada lFrm = new frmRecepcionColada();
                 lFrm.IniciaFormulario(iUserLog);
                //Code128.FrmGeneraCode128  lFrm = new Code128.FrmGeneraCode128();
                lFrm.ShowDialog();
            }
            if (iIdTipoTotem == 2)
            {
                string lEmpresa = ConfigurationManager.AppSettings["Empresa"].ToString();
                string lMultiMaq = ConfigurationManager.AppSettings["MultiMaq"].ToString();
                if (lEmpresa.ToUpper().Equals("TO"))
                {
                    if (lMultiMaq.ToUpper().Equals("S"))
                    {
                        MultiMaquina.Prueba lFrm = new MultiMaquina.Prueba();
                        iUserLog.IdMaquina = 0;
                        iUserLog.IdTotem   = 0;                        iUserLog.Iduser = "";
                        iUserLog.PerfilUsuario = "";                        iUserLog.Name = "";
                        iUserLog.Login  = ""; iUserLog.DescripcionMaq = "";

                        lFrm.IniciaFormulario(iUserLog);
                        lFrm.ShowDialog();
                    }
                    else
                    {
                        FrmProduccion_2 lFrm = new FrmProduccion_2();
                        lFrm.IniciaFormulario(iUserLog);
                        lFrm.ShowDialog();
                    }
                }
                else
                {
                    MultiMaquina.Prueba lFrm = new MultiMaquina.Prueba();
                    lFrm.IniciaFormulario(iUserLog);
                    lFrm.ShowDialog();
                }
                }
            if (iIdTipoTotem == 3)
            {
                frmDespachoCamion lFrm = new frmDespachoCamion();
                lFrm.IniciaFormulario(iUserLog);
                lFrm.ShowDialog();
            }

            if (iIdTipoTotem == 0)
            {
                Frm_Adm lFrm = new Frm_Adm();
                lFrm.IniciaForm(iUserLog);
                lFrm.ShowDialog();
            }

            if (iIdTipoTotem == 4)   
            {
                Conectores.Frm_CuadroProgramacion lFrm = new Conectores.Frm_CuadroProgramacion();
                lFrm.IniciaForm(iUserLog);
                lFrm.ShowDialog();
            }

            if (iIdTipoTotem == 5) //Personal de Calidad, para  producciones externas
            {
                ProduccionExterna.Frm_ProduccionExterna lfrm = new ProduccionExterna.Frm_ProduccionExterna();
                lfrm.InicializaForm(iUserLog, "C");
                lfrm.ShowDialog();
            }
            if (iIdTipoTotem == 6) //Personal de Oficina Tecnica, para envio de   producciones externas
            {
                ProduccionExterna.Frm_ProduccionExterna lfrm = new ProduccionExterna.Frm_ProduccionExterna();
                lfrm.InicializaForm(iUserLog, "O");
                lfrm.ShowDialog();
            }
            if (iIdTipoTotem == 7) //TOSOL, envio a produccion externa, dar como producido y dar como despachado
            {
                frmDespachoCamion lFrm = new frmDespachoCamion();
                lFrm.IniciaFormulario(iUserLog);
                lFrm.ShowDialog();
            }

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (mTipoTotem == 2)
            {
                txtUsuario.PasswordChar ='*';
                //PasswordChar = "*"c
                btnAceptar.Enabled = true;                              
            }              
            else
                btnAceptar.Enabled = (txtUsuario.Text.Trim().Length > 0 && txtClave.Text.Trim().Length > 0);

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            txtUsuario_TextChanged(sender, e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    //e.SuppressKeyPress = true;
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            Registry registry = new Registry();
            int iTipoTotem = int.Parse(registry.GetValue(Program.regeditKeyName, "Maquina", "0").ToString());
            mTipoTotem = iTipoTotem;
            if (registry.GetValue(Program.regeditKeyName, "Recordar", "0").Equals("1"))
            {
                txtUsuario.Text = (string)registry.GetValue(Program.regeditKeyName, "Usuario", "");
                SendKeys.Send("{ENTER}");
            }
            else
                chkRecordarUsuario.Checked = false;

            btnAceptar.Enabled = !txtUsuario.Text.Trim().Equals("") && !txtClave.Text.Trim().Equals("");
            
        }

        private string eliminarCaracteresEspeciales(string entrada)
        {
            StringUtility stringUtility = new StringUtility();
            string salida = entrada;
            if (!salida.Trim().Equals(""))
                salida = stringUtility.removeInvalidCharacters(salida, stringUtility.RegexPattern_Address);
            return salida;
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            txtUsuario.Text = eliminarCaracteresEspeciales(txtUsuario.Text.Trim());
            if (mLoginPorTarjeta.ToUpper().Equals("S"))
            { 
            btnAceptar_Click(null, null);            
            }            
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            txtClave.Text = eliminarCaracteresEspeciales(txtClave.Text.Trim());
        }

        private void BtnPrueba_Click(object sender, EventArgs e)
        {

            //Clases.ClsComun lComun = new Clases.ClsComun();
            //string lParam= Application.StartupPath;
            //lComun.EjecutaShell(lParam);
            //Bascula.Frm_DetalleGrabacion lFrm = new Bascula.Frm_DetalleGrabacion();
            //lFrm.ShowDialog();

            Conectores.Frm_CuadroProgramacion lFrm = new Conectores.Frm_CuadroProgramacion();
            lFrm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string textoAveria = "QUEDAN 3 FIERROS APRETADOS EN EL SECTOR DEL CUCHILLO";
            //Maquinas.Frm_IngresoRepuestos Frm = new Maquinas.Frm_IngresoRepuestos();
            //Frm.inicializar("8424", textoAveria, "442", "4", "10");
            //Frm.ShowDialog();

            //'Probamos Cambio en GDE 
            string iViajes = "";string iRespuesta = "";
            Integracion_INET.Cls_LN lDal = new Integracion_INET.Cls_LN();
            iViajes = "HBL-1582/1,HBL-1562/2,HBL-1563/2,HBL-1566/2,HBL-1567/2,HBL-1574/2,HBL-1568/2,HBL-1569/2,HBL-1570/2,HBL-1571/2,HBL-1577/2,HBL-1558/2,HBL-1559/2,HBL-1560/2,HBL-1554/2,HBL-1561/2,HBL-1552/2,HBL-1576/1,HBL-1575/1,HBL-1514/2,HBL-1530/2,HBL-1573/1,HBL-1540/1,HBL-1531/1";
            iRespuesta = "<?xml version='1.0' encoding='utf-16'?>  <ExecuteResponse xmlns:xsi='http//www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>  ";
            iRespuesta = String.Concat(iRespuesta, " <Xmlout>     <SDT_ERRORES_ERROR xmlns = 'http//www.informat.cl/ws' <> NUMERROR > 0</NUMERROR>    ");
            iRespuesta = String.Concat(iRespuesta, "  <DESCERROR><SDT_RESP_PROCESO xmlns='http://www.informat.cl/ws'>  <NRO_DOC>0</NRO_DOC>  <CAJCOD>0</CAJCOD>   ");
            iRespuesta = String.Concat(iRespuesta, "  	 <DOCCOD>363</DOCCOD>  <ATENUMREA>2777</ATENUMREA>  ");
            iRespuesta = String.Concat(iRespuesta, "   <COD_ESTADO>0</COD_ESTADO>  <DSC_ESTADO>Pendiente</DSC_ESTADO>");
            iRespuesta = String.Concat(iRespuesta, " <MOT_ESTADO/> </SDT_RESP_PROCESO> </DESCERROR>      </SDT_ERRORES_ERROR>    </Xmlout>  </ExecuteResponse> ");

            lDal.GrabaDetalleViajes_GDE(iRespuesta, iViajes);

            //string lSucursal = ""; string lPar = "SG-295/1|15|Stgo|60";
            //Registry registry = new Registry();
            //lSucursal = (string)registry.GetValue(Program.regeditKeyName, "Sucursal", "");
            ////lPar = string.Concat(Lbl_Viajes.Text, "|", lIdObra, "|", lSucursal, "|", idDespacho);
            //Clases.ClsComun lLog = new Clases.ClsComun();
            //lLog.EjecutaShell(Application.StartupPath, lPar);
            //Produccion.CargaEstadisticasMaq lfr = new Produccion.CargaEstadisticasMaq();
            //lfr.Show();

            //Conectores.Frm_CuadroProgramacion lFrm = new Conectores.Frm_CuadroProgramacion();
            //lFrm.ShowDialog();

            //ProduccionExterna.Frm_ProduccionExterna lFrm = new ProduccionExterna.Frm_ProduccionExterna();
            //lFrm.ShowDialog();

            //Metalurgica.Controls.CtlProduccion lCtl = new Controls.CtlProduccion();
            //lCtl.ObtenerEtiquetaAZA("2612286902;2019-03-14T01:28;33;B HORMIGON 25mm 7m A630-420H (N);110002927;1660");

            //RecepcionMP.Frm_RecepcionMP lFrm = new RecepcionMP.Frm_RecepcionMP();
            //lFrm.ShowDialog();

            //Muestreo.Frm_ControlDimensional lfrm = new Muestreo.Frm_ControlDimensional();
            //lfrm.ShowDialog();

            //Ws_TO.Ws_ToSoapClient PxWS = new Ws_TO.Ws_ToSoapClient();
            //WsCrud.CrudSoapClient lCr = new WsCrud.CrudSoapClient();
            //WsCrud.ListaDataSet lista = new WsCrud.ListaDataSet();

            //DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            //string lRes = "   "; string lSql = string.Concat("  SP_ConsultasGenerales  150, '4','16','','','' ");

            ////lDts = PxWS.ObtenerDatos(lSql);
            //lista = lCr.ListarAyudaSql(lSql);

            //MessageBox.Show("Termino la carga");

            //Tools.Frm_Tools lFrm = new Tools.Frm_Tools();
            //lFrm.ShowDialog();

            //Tools.Frm_CorrigeKilos lFrm = new Tools.Frm_CorrigeKilos();
            //lFrm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
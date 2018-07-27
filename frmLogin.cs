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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Registry registry = new Registry();
                Cursor.Current = Cursors.WaitCursor;                
                WsSesion.WS_SesionSoapClient wsSesions = new WsSesion.WS_SesionSoapClient();
                WsSesion.ListaDataSet  listaDataSet = new WsSesion.ListaDataSet();
                listaDataSet = wsSesions.ObtenerUsuario(txtUsuario.Text, txtClave.Text);
                DataSet Ldts = new DataSet(); string lPerfilUser="";
                Cursor.Current = Cursors.Default;

                if (listaDataSet.MensajeError.Equals(""))
                {
                    DataTable dt = listaDataSet.DataSet.Tables[0];

                    // Por nuevo requerimiento, para los usuarios de produccion deben poder ingresar solo con
                    // el RUT.
                    if ((dt.Rows.Count == 0) && (mTipoTotem ==2))
                    {
                        Ldts=ObtenerUsuario(txtUsuario.Text);
                        if (Ldts .Tables .Count >0)
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

                            lPerfilUser=dt.Rows[0]["Perfil"].ToString();
                            Program.currentUser.Login = dt.Rows[0]["Usuario"].ToString(); ;
                            Program.currentUser.Name = dt.Rows[0]["Nombre"].ToString() + " " + dt.Rows[0]["Apellidos"].ToString();
                            //Program.currentUser.Machine = 2;
                            Program.currentUser.Iduser = dt.Rows[0]["Id"].ToString();
                            Program.currentUser.ComputerName = System.Environment.MachineName;
                            Program.currentUser .DescripcionTotem = (string)registry.GetValue(Program.regeditKeyName, "Descrición", "");
                            Program.currentUser .Machine =int.Parse (registry.GetValue(Program.regeditKeyName, "Maquina", "0").ToString ());
                            Program.currentUser.IdMaquina = Convert.ToInt16(new Registry().GetValue(Program.regeditKeyName, "IdMaquina", -1));
                            Program.currentUser.IdTotem  = Convert.ToInt16(new Registry().GetValue(Program.regeditKeyName, "IdTotem", -1));

                            Program.currentUser.DescripcionMaq = ObtenerDescripcionMaquina(Program.currentUser.IdMaquina.ToString ());

                            Program.currentUser.PerfilUsuario = ObtenerPerfilUsuario(lPerfilUser);

                            ValidaAccesoProduccion(Program.currentUser.Iduser.ToString(), Program.currentUser.IdMaquina.ToString(), Program.currentUser.Machine.ToString());

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
                    MessageBox.Show(listaDataSet.MensajeError.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }            Application.Exit();
        }

        private void ValidaAccesoProduccion(string iIdUsuario, string iNroMaquina, string iPcAccede)
        {
            DataTable lTbl = new DataTable(); string lIdAccesoUser = "";
            WsSesion.WS_SesionSoapClient wsSesions = new WsSesion.WS_SesionSoapClient();
            WsSesion.ListaDataSet listaDataSet = new WsSesion.ListaDataSet();
            DataTable lTblUser = new DataTable();

            listaDataSet = wsSesions.ObtenerDatosUsuarioLogeado(iIdUsuario, iNroMaquina);
            if (listaDataSet.MensajeError.ToString().Trim().Length == 0)
            {
                if ((listaDataSet.DataSet.Tables.Count > 0) && (listaDataSet.DataSet.Tables[0].Rows.Count > 0))
                {
                    lTbl = listaDataSet.DataSet.Tables[0].Copy();
                    listaDataSet = new WsSesion.ListaDataSet();
                    if (lTbl.Rows.Count > 0)  // ya estaba logeado en el Pc
                        lTblUser = lTbl.Copy();
                    else   //no estaba logeado
                        lIdAccesoUser = wsSesions.RegistraLogin(iIdUsuario, iNroMaquina, iPcAccede);



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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string lSucursal = ""; string lPar = "SG-295/1|15|Stgo|60";
            //Registry registry = new Registry();
            //lSucursal = (string)registry.GetValue(Program.regeditKeyName, "Sucursal", "");
            ////lPar = string.Concat(Lbl_Viajes.Text, "|", lIdObra, "|", lSucursal, "|", idDespacho);
            //Clases.ClsComun lLog = new Clases.ClsComun();
            //lLog.EjecutaShell(Application.StartupPath, lPar);
            Produccion.CargaEstadisticasMaq lfr = new Produccion.CargaEstadisticasMaq();
            lfr.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
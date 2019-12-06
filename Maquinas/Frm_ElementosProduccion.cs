using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary2;

namespace Metalurgica.Maquinas
{
    public partial class Frm_ElementosProduccion : Form
    {
        private string mIdUserReporta = "";
        private CurrentUser mUserLog_Frm = new CurrentUser();
        private string mIdAveriaSeleccionada = "";

        public Frm_ElementosProduccion()
        {
            InitializeComponent();
        }

        private void Frm_ElementosProduccion_Load(object sender, EventArgs e)
        {
            int i = 0;
            Dgt_elementos.Columns["Id"].Width = 60;
            Dgt_elementos.Columns["Elemento"].Width = 300;

            for (i = 0; i < Dgt_elementos.RowCount; i++)
            {
                Dgt_elementos.Rows[i].Height = 30;
            }
            Btn_Solucion.Enabled = false;
            button1.Enabled = false;

        }


        public void IniciaFormulario(string iIdUser, string iIdSucursal)
        {
            mIdUserReporta = iIdUser;
            WsOperacion.OperacionSoapClient lDal = new WsOperacion.OperacionSoapClient(); int i = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            //DataRow lFila = null;

            AppDomain.CurrentDomain.SetData("ElementoSel", null);
            AppDomain.CurrentDomain.SetData("IdAveria", "");
            AppDomain.CurrentDomain.SetData("IdUser", "");
            AppDomain.CurrentDomain.SetData("User", "");

            lTbl.Columns.Add("Id", Type.GetType("System.String"));
            lTbl.Columns.Add("Elemento", Type.GetType("System.String"));
            lTbl.Columns.Add("NroNotificaciones", Type.GetType("System.String"));

            lDts = lDal.ObtenerDatosIniciales("EP", iIdSucursal);

            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                //for (i = 0; i < lDts.Tables[0].Rows.Count; i++)
                //{
                //    lFila = lTbl.NewRow();
                //    lFila["Id"] = lDts.Tables[0].Rows[i]["Id"].ToString ();
                //    lFila["Elemento"] = lDts.Tables[0].Rows[i]["Par1"].ToString();

                //    lTbl.Rows.Add(lFila);
                //}
                Dgt_elementos.DataSource = lTbl;

            }

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro que Desea Salir?", "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Dgt_elementos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int lFila = e.RowIndex; int lNroNotificaciones = 0; Clases.ClsComun lDal = new Clases.ClsComun();
            if (lFila > -1)
            {
                Lbl_Seleccionado.Text = Dgt_elementos.Rows[lFila].Cells["Elemento"].Value.ToString();
                Lbl_Seleccionado.Tag = Dgt_elementos.Rows[lFila].Cells["Id"].Value.ToString();
                lNroNotificaciones = lDal.Val(Dgt_elementos.Rows[lFila].Cells["NroNotificaciones"].Value.ToString());
                if (lNroNotificaciones > 0)
                {
                    button1.Enabled = true;
                    Btn_Solucion.Enabled = true;
                }
                else
                {
                    button1.Enabled = true;
                    Btn_Solucion.Enabled = false;
                }
            }
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            if ((Lbl_Seleccionado.Text.Length > 3) && (Lbl_Seleccionado.Tag.ToString().Length > 0))
            {
                Clases.Obj.Obj_ElementoProd lObj = new Clases.Obj.Obj_ElementoProd();
                lObj.DescripcionElemento = Lbl_Seleccionado.Text;
                lObj.IdElemento = Lbl_Seleccionado.Tag.ToString();
                lObj.IdUserReporta = mIdUserReporta;
                AppDomain.CurrentDomain.SetData("ElementoSel", lObj);
                this.Close();
            }
            else
                MessageBox.Show("Debe Seleccionar un elemento de Producción, Revisar", "Avisis sistema");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Btn_Aceptar_Click(null, null);
        }

        private void Btn_Solucion_Click(object sender, EventArgs e)
        {
            //Debemos solitar Login y Verificar el Perfil
            Habilita_Deshabilida(false);
            //Pnl_Login.Visible = true;
            CargaDatosAverias(Lbl_Seleccionado.Tag.ToString(), mUserLog_Frm.PerfilUsuario, mUserLog_Frm.Login);
            Pnl_SeleccionAveria.Visible = true;


        }

        private void Habilita_Deshabilida(Boolean iHabilitado)
        {
            button1.Enabled = iHabilitado;
            Btn_Solucion.Enabled = iHabilitado;
            Btn_Salir.Enabled = iHabilitado;
            Dgt_elementos.Enabled = iHabilitado;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Registry registry = new Registry();
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
                    if (dt.Rows[0]["Vigente"].ToString().Equals("S"))
                    {

                        lPerfilUser = dt.Rows[0]["Perfil"].ToString();
                        mUserLog_Frm.Login = dt.Rows[0]["Usuario"].ToString();
                        mUserLog_Frm.Name = dt.Rows[0]["Nombre"].ToString() + " " + dt.Rows[0]["Apellidos"].ToString();
                        mUserLog_Frm.Iduser = dt.Rows[0]["Id"].ToString();
                        mUserLog_Frm.ComputerName = System.Environment.MachineName;
                        //Program.currentUser.DescripcionTotem = (string)registry.GetValue(Program.regeditKeyName, "Descrición", "");
                        //Program.currentUser.Machine = int.Parse(registry.GetValue(Program.regeditKeyName, "Maquina", "0").ToString());
                        //Program.currentUser.IdMaquina = Convert.ToInt16(new Registry().GetValue(Program.regeditKeyName, "IdMaquina", -1));
                        //Program.currentUser.IdTotem = Convert.ToInt16(new Registry().GetValue(Program.regeditKeyName, "IdTotem", -1));

                        //Program.currentUser.DescripcionMaq = ObtenerDescripcionMaquina(Program.currentUser.IdMaquina.ToString());

                        mUserLog_Frm.PerfilUsuario = dt.Rows[0]["Descperfil"].ToString();


               

                        PuedeIngresarReparacion(Lbl_Seleccionado.Tag.ToString(), mUserLog_Frm.PerfilUsuario, mUserLog_Frm.Login );

                        //CargaDatosAverias(Lbl_Seleccionado.Tag.ToString(), mUserLog_Frm.PerfilUsuario, mUserLog_Frm.Login);
                        //Pnl_SeleccionAveria.Visible = true;


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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Habilita_Deshabilida(true);
            Pnl_Login.Visible = false;
            button1.Enabled = false;
            Btn_Solucion.Enabled = false;
            txtClave.Text = "";
            txtUsuario.Text = "";

        }

        private void CargaObj_UsuarioActual(string iIdUser)
        {



        }


        private void CargaDatosAverias(string iIdElementoPro, string iPerfilUsuario, string iIdUserLog)
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = ""; string lMsg = "";

            lMsg = string.Concat(Lbl_Titulo.Text.Replace("|", Lbl_Seleccionado.Text.ToUpper()));
            Lbl_Titulo.Text = lMsg;
            Lbl_Usuario.Text = iIdUserLog;
            Lbl_Perfil.Text = iPerfilUsuario;
            //Verificamos el estado de la averia
            lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA 0,0,'','','',0,'',", iIdElementoPro, ",'',5 ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {

                Dtg_Averias.DataSource = lDts.Tables[0].Copy();
                Dtg_Averias.Columns["MAquina"].Visible = false;
                Dtg_Averias.Columns["Id"].Visible = false;
                Dtg_Averias.Columns["IdOperador"].Visible = false;
                Dtg_Averias.Columns["TipoMaquina"].Visible = false;
                Dtg_Averias.Columns["Mailenviado"].Visible = false;
                Dtg_Averias.Columns["IdUserCrea"].Visible = false;
                Dtg_Averias.Columns["Estado"].Visible = false;
                Dtg_Averias.Columns["IdMaquina"].Visible = false;
                Dtg_Averias.Columns["EstadoSupervisor"].Visible = false;
                Dtg_Averias.Columns["Usuario"].Width = 90;
                Dtg_Averias.Columns["IDNotificacion"].Width = 50;
                Dtg_Averias.Columns["EstadoMaq"].Width = 50;
                Dtg_Averias.Columns["TextoIncidencia"].Width = 150;

                Pnl_SeleccionAveria.Dock = DockStyle.Fill;
            }

        }


        private void PuedeIngresarReparacion(string iIdElemento, string iPerfilUsuario, string iIdUserLog)
        {

            // Si es cambio de Rollo No requiere validacion del perfil del mecanico.

            //if (mTipoAveria.Equals("AV"))
            //{
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = ""; string lPerfil = iPerfilUsuario; string lMsg = "";

            //Verificamos el estado de la averia
            lSql = string.Concat("exec  SP_CRUD_NOTIFICACION_AVERIA ", mIdAveriaSeleccionada ,",0,'','','',0,'',", iIdElemento, ",'',7 ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                if (lDts.Tables[0].Rows[0]["EstadoSup"].ToString().Equals("NOOK") && lDts.Tables[0].Rows[0]["EstadoMaq"].ToString().Equals("OP"))
                {
                    if (lPerfil.ToString().ToUpper().Equals("SUPERVISOR"))
                    {
                        
                        //*****************************************
                        Pnl_Login.Visible = false;
                        //CargaDatosAverias(iIdElemento, iPerfilUsuario, iIdUserLog);
                        Pnl_SeleccionAveria.Visible = true;

                        string lIdNotificacion = string.Concat(Lbl_IdNotificacion.Text);
                        AppDomain.CurrentDomain.SetData("IdAveria", lIdNotificacion);
                        AppDomain.CurrentDomain.SetData("IdUser", mUserLog_Frm.Iduser);
                        AppDomain.CurrentDomain.SetData("User", mUserLog_Frm.Login);
                        this.Close();
                        //******************************************+

                    }
                    else
                    {
                        lMsg = String.Concat(" Solamente los Usuarios con Perfil de SUPERVISOR puedes Ingresar las liberaciones de  reparaciones ", Environment.NewLine, " No esta autorizado realizar la liberación de Reparaciones ");
                        MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    if (lPerfil.ToString().ToUpper().Equals("MECANICO"))
                    {
                        //Se deben listar las Notificaciones que estan Abiertas, el debe seleccionar 
                        //cual desea solucionar, Se debe listar todas pero solo puede liberar las pendientes
                        Pnl_Login.Visible = false;
                        //CargaDatosAverias(iIdElemento, iPerfilUsuario, iIdUserLog);
                        Pnl_SeleccionAveria.Visible = true;

                        string lIdNotificacion = string.Concat(Lbl_IdNotificacion.Text);
                        AppDomain.CurrentDomain.SetData("IdAveria", lIdNotificacion);
                        AppDomain.CurrentDomain.SetData("IdUser", mUserLog_Frm.Iduser);
                        AppDomain.CurrentDomain.SetData("User", mUserLog_Frm.Login);
                        this.Close();

                    }
                    else
                    {
                        lMsg = String.Concat(" Solamente los Usuarios con Perfil de Mecanicos puedes Ingresar las reparaciones ", Environment.NewLine, " No esta autorizado a ingresar Reparaciones ");
                        MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
                    }
                    //}
                }
            }


        }

        private void Btn_SalirSelNot_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro que Desea Salir?", "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Pnl_SeleccionAveria.Visible = false;
                Habilita_Deshabilida(true);
                Pnl_Login.Visible = false;
                button1.Enabled = false;
                Btn_Solucion.Enabled = false;
                txtUsuario.Text = "";
                txtClave.Text = "";
            }
        }

        private void Btn_Reparacion_Click(object sender, EventArgs e)
        {
            //string lIdNotificacion = string.Concat ("R|",Lbl_IdNotificacion.Text);
            // Segun el estado de la Notificacion se debe solicitar Login
            //Debemos solitar Login y Verificar el Perfil
            Habilita_Deshabilida(false);
            Pnl_SeleccionAveria.Visible = false;
            Pnl_Login.Visible = true;

            //string lIdNotificacion = string.Concat( Lbl_IdNotificacion.Text);
            //AppDomain.CurrentDomain.SetData("IdAveria", lIdNotificacion);
            //AppDomain.CurrentDomain.SetData("IdUser", mUserLog_Frm .Iduser );
            //AppDomain.CurrentDomain.SetData("User", mUserLog_Frm.Login);
            //this.Close();

        }

        private void Dtg_Averias_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int lFila = e.RowIndex;   Clases.ClsComun lDal = new Clases.ClsComun();
            if (lFila > -1)
            {
                Lbl_IdNotificacion .Text = Dtg_Averias.Rows[lFila].Cells["IdNotificacion"].Value.ToString();
               lbl_Averia .Text = Dtg_Averias.Rows[lFila].Cells["TextoIncidencia"].Value.ToString();
                mIdAveriaSeleccionada = Lbl_IdNotificacion.Text;
            }
        }

        //else
        //{
        //    Maquinas.NotificaAveria lFrm = new Maquinas.NotificaAveria();
        //    lFrm.IniciaForm(mUserLog);
        //    lFrm.ShowDialog();
        //}


        //VerificaEstadoMaquina(mUserLog.IdMaquina.ToString());



    }
}

using CommonLibrary2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Bascula
{
    
    public partial class Frm_PesajeCamion : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        private int mIdPesajeCamion = 0;
        private int mToleranciaBascula = 0;
        private int mKilosCargadosCamion = 0;


        public Frm_PesajeCamion()
        {
            InitializeComponent();
        }

        private void Btn_ObtenerTara_Click(object sender, EventArgs e)
        {
            string lTara = ObtenerTara();
            this.Tx_Tara.Text = lTara;
            

        }

        public void IniciaForm( CurrentUser iUseActivo)
        {
            mUserLog = iUseActivo;
            this.Dtp_FechaActual.Value = DateTime.Now;
            this.Dtp_FechaActual.MaxDate = DateTime.Now;
            this.Dtp_FechaActual.MinDate = DateTime.Now .AddDays(-1);
            Rb_Tara.Checked = true;
            MuestraDatosSegunCheck();
            string lToleranciaBascula = ConfigurationManager.AppSettings["ToleranciaBascula"].ToString();

            if (lToleranciaBascula.Length > 0)
                mToleranciaBascula = int.Parse(lToleranciaBascula);

            Tx_ToleranciaBascula.Text = mToleranciaBascula.ToString();

        }


        #region Metodos privados de la clase

        private string ObtenerPesoBruto()
        {
            string lRes = "0"; string lSql = ""; Clases.SqlBascula lTipoSql = new Clases.SqlBascula();
            DataTable lTbl = new DataTable(); Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = DateTime.Now.ToShortDateString(); int lPesoTara = int.Parse(Tx_Tara.Text);

            lTbl = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlPesoBruto(Cmb_Patente .SelectedValue .ToString (), lFecha, lPesoTara));

            if (lTbl.Rows.Count > 0)
            {
                lRes = lTbl.Rows[0]["PesoBruto"].ToString();

            }
            return lRes;
        }


        private string ObtenerTara()
        {
            string lRes = "";string lSql = ""; Clases.SqlBascula lTipoSql=new Clases.SqlBascula ();
            DataTable lTbl = new DataTable();Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = Dtp_FechaActual.Value.ToShortDateString();  //DateTime.Now.ToShortDateString();

            if (Tx_Patente.Text.Length == 0)
            {
                MessageBox.Show("Debe Ingresar una Patente para poder Obtener la Tara, revisar. . . ", "Validaciones Sistema", MessageBoxButtons.OK);
            }
            else
            {
                lSql = lTipoSql.ObtenerSqlTara(Tx_Patente.Text, lFecha);
                Tx_sql.Text = lSql;
                lTbl = lDAL.CargaTablaRomana(lSql);

                if (lTbl.Rows.Count > 0)
                {
                    lRes = lTbl.Rows[0]["PesoBruto"].ToString();

                }
            }
            return lRes;
        }

        private string ObtenerPesoCargaCamion(string iPatente)
        {
            string lres = "0";



            return lres;

        }

        private void MuestraDatosSegunCheck()
        {
            if (Rb_Tara.Checked == true)
            {
                Cmb_Patente.Visible = false;
                Btn_ObtenerTara.Enabled = true;
            }

            if (Rb_Carga .Checked == true)
            {
                //cargamos el desplegable con los datos de las patentes con camion cargado
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet();DataTable lTbl = new DataTable();
                DataRow lFila = null;

                lLIstaDts = wsOperacion.ObtenerPatentesParaCalculoCarga();
                if (lLIstaDts.DataSet.Tables.Count > 0)
                {
                    lTbl = lLIstaDts.DataSet.Tables[0].Copy();
                    lFila = lTbl.NewRow();
                    lFila["patente"] = "Seleccionar";
                    lTbl.Rows.Add(lFila);
                    new Forms().comboBoxFill(Cmb_Patente, lTbl, "patente", "patente", 0);
                    Cmb_Patente.SelectedText = "Seleccionar";
                }
         
                Cmb_Patente.Visible = true;
                Btn_ObtenerTara.Enabled = false;             
            }


        }
        private String GrabarDatos()
        {
                WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
                WsOperacion.PesajeCamion lObjCam = new WsOperacion.PesajeCamion();
            if (Rb_Tara.Checked == true)
            {
                
                lObjCam.Id = 0;
                lObjCam.Patente = Tx_Patente.Text;
                lObjCam.PesoTara = int.Parse(Tx_Tara.Text);
                lObjCam.FechaTara = DateTime.Now.ToString();
                lObjCam.IdUserTara = int.Parse(mUserLog.Iduser);
                lObjCam.PesoBruto = 0;
                lObjCam.IdDespachoCam = 0;
                lObjCam.Estado = "PesoTara";
                lObjCam = wsOperacion.GrabarDatosPesajeCamion(lObjCam);
                if (lObjCam.Id > 0)
                {
                    MessageBox.Show("Los Datos han sido Grabados Correctamente ", "Avisos Sistema", MessageBoxButtons.OK);
                }
            }

            if (Rb_Carga.Checked == true)
            {
                lObjCam.Id = mIdPesajeCamion ;
                lObjCam.Patente = Cmb_Patente .SelectedValue .ToString ();
                lObjCam.PesoTara = int.Parse(Tx_Tara.Text);
                lObjCam.PesoBruto = int.Parse(Tx_Bruto.Text); ;
                lObjCam.IdUserPesoBruto = int.Parse(mUserLog.Iduser);
                lObjCam.Estado = "PesoCarga";
                lObjCam = wsOperacion.GrabarDatosPesajeCamion(lObjCam);
                if (lObjCam.Id > 0)
                {
                    MessageBox.Show("Los Datos han sido Grabados Correctamente ", "Avisos Sistema", MessageBoxButtons.OK);
                }

            }


            return "";
        }


        #endregion

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            GrabarDatos();
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_PesajeCamion_Load(object sender, EventArgs e)
        {

        }

        private void Rb_Tara_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Tara.Checked == true)
            {
                MuestraDatosSegunCheck();
            }
        }

        private void Rb_Carga_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Carga.Checked == true)
            {
                MuestraDatosSegunCheck();
            }
        }

        private void Cmb_Patente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Cmb_Patente.SelectedValue!=null ) && (Cmb_Patente .SelectedValue.ToString ()!="Seleccionar" ))
                {
                CargaDatosPesoTaraPorPatente(Cmb_Patente.SelectedValue.ToString ());
            }
        }

        private void CargaDatosPesoTaraPorPatente(string iPatente)
        {
            WsOperacion.OperacionSoapClient wsOperacion = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();

            lLIstaDts = wsOperacion.ObtenerPesoTaraPorPatente(iPatente);
            if (lLIstaDts.DataSet.Tables.Count > 0)
            {
                lTbl = lLIstaDts.DataSet.Tables[0].Copy();
                if (lTbl.Rows.Count > 0)
                {
                    Tx_Tara.Text = lTbl.Rows[0]["PesoTara"].ToString();
                    mIdPesajeCamion = int.Parse(lTbl.Rows[0]["IdPesajeCamion"].ToString());
                    mKilosCargadosCamion= int.Parse (lTbl.Rows[0]["KgsCargados"].ToString());
                    Tx_Tara.ReadOnly = true;
                }
            }



        }

        private void Btn_PesoBruto_Click(object sender, EventArgs e)
        {
            int lDiferencia = 0;Double lToleranciaReal = 0;
            //ObtenerPesoBruto
            int lPesoBruto = int.Parse(ObtenerPesoBruto());
            int lPesoTara = int.Parse(Tx_Tara.Text);
            this.Tx_Bruto.Text = lPesoBruto.ToString();
            this.Tx_Carga.Text = (lPesoBruto - lPesoTara).ToString();
            lDiferencia = Math.Abs (mKilosCargadosCamion - int.Parse (Tx_Carga.Text));
            Tx_DiferenciaKilos.Text = lDiferencia.ToString();
            if (lDiferencia > 0)
            {
                lToleranciaReal = (double.Parse (lDiferencia.ToString ()) / double.Parse (mKilosCargadosCamion.ToString ())) * 100;
                Tx_ToleranciaReal.Text = Math.Round (lToleranciaReal,2).ToString();
                Tx_KgsCargados.Text = mKilosCargadosCamion.ToString();
                if (lToleranciaReal > Double .Parse(Tx_ToleranciaBascula.Text))
                {
                    Tx_Semaforo.BackColor = Color.Red;
                } else
                    Tx_Semaforo.BackColor = Color.Green ;


            }

            Tx_Carga.ReadOnly = true;

        }
    }
}

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
    public partial class Frm_AutorizaDespacho : Form
    {
        private Boolean DatosGrabados = false;
        public Frm_AutorizaDespacho()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        public void IniciaFormulario(WsOperacion.PesajeCamion iObj, string iPesoGD, string iTolerancia, string iFecha)
        {
            
            Clases.ClsComun lCom = new Clases.ClsComun();
            int PesoAdicional = lCom.Val(iObj.KgsCuartones.ToString()) + lCom.Val(iObj.KgsEstrobos.ToString());
            int lPesoBascula = iObj.PesoBruto - iObj.PesoTara;
            int lPesoNeto = lCom.Val(iObj.PesoBruto.ToString()) + lCom.Val(iObj.PesoTara.ToString());


            Tx_Patente.Text = iObj.Patente.ToString();
            Tx_PesoBruto.Text = iObj.PesoBruto.ToString ();
            Tx_PesoNeto.Text = iObj.PesoTara .ToString();
            Tx_PesoAdicional .Text = PesoAdicional.ToString ();

            Tx_PesoSoloFE.Text = (lPesoBascula - PesoAdicional).ToString ();
            Tx_PesoGD .Text = iPesoGD;
            Tx_Dif.Text = (lPesoBascula - lCom.Val (iPesoGD)).ToString ();

            Tx_Tolerancia.Text = iTolerancia;
            Tx_fecha.Text = iFecha;


            WsOperacion.OperacionSoapClient lWs = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lDts = new WsOperacion.ListaDataSet();
            DataTable lTbl = new DataTable(); DataRow lFila = null;
            string lCodSucursal = ConfigurationManager.AppSettings["IdSucursal"].ToString();

            lDts = lWs.ObtenerSupervisoresPorsucursal(lCodSucursal);
            if ((lDts.DataSet.Tables.Count > 0) && (lDts.DataSet.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.DataSet.Tables[0].Copy();
                lFila = lTbl.NewRow();
                lFila["par1"] = "Seleccionar";
                lTbl.Rows.Add(lFila);
                new Forms().comboBoxFill(Cmb_Supervisor, lTbl, "par1", "par1", 0);
                Cmb_Supervisor.SelectedIndex = lTbl.Rows.Count - 1;
                // Cmb_Supervisor.SelectedText = "Seleccionar";
            }


        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            string lMsg = "";
            if (DatosGrabados == false)
            {
                lMsg = string.Concat(" No se han Grabado los datos .");
                lMsg = string.Concat(lMsg, Environment.NewLine, " ¿Esta seguro que desea Salir?" );
                if (MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            Grabar();
       }

        private Boolean ValidarUsuario(string iUser, string iPass)
        {
            WsOperacion.OperacionSoapClient lWs = new WsOperacion.OperacionSoapClient();
            return lWs.ValidaUsuario(iUser, iPass);
        }

        private void Grabar()

        {
            Boolean lPuedeGrabar = true;
            string lMsg = "";string lUserAutoriza = "";
            if (Tx_Clave .Text .Trim ().Length ==0)
            {
                lMsg = " Debe ingresar  una clave valida para poder grabar";
                lPuedeGrabar = false;
            }
            if (Tx_Obs.Text.Trim().Length < 5)
            {
                lMsg = " Debe ingresar  una Observación de minimo 5 caracteres,  para poder grabar";
                lPuedeGrabar = false;
            }

            if (Cmb_Supervisor.SelectedValue.ToString () == "Seleccionar")
            {
                lMsg = string .Concat (lMsg ,Environment .NewLine ," Debe ingresar  una clave valida para poder grabar");
                lPuedeGrabar = false;
            }

            if (lPuedeGrabar == true)
            {
                if (ValidarUsuario(Cmb_Supervisor.SelectedValue.ToString(), Tx_Clave.Text) == true)
                {
                    DatosGrabados = true;
                    lUserAutoriza = Cmb_Supervisor.SelectedValue.ToString();
                    AppDomain.CurrentDomain.SetData("UserAutoriza", lUserAutoriza);
                    AppDomain.CurrentDomain.SetData("ObsUserAutoriza", Tx_Obs.Text);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("La clave ingresada NO es correcta", "Avisos Sistema", MessageBoxButtons.OK);
                }
               

            }
            else
            {
                MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
            }

            
        }

        private void Frm_AutorizaDespacho_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Grabar_Click_1(object sender, EventArgs e)
        {
            Grabar();
        }

        private void Btn_salir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

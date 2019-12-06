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
    public partial class Frm_CargaBasculaMovil : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        private int mPesoMaxBascula = 0;
        private string mUnidadMedidaBascula = "";
        private DataTable mTblDatos = new DataTable();
        private DataTable mTblDatosOK = new DataTable();
        private  double  mTotalKgs = 0;
        public Frm_CargaBasculaMovil()
        {
            InitializeComponent();
        }

        private void Frm_CargaBasculaMovil_Load(object sender, EventArgs e)
        {
            mTotalKgs = 0;
            Tx_idPaq.Focus();
        }

       

        public  void IniciaForm( DataTable lTbl, CurrentUser iUserLog)
        {
            int i = 0;

            mUserLog = iUserLog;
         
            WsOperacion.OperacionSoapClient PxOperacion = new WsOperacion.OperacionSoapClient();
            Clases.ClsComun lCom = new Clases.ClsComun();
            string lKgsMaxBascula = "";
              mTblDatos = lTbl.Copy ();

            mTblDatos.Columns.Add("PesoConectores", Type.GetType("System.String"));

            for (i = 0; i < lTbl.Rows.Count; i++)
            {
                mTblDatos.Rows[i]["PesoConectores"] = lCom.ObtenerPesoConectores(mTblDatos.Rows[i]["ETIQUETA_PIEZA"].ToString());
            }
          
            mTblDatosOK = mTblDatos.Copy();
            mTblDatosOK.Clear();
            //Debemos OBtener los Parametros 
            //1.- Peso Maximo Bascula Movil
            lKgsMaxBascula = PxOperacion.ObtenerPesoMaxBasculaMovil ();
            string[] split = lKgsMaxBascula.ToString().Split(new Char[] { '|' });
            if (split.Length > 1)
            {
                 mPesoMaxBascula = lCom .Val (split [0].ToString ());
                 mUnidadMedidaBascula = split[1].ToString();
                Lbl_Msg.Text = string.Concat(" El peso máximo a cargar en Báscula Móvil es de: ", mPesoMaxBascula, " ", mUnidadMedidaBascula);
            }
            Lbl_Usuario .Text = string.Concat("Usuario Responsable: ", mUserLog .Name  );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("EtiquetasOK", "");
            AppDomain.CurrentDomain.SetData("Volver", "N");
            this.Close();
        }

        private void Tx_idPaq_Validating(object sender, CancelEventArgs e)
        {
            if (Tx_idPaq.Text.Trim().Length > 0)
            {
                ProcesaEtiqueta(Tx_idPaq.Text);
                Tx_idPaq.Text = "";
                Tx_idPaq.Focus();
            }
        }

        private void ProcesaEtiqueta(string iIdOaq)
        {
          Clases.ClsComun lCom = new Clases.ClsComun(); int i = 0;DataRow lFila = null;
            try
            {
                //Revisamos que no este ya Registrada
                DataView lVista = new DataView(mTblDatosOK, String.Concat("Etiqueta_Pieza=", iIdOaq), "", DataViewRowState.CurrentRows);
                if (lVista.Count == 0)
                {
                    lVista = new DataView(mTblDatos, String.Concat("Etiqueta_Pieza=", iIdOaq), "", DataViewRowState.CurrentRows);
                    if (lVista.Count > 0)
                    {
                        lFila = mTblDatosOK.NewRow();
                        for (i = 0; i < mTblDatos.Columns.Count; i++)
                        {
                            lFila[i] = lVista[0][i];
                        }


                        if (mTotalKgs + (lCom .CDBL (lVista[0]["KgsReales"].ToString())) > mPesoMaxBascula)
                        {
                            MessageBox.Show(" EL Peso máximo a Cargar en la Bascula Móvil es de: " + mPesoMaxBascula.ToString(), "Avisos Sistema ", MessageBoxButtons.OK);
                        }
                        else
                        {
                            mTblDatosOK.Rows.Add(lFila);
                            Lbl_KgsCD.Text =lCom.CDBL (lVista[0]["KgsReales"].ToString()).ToString();
                            Lbl_KgsCon .Text =lCom .CDBL(lVista[0]["PesoConectores"].ToString() ).ToString ();

                            mTotalKgs = mTotalKgs + (lCom.CDBL(lVista[0]["KgsReales"].ToString())) + (lCom.CDBL (lVista[0]["PesoConectores"].ToString()));
                            Lbl_totalKgs.Text = mTotalKgs.ToString();
                            Dtg_OK.DataSource = mTblDatosOK;
                            FormateaGrilla();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido el Siguiente error: " + ex.Message.ToString());
            }

        }

        private void FormateaGrilla()
        {
            int i = 0;
            Dtg_OK.Columns["IdViaje"].Visible = false;
            Dtg_OK.Columns["IdViaje2"].Visible = false;
            Dtg_OK.Columns["Id"].Visible = false;
            Dtg_OK.Columns["TotalKgs"].Visible = false;
            Dtg_OK.Columns["NroLaminas"].Visible = false;
            Dtg_OK.Columns["Estado"].Visible = false;
            Dtg_OK.Columns["UserCrea"].Visible = false;
            Dtg_OK.Columns["NroDespacho"].Visible = false;
            Dtg_OK.Columns["FechaViaje"].Visible = false;
            Dtg_OK.Columns["Obs"].Visible = false;
            Dtg_OK.Columns["IdIt"].Visible = false;
            Dtg_OK.Columns["FechaMod"].Visible = false;
            Dtg_OK.Columns["PesoRomana"].Visible = false;
            Dtg_OK.Columns["Patente"].Visible = false;
            Dtg_OK.Columns["IdDespachoCamion"].Visible = false;
            Dtg_OK.Columns["NroGuiaINET"].Visible = false;
            Dtg_OK.Columns["IdRespuestaINET"].Visible = false;
            Dtg_OK.Columns["Id1"].Visible = false;
            Dtg_OK.Columns["IdPieza"].Visible = false;
            Dtg_OK.Columns["IdMov"].Visible = false;
            Dtg_OK.Columns["NroPaq"].Visible = false;
            Dtg_OK.Columns["TotalPaq"].Visible = false;
            Dtg_OK.Columns["Estado1"].Visible = false;
            Dtg_OK.Columns["FechaRegistro"].Visible = false;
            Dtg_OK.Columns["IDViaje1"].Visible = false;
            Dtg_OK.Columns["KgsPaquete1"].Visible = false;
            Dtg_OK.Columns["Etiqueta_Colada"].Visible = false;
            Dtg_OK.Columns["FechaCreacion"].Visible = false;
            Dtg_OK.Columns["Codigo"].Width = 120;
            Dtg_OK.Columns["KgsPaquete"].Width = 150;
            Dtg_OK.Columns["NroPiezas"].Width = 120;
            Dtg_OK.Columns["KgsReales"].Width = 130;
            Dtg_OK.Columns["Estado2"].Width = 120;
            Dtg_OK.Columns["Diametro"].Width = 120;
            Dtg_OK.Columns["Imagen"].Width = 180;
            Dtg_OK.Columns["Etiqueta"].Width = 200;
            Dtg_OK.Columns["Etiqueta_Pieza"].Width = 200;
            for (i = 0; i < Dtg_OK.Rows .Count-1; i++)
            {
                Dtg_OK.Rows[i].Height = 90;
            }

            Font lFuente = new Font("Arial", 15);
            Font lFuente18 = new Font("Arial", 18);

            Dtg_OK.Rows[1].Cells[1].Style.Font = lFuente;
            Dtg_OK.Rows[1].Cells[2].Style.Font = lFuente;

            Dtg_OK.Font = new Font("Arial", 17, FontStyle.Regular);

        }

        private void Tx_idPaq_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                this.Tx_idPaq_Validating(null, null);
            }
        }

        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            LimpiaFormulario();
        }

        private void LimpiaFormulario()
        {
            mTblDatosOK.Clear();
            Lbl_totalKgs.Text = "0";
            Tx_idPaq.Focus();
            mTotalKgs = 0;

        }

        private void Btn_NO_OK_Click(object sender, EventArgs e)
        {
            int i = 0; string lEtiquetasOK = ""; Clases.ClsComun lCom = new Clases.ClsComun();
            try
            {

                for (i = 0; i < Dtg_OK.Rows.Count - 1; i++)
                {
                    if (lCom.EsNumero(Dtg_OK.Rows[i].Cells["Etiqueta_pieza"].Value.ToString()) == true)
                    {
                        lEtiquetasOK = string.Concat(lEtiquetasOK, Dtg_OK.Rows[i].Cells["Etiqueta_pieza"].Value.ToString(), "|");
                        RegistraEtiquetas(lEtiquetasOK, "NOOK");
                    }
                }
                LimpiaFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido el siguiente error: " + ex.Message.ToString());

            }

         
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            int i = 0; string lEtiquetasOK = "";Clases.ClsComun lCom = new Clases.ClsComun();
            try
            {

                for (i = 0; i < Dtg_OK.Rows.Count-1; i++)
                {
                    if (lCom.EsNumero(Dtg_OK.Rows[i].Cells["Etiqueta_pieza"].Value.ToString()) == true)
                    {
                        lEtiquetasOK = string.Concat(lEtiquetasOK, Dtg_OK.Rows[i].Cells["Etiqueta_pieza"].Value.ToString(), "|");
                        
                    }
                }
                if (lEtiquetasOK.Length > 0)
                {
                    RegistraEtiquetas(lEtiquetasOK, "OK");
                    AppDomain.CurrentDomain.SetData("EtiquetasOK", lEtiquetasOK);
                    AppDomain.CurrentDomain.SetData("Volver", "S");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido el siguiente error: " + ex.Message.ToString());

            }

        }

        private void RegistraEtiquetas(string iEtiquetas, string iEstado)
        {
            WsOperacion.OperacionSoapClient wsOp = new WsOperacion.OperacionSoapClient();
            WsOperacion.TipoBasculaMovil[] lLista = null;// new WsOperacion.TipoBasculaMovil[];
            //List<WsOperacion.TipoBasculaMovil> lLista = new List<WsOperacion.TipoBasculaMovil>() ;
            WsOperacion.TipoBasculaMovil lBM = null; // new WsOperacion.TipoBasculaMovil(); 
            Clases.ClsComun lCom = new Clases.ClsComun();

            string[] split = iEtiquetas.ToString().Split(new Char[] { '|' });
            int i = 0;
            try
            {
                lLista =   new WsOperacion.TipoBasculaMovil[split.Length];
                for (i=0; i<split.Length;i++   )
            {
                if (lCom.Val(split[i]) > 0)
                {
                        //mUserLog
                    lBM = new WsOperacion.TipoBasculaMovil();
                    lBM.Id = 0;
                    lBM.Estado = iEstado; // "OK";
                    lBM.IdPaquete = lCom.Val(split[i]);
                    lBM.IdSucursal = ObtenerIdSucursal();
                    lBM.IdTotem = mUserLog.IdTotem;
                    lBM.IdUsuario = lCom.Val(mUserLog.Iduser) ;
                    lBM.Turno = ObtenerTurno();

                    lLista[i] = lBM;
                    lLista = wsOp.PersistePesajeBM(lLista);
                    }
                  
                }
             


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido el siguiente error: " + ex.Message.ToString());
            }
        }


        private int ObtenerIdSucursal()
        {
            int lIdSucursal = 0;Clases.ClsComun lCom = new Clases.ClsComun();
            string lTmp = ConfigurationManager.AppSettings["IdSucursal"].ToString();

            lIdSucursal = lCom.Val(lTmp);
            return lIdSucursal;
        }

        private string  ObtenerTurno()
        {
            int lHora = 0;  string lTurno = "";
            lHora = DateTime.Now.Hour;

            if ((lHora > 7) && (lHora < 20))
                lTurno = "Dia";
            else
                lTurno = "Noche";

            return lTurno;
        }

        private void Frm_CargaBasculaMovil_Activated(object sender, EventArgs e)
        {
            Tx_idPaq.Focus();
        }

        private void Tx_idPaq_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Bascula
{
    public partial class Frm_CargaBasculaMovil : Form
    {
        private DataTable mTblDatos = new DataTable();
        private DataTable mTblDatosOK = new DataTable();
        private  int mTotalKgs = 0;
        public Frm_CargaBasculaMovil()
        {
            InitializeComponent();
        }

        private void Frm_CargaBasculaMovil_Load(object sender, EventArgs e)
        {
            mTotalKgs = 0;
            Tx_idPaq.Focus();
        }

        public  void IniciaForm( DataTable lTbl )
        {
            mTblDatos = lTbl;

            mTblDatosOK = mTblDatos.Copy();
            mTblDatosOK.Clear();

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
                    mTblDatosOK.Rows.Add(lFila);
                    mTotalKgs = mTotalKgs + (int.Parse(lVista[0]["KgsReales"].ToString()));
                    Lbl_totalKgs.Text = mTotalKgs.ToString();
                    Dtg_OK.DataSource = mTblDatosOK;
                    FormateaGrilla();
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
            Dtg_OK.Columns["Codigo"].Width = 70;
            Dtg_OK.Columns["KgsPaquete"].Width = 70;
            Dtg_OK.Columns["NroPiezas"].Width = 70;
            Dtg_OK.Columns["KgsReales"].Width = 70;
            Dtg_OK.Columns["Estado2"].Width = 70;
            Dtg_OK.Columns["Diametro"].Width = 70;
            Dtg_OK.Columns["Imagen"].Width = 150;
            for (i = 0; i < Dtg_OK.Rows .Count-1; i++)
            {
                Dtg_OK.Rows[i].Height = 80;
            }

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
            LimpiaFormulario();
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

        private void Frm_CargaBasculaMovil_Activated(object sender, EventArgs e)
        {
            Tx_idPaq.Focus();
        }
    }
}

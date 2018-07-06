using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica
{
    public partial class Frm_ResumenDespacho : Form
    {

        private string mViajesSel = "";
        private string mOtrasObs = "";
        private int  mKilosPorCargar = 0;
        private int  mKilosCargados = 0;
        private int mPaqPorCargar = 0;
        private int mPaqCargados = 0;
        private int mNroPaqOk = 0;
        private int mNroPaqOtrosViajes = 0;


        public Frm_ResumenDespacho()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void MuestraOtrosErrores(string iOtrosERR )
        {
            bool lRes = false;
            char[] delimiterChars = { '|', '\t' };
            char[] delimiterChars2 = { '-', '\t' };
            int i = 0; string lMsg = ""; string lEstado = "";
            string[] words = iOtrosERR.Split(delimiterChars);
            for (i = 0; i < words.Length; i++)
            {
                if (words[i].ToString().Trim().Length >0)
                    {
                        string[] SubWords = words[i].ToString().Split(delimiterChars2);
                        if (SubWords.Length >0 )
                            {
                                if (SubWords[1].ToUpper().Equals("PNE"))
                                    lEstado = "Paquete No Existe ";

                                if (SubWords[1].ToUpper().Equals("EWS"))
                                    lEstado = "Error en acceso a datos ";

                                    lMsg = string.Concat(lMsg, " Se pistoleo el Paquete: ", SubWords[0], " pero ", lEstado ,"  -  ");
                            }
                    }
                Tx_OtrasObs.Text = lMsg;
            }

        }

        public void IniciaForm(string iViajesSel, string iOtrasObs, string iKilosPorCargar, string iKilosCargados, string iPaqPorCargar, string iPaqCargados, DataTable iTblDatos)
        {
            int Diferencia = 0;
            try
            {
                Tx_viajes.Text = iViajesSel;
                MuestraOtrosErrores(iOtrasObs);
                //Tx_OtrasObs.Text  = iOtrasObs;
                Tx_KgsPorCargar.Text = iKilosPorCargar.ToString();
                Tx_KgsCargados.Text = iKilosCargados.ToString();
                Tx_PaqPorCargar.Text = iPaqPorCargar.ToString();
                Tx_PaqCargados.Text = iPaqCargados.ToString();
                Tx_PaqOk.Text = "0";
                Tx_PaqOk.Text = "0";

                Diferencia = int.Parse(iKilosPorCargar) - int.Parse(iKilosCargados);
                Tx_difKgs.Text = Diferencia.ToString();

                Diferencia = int.Parse(iPaqPorCargar) - int.Parse(iPaqCargados);
                Tx_DifPaq.Text = Diferencia.ToString();


                if (iTblDatos != null)
                {
                    DataView lVistaPaqOK = new DataView(iTblDatos, "Estado1='POK'", "", DataViewRowState.CurrentRows);
                    Tx_PaqOk.Text = lVistaPaqOK.Count.ToString();
                    DataView lVistaPaqOtrosViajes = new DataView(iTblDatos, "Estado1='PNV'", "", DataViewRowState.CurrentRows);
                    Tx_paqOtrosViajes.Text = lVistaPaqOtrosViajes.Count.ToString();
                    dgvEtiquetasPiezas.DataSource = iTblDatos;
                    OcultaColumnas();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //
        }

        private void OcultaColumnas()
        {
            dgvEtiquetasPiezas.Columns["IdViaje2"].Visible = false;
            dgvEtiquetasPiezas.Columns["Id"].Visible = false;
            dgvEtiquetasPiezas.Columns["TotalKgs"].Visible = false;
            dgvEtiquetasPiezas.Columns["NroLaminas"].Visible = false;
            dgvEtiquetasPiezas.Columns["NroDespacho"].Visible = false;
            dgvEtiquetasPiezas.Columns["FechaViaje"].Visible = false;
            dgvEtiquetasPiezas.Columns["IdIt"].Visible = false;
            dgvEtiquetasPiezas.Columns["Id1"].Visible = false;
            dgvEtiquetasPiezas.Columns["IdViaje1"].Visible = false;
            dgvEtiquetasPiezas.Columns["FechaRegistro"].Visible = false;
            dgvEtiquetasPiezas.Columns["FechaMod"].Visible = false;
            dgvEtiquetasPiezas.Columns["UserCrea"].Visible = false;

        }

        private void PintaFila(int IndexFila, Color iColorFila)
        {
            int i = 0;
            for (i = 0; i < dgvEtiquetasPiezas.ColumnCount; i++)
            {
                dgvEtiquetasPiezas.Rows[IndexFila].Cells[i].Style.BackColor = iColorFila;

            }
        }

        private void ActualizaColoresGrilla()
        {
            int i = 0;
            for (i = 0; i < dgvEtiquetasPiezas.RowCount; i++)
            {
                switch (dgvEtiquetasPiezas.Rows[i].Cells["Estado1"].Value.ToString().Trim().ToUpper())
                {
                    case "PNV":  //Pieza no es del viaje
                        PintaFila(i, Color.LightSalmon);
                        //' Dtg_Resultado.Rows[i].Cells["Codigo"].Style.BackColor = Color.LightSalmon;
                        break;
                    case "POK":  //Pieza OK
                        PintaFila(i, Color.LightGreen);
                        //Dtg_Resultado.Rows[i].Cells["Codigo"].Style.BackColor = Color.LightGreen;
                        break;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Frm_ResumenDespacho_Load(object sender, EventArgs e)
        {
            ActualizaColoresGrilla();
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("Opcion", "A");
            this.Close();
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("Opcion", "C");
            this.Close();
        }
    }
}

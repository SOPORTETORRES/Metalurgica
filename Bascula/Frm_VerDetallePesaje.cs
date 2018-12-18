using CommonLibrary2;
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
    public partial class Frm_VerDetallePesaje : Form
    {
        private string mIdPesajeCamion = "0";
        private string mPatente = "0";
        private string mTara = "0";
        private string mBruto = "0";
        private string mBascula = "0";
        private double   mKgsReal = 0;
        private double mKgsDesarrollo = 0;

        public Frm_VerDetallePesaje()
        {
            InitializeComponent();
        }

        private void Frm_VerDetallePesaje_Load(object sender, EventArgs e)
        {
            PintaGrilla();
        }

        public  void CargaDatos(string iIdPesajeCam, string iPatente, string iTara, string iBruto, string iBas)
        {
            WsOperacion.OperacionSoapClient lPxOper = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet(); DataTable lTbl = new DataTable();
            int i = 0; DataTable lTblViajes = new DataTable(); int lTotalKgs = 0; Clases.ClsComun lCom = new Clases.ClsComun();
            lLIstaDts = lPxOper.ObtenerDetallePesaje(iIdPesajeCam);
            mIdPesajeCamion = iIdPesajeCam;
            mPatente = iPatente;
            mTara = iTara;
            mBruto = iBruto;
            mBascula = iBas;
            mKgsReal = 0;
            mKgsDesarrollo = 0;

            if (lLIstaDts.MensajeError.Trim().Length == 0)
            {
                if ((lLIstaDts.DataSet.Tables.Count > 0) && (lLIstaDts.DataSet.Tables[0].Rows.Count > 0))
                {
                    lTbl = lLIstaDts.DataSet.Tables["DetallePesaje"].Copy();
                    dataGridView1.DataSource = lTbl;
                    for (i = 0; i < lTbl.Rows.Count; i++)
                    {
                        mKgsReal = mKgsReal + lCom.CDBL (lTbl.Rows[i]["KgsPaquete"].ToString());
                        mKgsDesarrollo = mKgsDesarrollo + lCom.CDBL(lTbl.Rows[i]["KgsReales"].ToString());
                    }
                    Lbl_KgsGD.Text = lTotalKgs.ToString();
                    lTblViajes = lLIstaDts.DataSet.Tables["Viajes"].Copy();
                    new Forms().comboBoxFill(Cmb_Viajes, lTblViajes, "Codigo", "Codigo", 0);
                    //Cmb_Viajes.SelectedValue = "Codigo";
                    //Cmb_Viajes.DisplayMember  = "Codigo";

                    dataGridView1.Columns["Id"].Width = 80;
                    dataGridView1.Columns["Codigo"].Width = 80;
                    dataGridView1.Columns["Etiqueta"].Width = 100;

                    dataGridView1.Columns["KgsPaquete"].Width = 80;
                    dataGridView1.Columns["KgsReales"].Width = 80;
                    dataGridView1.Columns["FechaCarga"].Width = 100;


                }
            }
            CalculaDatos();
            PintaGrilla();
        }

        private void CalculaDatos()
        {
            double lTol = 0; double  lDifReal = 0;Clases.ClsComun lCom = new Clases.ClsComun(); double lDifDesa = 0;
            double lTolDesa = 0;
            Lbl_Bascula.Text = mBascula;
            Lbl_bruto.Text = mBruto;
            Lbl_patente.Text = mPatente;
            Lbl_Tara.Text  = mTara;
            lDifReal = lCom.Val(mBascula) -  mKgsReal ;
            lTol = (lDifReal /lCom.CDBL ( mBascula) * 100) ;
            lbl_TolReal.Text = Math.Round(lTol, 2).ToString ();
            Lbl_KgsGD.Text = Math.Round(mKgsReal,2).ToString ();

            lDifDesa = lCom.Val(mBascula) - mKgsDesarrollo ;
            lTolDesa= lDifDesa / lCom.CDBL(mBascula) * 100 ;
            Lbl_TolDesa.Text = Math.Round(lTolDesa, 2).ToString();
            Lbl_IdPesajeCam.Text = mIdPesajeCamion.ToString();
        }

        private void PintaGrilla()
        {
            int i = 0; int k = 0;
            try
            {
                for (i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    if ((dataGridView1.Rows[i].Cells["EsVaPero_NoVa"].Value != null))
                    {
                        if (dataGridView1.Rows[i].Cells["EsVaPero_NoVa"].Value.ToString().ToUpper().Equals("S"))
                        {
                            for (k = 0; k < dataGridView1.Columns.Count; k++)
                            {
                                dataGridView1.Rows[i].Cells[k].Style.BackColor = Color.LightSalmon;
                            }
                        }
                        else
                        {
                            for (k = 0; k < dataGridView1.Columns.Count; k++)
                            {
                                dataGridView1.Rows[i].Cells[k].Style.BackColor = Color.LightGreen;
                            }
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Concat("Se ha producido el Siguiente Error: ", ex.Message.ToString()), "Avisos Sistema", MessageBoxButtons.OK);
            }
        }

        private void SacarIT()
        {
            WsOperacion.OperacionSoapClient lPxOper = new WsOperacion.OperacionSoapClient();
            WsOperacion.ListaDataSet lLIstaDts = new WsOperacion.ListaDataSet();
            Clases.ClsComun lCom = new Clases.ClsComun(); DataTable lTbl = new DataTable();
            string lTx = "";


            if (Cmb_Viajes.SelectedValue != null)
            {
                lTx = string.Concat(" ¿ Esta seguro que desea Sacar la IT ", Cmb_Viajes.SelectedValue.ToString(), " del camión?");
                if (MessageBox.Show(lTx, "Avisos Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //SacarITDespacho'
                    lLIstaDts = lPxOper.SacarITDespacho(mIdPesajeCamion, Cmb_Viajes.SelectedValue.ToString());

                }
            }
            else
            {
                MessageBox.Show(" Debe Seleccionar una IT para poder sacarla de la IT");
                Cmb_Viajes.Focus();
            }

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_SacarIT_Click(object sender, EventArgs e)
        {
           
            SacarIT();
            CargaDatos(mIdPesajeCamion, mPatente, mTara, mBruto, mBascula);
        }

        private string ObtenerPesoPorViaje(string lViaje)
        {
            int i = 0; double lKgsViaje = 0;Clases.ClsComun lCom = new Clases.ClsComun();

            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                if ((dataGridView1.Rows[i].Cells["KgsPaquete"].Value !=null) && (dataGridView1.Rows[i].Cells["Codigo"].Value.ToString().Equals(lViaje)))
                {
                    lKgsViaje = lKgsViaje + lCom.CDBL(dataGridView1.Rows[i].Cells["KgsPaquete"].Value.ToString());
                }
            }

            return Math.Round (lKgsViaje,2).ToString ();
        }

        private void Cmb_Viajes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Viajes.SelectedValue != null)
            {
                Lbl_KgsIT.Text = ObtenerPesoPorViaje(Cmb_Viajes.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show(" Debe Seleccionar una IT para poder sacarla de la IT");
                Cmb_Viajes.Focus();
            }
        }
    }
}

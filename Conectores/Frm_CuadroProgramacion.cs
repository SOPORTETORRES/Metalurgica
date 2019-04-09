using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Conectores
{
    public partial class Frm_CuadroProgramacion : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        public Frm_CuadroProgramacion()
        {
            InitializeComponent();
        }

        private void Dt_FechaIni_ValueChanged(object sender, EventArgs e)
        {
            string lfechaSel = Dt_FechaIni.Value.ToShortDateString();
            CargaDatosDias(lfechaSel);
        }

        public void IniciaForm(CurrentUser iUserActivo)
        {
            mUserLog = iUserActivo;
        }

        private void CargaDatosDias(string iFechaInicial)
        {
            Px_Conectores.Ws_ConectoresSoapClient lCon = new Px_Conectores.Ws_ConectoresSoapClient();
            string lNroCon = "";  //lCon.NroConectoresPorDia(lfechaSel);
            string lFechaTmp = ""; Clases.ClsComun lComun = new Clases.ClsComun();
            DateTime lFechaTmporal;
            int i = 0;

          

            lFechaTmp = iFechaInicial;
            for (i =1; i < 8; i++)
            {
                if (lFechaTmp.IndexOf("-") > 0)
                {
                    lFechaTmp = lFechaTmp.Replace("-", "/");
                }
                lNroCon = lCon.NroConectoresPorDia(lFechaTmp);
                switch (i)
                {
                    case 1:  //
                        Btn_DiaSel.Text = string.Concat(lFechaTmp, "  (", lNroCon, ")");
                        break;
                    case 2:
                        Btn_Dia1.Text = string.Concat(lFechaTmp, "  (", lNroCon, ")");
                        break;
                    case 3:
                        Btn_Dia2.Text = string.Concat(lFechaTmp, "  (", lNroCon, ")");
                        break;
                    case 4:
                        Btn_Dia3.Text = string.Concat(lFechaTmp, "  (", lNroCon, ")");
                        break;
                    case 5:
                        Btn_Dia4.Text = string.Concat(lFechaTmp, "  (", lNroCon, ")");
                        break;
                    case 6:
                        Btn_Dia5.Text = string.Concat(lFechaTmp, "  (", lNroCon, ")");
                        break;
                    case 7:
                        Btn_Dia6.Text = string.Concat(lFechaTmp, "  (", lNroCon, ")");
                        break;
                }
                if (lComun.EsFecha(lFechaTmp) == true)
                {
                    //lFechaTmp=d
                       // textbox1.text = "10/10/2009";
                      lFechaTmporal = Convert.ToDateTime(lFechaTmp, new CultureInfo("es-ES"));

                    lFechaTmporal = lFechaTmporal.AddDays(1);

                    lFechaTmp = lFechaTmporal.ToString("dd/MM/yyyy");
                }
            }
        }

        private void Btn_DiaSel_Click(object sender, EventArgs e)
        {
            string lFecha = "";
            string[] lPartes = Btn_DiaSel.Text .Split(new Char[] { '(' });
            if (lPartes.Length == 2)
            {
                lFecha = lPartes[0].ToString();
                CargaDatos(lFecha);
            }
                
          //  CargaDatos
        }

        private void CargaDatos(string iFecha)
        {
            string lfechaSel = Dt_FechaIni.Value.ToShortDateString();
            Px_Conectores.Ws_ConectoresSoapClient lCon = new Px_Conectores.Ws_ConectoresSoapClient();
            Px_Conectores.ListaDataSet  lConectores = lCon.DetalleConectoresPorDia (iFecha);
            DataTable lTbl = new DataTable(); int i = 0; Color iColorFila = new Color(); int k = 0;

            if (lConectores.MensajeError.Trim().Length == 0)
            {
                if (lConectores.DataSet.Tables.Count > 0)
                {
                    lTbl = ObtenerTablaFinal(lConectores.DataSet.Tables[0].Copy());

                    dataGridView1.DataSource = lTbl;
                    //for (i = 0; i < dataGridView1.RowCount; i++)
                    //{
                    //    dataGridView1.Rows[i].Height = 90;
                    //}
                    dataGridView1.Columns["Codigo"].Width = 60;
                    dataGridView1.Columns["ConectorIzq"].Visible = false;
                    dataGridView1.Columns["tipoConector"].Visible = false;
                    dataGridView1.Columns["ConectorDer"].Visible = false;
                    dataGridView1.Columns["IdForma"].Width = 60;
                    dataGridView1.Columns["TipoConector"].Width = 60;
                    dataGridView1.Columns["Imagen"].Width = 250;

                    for (i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Cells["Estado"].Value != null)
                        {
                            if (dataGridView1.Rows[i].Cells["Estado"].Value.ToString().ToUpper().Equals("PR"))
                                iColorFila = Color.LightGreen;

                            if (dataGridView1.Rows[i].Cells["Estado"].Value.ToString().ToUpper().Equals("NP"))
                                iColorFila = Color.LightSalmon;

                            if (dataGridView1.Rows[i].Cells["Estado"].Value.ToString().ToUpper().Equals("EP"))
                                iColorFila = Color.LightYellow;


                            for (k = 0; k < dataGridView1.Columns.Count; k++)
                            {
                                dataGridView1.Rows[i].Cells[k].Style.BackColor = iColorFila;
                                dataGridView1.Rows[i].Height = 80;
                            }

                        }
                    }


                }
            }
        }

        private DataTable ObtenerTablaFinal(DataTable iTblOrigen)
        {
            DataTable lTblRes = new DataTable();DataView lVista = null;
            int i = 0;string lPiezasProc = ""; DataRow lFila = null;

            lTblRes.Columns.Add("Codigo", Type.GetType("System.String"));
            lTblRes.Columns.Add("Etiqueta", Type.GetType("System.String"));
            lTblRes.Columns.Add("NroPiezas", Type.GetType("System.String"));
            lTblRes.Columns.Add("ConectorIzq", Type.GetType("System.String"));
            lTblRes.Columns.Add("ConectorDer", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdForma", Type.GetType("System.String"));
            lTblRes.Columns.Add("TipoConector", Type.GetType("System.String"));
            lTblRes.Columns.Add("IdPaquete", Type.GetType("System.String"));
            lTblRes.Columns.Add("Imagen", Type.GetType("System.Byte[]"));
            lTblRes.Columns.Add("Estado", Type.GetType("System.String"));
            //

            for (i = 0; i < iTblOrigen.Rows.Count; i++)
            {
                if (lPiezasProc.IndexOf(iTblOrigen.Rows[i]["IdPaquete"].ToString()) < 0)
                {
                    lVista =new DataView (iTblOrigen ,string.Concat ("IdPaquete=", iTblOrigen.Rows[i]["IdPaquete"].ToString()),"",DataViewRowState.CurrentRows );
                    if (lVista.Count > 0)
                    {
                        //creamos la nueva Fila 
                        lFila = lTblRes.NewRow();
                        lFila["Codigo"] = lVista[0]["Codigo"].ToString();
                        lFila["IdForma"] = lVista[0]["IdForma"].ToString();
                        lFila["TipoConector"] = lVista[0]["TipoConector"].ToString();
                        lFila["Etiqueta"] = lVista[0]["Etiqueta"].ToString();
                        lFila["NroPiezas"] = lVista[0]["cantidad"].ToString();
                        lFila["IdPaquete"] = lVista[0]["IdPaquete"].ToString();
                        lFila["Imagen"] = lVista[0]["Imagen"];
                        lFila["Estado"] = lVista[0]["Estado"].ToString();

                        if (lVista[0]["LadoConector"].ToString().ToUpper().Equals("I"))
                             lFila["ConectorIzq"] = lVista[0]["IdConector"].ToString();
                        else
                            lFila["ConectorDer"] = lVista[0]["IdConector"].ToString();

                        //revisamos la segunda Fila
                        if (lVista.Count == 2)
                        {
                            if (lVista[1]["LadoConector"].ToString().ToUpper().Equals("I"))
                                lFila["ConectorIzq"] = lVista[1]["IdConector"].ToString();
                            else
                                lFila["ConectorDer"] = lVista[1]["IdConector"].ToString();
                        }
                        lTblRes.Rows.Add(lFila);
                        lPiezasProc = string.Concat(lPiezasProc, " , ", iTblOrigen.Rows[i]["IdPaquete"].ToString());

                    }
                    }

                }
            return lTblRes;

        }

        private void Btn_Produccion_Click(object sender, EventArgs e)
        {
            Frm_ProduccionConectores lFrm = new Frm_ProduccionConectores();
            lFrm.IniciaFormulario( mUserLog  );
            lFrm.ShowDialog(this);
        }

        private void Btn_Dia1_Click(object sender, EventArgs e)
        {
            string lFecha = "";
            string[] lPartes = Btn_Dia1.Text.Split(new Char[] { '(' });
            if (lPartes.Length == 2)
            {
                lFecha = lPartes[0].ToString();
                CargaDatos(lFecha);
            }
        }

        private void Btn_Dia2_Click(object sender, EventArgs e)
        {
            string lFecha = "";
            string[] lPartes = Btn_Dia2.Text.Split(new Char[] { '(' });
            if (lPartes.Length == 2)
            {
                lFecha = lPartes[0].ToString();
                CargaDatos(lFecha);
            }
        }

        private void Btn_Dia3_Click(object sender, EventArgs e)
        {
            string lFecha = "";
            string[] lPartes = Btn_Dia3.Text.Split(new Char[] { '(' });
            if (lPartes.Length == 2)
            {
                lFecha = lPartes[0].ToString();
                CargaDatos(lFecha);
            }
        }

        private void Btn_Dia4_Click(object sender, EventArgs e)
        {
            string lFecha = "";
            string[] lPartes = Btn_Dia4.Text.Split(new Char[] { '(' });
            if (lPartes.Length == 2)
            {
                lFecha = lPartes[0].ToString();
                CargaDatos(lFecha);
            }
        }

        private void Btn_Dia5_Click(object sender, EventArgs e)
        {
            string lFecha = "";
            string[] lPartes = Btn_Dia5.Text.Split(new Char[] { '(' });
            if (lPartes.Length == 2)
            {
                lFecha = lPartes[0].ToString();
                CargaDatos(lFecha);
            }
        }

        private void Btn_Dia6_Click(object sender, EventArgs e)
        {
            string lFecha = "";
            string[] lPartes = Btn_Dia6.Text.Split(new Char[] { '(' });
            if (lPartes.Length == 2)
            {
                lFecha = lPartes[0].ToString();
                CargaDatos(lFecha);
            }
        }
    }
    }


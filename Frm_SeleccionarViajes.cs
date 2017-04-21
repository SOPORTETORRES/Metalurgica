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
    public partial class Frm_SeleccionarViajes : Form
    {
        public string mViajesSel = "N";
        private DataTable mTblDatos = new DataTable();
        private string mViajesSeleccionados = "";
        public Frm_SeleccionarViajes()
        {
            InitializeComponent();
        }

        public void IniciaForm(DataTable iDatos,string lViajesSel, string iRb_Seleccionado )
            {

                mViajesSeleccionados = lViajesSel;
                mTblDatos = iDatos;
                CargaGrilla("PD",true);
            }


        public void AgregaColumnaCheck()
        {

            //Me.Dgt_Piezas.DataSource = lListaImp

            //    If mPrimeraVez = True Then
            //        Dim colcheckBox As New DataGridViewCheckBoxColumn
            DataGridViewCheckBoxColumn colcheckBox = new DataGridViewCheckBoxColumn();
            //        Dgt_Piezas.Columns.Insert(0, colcheckBox)
            this.Dtg_Resultado.Columns.Insert(0, colcheckBox);
            //        With colcheckBox
            //            .HeaderText = "Sel"
            colcheckBox.HeaderText = "Sel";
            //            .Name = "Sel"
            colcheckBox.Name = "Sel";
            colcheckBox.Width = 50;
            //        End With
            //        mPrimeraVez = False
            //    End If
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            string lViajes = ""; bool lContinuar = true;
            foreach (DataGridViewRow lRow in this.Dtg_Resultado.Rows)
            {
                if (lRow.Cells[0].Value != null)
                    if (lRow.Cells[0].Value.ToString() == "True")
                        if (lViajes .ToString().Trim().Length ==0)
                        {
                            lViajes = string.Concat(lViajes, "'", lRow.Cells["codigo"].Value.ToString(), "'|", lRow.Cells["Id"].Value.ToString(), ",");
                        }
                        else
                        {
                            MessageBox.Show("Solo se puede Seleccionar un Viaje para despachar. Seleccionar nuevamente el viaje a Despachar", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lViajes = "";
                            lContinuar = false;
                        }
            }
            if (lContinuar == true)
            {
                if (lViajes.Length > 0)
                {
                    lViajes = lViajes.Substring(0, lViajes.Length - 1);
                    mViajesSel = "S";
                }
                AppDomain.CurrentDomain.SetData("Viajes", lViajes);
                this.Hide();
            }
            else
            {
                foreach (DataGridViewRow lRow in this.Dtg_Resultado.Rows)
                {
                    lRow.Cells[0].Value = false;                    
                }
            }
            
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefrescaGrilla()
        {
            int i = 0;
            for (i = 0; i < Dtg_Resultado.RowCount; i++)
            {
                switch (Dtg_Resultado.Rows[i].Cells["Estado"].Value.ToString().Trim().ToUpper())
                {
                    case "DES":
                        PintaFila(i, Color.LightSalmon);
                        //' Dtg_Resultado.Rows[i].Cells["Codigo"].Style.BackColor = Color.LightSalmon;
                        break;
                    case "IVI":
                        PintaFila(i, Color.LightGreen);
                        //Dtg_Resultado.Rows[i].Cells["Codigo"].Style.BackColor = Color.LightGreen;
                        break;
                    case "DCAM":
                        PintaFila(i, Color.Yellow);
                        //Dtg_Resultado.Rows[i].Cells["Codigo"].Style.BackColor = Color.Yellow;
                        break;
                }
            }
        }

        private void Frm_SeleccionarViajes_Load(object sender, EventArgs e)
        {
            RefrescaGrilla();
        }

        private void PintaFila(int IndexFila,Color iColorFila)
        {
            int i = 0;
            for (i = 0; i < Dtg_Resultado.ColumnCount ; i++)
            {
                Dtg_Resultado.Rows[IndexFila].Cells[i].Style.BackColor = iColorFila;
                      
                }
            }

        private void Rb_Despachados_CheckedChanged(object sender, EventArgs e)
        {
            CargaGrilla("D",false );
        }


        private void CargaGrilla(string iTipo,Boolean iAgregaCol)
       {

           char[] delimiterChars = { ',', '\t' };
           int i = 0; int z = 0; string lWhere = ""; DataView lVista = new DataView();
           switch (iTipo.ToUpper())
           {
               case "T":
                   lWhere = "";
                   break;
               case "D":
                   lWhere = "Estado='DES'";
                   break;
               case "PD":
                   lWhere = " estado <>'DES'";
                   break;
           }
           lVista = new DataView(mTblDatos, lWhere, "", DataViewRowState.CurrentRows);

           Dtg_Resultado.DataSource = lVista;
           //Dtg_Resultado.DataSource = mTblDatos;


           //AppDomain.CurrentDomain.SetData("Viajes", "");
            if (iAgregaCol==true )
            {
                AgregaColumnaCheck();
            }    
          
           string[] words = mViajesSeleccionados.Split(delimiterChars);

           for (i = 1; i < words.Length; i++)
           {
               for (z = 1; z < Dtg_Resultado.Rows.Count - 1; z++)
               {
                   if (words[i].ToString().Equals(Dtg_Resultado.Rows[z].Cells["Codigo"].Value))
                   {
                       Dtg_Resultado.Rows[z].Cells[0].Value = true;

                   }
               }
           }
           RefrescaGrilla();

        }

        private void Rb_PorDespachar_CheckedChanged(object sender, EventArgs e)
        {
            CargaGrilla("PD",false );
        }

        private void Rb_Todos_CheckedChanged(object sender, EventArgs e)
        {
            CargaGrilla("",false );
        }

        private void Dtg_Resultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
          }
}
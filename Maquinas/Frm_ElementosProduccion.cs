using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Maquinas
{
    public partial class Frm_ElementosProduccion : Form
    {
        private string mIdUserReporta = "";

        public Frm_ElementosProduccion()
        {
            InitializeComponent();
        }

        private void Frm_ElementosProduccion_Load(object sender, EventArgs e)
        {
            Dgt_elementos.Columns["Id"].Width = 60;
            Dgt_elementos.Columns["Elemento"].Width = 300;

           

        }


        public void IniciaFormulario(string iIdUser)
        {
            mIdUserReporta = iIdUser;
            Ws_TO.Ws_ToSoapClient lDal = new Ws_TO.Ws_ToSoapClient(); int i = 0;
            DataSet lDts = new DataSet(); DataTable lTbl = new DataTable();
            DataRow lFila = null;

            lTbl.Columns.Add("Id", Type.GetType("System.String"));
            lTbl.Columns.Add("Elemento", Type.GetType("System.String"));

            lDts = lDal.ObtenerParametro("ElementosProduccion");
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                //lTbl = lDts.Tables[0].Copy();
                for (i = 0; i < lDts.Tables[0].Rows.Count; i++)
                {
                    lFila = lTbl.NewRow();
                    lFila["Id"] = lDts.Tables[0].Rows[i]["Id"].ToString ();
                    lFila["Elemento"] = lDts.Tables[0].Rows[i]["Par1"].ToString();
                    lTbl.Rows.Add(lFila);
                }
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
            int lFila = e.RowIndex;
            if (lFila > -1)
            {
                Lbl_Seleccionado.Text = Dgt_elementos.Rows[lFila].Cells["Elemento"].Value.ToString();
                Lbl_Seleccionado.Tag = Dgt_elementos.Rows[lFila].Cells["Id"].Value.ToString();
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
    }
}

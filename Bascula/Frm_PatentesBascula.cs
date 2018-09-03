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
    public partial class Frm_PatentesBascula : Form
    {
        DataTable mDatos = new DataTable();
        public Frm_PatentesBascula()
        {
            InitializeComponent();
        }

        private void Frm_PatentesBascula_Load(object sender, EventArgs e)
        {
            Gtg_Patentes.DataSource = mDatos;
            Gtg_Patentes.Columns[0].Width = 70;
            Gtg_Patentes.Columns[1].Width = 70;
            Gtg_Patentes.Columns[2].Width = 60;
            Gtg_Patentes.Columns[3].Width = 40;
            Gtg_Patentes.Columns[4].Width = 50;
            Gtg_Patentes.Columns[5].Width = 70;

            Gtg_Patentes.Columns[6].Width = 70;
            Gtg_Patentes.Columns[7].Visible = false;
            Gtg_Patentes.Columns[8].Visible = false;

            Gtg_Patentes.Columns[9].Width = 70;
            Gtg_Patentes.Columns[10].Width = 70;
            Gtg_Patentes.Columns[11].Width = 70;
            Gtg_Patentes.Columns[12].Width = 70;
            Gtg_Patentes.Columns[13].Visible = false;
            Gtg_Patentes.Columns[14].Visible = false;
            Gtg_Patentes.Columns[15].Visible = false;
            Gtg_Patentes.Columns[16].Visible = false;

        }

        public  void IniciaForm(DataTable iTbl)
        {
            mDatos = iTbl;

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IniciaColorGrilla()
        {
            int i = 0; int k = 0;

            for (k = 0; k < Gtg_Patentes.Rows .Count ; k++)
            {

                for (i = 0; i < Gtg_Patentes.Columns.Count; i++)
                {
                    Gtg_Patentes.Rows[k].Cells[i].Style.BackColor = Color.White ;
                }

            }


        }

        private void Gtg_Patentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;
            int i = 0;
            if (lIndex > -1)
            {
                IniciaColorGrilla();
                Tx_Correlativo.Text = Gtg_Patentes.Rows[lIndex].Cells["Correlativo"].Value.ToString();
                Tx_PesoBruto.Text = Gtg_Patentes.Rows[lIndex].Cells["PesoBruto"].Value.ToString();
                Tx_fecha .Text = Gtg_Patentes.Rows[lIndex].Cells["Fecha"].Value.ToString();
                Tx_hora.Text = Gtg_Patentes.Rows[lIndex].Cells["Hora"].Value.ToString();

                for (i=0;i<Gtg_Patentes .Columns.Count ;i++)
                {
                    Gtg_Patentes.Rows[lIndex].Cells[i].Style.BackColor = Color.LightGreen;
                }

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Tx_Correlativo.Text.Trim().Length > 0)
            {
                AppDomain.CurrentDomain.SetData("Correlativo",Tx_Correlativo .Text);
                AppDomain.CurrentDomain.SetData("PesoBruto", Tx_PesoBruto .Text  );
                this.Close();
            }
        }
    }
}

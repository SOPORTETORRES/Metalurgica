using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Controls
{
    public partial class CtlGrilla : UserControl
    {
        public CtlGrilla()
        {
            InitializeComponent();
        }
        public void CargaDatosGrilla(string iTitulo, DataTable iDatos)
        {
            Lbl_Titulo.Text = iTitulo;
            Dtg_Resultado.DataSource = iDatos;
        }

        public void CargaDatosGrillaSeleccionarViajes(string iTitulo, DataTable iDatos)
        {
            //Lbl_Titulo.Text = iTitulo;
            //Dtg_Resultado.DataSource = iDatos;
            //AgregaColumnaCheck();
        }
        public void CargaDatosGrilla(string iTitulo, object  iDatos)
        {
            Lbl_Titulo.Text = iTitulo;
            Dtg_Resultado.DataSource = iDatos;
        }

       
        


        public void ConfiguraGrillaPiezas()
        {
            //ctlGrilla1.CargaDatosGrilla(iTitulo, iDatos);
            this.Dtg_Resultado.Columns["FiguraB"].Visible = false;
            this.Dtg_Resultado.Columns["Figura"].Visible = false;
            this.Dtg_Resultado.Columns["Nivel"].Visible = false;
            this.Dtg_Resultado.Columns["Elemento"].Visible = false;
            this.Dtg_Resultado.Columns["Plano"].Visible = false;
            this.Dtg_Resultado.Columns["Ubicacion"].Visible = false;
            this.Dtg_Resultado.Columns["codigoIT"].Visible = false;
            this.Dtg_Resultado.Columns["Orden"].Visible = false;   
            this.Dtg_Resultado.Columns[0].Visible = false;
            this.Dtg_Resultado.Columns["CantEtiq"].Width = 60;
            this.Dtg_Resultado.Columns["PesoEtiq"].Width = 60;
            this.Dtg_Resultado.Columns["PiezasXEtiq"].Width = 70;
            this.Dtg_Resultado.Columns["NroPaquetes"].Width = 70;
            this.Dtg_Resultado.Columns["Peso"].Width = 70;

            this.Dtg_Resultado.Columns["Paquete"].Width = 60;
            this.Dtg_Resultado.Columns["Cantidad"].Width = 60;
            this.Dtg_Resultado.Columns["Diametro"].Width = 60;

            this.Dtg_Resultado.Columns["Largo"].Width = 70;
            this.Dtg_Resultado.Columns["marca"].Width = 70;
            this.Dtg_Resultado.Columns["pieza"].Width = 70;

            int i = 0;

            for (i=0;i<Dtg_Resultado.Rows  .Count -1;i++)
            {
                Dtg_Resultado.Rows[i].Height = 200;
            }
            Dtg_Resultado.Refresh();

        }

        private void Dtg_Resultado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)
                return;
           
        Dtg_Resultado.Refresh();
        }

        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            string lViajes = "";
            foreach (DataGridViewRow lRow in this .Dtg_Resultado .Rows )
            {
                if  (lRow .Cells [0].Value !=null) 
                    if (lRow .Cells [0].Value.ToString () =="True" )
                            lViajes = string.Concat(lViajes,"'", lRow.Cells["codigo"].Value.ToString(),"'", ",");
            }
            lViajes = lViajes.Substring(0, lViajes.Length - 1);
            AppDomain.CurrentDomain.SetData("Viajes", lViajes);
            this.Hide ();
        }

        private void Dtg_Resultado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string lIdSeleccionado = Dtg_Resultado.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            //AppDomain.CurrentDomain.SetData("IdMaquina", lIdSeleccionado);
           
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Informes
{
    public partial class Frm_Visualizador : Form
    {
        private string mDespachos="";

        public Frm_Visualizador()
        {
            InitializeComponent();
        }
        public void Inicia(string lDespachos)
        {
            mDespachos = lDespachos;        
        }

        public void CargarInforme(DataSet  lDts ) 
        {
       
        //Try
        //    Cursor = Cursors.WaitCursor

            Rpt_DetalleDespacho mReport=new Rpt_DetalleDespacho ();

            //Dim mReport As New CrystalReport1
            if  (lDts != null )
            {
                if (lDts.Tables .Count >0 )
                {
                    mReport.SetDataSource(lDts);
                    this .crystalReportViewer1 .ReportSource =mReport ;
                    //CrystalReportViewer1.ReportSource = mReport
                
                }
                //    Return True
                //End If
            }
                            

            //Return False

        //Catch ex As Exception
        //    Throw ex
        //Finally
        //    Cursor = Windows.Forms.Cursors.Default
        //End Try

    }

        private void Frm_Visualizador_Load(object sender, EventArgs e)
        {
            //ImprimeInformeCarga();
        }
    }
}

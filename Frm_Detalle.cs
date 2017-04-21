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
    public partial class Frm_Detalle : Form
    {
        public Frm_Detalle()
        {
            InitializeComponent();
        }

        public void CargaDatosGrillaSeleccionarViajes(string iTitulo, DataTable iDatos)
        {
            ctlGrilla1.CargaDatosGrillaSeleccionarViajes(iTitulo, iDatos);
            this.Text = iTitulo;
        }

        public void CargaDatosGrilla(string iTitulo, object  iDatos)
        {
            ctlGrilla1.CargaDatosGrilla(iTitulo, iDatos);
            this.Text = iTitulo;
            //this.Width = 800;
            //this.Height = 400;
        }

        public void ConfiguraGrillaPiezas()
        {
            ctlGrilla1.ConfiguraGrillaPiezas();
            
        }

        private void ctlGrilla1_Load(object sender, EventArgs e)
        {

        }
    }
}

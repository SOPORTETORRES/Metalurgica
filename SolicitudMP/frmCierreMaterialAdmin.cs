using System;
using System.Windows.Forms;

namespace Metalurgica
{
    public partial class frmCierreMaterialAdmin : Form
    {
        public bool ok = false;
        public string producto = "";
        public string diametro = "";
        public string largo = "";
        public string origen = "";
        public string tipo = "";
        public string cantidad = "";
        public string tipo_cierre = "";
        public int cantidad_cierre = 0;

        public frmCierreMaterialAdmin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //if (!txtObs.Text.Trim().Equals(""))
            //{
                ok = true;
                tipo_cierre = cboTipo.Text; //.Substring(0, 1);
                cantidad_cierre = Convert.ToInt32(numUpdCantidad.Value);
                this.Hide();
            //}
            //else
            //    MessageBox.Show("Falta ingresar la Observación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmCierreMaterialAdmin_Load(object sender, EventArgs e)
        {
            lblProducto.Text = producto;
            lblDiametro.Text = diametro;
            lblLargo.Text = largo;
            lblOrigen.Text = origen;
            lblTipo.Text = tipo;
            lblCantidad.Text = cantidad_cierre.ToString();
            cboTipo.Text = tipo_cierre;
            numUpdCantidad.Value = cantidad_cierre;
        }
    }
}
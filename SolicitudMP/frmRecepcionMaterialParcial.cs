using System;
using System.Windows.Forms;
using CommonLibrary2;
using System.Configuration;

namespace Metalurgica
{
    public partial class frmRecepcionMaterialParcial : Form
    {
        public bool ok = false;
        public string producto = "";
        public string diametro = "";
        public string largo = "";
        public string origen = "";
        public string tipo = "";
        public string cantidad = "";
        public int cantidad_parcial = 0;
        public string obs = "";
        public string KilosEtiquetaRollo = "";
        public string Kilos = "";
        public string Mensaje = "";

        public frmRecepcionMaterialParcial()
        {
            InitializeComponent();
        }

        private string eliminarCaracteresEspeciales(string entrada)
        {
            StringUtility stringUtility = new StringUtility();
            string salida = entrada;
            if (!salida.Trim().Equals(""))
                salida = stringUtility.removeInvalidCharacters(salida, stringUtility.RegexPattern_Address);
            return salida;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun();
            if (txtObs.Visible == true)
            {
                if (!txtObs.Text.Trim().Equals(""))
                {
                    //if (Convert.ToInt32(txtCantidad.Text.Trim()) > 0)
                    //{ 
                    ok = true;
                    cantidad_parcial = Convert.ToInt32(numUpdCantidad.Value); // Convert.ToInt32(txtCantidad.Text.Trim());
                    obs = eliminarCaracteresEspeciales(txtObs.Text.Trim());
                    KilosEtiquetaRollo = Tx_KilosEtiqueta.Text;
                    this.Hide();
                    //}
                    //else
                    //    MessageBox.Show("La cantidad debe ser mayor a cero (0).", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Falta ingresar la Observación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (VerificaKilosRollo(lblOrigen.Text, lCom.Val (Tx_KilosEtiqueta.Text)) == true)
                {
                    ok = true;
                    cantidad_parcial = Convert.ToInt32(numUpdCantidad.Value); // Convert.ToInt32(txtCantidad.Text.Trim());
                    obs = eliminarCaracteresEspeciales(txtObs.Text.Trim());
                    KilosEtiquetaRollo = Tx_KilosEtiqueta.Text;
                    this.Hide();
                }
                
            }
        }

        private bool VerificaKilosRollo(string iOrigen, int iKilosRollo)
        {
            bool lRes = true; int lMin = 0; int lMax = 0; string lMsg = "";
            string lRangoCAP = ConfigurationManager.AppSettings["RolloCAP"].ToString();
            string lRangoGerdau = ConfigurationManager.AppSettings["RolloGERDAU"].ToString();
            char[] delimiterChars = { '-' }; string[] words = lRangoCAP.Split(delimiterChars);
             Clases.ClsComun lCom = new Clases.ClsComun();


            if (iOrigen.ToUpper ().IndexOf("CAP") > -1) // es cap
            {
                words = lRangoCAP.Split(delimiterChars);
                lMin = lCom.Val (words[0].ToString());
                lMax = lCom.Val(words[1].ToString());
                if ((iKilosRollo < lMin) || (iKilosRollo > lMax))
                {
                    lRes = false;
                    lMsg=" Los kilos ingresados no estan en el rango permitido, Revisar.";
                }
            }
            if (iOrigen.ToUpper ().IndexOf("GER") > -1) // es Gerdau
            {
                words = lRangoGerdau.Split(delimiterChars);
                lMin = lCom.Val(words[0].ToString());
                lMax = lCom.Val(words[1].ToString());
                 if ((iKilosRollo < lMin) || (iKilosRollo > lMax))
                {
                    lRes = false;
                    lMsg = " Los kilos ingresados no estan en el rango permitido, Revisar.";
                }
            }

            if (lMsg.ToString().Length > 0)
            {
                MessageBox.Show(lMsg, "Avisos Sistema", MessageBoxButtons.OK);
            }
            return lRes;
        
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmRecepcionMaterialParcial_Load(object sender, EventArgs e)
        {
            lblProducto.Text = producto;
            lblDiametro.Text = diametro;
            lblLargo.Text = largo;
            lblOrigen.Text = origen;
            lblTipo.Text = tipo;
            lblCantidad.Text = cantidad;
            numUpdCantidad.Value = cantidad_parcial;
            txtObs.Text = obs;
            if (Mensaje.Length > 0)
            {
                Lbl_Msg.Text = Mensaje;
                Lbl_Msg.Visible = true;
                label8.Visible = false;
                txtObs .Visible =false ;
                Lbl_Msg.Top = txtObs.Top;
                Lbl_Msg.Left  = txtObs.Left ;
                numUpdCantidad.Enabled = false;
            }
            Lbl_Kilos.Text = Kilos;
            Tx_KilosEtiqueta.Text = "";
            Tx_KilosEtiqueta.Focus ();
        }

        private void Lbl_Msg_Click(object sender, EventArgs e)
        {

        }

        private void txtObs_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
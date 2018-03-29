using System;
using System.Windows.Forms;

namespace Metalurgica
{
    public partial class ctlInformacionUsuario : UserControl
    {
        private CurrentUser mUserlog = new CurrentUser();
        public ctlInformacionUsuario()
        {
            InitializeComponent();
        }

        private void ctlInformacionUsuario_Load(object sender, EventArgs e)
        {
            CurrentUser lUser = new CurrentUser();
            Clases.ClsComun lComun = new Clases.ClsComun();
            lUser = mUserlog; //lComun.ObtenerDatosEquipo();

            lblLogin.Text = lUser.Login;
            lblUsuario.Text = lUser.Name;
            lblComputador.Text = lUser.ComputerName;
            lblFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");

            LblMaq.Text = lUser.DescripcionMaq;
            LblIdTotem.Text = lUser.IdTotem.ToString ();

        }

        public void CargaDatosUserLog(CurrentUser iUser)
        {
            mUserlog = iUser;
            lblLogin.Text = mUserlog.Login;
            lblUsuario.Text = mUserlog.Name;
            lblComputador.Text = mUserlog.ComputerName;
            lblFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");

            LblMaq.Text = mUserlog.DescripcionMaq;
            LblIdTotem.Text = mUserlog.IdTotem.ToString();
            lblUsuario.Text = mUserlog.Name;
            //lblLogin.Text = iUser.Login;
            //lblUsuario.Text = iUser.Name;
            //lblComputador.Text = iUser.ComputerName;
            //lblFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");    
                         }

        public void CargaDatosMaq(string iIdMaq, string iNomreMaq)
        {
            //mUserlog = iUser;
            LblMaq.Text = iNomreMaq; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("H:mm:ss");
        }
    }
}
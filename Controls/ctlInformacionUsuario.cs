using System;
using System.Windows.Forms;

namespace Metalurgica
{
    public partial class ctlInformacionUsuario : UserControl
    {
        private CurrentUser mUserlog = new CurrentUser();
        private  int mContador= 0;
        private string mTipoMP_Maq = "";
        private string mProceso = "";

        public ctlInformacionUsuario()
        {
            InitializeComponent();
        }

        public  void InicializaCtl(string iTipoMP, string iProceso)
        {
            mTipoMP_Maq = iTipoMP;
            mProceso = iProceso;

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

            //LblMaq.Text = lUser.DescripcionMaq;
            LblIdTotem.Text = lUser.IdTotem.ToString ();

            // agregaremos en la parte del nombre de la maquina trabaja con (B-R) Proceso que realiza (C D)
            string ltmp = ""; string ltmp2 = "";

            if (mProceso == "C")
                ltmp = " Corte";

            if (mProceso == "D")
                ltmp = " Doblado";

            if (mProceso == "CYD")
                ltmp = " Corte y Doblado";

            if (mTipoMP_Maq == "B")
                ltmp2 = "Barras";

            if (mTipoMP_Maq == "R")
                ltmp2 = "Rollos";


            LblMaq.Text = string.Concat(LblMaq.Text, " Trabaja con :", ltmp2, " -  Proceso: ", ltmp);

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
            //if (mContador > 60)
            //{
            //    VerificaChequeoMaquina();
            //    mContador = 0;
            //}
            //else
            //    mContador++;
        }

       




    }
}
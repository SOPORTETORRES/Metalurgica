using System;
using System.Windows.Forms;
using CommonHelp;
using CommonLibrary2;

namespace Metalurgica
{
    static class Program
    {
        public static CurrentUser currentUser = new CurrentUser();

        private const string userRoot = "HKEY_CURRENT_USER";
        private const string subkey = "Software\\VB and VBA Program Settings\\Metalurgica";
        public static string regeditKeyName = userRoot + "\\" + subkey;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new frmLogin());
            //Application.Run(new Code128 .FrmGeneraCode128 ()  );
             //Application.Run(new Pruebas.Frm_Impresion());

            string accion = "RECEPCIONCOLADA";
            String[] arguments = Environment.GetCommandLineArgs();
            if (arguments.Length > 1)
                accion = arguments[1];
            Form form = null;


            currentUser.Machine = Convert.ToInt16(new Registry().GetValue(regeditKeyName, "Maquina", 2));
            currentUser.ComputerName = System.Environment.MachineName;

            switch (accion.ToUpper())
            {
                case "RECEPCIONCOLADA":
                    form = new frmRecepcionColada();
                    //form = new Code128.FrmGeneraCode128();

                    break;
                case "PRODUCCION":
                    form = new frmProduccion();
                    //form = new FrmProduccion_2 ();
                    //form = new MultiMaquina.Prueba();

                    
                    break;
                case "DESPACHOACOPIO":
                    form = new frmDespachoBodegaAcopio();
                    break;
                case "DESPACHOCAMION":
                    form = new frmDespachoCamion();
                    break;
                case "VBDESPACHOCAMION":
                    form = new frmVbDespachoCamion();
                                        break;
            }

            if (form != null)
            {
                frmLogin f = new frmLogin();
                f.ShowDialog();
                if (f.logon)
                {
                    f.Dispose();

                    try
                    {
                        //Login -> currentUser.Login 
                        currentUser.Machine = Convert.ToInt16(new Registry().GetValue(regeditKeyName, "Maquina", 2));
                        currentUser.ComputerName = System.Environment.MachineName;
                        WsSesion.WS_SesionSoapClient  wsSesion = new  WsSesion.WS_SesionSoapClient();
                        //WsSesion.Sesion WS_SesionSoapClient wsSesion = new WsSesion.WS_SesionSoapClient();
                        WsSesion.Sesion sesion = wsSesion.Iniciar(currentUser.Login, currentUser.Machine, currentUser.ComputerName, form.Name);

                        form.Text += " - versión: " + Application.ProductVersion;
                        Application.Run(form);

                        sesion = wsSesion.Terminar(sesion.Id);
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("La acción especificada es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}
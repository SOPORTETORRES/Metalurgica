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
    public partial class FrmProduccion_2 : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        
        
        private string mIdUser = "0";
        
        public FrmProduccion_2()
        {
            InitializeComponent();
        }

        public void IniciaFormulario(CurrentUser iUserLog)
        {
            mUserLog = iUserLog;
            mIdUser = iUserLog.Iduser;
            ctlProduccion1.IniciaFormulario(iUserLog);
            ctlProduccion1.HabilitaControl (true );
            ctlProduccion1.HabilitaOpcionSolicitudMaterial();

            string lParam = new Clases.ClsComun().ObtenerParametroAppConfig("VersionProduccion");
            this.Text = string.Concat(this.Text, "  Versión: ", lParam);
            //ctlInformacionUsuario1.CargaDatosUserLog(iUserLog);)
        }

        private void FrmProduccion_2_Load(object sender, EventArgs e)
        {

        }

        void Boton_EventoClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlProduccion1_Load(object sender, EventArgs e)
        {

        }
    }
}

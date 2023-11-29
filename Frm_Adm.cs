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
    public partial class Frm_Adm : Form
    {
        private CurrentUser mUser = new CurrentUser();
        public Frm_Adm()
        {
            InitializeComponent();
        }


        internal void IniciaForm(CurrentUser iUser)
        {
            mUser = iUser;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_CrudCamion_Click(object sender, EventArgs e)
        {
            frmCrudCamion lFrm = new frmCrudCamion();
            lFrm .ShowDialog ();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCrudBodega0 lFrm = new frmCrudBodega0();
            lFrm.ShowDialog();
        }

        private void Btn_Maquinas_Click(object sender, EventArgs e)
        {
            frmCrudMaquina lFrm = new frmCrudMaquina();
            lFrm.ShowDialog();
        }
    }
}
//testc Dconcha

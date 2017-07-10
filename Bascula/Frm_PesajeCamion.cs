using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Bascula
{
    public partial class Frm_PesajeCamion : Form
    {
        public Frm_PesajeCamion()
        {
            InitializeComponent();
        }

        private void Btn_ObtenerTara_Click(object sender, EventArgs e)
        {
            string lTara = ObtenerTara();
        }


        #region Metodos privados de la clase

        private string ObtenerTara()
        {
            string lRes = "";string lSql = ""; Clases.SqlBascula lTipoSql=new Clases.SqlBascula ();
            DataTable lTbl = new DataTable();Clases.ClsComun lDAL = new Clases.ClsComun();
            string lFecha = "06/07/2017";// DateTime.Now.ToShortDateString();

            lTbl = lDAL.CargaTablaRomana(lTipoSql.ObtenerSqlTara(Tx_Patente.Text, lFecha));

            if (lTbl.Rows.Count > 0)
            {
                lRes = lTbl.Rows[0][0].ToString();

            }
            return lRes;
        }

        #endregion

    }
}

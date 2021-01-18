using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Muestreo
{
    public partial class Frm_ControlDimensional : Form
    {
        public Frm_ControlDimensional()
        {
            InitializeComponent();
        }

        private void CargaDatos(string iIdPaqueteTO)
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = "";DataTable lTbl = new DataTable();
            Ws_TO.TipoForma lTipoForma = new Ws_TO.TipoForma();

           lSql = string.Concat(" SP_Consultas_WS 209,'", iIdPaqueteTO,"','','','','','',''  ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTbl = lDts.Tables[0].Copy();
                Tx_IdPieza.Text = lTbl.Rows[0]["IdForma"].ToString();
                Tx_cantidad .Text = lTbl.Rows[0]["NroPiezas"].ToString();
                TX_Daimetro .Text = lTbl.Rows[0]["Diametro"].ToString();
                Tx_Kilos .Text = lTbl.Rows[0]["KgsPaquete"].ToString();


                lTipoForma = lPx.ObtenerTipoForma(Tx_IdPieza.Text);
                HabilitaTxSegunForma(lTipoForma);
                ObtenerImagenDesdeBD2(Tx_IdPieza.Text);
            }

        }

        private void ObtenerImagenDesdeBD2( string  IdForma  )
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
       
            Byte[] bits = null;
            try
            {
                //Dim bits As Byte()
            bits = lPx.ObtenerImagenOriginal(int.Parse (IdForma));
                //Dim memorybits As New MemoryStream(bits);
                System.IO.MemoryStream memorybits = new System.IO.MemoryStream(bits);
                //Dim bitmap As New Drawing.Bitmap(memorybits);
                System.Drawing.Bitmap bitmap = new Bitmap(memorybits);
            Pic_Img.Image = bitmap;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "No se puede mostrar fotografia desde el WS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
}

        private void HabilitaTxSegunForma(Ws_TO.TipoForma  iTipoForma)
        {
            int i = 0; int lAngulos = -1; int lValores = -1;

            for (i = 0; i < iTipoForma.DetalleForma.Length; i++)
            {
                if ((iTipoForma.DetalleForma [i].EsAngulo .ToUpper().Equals("S")) ||(iTipoForma.DetalleForma[i].EsAngulo.ToUpper().Equals("R")) || iTipoForma.DetalleForma[i].EsAngulo.ToUpper().Equals("A") )
                {
                    //'Los Angulos comienzan desde  k
                    lAngulos = lAngulos + 1;
                }
                else
                    lValores = lValores + 1;
                
           }
            InicialidaTxForma();
            for (i = 0; i <= lValores; i++)
            {
                switch (i)  {
                    case 0:
                        Tx_a.BackColor = Color.LightCyan; Tx_a.Enabled = true ;
                        break;
                    case 1:
                        Tx_b.BackColor = Color.LightCyan; Tx_b.Enabled = true;
                        break;
                    case 2:
                        Tx_c.BackColor = Color.LightCyan; Tx_c.Enabled = true;
                        break;
                    case 3:
                        Tx_d.BackColor = Color.LightCyan; Tx_d.Enabled = true;
                        break;
                    case 4:
                        Tx_e.BackColor = Color.LightCyan; Tx_e.Enabled = true;
                        break;
                    case 5:
                        Tx_f.BackColor = Color.LightCyan; Tx_f.Enabled = true;
                        break;
                    case 6:
                        Tx_g.BackColor = Color.LightCyan; Tx_g.Enabled = true;
                        break;
                    case 7:
                        Tx_h.BackColor = Color.LightCyan; Tx_h.Enabled = true;
                        break;
                    case 8:
                        Tx_i.BackColor = Color.LightCyan; Tx_i.Enabled = true;
                        break;
                    case 9:
                        Tx_j.BackColor = Color.LightCyan; Tx_j.Enabled = true;
                        break;
                }
           }
            for (i = 0; i <= lAngulos; i++)
            {
                switch (i)
                {
                    case 0 :
                        Tx_k.BackColor = Color.LightCyan; Tx_k.Enabled = true;
                        break;
                    case 1 :
                        Tx_l.BackColor = Color.LightCyan; Tx_l.Enabled = true;
                        break;
                    case 2 :
                        Tx_m.BackColor = Color.LightCyan; Tx_m.Enabled = true;
                        break;
                    case 3 :
                        Tx_n.BackColor = Color.LightCyan; Tx_n.Enabled = true;
                        break;
                }
        }
        if  (Tx_a.Enabled == false)  Tx_a.Text = "";
        if (Tx_b.Enabled == false ) Tx_b.Text = "";
        if (Tx_d.Enabled == false ) Tx_d.Text = "";
        if (Tx_e.Enabled == false ) Tx_e.Text = "";
        if (Tx_f.Enabled == false ) Tx_f.Text = "";
        if (Tx_g.Enabled == false ) Tx_g.Text = "";
        if (Tx_h.Enabled == false ) Tx_h.Text = "";
        if (Tx_i.Enabled == false ) Tx_i.Text = "";
        if (Tx_j.Enabled == false ) Tx_j.Text = "";
        if (Tx_k.Enabled == false ) Tx_k.Text = "";
        if (Tx_l.Enabled == false ) Tx_l.Text = "";
        if (Tx_m.Enabled == false ) Tx_m.Text = "";
        if (Tx_n.Enabled == false ) Tx_n.Text = "";

        if (Tx_k.Enabled == false ) Tx_k.Text = "";


}
        private void InicialidaTxForma()
        {
            Tx_a.BackColor = Color.White; Tx_a.Enabled = false;
            Tx_b.BackColor = Color.White; Tx_b.Enabled = false;
            Tx_c.BackColor = Color.White; Tx_c.Enabled = false;
            Tx_d.BackColor = Color.White; Tx_d.Enabled = false;
            Tx_e.BackColor = Color.White; Tx_e.Enabled = false;
            Tx_f.BackColor = Color.White; Tx_f.Enabled = false;
            Tx_g.BackColor = Color.White; Tx_g.Enabled = false;
            Tx_h.BackColor = Color.White; Tx_h.Enabled = false;
            Tx_i.BackColor = Color.White; Tx_i.Enabled = false;
            Tx_j.BackColor = Color.White; Tx_j.Enabled = false;
            Tx_k.BackColor = Color.White; Tx_k.Enabled = false;
            Tx_l.BackColor = Color.White; Tx_l.Enabled = false;
            Tx_m.BackColor = Color.White; Tx_m.Enabled = false;
            Tx_n.BackColor = Color.White; Tx_n.Enabled = false;
        }

        private void Frm_ControlDimensional_Load(object sender, EventArgs e)
        {
            CargaDatos("2016750");
        }
    }
}

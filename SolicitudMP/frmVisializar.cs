using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.SolicitudMP
{
    public partial class frmVisializar : Form
    {
        string mUsuarioActivo = "";
        private CurrentUser mUserLog = new CurrentUser();
        public frmVisializar()
        {
            InitializeComponent();
        }


        private void PintaGrilla()
        {
        int i = 0;int lProd = 0;Clases.ClsComun lCom = new Clases.ClsComun();
            for (i = 0; i < Dtg_Datos.RowCount-1; i++)
            {
                if (lCom.Val (Dtg_Datos.Rows[i].Cells["producido"].Value.ToString()) == 100)
                {
                    Dtg_Datos.Rows[i].Cells["IdSol"].Style.BackColor  = Color.LightGreen;
                }


            }
        
        
        }

        public DataTable ObtenerSMP_PorTurno()
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient();
            DataSet lDts = new DataSet(); DataTable lTblTurno = new DataTable();
            int lHora = DateTime.Now.Hour; int lHInicio = 0; int lHFin = 0; int i = 0;
            string lTxTurno = ""; Clases.ClsComun lCom = new Clases.ClsComun();
            string lFechaIni = ""; string lFechaFin = "";
            lDts = lPx.ObtenerParametro("TurnoDia");
            lDts.Merge(lPx.ObtenerParametro("TurnoNoche"));
            if (lDts.Tables.Count > 0)
            {
                lTblTurno = lDts.Tables[0].Copy();

                for (i = 0; i < lTblTurno.Rows.Count; i++)
                {
                    lHInicio = lCom.Val(lTblTurno.Rows[i]["Par1"].ToString());
                    lHFin = lCom.Val(lTblTurno.Rows[i]["Par2"].ToString());
                    if (lTxTurno.Length == 0)
                    {
                        if ((lHora >= lHInicio) && (lHora <= lHFin))
                        {
                            lTxTurno = "Turno de Día";
                            lFechaIni = string.Concat(DateTime.Now.ToShortDateString(), " 07:59:59");
                            lFechaFin = string.Concat(DateTime.Now.ToShortDateString(), " 19:30:59");
                        }
                        else
                        {
                            lTxTurno = "Turno de Noche";
                            lFechaIni = string.Concat(DateTime.Now.AddDays(-1), " 20:00:01");
                            lFechaFin = string.Concat(DateTime.Now.ToShortDateString(), " 06:30:59");
                        }
                        Lbl_Msg.Text = Lbl_Msg.Text.Replace("@turno", lTxTurno);
                    }
                }

                WsOperacion.OperacionSoapClient lPXO = new WsOperacion.OperacionSoapClient();
                WsOperacion.ListaDataSet lListaDts = new WsOperacion.ListaDataSet();
                lListaDts = lPXO.ObtenerResumenSMP_PorTurno(lFechaIni, lFechaFin);
                if (lListaDts.MensajeError.Length == 0)
                                    lTblTurno= lListaDts.DataSet.Tables[0].Copy();

                }
            return lTblTurno;
            }

   
        public void IniciaFormulario(string lUsuario, CurrentUser iObjUsuario)
        {
            
            string lTxTurno = "";
            mUserLog = iObjUsuario;
            mUsuarioActivo = lUsuario;
            Lbl_Msg.Text = Lbl_Msg.Text.Replace("@User", lUsuario);
            //@User, en el Turno: @turno 

            Dtg_Datos.DataSource = ObtenerSMP_PorTurno();

      
                    Dtg_Datos.Columns["IdSol"].Width = 50;
                    Dtg_Datos.Columns["Soldable"].Width = 60;
                    Dtg_Datos.Columns["Codigo"].Width = 70;
                    Dtg_Datos.Columns["KgsSolicitados"].Width = 80;
                    Dtg_Datos.Columns["KgsRecep"].Width = 70;
                    Dtg_Datos.Columns["KgsProd"].Width = 70;
                    Dtg_Datos.Columns["KgsSaldo"].Width = 70;
                    Dtg_Datos.Columns["Producido"].Width = 70;
                    Dtg_Datos.Columns["BarrasSol"].Width = 70;
                    Dtg_Datos.Columns["BarrasRecep"].Width = 70;
                    //Dtg_Datos.Columns["Det_id"].Visible = false;



                    PintaGrilla();
              
            

        }

        private void Dtg_Datos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;
            Tx_Det_Id .Text  = Dtg_Datos.Rows[lIndex].Cells["Det_Id"].Value.ToString();
           

        }

        private void Btn_Dev_Click(object sender, EventArgs e)
        {
            SolicitudMP.FrmDevolucionMP lFrm = new FrmDevolucionMP();
            lFrm.IniciaForm(Tx_Det_Id .Text , mUserLog);
            lFrm.ShowDialog();
        }

        private void Dtg_Datos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex;
            Tx_Det_Id.Text = Dtg_Datos.Rows[lIndex].Cells["Det_Id"].Value.ToString();
        }
    }
}

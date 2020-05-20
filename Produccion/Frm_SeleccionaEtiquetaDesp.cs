using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Produccion
{
    public partial class Frm_SeleccionaEtiquetaDesp : Form
    {
        public Frm_SeleccionaEtiquetaDesp()
        {
            InitializeComponent();
        }

        private void Frm_SeleccionaEtiquetaDesp_Load(object sender, EventArgs e)
        {
            CargaDatos();
        }


        private void CargaDatos()
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = "";// string lPerfil = mUserLog.PerfilUsuario; string lMsg = "";
            DataTable lTblDatos = new DataTable();


            //Verificamos el estado de la averia
            lSql = string.Concat(" select * from to_parametros where subtabla='Diametro' ");
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblDatos = lDts.Tables[0].Copy();
                Cmb_Diam.SelectedValue = "par1";
                Cmb_Diam.ValueMember  = "par1";
                Cmb_Diam.DataSource = lTblDatos;
            }
        }

        private void BuscarDatos()
        {
            Ws_TO.Ws_ToSoapClient lPx = new Ws_TO.Ws_ToSoapClient(); DataSet lDts = new DataSet();
            string lSql = "";// string lPerfil = mUserLog.PerfilUsuario; string lMsg = "";
            DataTable lTblDatos = new DataTable();


            //Verificamos el estado de la averia
            lSql = string.Concat(" Select * from etiquetaAza where TipoEtiqueta='D'  and diametro=", Cmb_Diam .SelectedValue .ToString ());
            lDts = lPx.ObtenerDatos(lSql);
            if ((lDts.Tables.Count > 0) && (lDts.Tables[0].Rows.Count > 0))
            {
                lTblDatos = lDts.Tables[0].Copy();
                Dtg_Datos.DataSource = lTblDatos;

                Dtg_Datos.Columns["FechaFAbricacion"].Visible = false;
                Dtg_Datos.Columns["FechaInsert"].Visible = false;
                Dtg_Datos.Columns["IdColada"].Visible = false;
                Dtg_Datos.Columns["TramaEtiqueta"].Visible = false;
                Dtg_Datos.Columns["Id"].Visible = false;
                Dtg_Datos.Columns["Lote"].Visible = false;
                Dtg_Datos.Columns["paquete"].Visible = false;
                Dtg_Datos.Columns["TipoEtiqueta"].Visible = false;

                Dtg_Datos.Columns["Diametro"].Width = 60;
                Dtg_Datos.Columns["Largo"].Width = 40;
                Dtg_Datos.Columns["codigo"].Width = 80;

                Dtg_Datos.Columns["EsSoldable"].Width = 70;
                Dtg_Datos.Columns["procedencia"].Width = 70;
                Dtg_Datos.Columns["CalidadAcero"].Width = 80;

            }

        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("TramaET", "");
            this.Close();
        }

        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            BuscarDatos();
        }

        private void Dtg_Datos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex; int j = 0; int k = 0;
            if (i > -1)
            {
                for (k = 0; k < Dtg_Datos.RowCount; k++)
                {
                    for (j = 0; j < Dtg_Datos.ColumnCount; j++)
                    {
                        Dtg_Datos.Rows[k].Cells[j].Style.BackColor = Color.White;
                    }
                }

                for (j = 0; j < Dtg_Datos.ColumnCount; j++)
                {
                    Dtg_Datos.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;

                }
                //mLote = Dtg_Resultado.Rows[i].Cells["Lote"].Value.ToString();
                //mBulto = Dtg_Resultado.Rows[i].Cells["Paquete"].Value.ToString();
                Btn_Sel.Tag = e.RowIndex;
            }
        }

        private void Btn_Sel_Click(object sender, EventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun();string lTx = "";
            string lProducto = "";int lIndex = -1;string lLote = "";string lNroBulto = "";
            string lPesoBulto = "";string lCod = "";
            if (lCom.Val(Btn_Sel.Tag.ToString ()) > -1)
            {
                lIndex = lCom.Val(Btn_Sel.Tag.ToString());
                lProducto = Dtg_Datos.Rows[lIndex].Cells["Producto"].Value.ToString();
                lLote = Dtg_Datos.Rows[lIndex].Cells["Lote"].Value.ToString();
                lNroBulto = Dtg_Datos.Rows[lIndex].Cells["Paquete"].Value.ToString();
                  lPesoBulto  = Dtg_Datos.Rows[lIndex].Cells["PesoPaquete"].Value.ToString();
                lCod = Dtg_Datos.Rows[lIndex].Cells["Codigo"].Value.ToString();

               
                // lProducto = string.Concat("HORMIGON ", Tx_diametro.Text, "mm ", Tx_largo.Text, "m  A630-420H (N)");
              //  lTx = string.Concat(Tx_lote.Text, ";", DateTime.Now.ToShortDateString(), ";", Tx_nroBulto.Text, ";", lProducto, ";", lCod, "; ", Tx_PesoBulto.Text);

                lTx = string.Concat(lLote, ";", DateTime.Now.ToShortDateString(), ";", lNroBulto, ";", lProducto, ";", lCod, "; ", lPesoBulto);
                AppDomain.CurrentDomain.SetData("TramaET", lTx);
                this.Close();

            }

        }
    }
}

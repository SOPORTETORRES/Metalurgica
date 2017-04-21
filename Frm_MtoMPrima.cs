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
    public partial class Frm_MtoMPrima : Form
    {
        private DataTable mdatos = new DataTable();
        public Frm_MtoMPrima()
        {
            InitializeComponent();
            Clases.ClsComun lCom = new Clases.ClsComun();
            this.Text += " - versión: " + lCom.ObtenerVersion();  
        }


        internal void IniciaForm()
        {
            string lSql = "";
            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            DataTable lTblTipo = new DataTable(); DataTable lTblBodega = new DataTable();
            DataTable lTblDiam = new DataTable(); DataTable lTblDatos = new DataTable();

           //Cargamos los datos de los desplegables
            //Tipo
            //lTblTipo.Columns.Add("Tipo");

            lSql = "SP_CRUD_MateriaPrima 0,'','','','','',0,0,0,'','',2";
            listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
            lTblTipo = listaDataSet.DataSet.Tables[0].Copy();
            
            Cmb_Tipo.DataSource = lTblTipo;
            Cmb_Tipo.DisplayMember = "Tipo";
            Cmb_Tipo.ValueMember = "Tipo";
    //        ALTER PROCEDURE [SP_CRUD_MateriaPrima]       
    //@id int ,              //@Bodega Varchar(50),         //@Codigo Varchar(50),    //@Descripcion Varchar(200),	
    //@Tipo Varchar(1),	    //@NombreMedidas Varchar(50),	    //@Factor real,       //@Largo int,
    //@KgsEstimado real ,   // @Soldable Varchar(1),        //@vigente Varchar(1),    //@Opcion int 
            //Bodega
            lSql = "SP_CRUD_MateriaPrima 0,'','','','','',0,0,0,'','',3";
            listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
            lTblBodega = listaDataSet.DataSet.Tables[0].Copy();
            this.cmb_Bodega .DataSource = lTblBodega;
            cmb_Bodega.DisplayMember = "Bodega";
            cmb_Bodega.ValueMember = "Bodega";
            //Diámetro
            lSql = "SP_CRUD_MateriaPrima 0,'','','','','',0,0,0,'','',4";
            listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
            lTblDiam = listaDataSet.DataSet.Tables[0].Copy();
            Cmb_Diam.DataSource = lTblDiam;
            Cmb_Diam.DisplayMember = "Par1";
            Cmb_Diam.ValueMember = "Par1";

            //LLenamos la grilla
            lSql = "SP_CRUD_MateriaPrima 0,'','','','','',0,0,0,'','',5";
            listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
            mdatos = listaDataSet.DataSet.Tables[0].Copy();

            Dtg_Resultado.DataSource = mdatos;
            Dtg_Resultado.RowHeadersVisible = false;
            Dtg_Resultado.Columns[0].Width = 60;
            Dtg_Resultado.Columns[1].Width = 80;
            Dtg_Resultado.Columns[2].Width = 280;
            Dtg_Resultado.Columns[3].Width = 50;
            Dtg_Resultado.Columns[4].Width = 50;
            Dtg_Resultado.Columns[5].Width = 60;
            Dtg_Resultado.Columns[6].Width = 60;
            Dtg_Resultado.Columns[7].Width = 60;
            Dtg_Resultado.Columns[8].Width = 60;
            Dtg_Resultado.Columns[9].Width = 60;
        }

        private void PintaGrilla()
        {
            int i = 0; int j = 0;
            for (i = 0; i < Dtg_Resultado.RowCount-1; i++)
            {
                if (Dtg_Resultado.Rows[i].Cells["Vigente"].Value.ToString().ToUpper().Equals("S"))
                {
                    for (j = 0; j < Dtg_Resultado.ColumnCount; j++)
                    {
                        Dtg_Resultado.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                    }
                }
                else
                {
                    for (j = 0; j < Dtg_Resultado.ColumnCount; j++)
                    {
                        Dtg_Resultado.Rows[i].Cells[j].Style.BackColor = Color.LightSalmon ;
                    }
                }
            }

        }
        private void GrabaDatos()
        {

            string lSql = " exec SP_CRUD_MateriaPrima "; string lSoldable = "N"; string lVigente = "N";
            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();

            if (Chk_Soldable.Checked == true)
                lSoldable = "S";

            if (this.Chk_Vigente .Checked == true)
                lVigente = "S";

            if (this.Tx_Codigo.Tag.ToString ().Length ==0)
                Tx_Codigo.Tag = "0";

            lSql = string.Concat(lSql,Tx_Codigo .Tag, ",'",cmb_Bodega .SelectedValue ,"','",Tx_Codigo .Text ,"','");
            lSql = string.Concat(lSql, this.tx_descripcion .Text , "','", this.Cmb_Tipo .SelectedValue, "','");
            lSql = string.Concat(lSql, this.Cmb_Diam.SelectedValue, "','", this.tx_factor.Text, "','", this.tx_largo .Text,"','");
            lSql = string.Concat(lSql, this .tx_kilosEstimados .Text ,"','", lSoldable , "','",lVigente ,"',1");
            //            ALTER PROCEDURE [SP_CRUD_MateriaPrima]  
            //@id int ,         //@Bodega Varchar(50),          //@Codigo Varchar(50),       //@Descripcion Varchar(200),  
            //@Tipo Varchar(1),  //@NombreMedidas Varchar(50),  //@Factor real,  
            //@Largo int,       //@KgsEstimado real ,           //@Soldable Varchar(1),        //@vigente Varchar(1),  
            //@Opcion int  
            listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
            listaDataSet.MensajeError="";
            if (listaDataSet.MensajeError.Trim().Length > 0)
                MessageBox.Show("Ha ocurrido el siguiente Error: " + listaDataSet.MensajeError.ToString(), "Avisos Sistema"); 
            //, "Avisos Sistema", MessageBoxButtons.OK );
            //lTblDatos = listaDataSet.DataSet.Tables[0].Copy();

        }



        private void Btn_Grabar_Click(object sender, EventArgs e)
        {
            if (ValidaDatosAntesDeGrabar ()==true )
            {
                GrabaDatos();
                IniciaForm();
                PintaGrilla();
            }
        }

        private bool ValidaDatosAntesDeGrabar()
        {
            bool lEstaOK = true; string lMsg = "";
            if (Tx_Codigo .Text .Trim ().Length ==0)
            {
                lEstaOK = false;
                lMsg = string.Concat(lMsg, "Debe Indicar un Valor para el Código, Revisar",Environment .NewLine );
            }
            if (this.tx_descripcion .Text.Trim().Length == 0)
            {
                lEstaOK = false;
                lMsg = string.Concat(lMsg, "Debe Indicar un Valor para la Descrpción, Revisar", Environment.NewLine);
            }
            if (this.tx_largo .Text.Trim().Length == 0)
            {
                lEstaOK = false;
                lMsg = string.Concat(lMsg, "Debe Indicar un Valor para el Largo, Revisar", Environment.NewLine);
            }
            if (this.tx_kilosEstimados.Text.Trim().Length == 0)
            {
                lEstaOK = false;
                lMsg = string.Concat(lMsg, "Debe Indicar un Valor para los Kilos Estimados, Revisar", Environment.NewLine);
            }
            if (lMsg .Length >0)
            {
                MessageBox.Show(lMsg, "Avisos Sistema");
            }

            return lEstaOK;
        }

        private void Frm_MtoMPrima_Load(object sender, EventArgs e)
        {
            this.Tx_Codigo.Tag="0";
            IniciaForm();
            PintaGrilla();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dtg_Resultado_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow lFila = Dtg_Resultado.CurrentRow;

            Tx_Codigo.Text = lFila.Cells["Codigo"].Value.ToString();
            Tx_Codigo.Tag  = lFila.Cells["Id"].Value.ToString();
            this.tx_descripcion.Text = lFila.Cells["Descripcion"].Value.ToString();
            this.tx_factor.Text = lFila.Cells["Factor"].Value.ToString();
            this.tx_kilosEstimados.Text = lFila.Cells["KgsEstimado"].Value.ToString();
            this.tx_largo.Text = lFila.Cells["Largo"].Value.ToString();
            cmb_Bodega.SelectedValue = lFila.Cells["Bodega"].Value.ToString();
            this.Cmb_Tipo .SelectedValue = lFila.Cells["Tipo"].Value.ToString();
            this.Cmb_Diam .SelectedValue = lFila.Cells["Diam"].Value.ToString().Trim ();

            if (lFila.Cells["Soldable"].Value.ToString().Trim().ToUpper().Equals("S"))
                Chk_Soldable .Checked =true ;
            else
                Chk_Soldable .Checked =false  ;

            
            if (lFila.Cells["Vigente"].Value.ToString().Trim().ToUpper().Equals("S"))
                this.Chk_Vigente .Checked = true;
            else
                Chk_Vigente.Checked = false;

            Btn_Elimina.Enabled = true;

        }


        private void Limpiar()
        {
            Tx_Codigo.Text = "";
            this.tx_descripcion .Text = "";
            this.tx_factor .Text = "0";
            this.tx_kilosEstimados .Text = "0";
            this.tx_largo.Text = "0";

            Btn_Elimina.Enabled = false;

        }



        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Btn_Elimina_Click(object sender, EventArgs e)
        {
            int lId=0;
            if (Tx_Codigo .Tag .ToString().Trim ().Length >0 )
            {
                lId = int.Parse(Tx_Codigo.Tag.ToString());
                VerificaAntesDeEliminar(lId);
                Limpiar();
                IniciaForm();
                Btn_Elimina.Enabled = false;
            }
                
        }


        private void VerificaAntesDeEliminar(int iIdMP)
        {
            int lNroReg = 0;
            Ws_TO.Ws_ToSoapClient ldal = new Ws_TO.Ws_ToSoapClient();
            WsOperacion.ListaDataSet listaDataSet = new WsOperacion.ListaDataSet();
            string lSql = " exec SP_CRUD_MateriaPrima ";
            lSql = string.Concat(lSql, Tx_Codigo.Tag, ",'','','','','','0','0','0','','',6");

            listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
            listaDataSet.MensajeError = "";
            if (listaDataSet.MensajeError.ToString ().Trim().Length > 0)
                MessageBox.Show("Ha ocurrido el siguiente Error: " + listaDataSet.MensajeError.ToString(), "Avisos Sistema");
            else
            {
                if (listaDataSet.DataSet.Tables.Count > 0)
                {
                    lNroReg = int.Parse(listaDataSet.DataSet.Tables[0].Rows[0][0].ToString());
                    if (lNroReg > 0)
                    {
                        //mensaje al usuario 
                        MessageBox.Show("El registro seleccionado no se puede eliminar ya que tienen coladas vinculadas");
                    }
                    else
                    {
                         lSql = " exec SP_CRUD_MateriaPrima ";
                        lSql = string.Concat(lSql, Tx_Codigo.Tag, ",'','','','','','0','0','0','','',7");
                        listaDataSet.DataSet = ldal.ObtenerDatos(lSql);
                        listaDataSet.MensajeError = "";
                        if (listaDataSet.MensajeError.Trim().Length > 0)
                            MessageBox.Show("Ha ocurrido el siguiente Error: " + listaDataSet.MensajeError.ToString(), "Avisos Sistema");
                        else
                        {
                            if (listaDataSet.DataSet.Tables.Count > 0)
                            {
                                if (listaDataSet.DataSet.Tables[0].Rows.Count > 0)
                                {
                                    if (listaDataSet.DataSet.Tables[0].Rows[0][0].ToString().ToUpper().Equals("OK") == true)
                                    {
                                        MessageBox.Show("Los datos se han eliminado correctamente  " , "Avisos Sistema");
                                    }
                                }
                            }
                        }
                    }

                }

               //
              
            }
        }

        private void Rb_Vigente_CheckedChanged(object sender, EventArgs e)
        {
            string lFiltro = ""; DataView lVista = null;

            if (Rb_Vigente.Checked == true)
            {
                lFiltro = "Vigente='S'";
                lVista = new DataView(mdatos, lFiltro, "", DataViewRowState.CurrentRows);
                Dtg_Resultado.DataSource = lVista;
            }



        }

        private void Rb_NoVigente_CheckedChanged(object sender, EventArgs e)
        {
            string lFiltro = ""; DataView lVista = null;

            if (Rb_NoVigente.Checked == true)
            {
                lFiltro = "Vigente='N'";
                lVista = new DataView(mdatos, lFiltro, "", DataViewRowState.CurrentRows);
                Dtg_Resultado.DataSource = lVista;
            }

        }

        private void Rb_Todos_CheckedChanged(object sender, EventArgs e)
        {
            if (Rb_Todos.Checked == true)
            {
                Dtg_Resultado.DataSource = mdatos;
                PintaGrilla();
            }
        }


    }
}

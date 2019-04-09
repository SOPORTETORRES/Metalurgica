using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Metalurgica.Conectores
{
    public partial class Frm_ProduccionConectores : Form
    {
        private CurrentUser mUserLog = new CurrentUser();
        private string mIdMaqSel = "";
        private string mNombre_MaqSel = "";
        private CurrentUser mUserLog_Frm = new CurrentUser();
        private DataTable mTblDatos = new DataTable();
        private string mIdPaquete = "";
        private string mIdPiezaTipoB = "";

        public Frm_ProduccionConectores()
        {
            InitializeComponent();
        }

        public void IniciaFormulario(CurrentUser iUserLog)
        {
            mUserLog = iUserLog;
            //CargarMaquinas();
            //ctlProduccion1.IniciaFormulario(iUserLog);
            RefrescaFormulario();
        }

        private void CargaConectoresEnProduccion()
        {
            Clases.ClsComun lDal = new Clases.ClsComun(); DataTable lTbl = new DataTable();

            int i = 0;

            lTbl = lDal.CargaTabla_ConectoresEnProduccion();

            Dtg_EnProceso.DataSource = lTbl;
            if (lTbl.Rows.Count > 0)
            {
                Dtg_EnProceso.Columns["IdPiezaTipoB"].Visible = false;
                Dtg_EnProceso.Columns["IdMaquina"].Visible = false;
                Dtg_EnProceso.Columns["FechaFin"].Visible = false;
                Dtg_EnProceso.Columns["Id"].Visible = false;
                Dtg_EnProceso.Columns["IdUsuario"].Visible = false;
                Dtg_EnProceso.Columns["IdPaquete"].Visible = false;
                Dtg_EnProceso.Columns["Obs"].Visible = false;
                Dtg_EnProceso.Columns["MaqProd"].Width = 70;
                Dtg_EnProceso.Columns["Imagen"].Width = 220;

                Dtg_EnProceso.Columns["Etiqueta"].Width = 70;
                Dtg_EnProceso.Columns["FechaInicio"].Width = 70;
                Dtg_EnProceso.Columns["Estado"].Width = 70;
            }

            //Dtg_EnProceso.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //DataGridViewColumn col = new DataGridViewColumn() ;
            //    col=Dtg_EnProceso.Columns["MAqProd"];
            ////Ajustamos la celda a su contenido.
            //col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //// Especificamos el ancho de la columna
            //col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CargarMaquinas()
        {
            Clases.ClsComun lDal = new Clases.ClsComun(); DataTable lTbl = new DataTable();
            int i = 0; string lVersion = lDal.ObtenerVersionProduccion();

            this.Text = string.Concat("Formulario de registro de producción multi máquina (Versión ", lVersion, ")");
            string lMultiMaq = "S";

            if (lMultiMaq.ToUpper().Equals("S"))
                lTbl = lDal.CargaTabla_MUltiMaquinasConectores();
            //else
            //    lTbl = lDal.CargaTabla_Maquinas();


            for (i = 0; i < lTbl.Rows.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        Btn_Maquina1.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina1.Visible = true; Btn_Maquina1.Tag = lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if ((lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET")))
                        {
                            Btn_Maquina1.BackColor = Color.LightSalmon;
                            Btn_Maquina1.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }
                        else
                             if ((lTbl.Rows[i]["EnProduccion"].ToString().ToUpper().Equals("S")))
                            {
                                Btn_Maquina1.BackColor = Color.LightSalmon;
                                Btn_Maquina1.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (En PRODUCCIÓN)");
                            }
                            else
                                Btn_Maquina1.BackColor = Color.LightGreen;

                        break;
                    case 1:
                        Btn_Maquina2.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina2.Visible = true; Btn_Maquina2.Tag = lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))
                        {
                            Btn_Maquina2.BackColor = Color.LightSalmon;
                            Btn_Maquina2.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }

                        else 
                            if ((lTbl.Rows[i]["EnProduccion"].ToString().ToUpper().Equals("S")))
                            {
                                Btn_Maquina2.BackColor = Color.LightSalmon;
                                Btn_Maquina2.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (En PRODUCCIÓN)");
                            }
                            else
                                Btn_Maquina2.BackColor = Color.LightGreen;

                        break;
                    case 2:
                        Btn_Maquina3.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina3.Visible = true; Btn_Maquina3.Tag = lTbl.Rows[i]["MAQ_NRO"].ToString(); ;

                        if (lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))
                        {
                            Btn_Maquina3.BackColor = Color.LightSalmon;
                            Btn_Maquina3.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }

                        else
                             if ((lTbl.Rows[i]["EnProduccion"].ToString().ToUpper().Equals("S")))
                            {
                                Btn_Maquina3.BackColor = Color.LightSalmon;
                                Btn_Maquina3.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (En PRODUCCIÓN)");
                            }
                            else
                                Btn_Maquina3.BackColor = Color.LightGreen;

                        break;
                    case 3:
                        Btn_Maquina4.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina4.Visible = true; Btn_Maquina4.Tag = lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))
                        {
                            Btn_Maquina4.BackColor = Color.LightSalmon;
                            Btn_Maquina4.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }
                        else
                             if ((lTbl.Rows[i]["EnProduccion"].ToString().ToUpper().Equals("S")))
                        {
                            Btn_Maquina4.BackColor = Color.LightSalmon;
                            Btn_Maquina4.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (En PRODUCCIÓN)");
                        }
                        else
                            Btn_Maquina4.BackColor = Color.LightGreen;

                        break;
                    case 4:
                        Btn_Maquina5.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina5.Visible = true; Btn_Maquina5.Tag = lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))
                        {
                            Btn_Maquina5.BackColor = Color.LightSalmon;
                            Btn_Maquina5.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }
                        else
                             if ((lTbl.Rows[i]["EnProduccion"].ToString().ToUpper().Equals("S")))
                        {
                            Btn_Maquina5.BackColor = Color.LightSalmon;
                            Btn_Maquina5.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (En PRODUCCIÓN)");
                        }
                        else
                            Btn_Maquina5.BackColor = Color.LightGreen;

                        break;
                    case 5:
                        Btn_Maquina6.Text = lTbl.Rows[i]["MAQ_NOMBRE"].ToString();
                        Btn_Maquina6.Visible = true; Btn_Maquina6.Tag = lTbl.Rows[i]["MAQ_NRO"].ToString();

                        if (lTbl.Rows[i]["MAQBloqueada"].ToString().ToUpper().Equals("DET"))
                        {
                            Btn_Maquina6.BackColor = Color.LightSalmon;
                            Btn_Maquina6.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (BLOQUEADA)");
                        }
                        else
                             if ((lTbl.Rows[i]["EnProduccion"].ToString().ToUpper().Equals("S")))
                        {
                            Btn_Maquina6.BackColor = Color.LightSalmon;
                            Btn_Maquina6.Text = string.Concat(lTbl.Rows[i]["MAQ_NOMBRE"].ToString(), " (En PRODUCCIÓN)");
                        }
                        else
                            Btn_Maquina6.BackColor = Color.LightGreen;

                        break;
                    
                }

            }



        }

        private void Btn_Maquina1_Click(object sender, EventArgs e)
        {
            
                Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina1.Text, " - ", Btn_Maquina1.Tag.ToString());
                mIdMaqSel = Btn_Maquina1.Tag.ToString();
                mNombre_MaqSel = Btn_Maquina1.Text;
                Btn_MaquinaActiva.Tag = Btn_Maquina1.Tag;
               //' HabilitaControlParaLectura(true);
                CargarMaquinas();
           
        }

        private void Btn_Fin_Click(object sender, EventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun(); DataTable lTbl = new DataTable();
            lTbl = lCom.FinProduccionConectores(txtEtiquetaPieza .Tag.ToString () ,mIdPiezaTipoB,  Tx_Obs.Text);
            //(string idPaquete, string idPiezaTipoB, int idMaquina, string iUser, string iObs)
            if ((lTbl.Rows.Count > 0) && (lCom.Val(lTbl.Rows[0][0].ToString()) > 0))
            {
                MessageBox.Show("Los Datos se han grabado Correctamente", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            RefrescaFormulario();
            LimpiaDatos();
        }

        //private void RegistraProduccionConector(string idPaquete , string idPiezaTipoB, int idMaquina, string  iUser, string  iObs, string iTipo)
        //{
        //    Clases.ClsComun lCom = new Clases.ClsComun();DataTable lTbl = new DataTable();

        //    if (iTipo.ToUpper().Equals("I"))
        //    {
        //        lTbl = lCom.InicioProduccionConectores(idPaquete, idPiezaTipoB, idMaquina, iUser, iObs);

        //        if (lTbl.Rows .Count >0)
        //        {
        //            MessageBox.Show("Los datos fueron Grabados Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    if (iTipo.ToUpper().Equals("I"))
        //    {
        //        lTbl = lCom.InicioProduccionConectores(idPaquete, idPiezaTipoB, idMaquina, iUser, iObs);

        //        if (lTbl.Rows.Count > 0)
        //        {
        //            MessageBox.Show("Los datos fueron Grabados Correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //}


       

        private void txtEtiquetaPieza_Validated(object sender, EventArgs e)
        {
            CargaDatosPaquete(txtEtiquetaPieza.Text);
        }
        private void CargaDatosPaquete(string idPaquete)
        {
            Px_Conectores.Ws_ConectoresSoapClient lDal = new Px_Conectores.Ws_ConectoresSoapClient();
            Px_Conectores.ListaDataSet lRes = new Px_Conectores.ListaDataSet(); DataSet lDts = new DataSet();
            DataTable lTblConectores = new DataTable(); int i = 0;string lTxCon = ""; DataTable lTblConector = new DataTable();
            DataTable lTblDatos = new DataTable(); Byte[] lImg = null;

            lRes = lDal.ObtenerDatosParaProduccionConector(idPaquete);

            if ((lRes.MensajeError.Trim().Length == 0) && (lRes.DataSet .Tables .Count >0))
            {
                lDts = lRes.DataSet;
                if (lDts.Tables["Conectores"] != null)
                {
                    lTblConectores = lDts.Tables["Conectores"].Copy();
                    if (lTblConectores.Rows.Count > 0)
                    {
                        for (i = 0; i < lTblConectores.Rows.Count; i++)
                        {
                            lTxCon = string.Concat(lTblConectores.Rows[i]["Descipcion"].ToString(), " , ", lTxCon);
                        }
                        Tx_Conector.Text = lTxCon;
                    }
                }

                
                if (lDts.Tables["ProduccionConector"] != null)
                {
                    lTblConector = lDts.Tables["ProduccionConector"].Copy();
                    if (lTblConector.Rows.Count > 0)
                    {
                        Tx_Obs.Text = lTblConector.Rows[0]["Obs"].ToString();

                        if ((lTblConector.Rows[0]["FechaInicio"].ToString().Trim().Length > 0) && (lTblConector.Rows[0]["FechaFin"].ToString().Trim().Length == 0))
                        {  // Esta en proceso de produccion el conector, se debe habilitar la opción Finalizar
                            Btn_Fin.Enabled = true;
                            Btn_Inicio.Enabled = false;
                            Lbl_Msg.Text = " Puede Finalizar la Produccion de los conectores ";
                            txtEtiquetaPieza.Tag = lTblConector.Rows[0]["Id"].ToString();
                        }

                        if ((lTblConector.Rows[0]["FechaInicio"].ToString().Trim().Length > 0) && (lTblConector.Rows[0]["FechaFin"].ToString().Trim().Length > 0))
                        {  // Ya se produjo el conector, no se debe habilitar ningun boton
                            Btn_Fin.Enabled = false;
                            Btn_Inicio.Enabled = false;
                            Lbl_Msg.Text = string.Concat (" La producción de los Conectores se encuentra Finalizada, con fecha ", lTblConector.Rows[0]["FechaFin"].ToString()) ;
                        }

                    }
                    else
                    {   // NO hay registros de produccion de conectores Habilitar la Opcion de Iniciar Produccion
                        Btn_Fin.Enabled = false;
                        Btn_Inicio.Enabled = true;
                        Lbl_Msg.Text = " Puede Iniciar  la Produccion de los conectores ";
                    }
                }

                    if (lDts.Tables["Pieza"] != null)
                {
                    lTblDatos = lDts.Tables["Pieza"].Copy();
                    if (lTblDatos.Rows.Count > 0)
                    {
                        Tx_Diametro.Text = lTblDatos.Rows[0]["Diametro"].ToString();
                        Tx_Cantidad.Text = lTblDatos.Rows[0]["NroPiezas"].ToString();
                        lImg = (Byte[]) lTblDatos.Rows[0]["Imagen"];
                        Bitmap imagen = null;
                        MemoryStream ms = new MemoryStream(lImg);

                        imagen = new Bitmap(ms);
                        Pic_Pieza.Image = imagen;

                        if (lTblDatos.Rows[0]["EstadoProd"].ToString() != "O40")
                        {
                            Lbl_Msg.Text = " No se puede Producir el conector ya que la Pieza no ha sido Cortada y/o Doblada ";
                            Btn_Inicio.Enabled = false;
                            Btn_Fin.Enabled = false;
                            mIdPaquete = "";
                            mIdPiezaTipoB = "";
                        }
                        else
                        {
                            //Lbl_Msg.Text = " Puede Producir el conector ";
                            //Btn_Inicio.Enabled = true;
                            //Btn_Fin.Enabled = true ;
                            mIdPaquete = txtEtiquetaPieza.Text;
                            mIdPiezaTipoB = lTblDatos.Rows[0]["IdPiezaTipoB"].ToString();
    }
                    }
                }

            }


        }

        private void Btn_Inicio_Click(object sender, EventArgs e)
        {
            Clases.ClsComun lCom = new Clases.ClsComun(); DataTable lTbl = new DataTable();

            if (lCom.Val(Btn_MaquinaActiva.Tag.ToString()) < 0)
            {
                MessageBox.Show("Debe Seleccionar una Maquina Antes de Iniciar la Producción de los Conectores", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lTbl = lCom.InicioProduccionConectores(mIdPaquete, mIdPiezaTipoB, lCom.Val(mIdMaqSel.ToString()), mUserLog.Iduser.ToString(), Tx_Obs.Text);
                //(string idPaquete, string idPiezaTipoB, int idMaquina, string iUser, string iObs)
                if ((lTbl.Rows.Count > 0) && (lCom.Val(lTbl.Rows[0][0].ToString()) > 0))
                {
                    MessageBox.Show("Los Datos se han grabado Correctamente", "Avisos Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                RefrescaFormulario();
                LimpiaDatos();
            }
            


        
        }


        private void LimpiaDatos()
        {
            txtEtiquetaPieza.Text = "";
            Tx_Conector.Text = "";
            Tx_Cantidad.Text = "";
            Tx_Diametro.Text = "";
            Tx_Obs.Text = "";
            Lbl_Msg.Text = "";
            Pic_Pieza.Image = null;

        }


        private void RefrescaFormulario()
        {
            // Cargamos la grilla de producciones actuales
            CargaConectoresEnProduccion();
            // revisamos las maquinas y bloqueamos las que tienen producciones pendientes
            CargarMaquinas();

            // inicializamos los datos de produccion de conectores

        }

        private void txtEtiquetaPieza_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Maquina2_Click(object sender, EventArgs e)
        {
            Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina2.Text, " - ", Btn_Maquina2.Tag.ToString());
            mIdMaqSel = Btn_Maquina2.Tag.ToString();
            mNombre_MaqSel = Btn_Maquina2.Text;
            Btn_MaquinaActiva.Tag = Btn_Maquina2.Tag;
            //' HabilitaControlParaLectura(true);
            CargarMaquinas();
        }

        private void Btn_Maquina3_Click(object sender, EventArgs e)
        {
            Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina3.Text, " - ", Btn_Maquina3.Tag.ToString());
            mIdMaqSel = Btn_Maquina3.Tag.ToString();
            mNombre_MaqSel = Btn_Maquina3.Text;
            Btn_MaquinaActiva.Tag = Btn_Maquina3.Tag;
            //' HabilitaControlParaLectura(true);
            CargarMaquinas();
        }

        private void Btn_Maquina4_Click(object sender, EventArgs e)
        {
            Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina4.Text, " - ", Btn_Maquina4.Tag.ToString());
            mIdMaqSel = Btn_Maquina4.Tag.ToString();
            mNombre_MaqSel = Btn_Maquina4.Text;
            Btn_MaquinaActiva.Tag = Btn_Maquina4.Tag;
            //' HabilitaControlParaLectura(true);
            CargarMaquinas();
        }

        private void Btn_Maquina5_Click(object sender, EventArgs e)
        {
            Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina5.Text, " - ", Btn_Maquina5.Tag.ToString());
            mIdMaqSel = Btn_Maquina5.Tag.ToString();
            mNombre_MaqSel = Btn_Maquina5.Text;
            Btn_MaquinaActiva.Tag = Btn_Maquina5.Tag;
            //' HabilitaControlParaLectura(true);
            CargarMaquinas();
        }

        private void Btn_Maquina6_Click(object sender, EventArgs e)
        {
            Btn_MaquinaActiva.Text = String.Concat(Btn_Maquina6.Text, " - ", Btn_Maquina6.Tag.ToString());
            mIdMaqSel = Btn_Maquina6.Tag.ToString();
            mNombre_MaqSel = Btn_Maquina6.Text;
            Btn_MaquinaActiva.Tag = Btn_Maquina6.Tag;
            //' HabilitaControlParaLectura(true);
            CargarMaquinas();
        }

        private void Dtg_EnProceso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int lIndex = e.RowIndex; string lIdPc = "";
            if (lIndex > -1)
            {
                lIdPc = Dtg_EnProceso.Rows[lIndex].Cells["idPaquete"].Value.ToString();
                txtEtiquetaPieza.Text = lIdPc;
                CargaDatosPaquete(txtEtiquetaPieza.Text);
            }
           
        }
    }
          

        }




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text.pdf;

namespace Metalurgica.Code128
{
    public partial class FrmGeneraCode128 : Form
    {

        public enum Code128SubTypes
        {
            //CODABAR = iTextSharp.text.pdf.Barcode.CODABAR
            CODE128 = iTextSharp.text.pdf.Barcode.CODE128,
            CODE128_RAW = iTextSharp.text.pdf.Barcode.CODE128_RAW,
            CODE128_UCC = iTextSharp.text.pdf.Barcode.CODE128_UCC,

        };

        public FrmGeneraCode128()
        {
            InitializeComponent();
        }

        private void FrmGeneraCode128_Load(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Code128("1MK22100510-2210_MB002RR28001", PrintTextInCode: true, Height: 100);

        }

        public static Bitmap Code128(string _code, Code128SubTypes codeType = Code128SubTypes.CODE128, bool PrintTextInCode = false, float Height = 0, bool GenerateChecksum = true, bool ChecksumText = true)
        {
            if (_code.Trim() == "")
            {
                return null;
            }
            else
            {
                Barcode128 barcode = new Barcode128();

                barcode.CodeType = (int)codeType;
                barcode.StartStopText = true;
                barcode.GenerateChecksum = GenerateChecksum;
                barcode.ChecksumText = ChecksumText;
                if (Height != 0) barcode.BarHeight = Height;
                barcode.Code = _code;
                try
                {
                    System.Drawing.Bitmap bm = new System.Drawing.Bitmap(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
                    if (PrintTextInCode == false)
                    {
                        return bm;
                    }
                    else
                    {
                        Bitmap bmT;
                        bmT = new Bitmap(bm.Width, bm.Height + 14);
                        Graphics g = Graphics.FromImage(bmT);
                        g.FillRectangle(new SolidBrush(Color.White), 0, 0, bm.Width, bm.Height + 14);

                        Font drawFont = new Font("Arial", 8);
                        SolidBrush drawBrush = new SolidBrush(Color.Black);

                        SizeF stringSize = new SizeF();
                        stringSize = g.MeasureString(_code, drawFont);
                        float xCenter = (bm.Width - stringSize.Width) / 2;
                        float x = xCenter;
                        float y = bm.Height;

                        StringFormat drawFormat = new StringFormat();
                        drawFormat.FormatFlags = StringFormatFlags.NoWrap;

                        g.DrawImage(bm, 0, 0);
                        g.DrawString(_code, drawFont, drawBrush, x, y, drawFormat);

                        return bmT;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error generating code128 barcode. Desc:" + ex.Message);
                }
            }
        }

    }
}

using System;
using System.Windows.Forms;
using Patagames.Ocr;
using System.Drawing;

namespace ImageRecognition
{
    public partial class ImageRecognition : Form
    {
        public ImageRecognition()
        {
            InitializeComponent();
        }

        private void outPut_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string openstrFilename;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Image image;
            Bitmap bitmap = null;

            openFileDialog.Title = "이미지 읽기";
            openFileDialog.Filter = "All Files(*.*)|*.*|Bitmap File(*.bmp)|*.bmp|JPEG File(*.jpg)|*.jpg";

            // 다이얼로그의 확인 처리
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                openstrFilename = openFileDialog.FileName;
                image = Image.FromFile(openstrFilename);
                bitmap = new Bitmap(image);
            }
            else
            {
                return;
            }
            outPut.Text = onTesseract(bitmap);
        }

        private string onTesseract(Bitmap bitmap)
        {
            try
            {
                using (var objOcr = OcrApi.Create())
                {
                    objOcr.Init(Patagames.Ocr.Enums.Languages.English);

                    string output = objOcr.GetTextFromImage(bitmap);
                    return output;
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            characterPicture.BackgroundImageLayout = ImageLayout.Stretch;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Character");
            CharacterManager.directoryPath = path;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            int side = 1000;
            characterPicture.BackgroundImage = new Bitmap(side, side);
            Graphics graph = Graphics.FromImage(characterPicture.BackgroundImage);
            graph.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle rect = new Rectangle(0, 0, side, side);

            CharacterManager manager = new CharacterManager();
            var character = manager.GetRandomCharacter();
            var elements = character.GetElements().ToList();

            foreach (var element in elements)
            {
                var image = Image.FromFile(element);
                graph.DrawImage(image, rect);
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (characterPicture.BackgroundImage != null)
            {

                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";

                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        characterPicture.BackgroundImage.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

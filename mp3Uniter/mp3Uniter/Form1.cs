using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mp3Uniter
{

    public partial class Form1 : Form
    {
        List<byte> allBytes = new List<byte>();
        Queue<string> fileNames = new Queue<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Add_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            MessageBox.Show(files[0]);
        }

        private void Btn_Add_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        public string TakeFile()
        {
            OpenFileDialog source = new OpenFileDialog();

            if ((source.ShowDialog()) == DialogResult.OK)
            {
                return source.FileName;
            }
            else
            {
                return null;
            }

        }

        static void Unioner(Queue<string> names)
        {
            bool activate = false;
            string fileToRead = names.Dequeue();

            using (FileStream writer = new FileStream(@"C:\Users\DESKTOP PC\Desktop\as\okay.mp3", FileMode.Create))
            {
                while (names.Count > 0)
                {
                    if (activate)
                    {
                        fileToRead = names.Dequeue();
                    }

                    using (FileStream reader = new FileStream(fileToRead, FileMode.Open))
                    {
                        byte[] buffer = new byte[(int)Math.Pow((double)2,20)];

                        while (true)
                        {
                            int readedBytes = reader.Read(buffer, 0, buffer.Length);


                            if (readedBytes == 0)
                            {
                                activate = true;
                                break;
                            }

                            if (readedBytes < buffer.Length)
                            {
                                buffer = buffer.Take(readedBytes).ToArray();
                            }

                            writer.Write(buffer, 0, buffer.Length);
                        }

                    }
                }
            }
        }

        public bool InputValidator(string input)
        {
            bool inputValidator = false;

            Regex mp3InputValidator = new Regex(@"^[\w\D]*\.mp3");

            if (mp3InputValidator.IsMatch(input))
            {
                inputValidator = true;
            }

            if (inputValidator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            string fileName = TakeFile();
            if (InputValidator(fileName))
            {
                Btn_Add.Text = fileName;
                fileNames.Enqueue(fileName);
            }
            else
            {
                MessageBox.Show("Невалидно съдържание! Програмата обединява само файлове с .mp3 удължения!"
                    , "ГРЕШКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Unioner(fileNames);
        }
    }
}

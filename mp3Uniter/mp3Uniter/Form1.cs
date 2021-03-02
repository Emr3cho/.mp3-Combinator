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
        Queue<string> fileNames = new Queue<string>();
        decimal size = 0;
        int added = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_render_Click(object sender, EventArgs e)
        {
            Combinator(fileNames, SaveWay());
            Btn_render.Enabled = false;
            size = 0;
            added = 0;
            info.ForeColor = Color.Green;
            info.Text = "Готово!";
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

        public bool InputValidator(string input)
        {
            if (input == null)
            {
                return false;
            }

            bool inputValidator = false;

            Regex mp3InputValidator = new Regex(@"^[\w\D]+\.mp3");

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

        static void Combinator(Queue<string> names, string saveWay)
        {
            bool activate = false;
            string fileToRead = names.Dequeue();

            using (FileStream writer = new FileStream(saveWay, FileMode.Create))
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
       
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            info.ForeColor = Color.Black;
            string fileName = TakeFile();
            if (InputValidator(fileName))
            {            
                added++;
                fileNames.Enqueue(fileName);
                size += FileSize(fileName);
                info.Text = $"Добавени {added} песни - Общо {size / 1024 / 1024:F02}MB";
                if (added > 1)
                {
                    Btn_render.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Невалидно съдържание! Програмата обединява само файлове с .mp3 удължения!"
                    , "ГРЕШКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static long FileSize(string path)
        {
            FileInfo size = new FileInfo(path);
            long currentSize = size.Length;
            return currentSize;        
        }

        static string SaveWay()
        {
            string extension = "\\result.mp3";
            string saveWay = string.Empty;
            
            using (FolderBrowserDialog fdb = new FolderBrowserDialog() { Description = "Моля изберете път за записване!" })
            {
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    saveWay = fdb.SelectedPath;
                }
                else
                {
                    while (saveWay == string.Empty)
                    {
                        MessageBox.Show("Моля изберете път за записване!", "ВНИМАНИЕ!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if (fdb.ShowDialog() == DialogResult.OK)
                        {
                            saveWay = fdb.SelectedPath;
                        }
                    }
                }

                string fullSaveWay = saveWay + extension;
                return fullSaveWay;
            }
        }    
    }
}

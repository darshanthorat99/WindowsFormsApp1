using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        FileStream fs;
        BinaryWriter bw;
        BinaryReader br;
        StreamWriter sw;
        StreamReader sr;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnbinarywrite_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\emp.dat", FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);
                bw.Write(Convert.ToInt32(txtid.Text));
                bw.Write(txtname.Text);
                bw.Write(Convert.ToDouble(txtsalary.Text));
                MessageBox.Show("Data added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bw.Close();
                fs.Close();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                fs = new FileStream(@"D:\Tesla\emp.dat", FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                txtid.Text = br.ReadInt32().ToString();
                txtname.Text = br.ReadString();
                txtsalary.Text = br.ReadDouble().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                br.Close();
                fs.Close();
            }


        }

        private void btncreatefolder_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\Tesla";
                if (Directory.Exists(path))
                {
                    MessageBox.Show("Folder exists");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Folder created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btncreatefile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\Tesla\sample.txt";
                if (File.Exists(path))
                {
                    MessageBox.Show("File exits");
                }
                else
                {
                    File.Create(path);
                    MessageBox.Show("File created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnstreamwrite_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\test.txt", FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(richTextBox1.Text);
                MessageBox.Show("Done !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }


        }

        private void btnstreamread_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\test.txt", FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                richTextBox1.Text = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sr.Close();
                fs.Close();
            }


        }
    }
}

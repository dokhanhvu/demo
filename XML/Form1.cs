using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace XML
{
    public partial class Form1 : Form
    {
        string[] filePahts = new string[100];
        string filePahts2;
        List<string> AtributesName = new List<string>();
        List<List<string>> Value = new List<List<string>>();
        Label[] lbl = new Label[6];
        TextBox[] tbx = new TextBox[6];

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 6; i++)
            {
                lbl[i] = new Label();
                tbx[i] = new TextBox();
                lbl[i].Hide();
                tbx[i].Hide();
            }
            comboBox1.Hide();
            comboBox2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
                filePahts = System.IO.Directory.GetFiles(textBox1.Text, "*.xml", SearchOption.TopDirectoryOnly);
            }
            if (filePahts.Length == 0)
            {
                MessageBox.Show("Khong tim thay file XML", "Loi");
            }
            else
            {
                comboBox1.Show();
                comboBox2.Show();
            }
        }

        private void Selection(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            AtributesName.Clear();
            Value.Clear();

            for (int i = 0; i < filePahts.Length; i++)
            {
                if (filePahts[i].Contains(comboBox1.Text))
                {
                    filePahts2 = filePahts[i];
                }
            }

            XmlDocument reader = new XmlDocument();
            reader.Load(filePahts2);

            XmlElement elm = reader.DocumentElement;
            int nChild = elm.ChildNodes.Count;
            int nAtru = elm.ChildNodes[0].Attributes.Count;

            for (int i = 0; i < nAtru; i++)
            {
                AtributesName.Add(elm.ChildNodes[0].Attributes[i].Name);
            }

            for (int i = 0; i < nChild; i++)
            {
                List<string> tmp = new List<string>();
                for (int j = 0; j < nAtru; j++)
                {
                    tmp.Add(elm.ChildNodes[i].Attributes[j].InnerText);
                }
                Value.Add(tmp);
            }

            for (int i = 0; i < nChild; i++)
            {
                comboBox2.Items.Add(Value[i][1]);
            }
        }

        private void Selection2(object sender, EventArgs e)
        {
            int n = AtributesName.Count;
            int m = new int();
            for (int i = 0; i < Value.Count; i++)
            {
                if (Value[i][1] == comboBox2.Text)
                    m = i;
            }

            for (int i = 0; i < 6; i++)
            {
                if (i < n)
                {
                    lbl[i].Show();
                    tbx[i].Show();
                    lbl[i].Name = AtributesName[i];
                    lbl[i].Text = AtributesName[i];
                    tbx[i].Text = Value[m][i];
                    lbl[i].Location = new System.Drawing.Point(13, 200 + i * 40); // vi tri xuat hien
                    tbx[i].Location = new System.Drawing.Point(150, 200 + i * 40);
                    lbl[i].Size = new System.Drawing.Size(100, 20);  // kich thuoc
                    tbx[i].Size = new System.Drawing.Size(300, 40);  // kich thuoc
                    this.Controls.Add(lbl[i]);// them controls vaof Form1
                    this.Controls.Add(tbx[i]);
                }
                else
                {
                    lbl[i].Hide();
                    tbx[i].Hide();
                }
            }
        }

    }
}

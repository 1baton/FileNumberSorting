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

namespace FileNumberSorting
{
    public partial class Form1 :Form
    {
        Queue<double> queue = new Queue<double>();
        List<double> zero = new List<double>();
        public Form1 ()
        {
            InitializeComponent();
        }
        private void loadButton_Click (object sender, EventArgs e)
        {
           
        }

        private List<double> SortNumbers (List<double> numbers)
        {
            return numbers.OrderBy(n => n >= 0 ? (n == 0 ? 2 : 0) : 1).ToList();
        }

        private void button1_Click (object sender, EventArgs e)
        {
            try
            {
                queue.Clear();
                listBox1.Items.Clear();
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string namefile = openFileDialog1.FileName;
                    int count = File.ReadAllText(namefile).Length;
                    if (count > 0)
                    {

                        listBox1.Items.Clear();
                        string[] st = File.ReadAllLines(namefile);
                        for (int i = 0; i < st.Length; i++)
                        {
                            if (double.Parse(st[i]) < 0)
                                queue.Enqueue(double.Parse(st[i]));
                            else if (double.Parse(st[i]) == 0)
                                zero.Add(0);
                            else
                                listBox1.Items.Add(st[i]);
                        }
                        foreach (double lines in queue)
                        {
                            listBox1.Items.Add(lines);
                        }
                        foreach (double lines in zero)
                        {
                            listBox1.Items.Add(lines);
                        }
                    } else
                        MessageBox.Show("Найден пустой файл", "Сообщение", MessageBoxButtons.OK);

                } else
                    MessageBox.Show("Не был выбран файл", "Сообщение", MessageBoxButtons.OK);
            } catch { MessageBox.Show("Выбран некорректный файл", "Сообщение", MessageBoxButtons.OK); }
        }
    }
}

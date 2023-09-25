using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Priklad_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader ctenar = new StreamReader("cisla.txt");
                try
                {
                    int N = Convert.ToInt32(textBox1.Text);
                    List<int> vstup = new List<int>();
                    while (!ctenar.EndOfStream)
                    {
                        vstup.Add(Convert.ToInt32(ctenar.ReadLine()));
                    }
                    try
                    {
                        int pate = vstup[4];
                        while (N != 1 && N > 0)
                        {
                            pate *= pate;
                            N--;
                        }
                        N = Convert.ToInt32(textBox1.Text);
                        label3.Text = pate.ToString();
                        //MessageBox.Show("Umocněné páté číslo na N(" + vstup[4] + " na " + N + ") = " + pate.ToString());
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (OverflowException ex)
                    {
                        MessageBox.Show("Došlo k přetečení v umocňování. " + ex.Message);
                    }
                    double podil = 0;
                    double patecislo = vstup[4];
                    if (N != 0)
                    {
                        podil = patecislo / N;
                        label5.Text = podil.ToString();
                        //MessageBox.Show("Podíl pátého čísla s N(" + vstup[4] + " / " + N + ") = " + podil.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Nelze dělit nulou!");
                        label3.Text = "1";
                        //MessageBox.Show("Umocněné páté číslo na N(" + vstup[4] + " na " + N + ") = " + "1");
                    }
                    int soucet = 0;
                    foreach(int cislo in vstup)
                    {
                        soucet += cislo;
                    }
                    label7.Text = soucet.ToString();
                    //MessageBox.Show("Soucet všech čísel ze souboru = " + soucet.ToString());
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show("Došlo k přetečení v součtu. " + ex.Message);
                }
                finally
                {
                    ctenar.Close();
                }
            }
            catch (PathTooLongException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Gold;
            button1.BackColor = Color.DarkGreen;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.LawnGreen;
            button1.BackColor = Color.Black;
        }
    }
}

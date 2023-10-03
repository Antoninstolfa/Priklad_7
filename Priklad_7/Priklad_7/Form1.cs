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
                        if(vstup.Count < 5)
                        {
                            MessageBox.Show("V textovém souboru není dostatek čísel!");
                        }
                        else
                        {
                            int pate = vstup[4];
                            int vysledek = pate;
                            if(N>25)
                            {
                                MessageBox.Show("N je moc velké, dojde k přetečení datového typu.");
                                label3.Text = "x";
                            }
                            else
                            {
                                while (N != 1 && N > 0)
                                {
                                    vysledek *= pate;
                                    N--;
                                }
                                N = Convert.ToInt32(textBox1.Text);
                                label3.Text = vysledek.ToString();
                            }
                        }
                        
                    }
                    catch (OverflowException ex)
                    {
                        MessageBox.Show("Došlo k přetečení v umocňování. " + ex.Message);
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }  
                    catch (ArithmeticException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    double podil = 0;
                    double patecislo = vstup[4];
                    if (N != 0)
                    {
                        podil = patecislo / N;
                        label5.Text = podil.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Nelze dělit nulou!");
                        label3.Text = "1";
                    }
                    int soucet = 0;
                    foreach(int cislo in vstup)
                    {
                        soucet += cislo;
                    }
                    label7.Text = soucet.ToString();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
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
                catch (ArithmeticException ex)
                {
                    MessageBox.Show(ex.Message);
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

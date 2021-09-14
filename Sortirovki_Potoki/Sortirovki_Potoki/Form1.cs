using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Sortirovki_Potoki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string d;
        Random random = new Random();
        Random rnd;
        public int k = 0;
        int prOne = 0;
        int prTwo = 0;
        int prthree = 0;
        int srvOne = 0;
        int srvTwo = 0;
        int srvThree = 0;
        public int[] massivOne;
        public int[] massivtwo;
        public int[] massivThree;
        DateTime time1;
        DateTime time2;
        DateTime time3;
        DateTime time4;
        DateTime time5;
        DateTime time6;



        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        public int[] BubbleSort(int[] array)
        {
            time1 = DateTime.Now;
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        prOne++;
                        srvOne++;
                    }
                    else
                    {
                        srvOne++;
                    }
                }
            }
            time2 = DateTime.Now;
            //times = (d2 - d1).TotalSeconds;
                
            return array;
        }
        public int[] ShellSort(int[] array)
        {
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            time3 = DateTime.Now;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        prTwo++;
                        srvTwo++;
                        j = j - d;
                    }

                }

                d = d / 2;
            }
            time4 = DateTime.Now;
            return array;
            
        }
        public int[] ShakerSort(int[] array)
        {
            time5 = DateTime.Now;
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                //проход слева направо
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                        prthree++;
                        srvThree++;
                    }
                    else
                    {
                        srvThree++;
                    }
                }

                //проход справа налево
                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                        prthree++;
                        srvThree++;
                    }
                    {
                        srvThree++;
                    }
                }

                //если обменов не было выходим
                if (!swapFlag)
                {
                    break;
                }
            }
            time6 = DateTime.Now;
            return array;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            k = Convert.ToInt32(textBox5.Text);
            massivOne = new int[k];
            massivtwo = new int[k];
            massivThree = new int[k];
            for (int i = 0; i < k; i++)
            {
                massivOne[i] = rnd.Next(0, 50);
                massivtwo[i] = massivOne[i];
                massivThree[i] = massivOne[i];
            }
            BubbleSort(massivOne);
            ShellSort(massivtwo);
            ShakerSort(massivThree);
            label6.Text = (time2 - time1).TotalSeconds.ToString();
            label7.Text = prOne.ToString();
            label8.Text = srvOne.ToString();
            label9.Text = (time4 - time3).TotalSeconds.ToString();
            label10.Text = prTwo.ToString();
            label11.Text = srvTwo.ToString();
            label12.Text = (time6 - time5).TotalSeconds.ToString();
            label13.Text = prthree.ToString();
            label14.Text = srvThree.ToString();
            for (int i = 0; i < k; i++)
            {
                textBox2.Text += massivOne[i].ToString() + " ";
                textBox3.Text += massivtwo[i].ToString() + " ";
                textBox4.Text += massivThree[i].ToString() + " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form1 : Form
    {
        int butclick=0;
        int vershin,reber;
        int[,] smatrix;
        int[,] imatrix;
        int[,] objects;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (reber.Equals(butclick + 1))
            {
                Add.Enabled = false;
                End.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
                backsave.Checked = false;
                backsave.Enabled = false;
            }//вимикаєм кнопку, щоб не вводити більш ніж треба ребер
            else if (reber.Equals(butclick + 2) && backsave.Checked==true)
            {
                Add.Enabled = false;
                End.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
                backsave.Enabled = false;
            }
            else if (reber.Equals(butclick + 2)&&backsave.Checked==false) { backsave.Checked = false; backsave.Enabled = false; }//если осталось указать 1 ребро запрещаем устанавливать двойную связь
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        int a =Decimal.ToInt32(numericUpDown3.Value);
                        int b = Decimal.ToInt32(numericUpDown4.Value);
                        int ves = Decimal.ToInt32(numericUpDown5.Value);
                        smatrix[a - 1, b - 1] = ves;
                        smatrix[b - 1, a - 1] = ves;
                        if(backsave.Checked)
                        {
                            imatrix[a - 1, butclick ] = -1;
                            imatrix[b - 1, butclick ] = 1;
                            objects[a - 1, b - 1] = b-1;
                            butclick++;
                            objects[b - 1, a - 1] = a-1;
                            imatrix[b - 1, butclick ] = -1;
                            imatrix[a - 1, butclick ] = 1;
                            butclick++;
                        }
                        else{
                            objects[a - 1, b - 1] = b-1;
                            imatrix[a - 1, butclick ] = -1;
                            imatrix[b - 1, butclick ] = 1;
                            butclick++;
                        }
                        break;
                    }
                case 1:
                    {
                        int a = Decimal.ToInt32(numericUpDown3.Value);
                        int b = Decimal.ToInt32(numericUpDown4.Value);
                        int ves = Decimal.ToInt32(numericUpDown5.Value);
                        smatrix[a-1, b-1] = ves;
                        smatrix[b-1, a-1] = ves;
                        imatrix[a - 1, butclick ] = 0;
                        imatrix[b - 1, butclick ] = 1;
                        objects[a - 1, b - 1] = b-1;
                        butclick++;
                        break;
                    }
                case 2:
                    {
                        int a = Decimal.ToInt32(numericUpDown3.Value);
                        int b = Decimal.ToInt32(numericUpDown4.Value);
                        int ves = Decimal.ToInt32(numericUpDown5.Value);
                        smatrix[a - 1, b - 1] = 1;
                        smatrix[b - 1, a - 1] = 1;
                        if (backsave.Checked)
                        {
                            imatrix[a - 1, butclick ] = -1;
                            imatrix[b - 1, butclick ] = 1;
                            objects[a - 1, b - 1] = b-1;
                            butclick++;
                            objects[b - 1, a - 1] = a-1;
                            imatrix[b - 1, butclick ] = -1;
                            imatrix[a - 1, butclick ] = 1;
                            butclick++;
                        }
                        else
                        {
                            objects[a - 1, b - 1] = b-1;
                            imatrix[a - 1, butclick ] = -1;
                            imatrix[b - 1, butclick ] = 1;
                            butclick++;
                        }
                        break;
                    }
                case 3:
                    {
                        int a = Decimal.ToInt32(numericUpDown3.Value);
                        int b = Decimal.ToInt32(numericUpDown4.Value);
                        int ves = Decimal.ToInt32(numericUpDown5.Value);
                        smatrix[a-1, b-1] = 1;
                        smatrix[b-1, a-1] = 1;
                        imatrix[a - 1, butclick ] = 0;
                        imatrix[b - 1, butclick ] = 1;
                        objects[a - 1, b - 1] = b-1;
                        butclick++;
                        break;
                    }
                default:
                    break;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Obj.Clear();
            textBox5.Clear();
            textBox6.Clear();
            butclick = 0;
            for(int i = 0; i < vershin; i++)
            {
                for (int j = 0; j < vershin; j++) {
                    textBox6.Text += smatrix[i, j]+"\t";
                }
                textBox6.Text +=Environment.NewLine;
            }
            for (int i = 0; i < vershin; i++)
            {
                for (int j = 0; j < reber; j++)
                {
                    textBox5.Text += imatrix[i, j] + "\t";
                }
                textBox5.Text += Environment.NewLine;
            }
            for (int i = 0; i < vershin; i++)
            {
                Obj.Text += (i+1) + " : ";
                for (int j = 0; j < vershin; j++)
                {
                    if(objects[i,j]!=0)
                    Obj.Text += objects[i, j]+1 + "\t";
                }
                Obj.Text += Environment.NewLine;
            }
            Stack<int> nobr = new Stack<int>();
            List<int> obr = new List<int>();
            int start = Decimal.ToInt32(numericUpDown6.Value);
            obr.Add(start-1);
            for(int i = 0; i < vershin; i++)
            {
                if(objects[start-1, i]!=0)
                nobr.Push(objects[start-1, i]);
            }
            while (nobr.Count != 0)
            {
                if (obr.Contains(nobr.Peek())) nobr.Pop();//якщо опрацьована извлекаем
                else
                {
                    obr.Add(nobr.Pop());//якщо не опрацьована, опрацьовуєм
                    for(int i = 0; i < vershin&&obr.Count!=0; i++)
                    {
                        if (objects[obr[obr.Count - 1], i] != 0&&obr.Contains(objects[obr[obr.Count - 1], i])==false) nobr.Push(objects[obr[obr.Count - 1], i]);//добавляем в стек смежные не обработанные
                    }
                }
            }
            for(int i = 0; i < obr.Count; i++)
            {
                if (i < obr.Count - 1) textBox1.Text += obr[i]+1 + "->";
                else textBox1.Text += obr[i]+1;
            }
            start = Decimal.ToInt32(numericUpDown7.Value);
            Queue<int> nque = new Queue<int>();
            List<int> obrabot = new List<int>();
            obrabot.Add(start-1);
            for (int i = 0; i < vershin; i++)
            {
                if (objects[start-1, i] != 0)
                    nque.Enqueue(objects[start-1, i]);
            }
            while (nque.Count != 0)
            {
                if (obrabot.Contains(nque.Peek())) nque.Dequeue();//якщо опрацьована видаляєм
                else
                {
                    obrabot.Add(nque.Dequeue());//видаляєм з черги і додаємо в список опрацьованих 
                    for (int i = 0; i < vershin; i++)
                    {
                        if (objects[obrabot[obrabot.Count - 1], i] != 0 && obrabot.Contains(objects[obrabot[obrabot.Count - 1], i]) == false) nque.Enqueue(objects[obrabot[obrabot.Count - 1], i]);//добавляем в очредь смежные не обработанные
                    }
                }
            }
            for (int i = 0; i < obrabot.Count; i++)
            {
                if (i < obrabot.Count - 1) textBox2.Text += obr[i]+1 + "->";
                else textBox2.Text += obr[i]+1;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            vershin = Decimal.ToInt32(numericUpDown1.Value);
            reber = Decimal.ToInt32(numericUpDown2.Value);
            smatrix = new int[vershin, vershin];//матриця суміжності
            imatrix = new int[vershin, reber];//матриця інцедентності
            objects = new int[vershin,vershin];//об'єкти та вказівники
            numericUpDown6.Maximum = vershin;
            numericUpDown7.Maximum = vershin;
            numericUpDown3.Maximum = vershin;
            numericUpDown4.Maximum = vershin;
            numericUpDown3.ReadOnly = false;
            numericUpDown4.ReadOnly = false;
            Add.Enabled = true;
            create.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            comboBox1.Enabled = false;
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        numericUpDown5.ReadOnly = false;
                        backsave.Enabled = true;
                        break;
                    }
                case 1:
                    {
                        numericUpDown5.ReadOnly = false;
                        break;
                    }
                case 2:
                    {
                        backsave.Enabled = true;
                        break;
                    }
                case 3:
                    {
                        break;
                    }
                default:
                    {
                        numericUpDown3.ReadOnly = true;
                        numericUpDown4.ReadOnly = true;
                        Add.Enabled = false;
                        create.Enabled = true;
                        numericUpDown1.Enabled = true;
                        numericUpDown2.Enabled = true;
                        comboBox1.Enabled = true;
                        break;
                    }
            }
        }
    }
}

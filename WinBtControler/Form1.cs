using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace WinBtControler
{

    public partial class Form1 : Form
    {

        public Form1()
        {


            InitializeComponent();
            wolnePorty();
            button3.Enabled = false;
            button4.Enabled = false;

        } 
        void wolnePorty()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Musisz wybrać port!");
                }
                else
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = 4800;
                    serialPort1.Open();
                    serialPort1.Write("x");
                    button1.Enabled = false;
                    button2.Enabled = true;
                    comboBox1.Enabled = false;
                    label2.Text = "POŁĄCZONY";
                    label2.ForeColor = System.Drawing.Color.Green;
                    
                    groupBox2.Enabled = true;
                    textBox1.Enabled = true;
                    button2.Visible = true;
                    button1.Visible = false;
                    button3.Enabled = true;
                    button4.Enabled = true;

                    //wylaczyc przyciski


                }
            }
            catch (UnauthorizedAccessException)
            {

            }
        }

        private void tył_Click(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            label2.Text = "ROZŁĄCZONY";
            label2.ForeColor = System.Drawing.Color.Red;
            groupBox2.Enabled = false;
            comboBox1.Enabled = false;
            button2.Enabled = false;
            button1.Visible = true;
            button2.Visible = false;
            button1.Enabled = true;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.Red;
            progressBar1.Value = 200;
            groupBox4.Text = "Prędkość: " + ((progressBar1.Value / 250.0) * 100) + "%";
            comboBox1.Text = "COM3";
        }

        private void prawo_MouseDown(object sender, MouseEventArgs e)
        {
            serialPort1.Write("R"); //PRAWO - RIGHT
        }

        private void prawo_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort1.Write("X");
            //int MyInt =10;

            //byte[] b = BitConverter.GetBytes(MyInt);
            //serialPort1.Write(b, 0, 4);
        }



        private void lewo_MouseDown(object sender, MouseEventArgs e)
        {
            serialPort1.Write("L"); //LEWO - LEFT
        }

        private void lewo_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort1.Write("X");
        }

        private void przod_MouseDown(object sender, MouseEventArgs e)
        {
            serialPort1.Write("F"); //FRONT - PRZOD
        }

        private void przod_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort1.Write("X");
        }

        private void tył_MouseDown(object sender, MouseEventArgs e)
        {
            serialPort1.Write("B"); //BACK - TYŁ
        }

        private void tył_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort1.Write("X");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value >= 250)
                progressBar1.Value = 250;
            else
                progressBar1.Value += 10;
            groupBox4.Text = "Prędkość: " + (progressBar1.Value / 250.0) * 100 + "%";
            serialPort1.Write("S");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value <= 0)
                progressBar1.Value = 0;
            else
                progressBar1.Value -= 10;
            groupBox4.Text = "Prędkość: " + (progressBar1.Value / 250.0) * 100 + "%";
            serialPort1.Write("s");


        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            string x = Convert.ToString(MousePosition.X);
            string y = Convert.ToString(MousePosition.Y);
            label3.Text = ("POZ X: " + x + " POZ Y: " + y);


        }

       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                serialPort1.Write("F"); //FRONT - PRZOD
                
                

            }

            if (e.KeyCode == Keys.Down)
            {
                serialPort1.Write("B"); //BACK - TYL
            }

            if (e.KeyCode == Keys.Left)
            {
                serialPort1.Write("L"); // LEFT

            }

            if (e.KeyCode == Keys.Right)
            {
                serialPort1.Write("R");
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            serialPort1.Write("X");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}   


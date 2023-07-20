using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;



namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

       



[DllImport("easylase.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "EasyLaseGetCardNum")]
public static extern int EasyLaseGetCardNum();
[DllImport("easylase.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "EasyLaseWriteFrame")]
public static extern bool EasyLaseWriteFrame(int cardNumber, ushort[] datapointer, int bytecount, ushort speed);
//[DllImport("easylase.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "EasyLaseWriteFrame")]
//public static extern byte EasyLaseWriteFrame(int cardNumber, Point[] datapointer, int bytecount, ushort speed);
[DllImport("easylase.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "EasyLaseStop")]
public static extern bool EasyLaseStop(int cardNumber);
[DllImport("easylase.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "EasyLaseClose")]
public static extern bool EasyLaseClose();
[DllImport("easylase.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "EasyLaseGetLastError")]
public static extern int EasyLaseGetLastError(int CardNumber);
[DllImport("easylase.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "EasyLaseGetStatus")]
public static extern int EasyLaseGetStatus(int CardNumber);





private int easylaseCount;
private int card = 0;



private void Form_Closing(object sender, EventArgs e)
{
    easylaseCount = EasyLaseGetCardNum();
    if (easylaseCount > 0)
    {
        EasyLaseStop(0);
        EasyLaseClose();
    }
}


/*
 * 
 * 
 *         private unsafe void button1_Click(object sender, EventArgs e)
        {
            easylaseCount = EasyLaseGetCardNum();
            MessageBox.Show(Convert.ToString(EasyLaseGetStatus(ref card)));
            if (easylaseCount > 0)
            {

                Point[] pointarray = new Point[15];
                ushort x = 2000;
                ushort y = 2000;
                byte r = 0;
                byte g = 255;
                byte b = 0;
                byte intens = 0;

                for (int i = 0; i < 15; i++)
                {
                    pointarray[i].x = x;
                    pointarray[i].y = y;
                    pointarray[i].r = r;
                    pointarray[i].g = g;
                    pointarray[i].b = b;
                    pointarray[i].i = intens;
                    x += 30;
                    //y += 30;
                }
                try
                {
                    EasyLaseWriteFrame(ref card, pointarray, Marshal.SizeOf(typeof(Point)) * pointarray.Length, 500);
                }
                catch (AccessViolationException ave)
                {
                    
                    MessageBox.Show(ave.Message);
                }
            }
        }
    }*/



ushort[] frame = new ushort[] { 1, 1, 0, 30000, 0, 0, 0, 0 };

ushort[] x = new ushort[1000];  // now it's a 20-element array
ushort[] y = new ushort[1000];  // now it's a 20-element array
ushort[] g = new ushort[1000];  // now it's a 20-element array


static Random _r = new Random();




/*public struct Point
{
    public ushort x;    // 2 bytes, value: 0-4095 (x-coordinate)
    public ushort y;    // 2 bytes, value: 0-4095 (y-coordinate)
    public ushort r;    // 1 byte, value: 0-255 (red)
    public ushort g;    // 1 byte, value: 0-255 (green)
    public ushort b;    // 1 byte, value: 0-255 (blue)
    public ushort i;    // 1 byte, value: 0-255 (intensity)
    public ushort AL;    // 1 byte, value: 0-255 (intensity)
    public ushort AR;    // 1 byte, value: 0-255 (intensity)
};*/


        private unsafe void button1_Click(object sender, EventArgs e)
        {
            int i = 0;


            if (easylaseCount > 0)
            {


                //x[1] = 1; y[1] = 1; g[1] = 1;


                try
                {
                    //EasyLaseWriteFrame((int)0, frame, (int)8, (ushort)5000);
                   // EasyLaseWriteFrame(1, pointarray, Marshal.SizeOf(typeof(Point)) * pointarray.Length, 5000);
                    for (int intI = 0; intI < 500; intI++)
                    {

                        int delay = 10;
                        /*int random_x = _r.Next(30000);
                        int random_y = _r.Next(30000);
                        x[1] = Convert.ToUInt16(random_x);
                        y[1] = Convert.ToUInt16(random_y);*/
                        x[1] = 300;  y[1] = 500;
                        x[2] = 0; y[2] =  0;

                        frame = new ushort[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                        EasyLaseWriteFrame(1, frame, 8, 5000);
                        System.Threading.Thread.Sleep(delay); // 5 micro s 


                        frame = new ushort[] { 40000, 40000, 40000, 65000, 65000, 65000, 0, 0 };
                        EasyLaseWriteFrame(1, frame, 8, 5000);
                        System.Threading.Thread.Sleep(delay); // 5 micro s 
                    }
                }
                catch (AccessViolationException ave)
                {

                    MessageBox.Show(ave.ToString());
                }
            }

        }

        private void Do_This_On_Form_Load(object sender, EventArgs e)
        {
            easylaseCount = EasyLaseGetCardNum();
            label1.Text = easylaseCount.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //if (easylaseCount > 0)
            //{


                //x[1] = 1; y[1] = 1; g[1] = 1;


                try
                {

                    for (int intI = 0; intI < 10; intI++)
                    {

                        frame = new ushort[] { 40000, 40000, 40000, 65000, 65000, 65000, 0, 0 };
                        EasyLaseWriteFrame(1, frame, 8, 5000);
                        System.Threading.Thread.Sleep(10); // 5 micro s 
                    }
                }
                catch (AccessViolationException ave)
                {

                    MessageBox.Show(ave.ToString());
                }
            //}
        }

        private unsafe void button3_Click(object sender, EventArgs e)
        {

            try
            {

                for (int intI = 0; intI < 10; intI++)
                {

                    frame = new ushort[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    EasyLaseWriteFrame(1, frame, 8, 5000);
                    System.Threading.Thread.Sleep(10); // 5 micro s 
                }
            }
            catch (AccessViolationException ave)
            {

                MessageBox.Show(ave.ToString());
            }

 



        }


       


    }
}

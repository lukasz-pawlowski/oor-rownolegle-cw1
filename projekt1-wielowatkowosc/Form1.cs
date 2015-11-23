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
using System.Threading;

namespace projekt1_wielowatkowosc
{
    public partial class Form1 : Form
    {

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        delegate void GetTextCallback();
        delegate void SetLabelHashCallback(string text);
        delegate string GetLabelHashCallback();
        delegate void SetLabelFibCallback(string text);
        delegate string GetLabelFibCallback();


        Thread rwThread, fibThread, hashThread, hashThread2;
        String richTextString;
        String fibTextString;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //threads
            rwThread = new Thread(readWrite);
            rwThread.Start();

            fibThread = new Thread(fib);
            fibThread.Start();

            hashThread = new Thread(calculateHash);
            hashThread.Start();

            hashThread2 = new Thread(calculateHash);
            hashThread2.Start();

        }

        private void readWrite()
        {
            while(true)
            {
                //oczekiwanie na watek fibonacci
                fibThread.Join();

                //podstawowe pobieranie wartosci
                System.Threading.Thread.Sleep(1001);
                this.GetText();
                string s = richTextString;

                this.GetLabelFib();
                string t = fibTextString;
      
                string u = s + t;

                //zapis
                byte[] data = Encoding.UTF8.GetBytes(u);
                string path = @"c:\x.txt";
                FileStream fs = null;

                try
                {
                    fs = new System.IO.FileStream(path, FileMode.Create);
                    fs.Write(data, 0, data.Length);
                }
                catch (UnauthorizedAccessException)
                {
                   
                }
                finally
                {
                    if(fs != null) fs.Close();
                }

                //odczyt
                if (File.Exists(path))
                {
                    FileStream fso = new System.IO.FileStream(path, FileMode.Open);
                    data = new byte[fso.Length];
                    fso.Position = 0;
                    fso.Read(data, 0, (int)fso.Length);
                    fso.Close();
                }
            }
        }

        private void fib()
        {
            //throw new NotImplementedException();
            int prev = 1;
            int next = 1;
            int sum = 0;

            while(true)
            {
                System.Threading.Thread.Sleep(1000);
                sum = prev + next;
                prev = next;
                next = sum;
                this.SetLabelFib(sum.ToString());

            }

        }
        

        //calculate hash of all data
        private void calculateHash()
        {
            while (true)
            {
                lock (this.labelHash)
                {
                    this.GetText();
                    String s = richTextString;

                    System.Threading.Thread.Sleep(1000);
                    int h = s.GetHashCode();
                    this.SetLabelHash(h.ToString());
                }
            }
        }
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.richTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox.Text = text;
            }
        }
        private void GetText()
        {
            if (this.richTextBox.InvokeRequired)
            {
                GetTextCallback d = new GetTextCallback(GetText);
                this.Invoke(d, new object[] {  });
               
            }
            else
            {
                richTextString = this.richTextBox.Text;

            }
        }
        private void SetLabelFib(string text)
        {
            if (this.richTextBox.InvokeRequired)
            {
                SetLabelFibCallback d = new SetLabelFibCallback(SetLabelFib);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelFib.Text = text;
                this.fibTextString = text;
            }
        }
        private string GetLabelFib()
        {
            if (this.richTextBox.InvokeRequired)
            {
                GetLabelFibCallback d = new GetLabelFibCallback(GetLabelFib);
                this.Invoke(d, new object[] { });
                return "empty";
            }
            else
            {
                return this.labelFib.Text;

            }
        }
        private void SetLabelHash(string text)
        {
            if (this.richTextBox.InvokeRequired)
            {
                SetLabelHashCallback d = new SetLabelHashCallback(SetLabelHash);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.labelHash.Text = text;
            }
        }
        private string GetLabelHash()
        {
            if (this.richTextBox.InvokeRequired)
            {
                GetLabelHashCallback d = new GetLabelHashCallback(GetLabelHash);
                this.Invoke(d, new object[] { });
                return "empty";
            }
            else
            {
                return this.labelHash.Text;

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            rwThread.Abort();
            fibThread.Abort();
            hashThread.Abort();
        }
    }
}

using NAudio.Gui;
using NAudio.Wave;
using RJCP.IO.Ports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace SRDS_SN
{
    public partial class Form1 : Form
    {
        private static List<short> PCM = new List<short>();
        private static Queue<byte> Data = new Queue<byte>();

        public static bool saving;

        private static SerialPortStream serialPort;

        private static bool isclosing = false;
        private static string portName = "COM3";

        int n = 4000;
        WaveIn wi;
        Queue<double> myQ;

        public Form1()
        {
            InitializeComponent();

            myQ = new Queue<double>(Enumerable.Repeat(0.0, n).ToList()); // fill myQ w/ zeros
            chart.ChartAreas[0].AxisY.Minimum = -10000;
            chart.ChartAreas[0].AxisY.Maximum = 10000;
        }

        private void povezi_button_Click(object sender, EventArgs e)
        {
            if(!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }

        /*
        private static void SerialPort_DataReceived(object sender, RJCP.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    byte[] data = new byte[serialPort.BytesToRead];
                    serialPort.Read(data, 0, data.Length);
                    data.ToList().ForEach(b => Data.Enqueue(b));

                    if (Data.Count > 1760000)
                    {
                        Enumerable.Range(0, 1760000).Select(i => Data.Dequeue());
                        ShraniVWav(Data.ToArray());
                        Console.WriteLine("Done");
                    }

                    short result = 0;
                    string podatki = serialPort.ReadExisting();
                    foreach(string podatek in podatki.Split(' '))
                    {
                        bool success = short.TryParse(podatek, out result);
                        if (success){
                            PCM.Add(result);
                        }
                        else
                        {
                            int tempRes = int.Parse(podatek);
                            tempRes &= ~(1 << 15);
                            PCM.Add(result);
                        }
                        
                        //Console.WriteLine(podatek);
                        if (PCM.Count * sizeof(short) >= 176000)
                        {
                            saving = true;
                            byte[] rezultat = new byte[PCM.Count * sizeof(short)];
                            Buffer.BlockCopy(PCM.ToArray(), 0, rezultat, 0, rezultat.Length);
                            ShraniVWav(rezultat);
                            PCM.Clear();

                            Console.WriteLine("Shranjevanje končano!");
                        }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }*/

        private void ShraniVWav(byte[] rezultat)
        {
            string tempFile = "C:/Users/Ziga/Desktop/test1.wav";
            WaveFormat waveFormat = new WaveFormat(44000, 16, 1);

            using (WaveFileWriter writer = new WaveFileWriter(tempFile, waveFormat))
            {
                writer.Write(rezultat, 0, rezultat.Length);
            }
        }


        //https://stackoverflow.com/questions/9416608/rich-text-box-scroll-to-the-bottom-when-new-data-is-written-to-it
        private void output_RTB_TextChanged(object sender, EventArgs e)
        {
            RichTextBox temp = (sender as RichTextBox);
            temp.SelectionStart = temp.Text.Length;
            temp.ScrollToCaret();
        }

        private void prekini_povezavo_Click(object sender, EventArgs e)
        {
            if(serialPort.IsOpen)
                serialPort.Close();

            if(backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();

        }

        //napisi v STM-ju, da pobereš vse skupaj 128 znakov in jih nato poslji
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var isValid = SerialPortStream.GetPortNames().Any(x => string.Compare(x, portName, true) == 0);
                if (!isValid)
                {
                    stevilo_shranjenih_bytov_label.Text = "Port ne obstaja.";
                }
                else
                {
                    serialPort = new SerialPortStream(portName);
                    //serialPort.DataReceived += SerialPort_DataReceived;
                    serialPort.OpenDirect();
                    while (serialPort.IsOpen)
                    {
                        byte[] data = new byte[serialPort.BytesToRead];
                        if (data.Length == 0)
                            continue;
                        serialPort.Read(data, 0, data.Length);
                        data.ToList().ForEach(b => Data.Enqueue(b));

                        Enumerable.Range(0, Data.Count - 1).Select(i => Data.Dequeue());
                        ShraniVWav(Data.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                if (error_RTB.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate {
                        error_RTB.Text += ex + "\n";
                    }));
                    return;
                }
                
            }
        }

        private void odpriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Wave file (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;

            WaveViewer.WaveStream = new WaveFileReader(open.FileName);
        }

        private void clear_errors_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        void wi_DataAvailable(object sender, WaveInEventArgs e)
        {
            for (int i = 0; i < e.BytesRecorded; i += 2)
            {
                myQ.Enqueue(BitConverter.ToInt16(e.Buffer, i));
                myQ.Dequeue();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                chart.Series["Series1"].Points.DataBindY(Data);
                //chart1.ResetAutoValues();
            }
            catch
            {
                Console.WriteLine("No bytes recorded");
            }
        }
    }
}

/*//var podatki = (string)serialPort.ReadExisting();
                        string podatki = "";
                        if (podatki != "")
                        {
                            if (output_RTB.InvokeRequired)
                            {
                                this.Invoke(new MethodInvoker(delegate
                                {
                                    stevilo_shranjenih_bytov_label.Text = PCM.Count.ToString();
                                }));
                            }

                            
                            

                            /*
                            short result = 0;
                            foreach (string podatek in podatki.Split(' '))
                            {
                                if (podatek.Contains("\n\r"))
                                    break;
                                bool success = short.TryParse(podatek, out result);
                                if (success)
                                {
                                    PCM.Add(result);
                                }
                                else
                                {
                                    int tempRes = int.Parse(podatek);
                                    tempRes &= ~(1 << 15);
                                    PCM.Add(result);
                                }

                                //Console.WriteLine(podatek);
                                if (PCM.Count * sizeof(short) >= 176000)
                                {
                                    saving = true;
                                    byte[] rezultat = new byte[PCM.Count * sizeof(short)];
                                    Buffer.BlockCopy(PCM.ToArray(), 0, rezultat, 0, rezultat.Length);
                                    ShraniVWav(rezultat);
                                    PCM.Clear();

                                    Console.WriteLine("Shranjevanje končano!");
                                }
                            }
                        }
byte[] data = new byte[serialPort.BytesToRead];
                        serialPort.Read(data, 0, data.Length);
                        data.ToList().ForEach(b => Data.Enqueue(b));

                        if (Data.Count > 1760000)
                        {
                            Enumerable.Range(0, 1760000).Select(i => Data.Dequeue());
                            ShraniVWav(Data.ToArray());
                            Console.WriteLine("Done");
                        }
*/
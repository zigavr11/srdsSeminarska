using NAudio.Wave;
//using RJCP.IO.Ports;
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
        private static System.Timers.Timer aTimer;
        private static System.Timers.Timer aTimer1;
        private static List<short> PCM;
        private static Queue<byte> Data = new Queue<byte>();
        public static bool saving;

        private static SerialPort serialPort = new SerialPort("COM3", 115200, Parity.None, 8,  StopBits.One);
        private static bool isclosing = false;

        public Form1()
        {
            InitializeComponent();
        }


        /*static void Main(string[] args)
        {
            var th = new Thread(ZapisujPodatek);
            th.Start();

            PCM = new List<short>();
            saving = false;

            // Create a timer with a two second interval.
            aTimer1 = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer1.Elapsed += IzpisiSteviloShranjenihPodatkov;
            aTimer1.AutoReset = true;
            aTimer1.Enabled = true;

            //https://social.msdn.microsoft.com/Forums/vstudio/en-US/707e9ae1-a53f-4918-8ac4-62a1eddb3c4a/detecting-console-application-exit-in-c?forum=csharpgeneral
            SetConsoleCtrlHandler(new HandlerRoutine(ConsoleCtrlCheck), true);
            Console.WriteLine("CTRL+C,CTRL+BREAK or suppress the application to exit");
        }*/

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (output_RTB.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate {
                    output_RTB.Text += serialPort.ReadExisting();
                }));
                return;
                
            }
        }

        private static void IzpisiSteviloShranjenihPodatkov(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine(PCM.Count);
            //Console.WriteLine(PCM1.Count);
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

        private static void ShraniVWav(byte[] rezultat)
        {
            string tempFile = "C:/Users/Ziga/Desktop/test1.wav";
            WaveFormat waveFormat = new WaveFormat(44100, 16, 1);

            using (WaveFileWriter writer = new WaveFileWriter(tempFile, waveFormat))
            {
                writer.Write(rezultat, 0, rezultat.Length);
            }
            //System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
            //myPlayer.SoundLocation = @"C:/Users/Ziga/Desktop/test1.wav";
            //myPlayer.Play();
        }

        private void povezi_button_Click(object sender, EventArgs e)
        {
            try
            {
                // Attach a method to be called when there
                // is data waiting in the port's buffer 
                serialPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                // Begin communications 
                serialPort.Open();
            }
            catch(IOException ex)
            {
                error_RTB.Text += "Bog ve ka je narobe ko se to zgodi." + ex + "\n";
            }
        }

        //https://stackoverflow.com/questions/9416608/rich-text-box-scroll-to-the-bottom-when-new-data-is-written-to-it
        private void output_RTB_TextChanged(object sender, EventArgs e)
        {
            RichTextBox temp = (sender as RichTextBox);
            temp.SelectionStart = temp.Text.Length;
            temp.ScrollToCaret();
        }

        private void clear_errors_Click(object sender, EventArgs e)
        {
            error_RTB.Clear();
        }
    }
}

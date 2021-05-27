using NAudio.Wave;
using RJCP.IO.Ports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SRDS_Seminarska_Naloga
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        private static System.Timers.Timer aTimer1;
        private static List<short> PCM;
        private static Queue<byte> Data = new Queue<byte>();
        public static bool saving;

        private static SerialPortStream serialPort = new SerialPortStream("COM3", 115200, 8, RJCP.IO.Ports.Parity.None, RJCP.IO.Ports.StopBits.One);
        private static bool isclosing = false;

        [STAThread]
        static void Main(string[] args)
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
            while (!isclosing);
        }

        private static void ZapisujPodatek()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += SerialPortProgram;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void SerialPortProgram(Object source, ElapsedEventArgs e)
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    serialPort.DataReceived += SerialPort_DataReceived;
                    serialPort.OpenDirect();
                }
                //Console.WriteLine("Port uspešno odprl!");
            }
            catch (Exception ex)
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                //Console.WriteLine(ex);
                //Console.WriteLine("Port se ni uspešno odprl.");
            }
            
        }

        private static void IzpisiSteviloShranjenihPodatkov(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine(PCM.Count);
            //Console.WriteLine(PCM1.Count);
        }

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
                    /*
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
                    }*/
                }
                    
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

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

        #region ZA ZAZNAVO KO SE KONZOLA ZAPRE
        private static bool ConsoleCtrlCheck(CtrlTypes ctrlType)
        {
            // Put your own handler here
            switch (ctrlType)
            {
                case CtrlTypes.CTRL_C_EVENT:
                    isclosing = true;
                    Console.WriteLine("CTRL+C received!");
                    break;
                case CtrlTypes.CTRL_BREAK_EVENT:
                    isclosing = true;
                    Console.WriteLine("CTRL+BREAK received!");
                    break;
                case CtrlTypes.CTRL_CLOSE_EVENT:
                    isclosing = true;
                    Console.WriteLine("Program being closed!");
                    break;
                case CtrlTypes.CTRL_LOGOFF_EVENT:
                case CtrlTypes.CTRL_SHUTDOWN_EVENT:
                    isclosing = true;
                    Console.WriteLine("User is logging off!");
                    break;
            }
            return true;
        }
        // Declare the SetConsoleCtrlHandler function
        // as external and receiving a delegate.
        [DllImport("Kernel32")]
        public static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);
        // A delegate type to be used as the handler routine
        // for SetConsoleCtrlHandler.
        public delegate bool HandlerRoutine(CtrlTypes CtrlType);
        // An enumerated type for the control messages
        // sent to the handler routine.
        public enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT,
            CTRL_CLOSE_EVENT,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT
        }
        #endregion
    }
}

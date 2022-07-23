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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using AForge.Math;
using System.Drawing.Text;
using System.Media;
using NAudio.Dsp;

namespace SRDS_SN
{
    public partial class Form1 : Form
    {
        private Queue<byte> zaShranjevanjeData = new Queue<byte>();

        private Queue<byte> zaPrikazData = new Queue<byte>();

        bool ustaviThread;
        public static bool saving;
        private static SerialPortStream serialPort;
        private static string portName = "COM3";

        public Form1()
        {
            InitializeComponent();
            nastaviNastavitve();

            
            //zaPrikazData = new Queue<double>(Enumerable.Repeat(0.0, n).ToList());
            //myQ = new Queue<double>(Enumerable.Repeat(0.0, n).ToList()); // fill myQ w/ zeros

            //naložiTestToolStripMenuItem_Click(null, null);

            //Y
            streamingAudioPCM.ChartAreas[0].AxisY.Minimum = 0;
            streamingAudioPCM.ChartAreas[0].AxisY.Maximum = 300;

            
            streamingChartZdruzen.ChartAreas[0].AxisY.Minimum = -20000;
            streamingChartZdruzen.ChartAreas[0].AxisY.Maximum = 20000;
            

            //streamingAudioWAVBytes.ChartAreas[0].AxisY.Minimum = -0.06;
            //streamingAudioWAVBytes.ChartAreas[0].AxisY.Maximum = 0.06;

            //streamingAudioWAV.ChartAreas[0].AxisY.Minimum = -0.06;
            //streamingAudioWAV.ChartAreas[0].AxisY.Maximum = 0.06;
        }

        private void ShraniVWav(byte[] rezultat)
        {
            string tempFile = "C:/Users/Ziga/Desktop/test1.wav";
            WaveFormat waveFormat = new WaveFormat(16000, 16, 1);

            using (WaveFileWriter writer = new WaveFileWriter(tempFile, waveFormat))
            {
                writer.Write(rezultat, 0, rezultat.Length);
            }
        }

        //Sprotno srhanjevanje audia, ki se v zivo prikazuje
        private void Shrani(byte[] rezultat)
        {
            try
            {
                string tempFile = "C:/Users/Ziga/Desktop/test2.wav";
                WaveFormat waveFormat = new WaveFormat(16000, 16, 1);

                using (WaveFileWriter writer = new WaveFileWriter(tempFile, waveFormat))
                {
                    writer.Write(rezultat, 0, rezultat.Length);
                }
            }
            catch(Exception ex)
            {
                if (error_RTB.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate {
                        error_RTB.Text += ex + "\n";
                    }));
                }
            }
        }

        //napisi v STM-ju, da pobereš vse skupaj 128 znakov in jih nato poslji
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ustaviThread)
                return;
            try
            {
                var isValid = SerialPortStream.GetPortNames().Any(x => string.Compare(x, portName, true) == 0);
                if (!isValid)
                {
                    error_RTB.Text = "Port ne obstaja al pa je neki druga narobe.";
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

                        data.ToList().ForEach(b =>
                        {
                            zaShranjevanjeData.Enqueue(b);
                            zaPrikazData.Enqueue(b);
                            if (zaPrikazData.Count > Settings.SteviloBytov)
                                zaPrikazData.Dequeue();
                        });
                        
                        Shrani(zaPrikazData.ToArray());
                        //Enumerable.Range(0, Data.Count - 1).Select(i => Data.Dequeue());
                        //ShraniVWav(savingData.ToArray());
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
                }
                if (ex.Message.Contains("The process cannot access the file"))
                {
                    serialPort.Close();
                    backgroundWorker.CancelAsync();
                    backgroundWorker.Dispose();
                    povezi_button_Click(null, null);
                }
            }
        }
        private void odpriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Wave file (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;

            //https://www.youtube.com/watch?v=ZnFoVuOVrUQ
            WaveChannel32 wave = new WaveChannel32(new WaveFileReader(open.FileName));
            byte[] buffer = new byte[16384];
            int read = 0;

            /*
            while(wave.Position < wave.Length)
            {
                read = wave.Read(buffer, 0, 16384);
                for (int i = 0; i < read; i++)
                {
                    streamingChartFFT.Series["Zvok"].Points.Add(buffer[i]);
                }
            }
            */
            wave = new WaveChannel32(new WaveFileReader(open.FileName));
            buffer = new byte[16384];
            while (wave.Position < wave.Length)
            {
                read = wave.Read(buffer, 0, 16384);

                for (int i = 0; i < read / 4; i++)
                {
                    streamingAudioWAV.Series["Zvok"].Points.Add(BitConverter.ToSingle(buffer, i * 4));
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
                return;
            try
            {
                streamingAudioPCM.Series["Zvok"].Points.DataBindY(zaPrikazData);

                //https://github.com/swharden/Csharp-Data-Visualization/blob/master/projects/18-09-19_microphone_FFT_revisited/ScottPlotMicrophoneFFT/ScottPlotMicrophoneFFT/Form1.cs

                if (Settings.IzklopiStream)
                    return;

                int BYTES_PER_POINT = 2;

                float[] res = new float[zaPrikazData.Count / BYTES_PER_POINT];
                

                for (int i = 0; i < zaPrikazData.Count / BYTES_PER_POINT; i++)
                {
                    res[i] = BitConverter.ToInt16(zaPrikazData.ToArray(), i * 2);    
                }

                streamingChartZdruzen.Series["Zvok"].Points.DataBindY(res);

                //streamingChartZdruzen.Series["Avarage"].Points.DataBindY(res);

                float[] res_ma = new float[res.Length];
                float ma_zvezdica = res[0];

                for (int i = 0; i < res.Length; i++)
                {
                    ma_zvezdica = ma_zvezdica + res[i] - (ma_zvezdica / Settings.N);
                    res_ma[i] = ma_zvezdica / Settings.N;
                }
                streamingChartZdruzen.Series["Average"].Points.DataBindY(res_ma);

                //FFT(res);

                /*
                using (WaveChannel32 wave = new WaveChannel32(new WaveFileReader("C:/Users/Ziga/Desktop/test2.wav")))
                {
                    int decimation = 4;
                    int bits = 16000;

                    byte[] buffer = new byte[bits];
                    int read = 0;
                    res = new float[wave.Length / decimation];

                    if (wave.Length < bits)
                    {
                        ustaviThread = false;
                        return;
                    }

                    while (wave.Position < wave.Length)
                    {
                        read = wave.Read(buffer, 0, bits);
                        streamingAudioWAVBytes.Series["Zvok"].Points.DataBindY(buffer);
                        for (int i = 0; i < read / decimation; i++)
                        {
                            res[i] = BitConverter.ToSingle(buffer, i * decimation);
                        }
                    }
                    streamingAudioWAV.Series["Zvok"].Points.DataBindY(res);
                    FFT(res);
                }
                ustaviThread = false;
                */
            }
            catch(Exception ex)
            {
                Console.WriteLine("No bytes recorded");
            }
        }

        private void nastaviNastavitve()
        {
            Settings.StreamingAudioPCM_XMin = int.Parse(streamingAudioPCM_XMin.Text);
            Settings.StreamingAudioPCM_XMax = int.Parse(streamingAudioPCM_XMax.Text);

            Settings.StreamingAudioWAVBytes_XMin = int.Parse(streamingAudioBytes_XMin.Text);
            Settings.StreamingAudioWAVBytes_XMax = int.Parse(streamingAudioBytes_XMax.Text);

            Settings.StreamingAudioWAV_XMin = int.Parse(streamingAudioZdruzen_XMin.Text);
            Settings.StreamingAudioWAV_XMax = int.Parse(streamingAudioZdruzen_XMax.Text);

            Settings.SteviloBytov = int.Parse(steviloBytov_TB.Text);
            Settings.Rate = int.Parse(Rate_TB.Text);
            Settings.Bits = int.Parse(Bits_TB.Text);

            Settings.N = int.Parse(N_TB.Text);

            streamingAudioPCM.ChartAreas[0].AxisX.Minimum = Settings.StreamingAudioPCM_XMin;
            streamingAudioPCM.ChartAreas[0].AxisX.Maximum = Settings.StreamingAudioPCM_XMax;

            streamingChartZdruzen.ChartAreas[0].AxisX.Minimum = Settings.StreamingAudioWAVBytes_XMin;
            streamingChartZdruzen.ChartAreas[0].AxisX.Maximum = Settings.StreamingAudioWAVBytes_XMax;

            streamingChartFFT.ChartAreas[0].AxisX.Minimum = Settings.StreamingAudioWAV_XMin;
            streamingChartFFT.ChartAreas[0].AxisX.Maximum = Settings.StreamingAudioWAV_XMax;

        }

        private void FFT(float[]res)
        {
            alglib.complex[] rezultat;

            streamingChartFFT.Series["Zvok"].Points.Clear();
            alglib.complex[] complexData = new alglib.complex[res.Length];

            for (int i = 0; i < res.Length; i++)
            {
                complexData[i] = new alglib.complex(res[i], 0);
            }

            for (int i = 0; i < complexData.Length; i++)
            {
                streamingChartFFT.Series["Zvok"].Points.Add(complexData[i].x);
            }
        }
        #region OSTALI EVENTI
        private void povezi_button_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                zaPrikazData.Clear();
                zaShranjevanjeData.Clear();
                backgroundWorker.RunWorkerAsync();            
            }
        }
        private void output_RTB_TextChanged(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/9416608/rich-text-box-scroll-to-the-bottom-when-new-data-is-written-to-it
            RichTextBox temp = (sender as RichTextBox);
            temp.SelectionStart = temp.Text.Length;
            temp.ScrollToCaret();
        }
        private void prekini_povezavo_Click(object sender, EventArgs e)
        {
            if(serialPort.IsOpen)
                serialPort.Close();

            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
        }
        private void clear_errors_Click(object sender, EventArgs e)
        {
            error_RTB.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private void shrani_button_Click(object sender, EventArgs e)
        {
            ShraniVWav(zaShranjevanjeData.ToArray());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ustaviThread = true;

            nastaviNastavitve();

            ustaviThread = false;
        }
        private void izklopiStream_CB_CheckedChanged(object sender, EventArgs e)
        {
            Settings.IzklopiStream = (sender as CheckBox).Checked;
        }
        #endregion

        private void naložiTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WaveChannel32 testSound = new WaveChannel32(new WaveFileReader("Files/Test.wav"));
            byte[] buffer = new byte[16384];
            int read = 0;

            buffer = new byte[16384];
            while (testSound.Position < testSound.Length)
            {
                read = testSound.Read(buffer, 0, 16384);

                for (int i = 0; i < read / 4; i++)
                {
                    recordedAudioWAV.Series["Zvok"].Points.Add(BitConverter.ToSingle(buffer, i * 4));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer my_wave_file = new SoundPlayer("Files/Test.wav");
            my_wave_file.PlaySync();
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
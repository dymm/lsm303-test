using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//https://msdn.microsoft.com/fr-fr/library/system.io.ports.serialport(v=vs.110).aspx
using System.IO.Ports;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SerialPort _serialPort;
        volatile bool _reading;
        Thread _readThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _reading = false;
            _serialPort = null;
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBoxSerialNames.Items.Add(s);
            }
            if(comboBoxSerialNames.Items.Count>0)
            {
                comboBoxSerialNames.SelectedIndex = 0;
            }

            for(int i=600;i<=256000;i*=2)
            {
                comboBoxBaudRate.Items.Add(i);
            }
            comboBoxBaudRate.SelectedIndex = 4;

            for(int i=5;i<=8;i++)
            {
                comboBoxDataBit.Items.Add(i);
            }
            comboBoxDataBit.SelectedIndex = 3;

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                comboBoxParity.Items.Add(s);
            }
            if (comboBoxParity.Items.Count > 0)
            {
                comboBoxParity.SelectedIndex = 0;
            }

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                comboBoxStopBit.Items.Add(s);
            }
            if (comboBoxStopBit.Items.Count > 0)
            {
                comboBoxStopBit.SelectedIndex = 1;
            }

            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                comboBoxHandshake.Items.Add(s);
            }
            if (comboBoxHandshake.Items.Count > 0)
            {
                comboBoxHandshake.SelectedIndex = 0;
            }

        }

        private void comboBoxSerialNames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonConnexion_Click(object sender, EventArgs e)
        {
            if (_serialPort != null)
            {
                _reading = false;
                if (!_readThread.Join(3 * 1000)) _readThread.Interrupt();
                _serialPort.Close();
                _serialPort = null;
                buttonConnexion.Text = "Connection";
            }
            else
            {
                _serialPort = new SerialPort();
                _serialPort.PortName = comboBoxSerialNames.Items[comboBoxSerialNames.SelectedIndex].ToString();
                _serialPort.BaudRate = (int)comboBoxBaudRate.Items[comboBoxBaudRate.SelectedIndex];
                _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxParity.Items[comboBoxParity.SelectedIndex].ToString(), true);
                _serialPort.DataBits = (int)comboBoxDataBit.Items[comboBoxDataBit.SelectedIndex];
                _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopBit.Items[comboBoxStopBit.SelectedIndex].ToString(), true);
                _serialPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), comboBoxHandshake.Items[comboBoxStopBit.SelectedIndex].ToString(), true);

                // Set the read/write timeouts
                _serialPort.ReadTimeout = 1500;
                _serialPort.WriteTimeout = 1500;

                _readThread = new Thread(this.Read);
                _serialPort.Open();
                _reading = true;
                _readThread.Start();

                buttonConnexion.Text = "Disconnect";
            }

        }

        public void Read()
        {
            while (_reading && _serialPort!=null)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    if (message.Length < 10) continue;
                    char type = message[0];
                    message = message.Remove(0, 2);
                    System.Console.WriteLine(message);
                    if (type == 'd')
                    {
                        //Données de l'accelerometre et du magnétomètre
                        SetText(message.Split(' '));
                        
                    }
                    else if(type == 'i')
                    {
                        //Informations
                        
                    }
                }
                catch (TimeoutException)
                {
                    _reading = false;
                }
                catch (ArgumentOutOfRangeException)
                {
                    //on continue
                }
                catch (ThreadInterruptedException)
                {
                    //Ne rien faire
                }
            }
        }

        private double GetAccelValue(string txt)
        {
            if ("".Equals(txt)) return 0.0;
            return float.Parse(txt) * (2.0 / 32767.0);
        }

        private double GetMagnetoValue(string txt)
        {
            if ("".Equals(txt)) return 0.0;
            return int.Parse(txt) * (8.1 / 32767.0);
        }

        private void SetText(string[] values)
        {
            setTextBoxText(textBoxAccelX, GetAccelValue(values.Length > 0 ? values[0] : "").ToString("F"));
            setTextBoxText(textBoxAccelY, GetAccelValue(values.Length > 1 ? values[1] : "").ToString("F"));
            setTextBoxText(textBoxAccelZ, GetAccelValue(values.Length > 2 ? values[2] : "").ToString("F"));

            setTextBoxText(textBoxMagnetX, GetMagnetoValue(values.Length > 3 ? values[3]: "").ToString("F"));
            setTextBoxText(textBoxMagnetY, GetMagnetoValue(values.Length > 4 ? values[4] : "").ToString("F"));
            setTextBoxText(textBoxMagnetZ, GetMagnetoValue(values.Length > 5 ? values[5] : "").ToString("F"));
        }

        // This delegate enables asynchronous calls for setting  
        // the text property on a TextBox control.  
        delegate void StringArgReturningVoidDelegate(TextBox box, string text);

        private void setTextBoxText(TextBox box, string value)
        {
            // InvokeRequired required compares the thread ID of the  
            // calling thread to the thread ID of the creating thread.  
            // If these threads are different, it returns true.  
            if (box.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(setTextBoxText);
                this.Invoke(d, new object[] { box, value });
            }
            else
            {
                box.Text = value;
            }
        }



    }
}

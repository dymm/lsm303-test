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
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private SerialPort _serialPort;
        private bool _reading;
        private Thread _readThread;

        private System.Object lockHardwareData = new System.Object();
        private double m_gMinMax = 2.0;
        private double m_gx = 0.0;
        private double m_gy = 0.0;
        private double m_gz = 0.0;
        private double m_mMinMax = 8.0;
        private double m_mx = 0.0;
        private double m_my = 0.0;
        private double m_mz = 0.0;

        private System.Object lockRenderData = new System.Object();
        private double m_viewAngleX = 0.0;
        private double m_viewAngleY = 0.0;
        private double m_viewAngleZ = 0.0;


        public MainForm()
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

            comboBoxMagnMinMax.Items.Add(4.0);
            comboBoxMagnMinMax.Items.Add(8.0);
            comboBoxMagnMinMax.SelectedIndex = 0;

            comboBoxAccelMinMax.Items.Add(2.0);
            comboBoxAccelMinMax.Items.Add(4.0);
            comboBoxAccelMinMax.Items.Add(8.0);
            comboBoxAccelMinMax.SelectedIndex = 0;

            glControl_Resize(glControl, EventArgs.Empty);   // Ensure the Viewport is set up correctly
        }

        private void comboBoxAccelMinMax_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock (lockHardwareData)
            {
                m_gMinMax = (double)comboBoxAccelMinMax.Items[comboBoxAccelMinMax.SelectedIndex];
            }
        }

        private void comboBoxMagnMinMax_SelectedIndexChanged(object sender, EventArgs e)
        {
            lock (lockHardwareData)
            {
                m_mMinMax = (double)comboBoxMagnMinMax.Items[comboBoxMagnMinMax.SelectedIndex];
            }
        }

        private void timerUpdateValues_Tick(object sender, EventArgs e)
        {
            string precision = "F3";

            lock (lockHardwareData)
            {
                textBoxAccelX.Text = m_gx.ToString(precision);
                textBoxAccelY.Text = m_gy.ToString(precision);
                textBoxAccelZ.Text = m_gz.ToString(precision);
                textBoxMagnetX.Text = m_mx.ToString(precision);
                textBoxMagnetY.Text = m_my.ToString(precision);
                textBoxMagnetZ.Text = m_mz.ToString(precision);
            }
            lock (lockRenderData)
            {
                glControl.Invalidate();
            }
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
                    string[] values = message.Split(' ');

                    if (values[0] == "d")
                    {
                        //Données de l'accelerometre et du magnétomètre
                        SetValues(values);
                        
                    }
                    else if(values[0] == "i")
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
            return float.Parse(txt) * (m_gMinMax / 32767.0);
        }

        private double GetMagnetoValue(string txt)
        {
            if ("".Equals(txt)) return 0.0;
            return int.Parse(txt) * (m_mMinMax / 32767.0);
        }

        private void SetValues(string[] values)
        {
            double gx = GetAccelValue((values.Length > 1 ? values[1] : ""));
            double gy = GetAccelValue((values.Length > 2 ? values[2] : ""));
            double gz = GetAccelValue((values.Length > 3 ? values[3] : ""));

            double gxnorm = gx / Math.Sqrt(gx * gx + gy * gy + gz * gz);
            double gynorm = gy / Math.Sqrt(gx * gx + gy * gy + gz * gz);

            double mx = GetMagnetoValue(values.Length > 4 ? values[4] : "");
            double my = GetMagnetoValue(values.Length > 5 ? values[5] : "");
            double mz = GetMagnetoValue(values.Length > 6 ? values[6] : "");

            lock(lockHardwareData)
            {
                m_gx = gx;
                m_gy = gy;
                m_gz = gz;
                m_mx = mx;
                m_my = my;
                m_mz = mz;
            }
            lock(lockRenderData) {
                m_viewAngleX = Math.Asin(-gxnorm);
                m_viewAngleZ = Math.Asin(gynorm / Math.Cos(m_viewAngleX));

                m_viewAngleY = (Math.Atan2(my,mx) * 180.0) / Math.PI;
                if (m_viewAngleY < 0)   // Normalize to 0-360
                {
                    m_viewAngleY = 360 + m_viewAngleY;
                }
            }
        }

        private void glControl_Resize(object sender, EventArgs e)
        {
            OpenTK.GLControl c = sender as OpenTK.GLControl;

            if (c.ClientSize.Height == 0)
                c.ClientSize = new System.Drawing.Size(c.ClientSize.Width, 1);

            GL.CullFace(CullFaceMode.FrontAndBack);
            GL.Viewport(0, 0, c.ClientSize.Width, c.ClientSize.Height);

            float aspect_ratio = Width / (float)Height;
            Matrix4 perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void Render()
        {
            Matrix4 lookat = Matrix4.LookAt(0, 5, 5, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Rotate(m_viewAngleX, 0.0f, 1.0f, 0.0f);
            GL.Rotate(m_viewAngleY, 0.0f, 1.0f, 0.0f);
            GL.Rotate(m_viewAngleZ, 0.0f, 1.0f, 0.0f);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            DrawCube();
            glControl.SwapBuffers();
        }

        private void DrawCube()
        {
            GL.Begin(BeginMode.Quads);

            GL.Color3(Color.Silver);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.Color3(Color.Honeydew);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            GL.Color3(Color.Moccasin);

            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            GL.Color3(Color.IndianRed);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            GL.Color3(Color.PaleVioletRed);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);

            GL.Color3(Color.ForestGreen);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);

            GL.End();
        }


    }
}

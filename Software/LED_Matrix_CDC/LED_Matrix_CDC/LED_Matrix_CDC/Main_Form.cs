/* -----------------------------------------------------------------
 * Project: LED Matrix with CDC
 * Author: Santiago Villafuerte (migsantiago.com - san.link@yahoo.com.mx)
 * -----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

using Microsoft.WindowsAPICodePack.Shell;

namespace LED_Matrix_CDC
{
    public partial class Main_Form : GlassForm
    {
        //-------------------------------------------------------------------------------------------------------------------
        // Objects

        /// <summary>
        /// Used to invoke the GUI thread in the AddMessage function.
        /// </summary>
        /// <param name="msg"></param>
        public delegate void addMessageDelegate(object sender, System.IO.Ports.SerialDataReceivedEventArgs e);

        /* Build a dictionary to match a label to a coordinate in the tblMatrix */
        Dictionary<Label, Point> Map_Lbl_Point = new Dictionary<Label, Point>();

        /* A matrix of LEDs */
        Boolean[,] LED_Matrix;

        /* Matrix strings */
        String Set_LED = "~";
        String Clear_LED = " ";

        //-------------------------------------------------------------------------------------------------------------------
        // Functions

        /// <summary>
        /// Pass arguments to the constructor
        /// </summary>
        /// <param name="args">
        ///     [0] COM port to use in int, example: "4"
        ///     [1] Send time automatically, true if yes, false if not; example: "true"
        ///     [2] Set rotation automatically, use 0, 90, 180 or 270; example "180"
        /// </param>
        public Main_Form(String[] args)
        {
            if (args.Length != 0)
            {
                CustomizeLaunch(args);
                Close();
            }
        }

        public Main_Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Customize the execution, refer to the constructor details
        /// </summary>
        /// <param name="args"></param>
        private void CustomizeLaunch(String[] args)
        {
            /* Initialize the Process Event class */
            Process_Ev.Set_Main_Form_Ref(this);

            serialPort1 = new SerialPort();
            try
            {
                serialPort1.PortName = "COM" + args[0];
                serialPort1.Open();

                if ((args[1].Length != 0) && (args[1] == "true"))
                {
                    Process_Ev.Set_PIC_Time();
                    Process_Ev.Draw_Time();
                }

                if (args[2].Length != 0)
                {
                    int number = 0;
                    Process_Ev.Matrix_Rotation_T rot;
                    Int32.TryParse(args[2], out number);

                    switch (number)
                    {
                        case 0: rot = Process_Ev.Matrix_Rotation_T.ROTATE_0_DEG; break;
                        case 90: rot = Process_Ev.Matrix_Rotation_T.ROTATE_90_DEG; break;
                        case 180: rot = Process_Ev.Matrix_Rotation_T.ROTATE_180_DEG; break;
                        case 270: rot = Process_Ev.Matrix_Rotation_T.ROTATE_270_DEG; break;
                        default: rot = Process_Ev.Matrix_Rotation_T.ROTATE_0_DEG; break;
                    }

                    Process_Ev.Set_Matrix_Rotation(rot);
                }

                serialPort1.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            this.Text = System.AppDomain.CurrentDomain.FriendlyName + " v" + Application.ProductVersion;
            About about = new About();
            about.ShowDialog();

            /* Initialize the Process Event class */
            Process_Ev.Set_Main_Form_Ref(this);

            /* Initialize the rotation combo list */
            cmbRotation.SelectedIndex = 0;

            Enable_Controls(false);

            /* Initialize the Webdings object in the table */
            foreach (Control ctl in tblMatrix.Controls)
            {
                ((Label)ctl).Text = Set_LED;
            }

            /* Build a dictionary to know the point for each label */
            for (int x = 0; x < tblMatrix.ColumnCount; ++x)
            {
                for (int y = 0; y < tblMatrix.RowCount; ++y)
                {
                    Control ctl = tblMatrix.GetControlFromPosition(x, y);
                    Map_Lbl_Point.Add((Label)ctl, new Point(x, y));
                }
            }

            /* Initialize the Matrix Values */
            LED_Matrix = new Boolean[7, 7] /* Column, Row */
            {
                {false, false, true, true, true, false, false},
                {false, true, false, false, false, true, false},
                {true, false, true, false, true, false, true},
                {true, true, false, false, false, true, true},
                {true, false, true, true, true, false, true},
                {false, true, false, false, false, true, false},
                {false, false, true, true, true, false, false},
            };
            for (int x = 0; x < tblMatrix.ColumnCount; ++x)
            {
                for (int y = 0; y < tblMatrix.RowCount; ++y)
                {
                    Label lbl = (Label)tblMatrix.GetControlFromPosition(x, y);
                    String str = LED_Matrix[y, x] ? Set_LED : Clear_LED;
                    lbl.Text = str;
                }
            }
        }

        public Boolean Get_Point_From_Label_Reference(Label lbl, out Point p)
        {
            Boolean found;
            found = Map_Lbl_Point.TryGetValue(lbl, out p);
            return found;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = txtCOMPort.Text;

            try
            {
                serialPort1.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Serial port: " + ex.Message);
                return;
            }
            Enable_Controls(serialPort1.IsOpen);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("btnDisconnect_Click " + ex.Message);
                    Enable_Controls(false);
                    return;
                }
            }
            Enable_Controls(serialPort1.IsOpen);
        }

        private void Enable_Controls(Boolean port_is_open)
        {
            btnConnect.Enabled = !port_is_open;
            txtCOMPort.Enabled = !port_is_open;

            btnDisconnect.Enabled = port_is_open;
            btnDrawNumber.Enabled = port_is_open;
            btnRotate.Enabled = port_is_open;
            btnSetPICTime.Enabled = port_is_open;
            btnGameLife.Enabled = port_is_open;
            tblMatrix.Enabled = port_is_open;
        }

        private void btnDrawNumber_Click(object sender, EventArgs e)
        {
            Byte number;

            if (Byte.TryParse(txtDrawNumber.Text, out number))
            {
                Process_Ev.Draw_A_Number(number);
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            // Check if the GUI thread needs to be invoked.
            if (this.InvokeRequired)
            {
                Invoke(new addMessageDelegate(serialPort1_DataReceived), sender, e);
            }
            else
            {
                Byte[] buffer = new Byte[serialPort1.ReadBufferSize];
                serialPort1.Read(buffer, 0, buffer.Length);

                StringBuilder hex = new StringBuilder(buffer.Length * 2);
                foreach (byte b in buffer)
                {
                    hex.AppendFormat("{0:x2}", b);
                }
                //lstConsole.Items.Add(hex.ToString());
            }
        }

        private void btnSetPICTime_Click(object sender, EventArgs e)
        {
            Process_Ev.Set_PIC_Time();
            Process_Ev.Draw_Time();
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            Process_Ev.Set_Matrix_Rotation((Process_Ev.Matrix_Rotation_T)cmbRotation.SelectedIndex);
        }

        private void btnGameLife_Click(object sender, EventArgs e)
        {
            Process_Ev.Play_Game_Of_Life();
        }

        private void LED_Click(object sender, EventArgs e)
        {
            Boolean found;
            Point p = new Point();

            Label lbl = (Label)sender;

            /* Find out where the label is placed in the table */
            found = Get_Point_From_Label_Reference(lbl, out p);

            if (found)
            {
                if (lbl.Text == Set_LED)
                {
                    lbl.Text = Clear_LED;
                    LED_Matrix[p.Y, p.X] = false;
                }
                else
                {
                    lbl.Text = Set_LED;
                    LED_Matrix[p.Y, p.X] = true;
                }

                if (chkEnableDraw.Checked)
                {
                    /* Send the command to the PIC */
                    Process_Ev.Draw_Raw_Frame(LED_Matrix);
                }
            }
        }
    }
}

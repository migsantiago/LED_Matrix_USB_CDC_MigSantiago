namespace LED_Matrix_CDC
{
    partial class Main_Form
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCOMPort = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtDrawNumber = new System.Windows.Forms.TextBox();
            this.btnDrawNumber = new System.Windows.Forms.Button();
            this.btnSetPICTime = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.cmbRotation = new System.Windows.Forms.ComboBox();
            this.btnGameLife = new System.Windows.Forms.Button();
            this.tblMatrix = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.chkEnableDraw = new System.Windows.Forms.CheckBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnPlotFFT = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFFTLevel = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.txtMaxFrequency = new System.Windows.Forms.TextBox();
            this.tblMatrix.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // txtCOMPort
            // 
            this.txtCOMPort.Location = new System.Drawing.Point(71, 6);
            this.txtCOMPort.Name = "txtCOMPort";
            this.txtCOMPort.Size = new System.Drawing.Size(55, 20);
            this.txtCOMPort.TabIndex = 1;
            this.txtCOMPort.Text = "COM3";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // txtDrawNumber
            // 
            this.txtDrawNumber.Location = new System.Drawing.Point(140, 62);
            this.txtDrawNumber.Name = "txtDrawNumber";
            this.txtDrawNumber.Size = new System.Drawing.Size(36, 20);
            this.txtDrawNumber.TabIndex = 1;
            this.txtDrawNumber.Text = "0";
            // 
            // btnDrawNumber
            // 
            this.btnDrawNumber.Location = new System.Drawing.Point(12, 61);
            this.btnDrawNumber.Name = "btnDrawNumber";
            this.btnDrawNumber.Size = new System.Drawing.Size(114, 23);
            this.btnDrawNumber.TabIndex = 2;
            this.btnDrawNumber.Text = "Draw this number:";
            this.btnDrawNumber.UseVisualStyleBackColor = true;
            this.btnDrawNumber.Click += new System.EventHandler(this.btnDrawNumber_Click);
            // 
            // btnSetPICTime
            // 
            this.btnSetPICTime.Location = new System.Drawing.Point(12, 90);
            this.btnSetPICTime.Name = "btnSetPICTime";
            this.btnSetPICTime.Size = new System.Drawing.Size(164, 23);
            this.btnSetPICTime.TabIndex = 4;
            this.btnSetPICTime.Text = "Set PIC time";
            this.btnSetPICTime.UseVisualStyleBackColor = true;
            this.btnSetPICTime.Click += new System.EventHandler(this.btnSetPICTime_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(12, 119);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(114, 23);
            this.btnRotate.TabIndex = 5;
            this.btnRotate.Text = "Set Rotation";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // cmbRotation
            // 
            this.cmbRotation.FormattingEnabled = true;
            this.cmbRotation.Items.AddRange(new object[] {
            "0°",
            "90°",
            "180°",
            "270°"});
            this.cmbRotation.Location = new System.Drawing.Point(132, 121);
            this.cmbRotation.Name = "cmbRotation";
            this.cmbRotation.Size = new System.Drawing.Size(44, 21);
            this.cmbRotation.TabIndex = 6;
            // 
            // btnGameLife
            // 
            this.btnGameLife.Location = new System.Drawing.Point(12, 148);
            this.btnGameLife.Name = "btnGameLife";
            this.btnGameLife.Size = new System.Drawing.Size(164, 23);
            this.btnGameLife.TabIndex = 7;
            this.btnGameLife.Text = "Game of Life =)";
            this.btnGameLife.UseVisualStyleBackColor = true;
            this.btnGameLife.Click += new System.EventHandler(this.btnGameLife_Click);
            // 
            // tblMatrix
            // 
            this.tblMatrix.AutoSize = true;
            this.tblMatrix.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.tblMatrix.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblMatrix.ColumnCount = 7;
            this.tblMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tblMatrix.Controls.Add(this.label51, 0, 6);
            this.tblMatrix.Controls.Add(this.label50, 0, 6);
            this.tblMatrix.Controls.Add(this.label49, 0, 6);
            this.tblMatrix.Controls.Add(this.label48, 0, 6);
            this.tblMatrix.Controls.Add(this.label47, 0, 6);
            this.tblMatrix.Controls.Add(this.label46, 0, 6);
            this.tblMatrix.Controls.Add(this.label45, 0, 5);
            this.tblMatrix.Controls.Add(this.label44, 0, 5);
            this.tblMatrix.Controls.Add(this.label43, 0, 5);
            this.tblMatrix.Controls.Add(this.label42, 0, 5);
            this.tblMatrix.Controls.Add(this.label41, 0, 5);
            this.tblMatrix.Controls.Add(this.label40, 0, 5);
            this.tblMatrix.Controls.Add(this.label39, 0, 5);
            this.tblMatrix.Controls.Add(this.label38, 0, 4);
            this.tblMatrix.Controls.Add(this.label37, 0, 4);
            this.tblMatrix.Controls.Add(this.label36, 0, 4);
            this.tblMatrix.Controls.Add(this.label35, 0, 4);
            this.tblMatrix.Controls.Add(this.label34, 0, 4);
            this.tblMatrix.Controls.Add(this.label33, 0, 4);
            this.tblMatrix.Controls.Add(this.label32, 0, 4);
            this.tblMatrix.Controls.Add(this.label31, 0, 3);
            this.tblMatrix.Controls.Add(this.label30, 0, 3);
            this.tblMatrix.Controls.Add(this.label29, 0, 3);
            this.tblMatrix.Controls.Add(this.label28, 0, 3);
            this.tblMatrix.Controls.Add(this.label27, 0, 3);
            this.tblMatrix.Controls.Add(this.label26, 0, 3);
            this.tblMatrix.Controls.Add(this.label25, 0, 3);
            this.tblMatrix.Controls.Add(this.label24, 0, 2);
            this.tblMatrix.Controls.Add(this.label23, 0, 2);
            this.tblMatrix.Controls.Add(this.label22, 0, 2);
            this.tblMatrix.Controls.Add(this.label21, 0, 2);
            this.tblMatrix.Controls.Add(this.label20, 0, 2);
            this.tblMatrix.Controls.Add(this.label19, 0, 2);
            this.tblMatrix.Controls.Add(this.label18, 0, 2);
            this.tblMatrix.Controls.Add(this.label17, 0, 1);
            this.tblMatrix.Controls.Add(this.label16, 0, 1);
            this.tblMatrix.Controls.Add(this.label15, 0, 1);
            this.tblMatrix.Controls.Add(this.label14, 0, 1);
            this.tblMatrix.Controls.Add(this.label13, 0, 1);
            this.tblMatrix.Controls.Add(this.label12, 0, 1);
            this.tblMatrix.Controls.Add(this.label11, 0, 1);
            this.tblMatrix.Controls.Add(this.label10, 0, 0);
            this.tblMatrix.Controls.Add(this.label9, 0, 0);
            this.tblMatrix.Controls.Add(this.label8, 0, 0);
            this.tblMatrix.Controls.Add(this.label7, 0, 0);
            this.tblMatrix.Controls.Add(this.label6, 0, 0);
            this.tblMatrix.Controls.Add(this.label5, 0, 0);
            this.tblMatrix.Controls.Add(this.label4, 0, 0);
            this.tblMatrix.Controls.Add(this.label3, 0, 0);
            this.tblMatrix.ForeColor = System.Drawing.Color.Yellow;
            this.tblMatrix.Location = new System.Drawing.Point(19, 292);
            this.tblMatrix.Name = "tblMatrix";
            this.tblMatrix.RowCount = 7;
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMatrix.Size = new System.Drawing.Size(152, 148);
            this.tblMatrix.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label3.Location = new System.Drawing.Point(109, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "b";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.LED_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label4.Location = new System.Drawing.Point(88, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "b";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.LED_Click);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label5.Location = new System.Drawing.Point(4, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "b";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.LED_Click);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label6.Location = new System.Drawing.Point(130, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "b";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.LED_Click);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label7.Location = new System.Drawing.Point(25, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "b";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.LED_Click);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label8.Location = new System.Drawing.Point(4, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "b";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.LED_Click);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label9.Location = new System.Drawing.Point(67, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "b";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Click += new System.EventHandler(this.LED_Click);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label10.Location = new System.Drawing.Point(46, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "b";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.Click += new System.EventHandler(this.LED_Click);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label11.Location = new System.Drawing.Point(109, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "b";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.Click += new System.EventHandler(this.LED_Click);
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label12.Location = new System.Drawing.Point(130, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 20);
            this.label12.TabIndex = 10;
            this.label12.Text = "b";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Click += new System.EventHandler(this.LED_Click);
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label13.Location = new System.Drawing.Point(4, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 20);
            this.label13.TabIndex = 11;
            this.label13.Text = "b";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Click += new System.EventHandler(this.LED_Click);
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label14.Location = new System.Drawing.Point(88, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 20);
            this.label14.TabIndex = 12;
            this.label14.Text = "b";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label14.Click += new System.EventHandler(this.LED_Click);
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label15.Location = new System.Drawing.Point(25, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 20);
            this.label15.TabIndex = 13;
            this.label15.Text = "b";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label15.Click += new System.EventHandler(this.LED_Click);
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label16.Location = new System.Drawing.Point(46, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 20);
            this.label16.TabIndex = 14;
            this.label16.Text = "b";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label16.Click += new System.EventHandler(this.LED_Click);
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label17.Location = new System.Drawing.Point(67, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 20);
            this.label17.TabIndex = 15;
            this.label17.Text = "b";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label17.Click += new System.EventHandler(this.LED_Click);
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label18.Location = new System.Drawing.Point(109, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 20);
            this.label18.TabIndex = 16;
            this.label18.Text = "b";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label18.Click += new System.EventHandler(this.LED_Click);
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label19.Location = new System.Drawing.Point(130, 43);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 20);
            this.label19.TabIndex = 17;
            this.label19.Text = "b";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label19.Click += new System.EventHandler(this.LED_Click);
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label20.Location = new System.Drawing.Point(4, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 20);
            this.label20.TabIndex = 18;
            this.label20.Text = "b";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label20.Click += new System.EventHandler(this.LED_Click);
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label21.Location = new System.Drawing.Point(88, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 20);
            this.label21.TabIndex = 19;
            this.label21.Text = "b";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label21.Click += new System.EventHandler(this.LED_Click);
            // 
            // label22
            // 
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label22.Location = new System.Drawing.Point(25, 43);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(14, 20);
            this.label22.TabIndex = 20;
            this.label22.Text = "b";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label22.Click += new System.EventHandler(this.LED_Click);
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label23.Location = new System.Drawing.Point(46, 43);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(14, 20);
            this.label23.TabIndex = 21;
            this.label23.Text = "b";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label23.Click += new System.EventHandler(this.LED_Click);
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label24.Location = new System.Drawing.Point(67, 43);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(14, 20);
            this.label24.TabIndex = 22;
            this.label24.Text = "b";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label24.Click += new System.EventHandler(this.LED_Click);
            // 
            // label25
            // 
            this.label25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label25.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label25.Location = new System.Drawing.Point(46, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(14, 20);
            this.label25.TabIndex = 23;
            this.label25.Text = "b";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label25.Click += new System.EventHandler(this.LED_Click);
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label26.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label26.Location = new System.Drawing.Point(25, 64);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(14, 20);
            this.label26.TabIndex = 24;
            this.label26.Text = "b";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label26.Click += new System.EventHandler(this.LED_Click);
            // 
            // label27
            // 
            this.label27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label27.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label27.Location = new System.Drawing.Point(67, 64);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(14, 20);
            this.label27.TabIndex = 25;
            this.label27.Text = "b";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label27.Click += new System.EventHandler(this.LED_Click);
            // 
            // label28
            // 
            this.label28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label28.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label28.Location = new System.Drawing.Point(130, 64);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(18, 20);
            this.label28.TabIndex = 26;
            this.label28.Text = "b";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label28.Click += new System.EventHandler(this.LED_Click);
            // 
            // label29
            // 
            this.label29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label29.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label29.Location = new System.Drawing.Point(4, 85);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(14, 20);
            this.label29.TabIndex = 27;
            this.label29.Text = "b";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label29.Click += new System.EventHandler(this.LED_Click);
            // 
            // label30
            // 
            this.label30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label30.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label30.Location = new System.Drawing.Point(88, 64);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(14, 20);
            this.label30.TabIndex = 28;
            this.label30.Text = "b";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label30.Click += new System.EventHandler(this.LED_Click);
            // 
            // label31
            // 
            this.label31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label31.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label31.Location = new System.Drawing.Point(109, 64);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(14, 20);
            this.label31.TabIndex = 29;
            this.label31.Text = "b";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label31.Click += new System.EventHandler(this.LED_Click);
            // 
            // label32
            // 
            this.label32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label32.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label32.Location = new System.Drawing.Point(109, 85);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(14, 20);
            this.label32.TabIndex = 30;
            this.label32.Text = "b";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label32.Click += new System.EventHandler(this.LED_Click);
            // 
            // label33
            // 
            this.label33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label33.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label33.Location = new System.Drawing.Point(130, 85);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(18, 20);
            this.label33.TabIndex = 31;
            this.label33.Text = "b";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label33.Click += new System.EventHandler(this.LED_Click);
            // 
            // label34
            // 
            this.label34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label34.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label34.Location = new System.Drawing.Point(4, 106);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(14, 20);
            this.label34.TabIndex = 32;
            this.label34.Text = "b";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label34.Click += new System.EventHandler(this.LED_Click);
            // 
            // label35
            // 
            this.label35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label35.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label35.Location = new System.Drawing.Point(88, 85);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(14, 20);
            this.label35.TabIndex = 33;
            this.label35.Text = "b";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label35.Click += new System.EventHandler(this.LED_Click);
            // 
            // label36
            // 
            this.label36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label36.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label36.Location = new System.Drawing.Point(25, 85);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(14, 20);
            this.label36.TabIndex = 34;
            this.label36.Text = "b";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label36.Click += new System.EventHandler(this.LED_Click);
            // 
            // label37
            // 
            this.label37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label37.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label37.Location = new System.Drawing.Point(46, 85);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(14, 20);
            this.label37.TabIndex = 35;
            this.label37.Text = "b";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label37.Click += new System.EventHandler(this.LED_Click);
            // 
            // label38
            // 
            this.label38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label38.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label38.Location = new System.Drawing.Point(67, 85);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(14, 20);
            this.label38.TabIndex = 36;
            this.label38.Text = "b";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label38.Click += new System.EventHandler(this.LED_Click);
            // 
            // label39
            // 
            this.label39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label39.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label39.Location = new System.Drawing.Point(109, 106);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(14, 20);
            this.label39.TabIndex = 37;
            this.label39.Text = "b";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label39.Click += new System.EventHandler(this.LED_Click);
            // 
            // label40
            // 
            this.label40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label40.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label40.Location = new System.Drawing.Point(130, 106);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(18, 20);
            this.label40.TabIndex = 38;
            this.label40.Text = "b";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label40.Click += new System.EventHandler(this.LED_Click);
            // 
            // label41
            // 
            this.label41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label41.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label41.Location = new System.Drawing.Point(4, 127);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(14, 20);
            this.label41.TabIndex = 39;
            this.label41.Text = "b";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label41.Click += new System.EventHandler(this.LED_Click);
            // 
            // label42
            // 
            this.label42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label42.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label42.Location = new System.Drawing.Point(88, 106);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(14, 20);
            this.label42.TabIndex = 40;
            this.label42.Text = "b";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label42.Click += new System.EventHandler(this.LED_Click);
            // 
            // label43
            // 
            this.label43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label43.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label43.Location = new System.Drawing.Point(25, 106);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(14, 20);
            this.label43.TabIndex = 41;
            this.label43.Text = "b";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label43.Click += new System.EventHandler(this.LED_Click);
            // 
            // label44
            // 
            this.label44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label44.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label44.Location = new System.Drawing.Point(46, 106);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(14, 20);
            this.label44.TabIndex = 42;
            this.label44.Text = "b";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label44.Click += new System.EventHandler(this.LED_Click);
            // 
            // label45
            // 
            this.label45.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label45.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label45.Location = new System.Drawing.Point(67, 106);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(14, 20);
            this.label45.TabIndex = 43;
            this.label45.Text = "b";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label45.Click += new System.EventHandler(this.LED_Click);
            // 
            // label46
            // 
            this.label46.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label46.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label46.Location = new System.Drawing.Point(88, 127);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(14, 20);
            this.label46.TabIndex = 44;
            this.label46.Text = "b";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label46.Click += new System.EventHandler(this.LED_Click);
            // 
            // label47
            // 
            this.label47.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label47.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label47.Location = new System.Drawing.Point(109, 127);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(14, 20);
            this.label47.TabIndex = 45;
            this.label47.Text = "b";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label47.Click += new System.EventHandler(this.LED_Click);
            // 
            // label48
            // 
            this.label48.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label48.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label48.Location = new System.Drawing.Point(130, 127);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(18, 20);
            this.label48.TabIndex = 46;
            this.label48.Text = "b";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label48.Click += new System.EventHandler(this.LED_Click);
            // 
            // label49
            // 
            this.label49.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label49.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label49.Location = new System.Drawing.Point(25, 127);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(14, 20);
            this.label49.TabIndex = 47;
            this.label49.Text = "b";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label49.Click += new System.EventHandler(this.LED_Click);
            // 
            // label50
            // 
            this.label50.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label50.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label50.Location = new System.Drawing.Point(46, 127);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(14, 20);
            this.label50.TabIndex = 48;
            this.label50.Text = "b";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label50.Click += new System.EventHandler(this.LED_Click);
            // 
            // label51
            // 
            this.label51.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label51.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label51.Location = new System.Drawing.Point(67, 127);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(14, 20);
            this.label51.TabIndex = 49;
            this.label51.Text = "b";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label51.Click += new System.EventHandler(this.LED_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 32);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // chkEnableDraw
            // 
            this.chkEnableDraw.AutoSize = true;
            this.chkEnableDraw.Location = new System.Drawing.Point(36, 269);
            this.chkEnableDraw.Name = "chkEnableDraw";
            this.chkEnableDraw.Size = new System.Drawing.Size(118, 17);
            this.chkEnableDraw.TabIndex = 9;
            this.chkEnableDraw.Text = "Enable Matrix Draw";
            this.chkEnableDraw.UseVisualStyleBackColor = true;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(101, 32);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnPlotFFT
            // 
            this.btnPlotFFT.Location = new System.Drawing.Point(12, 235);
            this.btnPlotFFT.Name = "btnPlotFFT";
            this.btnPlotFFT.Size = new System.Drawing.Size(164, 23);
            this.btnPlotFFT.TabIndex = 10;
            this.btnPlotFFT.Text = "Plot FFT";
            this.btnPlotFFT.UseVisualStyleBackColor = true;
            this.btnPlotFFT.Click += new System.EventHandler(this.btnPlotFFT_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "FFT Level (dB):";
            // 
            // txtFFTLevel
            // 
            this.txtFFTLevel.Location = new System.Drawing.Point(98, 182);
            this.txtFFTLevel.Name = "txtFFTLevel";
            this.txtFFTLevel.Size = new System.Drawing.Size(46, 20);
            this.txtFFTLevel.TabIndex = 12;
            this.txtFFTLevel.Text = "-12.0";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(12, 212);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(108, 13);
            this.label52.TabIndex = 13;
            this.label52.Text = "Max frequency (kHz):";
            // 
            // txtMaxFrequency
            // 
            this.txtMaxFrequency.Location = new System.Drawing.Point(125, 209);
            this.txtMaxFrequency.Name = "txtMaxFrequency";
            this.txtMaxFrequency.Size = new System.Drawing.Size(50, 20);
            this.txtMaxFrequency.TabIndex = 14;
            this.txtMaxFrequency.Text = "5.0";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 449);
            this.Controls.Add(this.txtMaxFrequency);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.txtFFTLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tblMatrix);
            this.Controls.Add(this.chkEnableDraw);
            this.Controls.Add(this.btnPlotFFT);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.txtCOMPort);
            this.Controls.Add(this.btnGameLife);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbRotation);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnRotate);
            this.Controls.Add(this.btnDrawNumber);
            this.Controls.Add(this.btnSetPICTime);
            this.Controls.Add(this.txtDrawNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.LightGray;
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.tblMatrix.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCOMPort;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txtDrawNumber;
        private System.Windows.Forms.Button btnDrawNumber;
        private System.Windows.Forms.Button btnSetPICTime;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.ComboBox cmbRotation;
        private System.Windows.Forms.Button btnGameLife;
        private System.Windows.Forms.TableLayoutPanel tblMatrix;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.CheckBox chkEnableDraw;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnPlotFFT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFFTLevel;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox txtMaxFrequency;
    }
}


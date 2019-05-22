namespace AirportSimulation
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgwPlanes = new System.Windows.Forms.DataGridView();
            this.dgwPorts = new System.Windows.Forms.DataGridView();
            this.portName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portBusyStops = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portRunwayStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWorldtime = new System.Windows.Forms.Label();
            this.planeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planeCurrentPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planeDest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShowPassengersInFlight = new System.Windows.Forms.Button();
            this.btnShowPlanesInAir = new System.Windows.Forms.Button();
            this.btnShowAllCargo = new System.Windows.Forms.Button();
            this.btnShowCrashedPlanes = new System.Windows.Forms.Button();
            this.lbAirplanes = new System.Windows.Forms.ListBox();
            this.btnPlaneInfo = new System.Windows.Forms.Button();
            this.lbAirports = new System.Windows.Forms.ListBox();
            this.btnPortInfo = new System.Windows.Forms.Button();
            this.nudMinutes = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPlanes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPorts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Самолеты";
            // 
            // dgwPlanes
            // 
            this.dgwPlanes.AllowUserToAddRows = false;
            this.dgwPlanes.AllowUserToDeleteRows = false;
            this.dgwPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPlanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.planeName,
            this.planeCurrentPort,
            this.planeStatus,
            this.planeDest});
            this.dgwPlanes.Location = new System.Drawing.Point(12, 25);
            this.dgwPlanes.Name = "dgwPlanes";
            this.dgwPlanes.ReadOnly = true;
            this.dgwPlanes.Size = new System.Drawing.Size(701, 390);
            this.dgwPlanes.TabIndex = 2;
            // 
            // dgwPorts
            // 
            this.dgwPorts.AllowUserToAddRows = false;
            this.dgwPorts.AllowUserToDeleteRows = false;
            this.dgwPorts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPorts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.portName,
            this.portBusyStops,
            this.portRunwayStatus,
            this.dataGridViewTextBoxColumn4});
            this.dgwPorts.Location = new System.Drawing.Point(719, 25);
            this.dgwPorts.Name = "dgwPorts";
            this.dgwPorts.ReadOnly = true;
            this.dgwPorts.Size = new System.Drawing.Size(545, 390);
            this.dgwPorts.TabIndex = 3;
            // 
            // portName
            // 
            this.portName.HeaderText = "Название аэропорта";
            this.portName.Name = "portName";
            this.portName.ReadOnly = true;
            this.portName.Width = 130;
            // 
            // portBusyStops
            // 
            this.portBusyStops.HeaderText = "Занято стоянок";
            this.portBusyStops.Name = "portBusyStops";
            this.portBusyStops.ReadOnly = true;
            // 
            // portRunwayStatus
            // 
            this.portRunwayStatus.HeaderText = "Статус ВПП";
            this.portRunwayStatus.Name = "portRunwayStatus";
            this.portRunwayStatus.ReadOnly = true;
            this.portRunwayStatus.Width = 170;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Координаты";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(716, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Аэропорты";
            // 
            // lblWorldtime
            // 
            this.lblWorldtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWorldtime.Location = new System.Drawing.Point(1282, 9);
            this.lblWorldtime.Name = "lblWorldtime";
            this.lblWorldtime.Size = new System.Drawing.Size(100, 33);
            this.lblWorldtime.TabIndex = 5;
            this.lblWorldtime.Text = "Время";
            this.lblWorldtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // planeName
            // 
            this.planeName.HeaderText = "Имя самолета";
            this.planeName.Name = "planeName";
            this.planeName.ReadOnly = true;
            this.planeName.Width = 150;
            // 
            // planeCurrentPort
            // 
            this.planeCurrentPort.HeaderText = "Текущий аэропорт";
            this.planeCurrentPort.Name = "planeCurrentPort";
            this.planeCurrentPort.ReadOnly = true;
            // 
            // planeStatus
            // 
            this.planeStatus.HeaderText = "Статус";
            this.planeStatus.Name = "planeStatus";
            this.planeStatus.ReadOnly = true;
            this.planeStatus.Width = 300;
            // 
            // planeDest
            // 
            this.planeDest.HeaderText = "Аэропорт назначения";
            this.planeDest.Name = "planeDest";
            this.planeDest.ReadOnly = true;
            // 
            // btnShowPassengersInFlight
            // 
            this.btnShowPassengersInFlight.Location = new System.Drawing.Point(1270, 45);
            this.btnShowPassengersInFlight.Name = "btnShowPassengersInFlight";
            this.btnShowPassengersInFlight.Size = new System.Drawing.Size(129, 42);
            this.btnShowPassengersInFlight.TabIndex = 6;
            this.btnShowPassengersInFlight.Text = "Кол-во пассажиров в полете";
            this.btnShowPassengersInFlight.UseVisualStyleBackColor = true;
            this.btnShowPassengersInFlight.Click += new System.EventHandler(this.BtnShowPassengersInFlight_Click);
            // 
            // btnShowPlanesInAir
            // 
            this.btnShowPlanesInAir.Location = new System.Drawing.Point(1270, 93);
            this.btnShowPlanesInAir.Name = "btnShowPlanesInAir";
            this.btnShowPlanesInAir.Size = new System.Drawing.Size(129, 42);
            this.btnShowPlanesInAir.TabIndex = 6;
            this.btnShowPlanesInAir.Text = "Кол-во самолетов в воздухе";
            this.btnShowPlanesInAir.UseVisualStyleBackColor = true;
            this.btnShowPlanesInAir.Click += new System.EventHandler(this.BtnShowPlanesInAir_Click);
            // 
            // btnShowAllCargo
            // 
            this.btnShowAllCargo.Location = new System.Drawing.Point(1270, 141);
            this.btnShowAllCargo.Name = "btnShowAllCargo";
            this.btnShowAllCargo.Size = new System.Drawing.Size(129, 42);
            this.btnShowAllCargo.TabIndex = 7;
            this.btnShowAllCargo.Text = "Общее кол-во груза";
            this.btnShowAllCargo.UseVisualStyleBackColor = true;
            this.btnShowAllCargo.Click += new System.EventHandler(this.BtnShowAllCargo_Click);
            // 
            // btnShowCrashedPlanes
            // 
            this.btnShowCrashedPlanes.Location = new System.Drawing.Point(1270, 189);
            this.btnShowCrashedPlanes.Name = "btnShowCrashedPlanes";
            this.btnShowCrashedPlanes.Size = new System.Drawing.Size(129, 42);
            this.btnShowCrashedPlanes.TabIndex = 8;
            this.btnShowCrashedPlanes.Text = "Потерпевшие крушение самолеты";
            this.btnShowCrashedPlanes.UseVisualStyleBackColor = true;
            this.btnShowCrashedPlanes.Click += new System.EventHandler(this.BtnShowCrashedPlanes_Click);
            // 
            // lbAirplanes
            // 
            this.lbAirplanes.FormattingEnabled = true;
            this.lbAirplanes.Location = new System.Drawing.Point(15, 422);
            this.lbAirplanes.Name = "lbAirplanes";
            this.lbAirplanes.Size = new System.Drawing.Size(300, 82);
            this.lbAirplanes.TabIndex = 9;
            // 
            // btnPlaneInfo
            // 
            this.btnPlaneInfo.Location = new System.Drawing.Point(321, 421);
            this.btnPlaneInfo.Name = "btnPlaneInfo";
            this.btnPlaneInfo.Size = new System.Drawing.Size(129, 80);
            this.btnPlaneInfo.TabIndex = 10;
            this.btnPlaneInfo.Text = "Информация по самолету";
            this.btnPlaneInfo.UseVisualStyleBackColor = true;
            this.btnPlaneInfo.Click += new System.EventHandler(this.BtnPlaneInfo_Click);
            // 
            // lbAirports
            // 
            this.lbAirports.FormattingEnabled = true;
            this.lbAirports.Location = new System.Drawing.Point(719, 422);
            this.lbAirports.Name = "lbAirports";
            this.lbAirports.Size = new System.Drawing.Size(300, 82);
            this.lbAirports.TabIndex = 11;
            // 
            // btnPortInfo
            // 
            this.btnPortInfo.Location = new System.Drawing.Point(1025, 422);
            this.btnPortInfo.Name = "btnPortInfo";
            this.btnPortInfo.Size = new System.Drawing.Size(129, 79);
            this.btnPortInfo.TabIndex = 12;
            this.btnPortInfo.Text = "Информация по самолету";
            this.btnPortInfo.UseVisualStyleBackColor = true;
            this.btnPortInfo.Click += new System.EventHandler(this.BtnPortInfo_Click);
            // 
            // nudMinutes
            // 
            this.nudMinutes.Location = new System.Drawing.Point(1270, 395);
            this.nudMinutes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMinutes.Name = "nudMinutes";
            this.nudMinutes.Size = new System.Drawing.Size(129, 20);
            this.nudMinutes.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1270, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 55);
            this.button1.TabIndex = 14;
            this.button1.Text = "Самолеты, у которых ост. время полета ниже, чем";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1406, 513);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nudMinutes);
            this.Controls.Add(this.btnPortInfo);
            this.Controls.Add(this.lbAirports);
            this.Controls.Add(this.btnPlaneInfo);
            this.Controls.Add(this.lbAirplanes);
            this.Controls.Add(this.btnShowCrashedPlanes);
            this.Controls.Add(this.btnShowAllCargo);
            this.Controls.Add(this.btnShowPlanesInAir);
            this.Controls.Add(this.btnShowPassengersInFlight);
            this.Controls.Add(this.lblWorldtime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgwPorts);
            this.Controls.Add(this.dgwPlanes);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Просмотр";
            ((System.ComponentModel.ISupportInitialize)(this.dgwPlanes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPorts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgwPlanes;
        private System.Windows.Forms.DataGridView dgwPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWorldtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn portName;
        private System.Windows.Forms.DataGridViewTextBoxColumn portBusyStops;
        private System.Windows.Forms.DataGridViewTextBoxColumn portRunwayStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn planeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn planeCurrentPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn planeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn planeDest;
        private System.Windows.Forms.Button btnShowPassengersInFlight;
        private System.Windows.Forms.Button btnShowPlanesInAir;
        private System.Windows.Forms.Button btnShowAllCargo;
        private System.Windows.Forms.Button btnShowCrashedPlanes;
        private System.Windows.Forms.ListBox lbAirplanes;
        private System.Windows.Forms.Button btnPlaneInfo;
        private System.Windows.Forms.ListBox lbAirports;
        private System.Windows.Forms.Button btnPortInfo;
        private System.Windows.Forms.NumericUpDown nudMinutes;
        private System.Windows.Forms.Button button1;
    }
}


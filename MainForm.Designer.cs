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
            this.label2 = new System.Windows.Forms.Label();
            this.lblWorldtime = new System.Windows.Forms.Label();
            this.planeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planeCurrentPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planeDest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portBusyStops = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portRunwayStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPlanes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPorts)).BeginInit();
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
            this.dgwPlanes.Size = new System.Drawing.Size(545, 390);
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
            this.dgwPorts.Location = new System.Drawing.Point(563, 25);
            this.dgwPorts.Name = "dgwPorts";
            this.dgwPorts.ReadOnly = true;
            this.dgwPorts.Size = new System.Drawing.Size(545, 390);
            this.dgwPorts.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Аэропорты";
            // 
            // lblWorldtime
            // 
            this.lblWorldtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWorldtime.Location = new System.Drawing.Point(1114, 9);
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
            this.planeStatus.Width = 150;
            // 
            // planeDest
            // 
            this.planeDest.HeaderText = "Аэропорт назначения";
            this.planeDest.Name = "planeDest";
            this.planeDest.ReadOnly = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 450);
            this.Controls.Add(this.lblWorldtime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgwPorts);
            this.Controls.Add(this.dgwPlanes);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Просмотр";
            ((System.ComponentModel.ISupportInitialize)(this.dgwPlanes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPorts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgwPlanes;
        private System.Windows.Forms.DataGridView dgwPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWorldtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn planeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn planeCurrentPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn planeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn planeDest;
        private System.Windows.Forms.DataGridViewTextBoxColumn portName;
        private System.Windows.Forms.DataGridViewTextBoxColumn portBusyStops;
        private System.Windows.Forms.DataGridViewTextBoxColumn portRunwayStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}


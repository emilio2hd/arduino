namespace LeitorDeClimaComArduino
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.arduino = new System.IO.Ports.SerialPort(this.components);
            this.portasComboBox = new System.Windows.Forms.ComboBox();
            this.portaLabel = new System.Windows.Forms.Label();
            this.baudRateComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btConectar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btDesconectar = new System.Windows.Forms.Button();
            this.btLimparHistorico = new System.Windows.Forms.Button();
            this.rodape = new System.Windows.Forms.StatusStrip();
            this.lblStatusBarraFerramentas = new System.Windows.Forms.ToolStripStatusLabel();
            this.temporizador = new System.Windows.Forms.Timer(this.components);
            this.historicoDeClima = new System.Windows.Forms.DataGridView();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temperaturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.umidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.climaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.rodape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historicoDeClima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.climaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // arduino
            // 
            this.arduino.DtrEnable = true;
            this.arduino.PortName = "COM16";
            this.arduino.RtsEnable = true;
            this.arduino.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ArduinoDataReceived);
            // 
            // portasComboBox
            // 
            this.portasComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portasComboBox.FormattingEnabled = true;
            this.portasComboBox.Location = new System.Drawing.Point(9, 40);
            this.portasComboBox.Name = "portasComboBox";
            this.portasComboBox.Size = new System.Drawing.Size(121, 21);
            this.portasComboBox.TabIndex = 9;
            // 
            // portaLabel
            // 
            this.portaLabel.AutoSize = true;
            this.portaLabel.Location = new System.Drawing.Point(6, 24);
            this.portaLabel.Name = "portaLabel";
            this.portaLabel.Size = new System.Drawing.Size(35, 13);
            this.portaLabel.TabIndex = 10;
            this.portaLabel.Text = "Porta:";
            // 
            // baudRateComboBox
            // 
            this.baudRateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudRateComboBox.FormattingEnabled = true;
            this.baudRateComboBox.Location = new System.Drawing.Point(149, 40);
            this.baudRateComboBox.Name = "baudRateComboBox";
            this.baudRateComboBox.Size = new System.Drawing.Size(123, 21);
            this.baudRateComboBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "BaudRate:";
            // 
            // btConectar
            // 
            this.btConectar.Location = new System.Drawing.Point(183, 3);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(75, 23);
            this.btConectar.TabIndex = 13;
            this.btConectar.Text = "Conectar";
            this.btConectar.UseVisualStyleBackColor = true;
            this.btConectar.Click += new System.EventHandler(this.BtConectarClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.baudRateComboBox);
            this.groupBox1.Controls.Add(this.portasComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.portaLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 105);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btConectar);
            this.flowLayoutPanel1.Controls.Add(this.btDesconectar);
            this.flowLayoutPanel1.Controls.Add(this.btLimparHistorico);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 67);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(261, 31);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // btDesconectar
            // 
            this.btDesconectar.Location = new System.Drawing.Point(95, 3);
            this.btDesconectar.Name = "btDesconectar";
            this.btDesconectar.Size = new System.Drawing.Size(82, 23);
            this.btDesconectar.TabIndex = 14;
            this.btDesconectar.Text = "Desconectar";
            this.btDesconectar.UseVisualStyleBackColor = true;
            this.btDesconectar.Visible = false;
            this.btDesconectar.Click += new System.EventHandler(this.BtDesconectarClick);
            // 
            // btLimparHistorico
            // 
            this.btLimparHistorico.Enabled = false;
            this.btLimparHistorico.Location = new System.Drawing.Point(3, 3);
            this.btLimparHistorico.Name = "btLimparHistorico";
            this.btLimparHistorico.Size = new System.Drawing.Size(86, 23);
            this.btLimparHistorico.TabIndex = 15;
            this.btLimparHistorico.Text = "Limpar Lista";
            this.btLimparHistorico.UseVisualStyleBackColor = true;
            this.btLimparHistorico.Click += new System.EventHandler(this.BtLimparHistoricoClick);
            // 
            // rodape
            // 
            this.rodape.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusBarraFerramentas});
            this.rodape.Location = new System.Drawing.Point(0, 289);
            this.rodape.Name = "rodape";
            this.rodape.Size = new System.Drawing.Size(302, 22);
            this.rodape.TabIndex = 15;
            this.rodape.Text = "rodape";
            // 
            // lblStatusBarraFerramentas
            // 
            this.lblStatusBarraFerramentas.Name = "lblStatusBarraFerramentas";
            this.lblStatusBarraFerramentas.Size = new System.Drawing.Size(85, 17);
            this.lblStatusBarraFerramentas.Text = "Desconectado.";
            // 
            // temporizador
            // 
            this.temporizador.Interval = 10000;
            this.temporizador.Tick += new System.EventHandler(this.TemporizadorTick);
            // 
            // historicoDeClima
            // 
            this.historicoDeClima.AllowUserToAddRows = false;
            this.historicoDeClima.AllowUserToDeleteRows = false;
            this.historicoDeClima.AllowUserToResizeColumns = false;
            this.historicoDeClima.AllowUserToResizeRows = false;
            this.historicoDeClima.AutoGenerateColumns = false;
            this.historicoDeClima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.historicoDeClima.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.temperaturaDataGridViewTextBoxColumn,
            this.umidadeDataGridViewTextBoxColumn,
            this.Data});
            this.historicoDeClima.DataSource = this.climaBindingSource;
            this.historicoDeClima.Location = new System.Drawing.Point(12, 120);
            this.historicoDeClima.Margin = new System.Windows.Forms.Padding(0);
            this.historicoDeClima.MultiSelect = false;
            this.historicoDeClima.Name = "historicoDeClima";
            this.historicoDeClima.ReadOnly = true;
            this.historicoDeClima.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.historicoDeClima.RowHeadersVisible = false;
            this.historicoDeClima.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.historicoDeClima.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.historicoDeClima.Size = new System.Drawing.Size(278, 154);
            this.historicoDeClima.TabIndex = 16;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "Data";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm";
            dataGridViewCellStyle3.NullValue = null;
            this.Data.DefaultCellStyle = dataGridViewCellStyle3;
            this.Data.FillWeight = 97F;
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Data.Width = 97;
            // 
            // temperaturaDataGridViewTextBoxColumn
            // 
            this.temperaturaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.temperaturaDataGridViewTextBoxColumn.DataPropertyName = "Temperatura";
            this.temperaturaDataGridViewTextBoxColumn.FillWeight = 92F;
            this.temperaturaDataGridViewTextBoxColumn.HeaderText = "Temperatura º C";
            this.temperaturaDataGridViewTextBoxColumn.Name = "temperaturaDataGridViewTextBoxColumn";
            this.temperaturaDataGridViewTextBoxColumn.ReadOnly = true;
            this.temperaturaDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.temperaturaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.temperaturaDataGridViewTextBoxColumn.Width = 92;
            // 
            // umidadeDataGridViewTextBoxColumn
            // 
            this.umidadeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.umidadeDataGridViewTextBoxColumn.DataPropertyName = "Umidade";
            this.umidadeDataGridViewTextBoxColumn.FillWeight = 68F;
            this.umidadeDataGridViewTextBoxColumn.HeaderText = "Umidade %";
            this.umidadeDataGridViewTextBoxColumn.Name = "umidadeDataGridViewTextBoxColumn";
            this.umidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.umidadeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.umidadeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.umidadeDataGridViewTextBoxColumn.Width = 68;
            // 
            // climaBindingSource
            // 
            this.climaBindingSource.DataSource = typeof(LeitorDeClimaComArduino.Clima);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 311);
            this.Controls.Add(this.historicoDeClima);
            this.Controls.Add(this.rodape);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leitor de Clima do Arduino";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipalClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.rodape.ResumeLayout(false);
            this.rodape.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historicoDeClima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.climaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort arduino;
        private System.Windows.Forms.ComboBox portasComboBox;
        private System.Windows.Forms.Label portaLabel;
        private System.Windows.Forms.ComboBox baudRateComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btConectar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btDesconectar;
        private System.Windows.Forms.StatusStrip rodape;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBarraFerramentas;
        private System.Windows.Forms.Timer temporizador;
        private System.Windows.Forms.DataGridView historicoDeClima;
        private System.Windows.Forms.BindingSource climaBindingSource;
        private System.Windows.Forms.Button btLimparHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn temperaturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn umidadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
    }
}


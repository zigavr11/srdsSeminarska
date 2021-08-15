namespace SRDS_SN
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.prekini_povezavo = new System.Windows.Forms.Button();
            this.povezi_button = new System.Windows.Forms.Button();
            this.stevilo_shranjenih_bytov_label = new System.Windows.Forms.Label();
            this.output_RTB = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.WaveViewer = new NAudio.Gui.WaveViewer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.datotekaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odpriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clear_errors = new System.Windows.Forms.Button();
            this.error_RTB = new System.Windows.Forms.RichTextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.prekini_povezavo);
            this.panel1.Controls.Add(this.clear_errors);
            this.panel1.Controls.Add(this.povezi_button);
            this.panel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panel1.Location = new System.Drawing.Point(3, 530);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 29);
            this.panel1.TabIndex = 0;
            // 
            // prekini_povezavo
            // 
            this.prekini_povezavo.Dock = System.Windows.Forms.DockStyle.Right;
            this.prekini_povezavo.Location = new System.Drawing.Point(832, 0);
            this.prekini_povezavo.Name = "prekini_povezavo";
            this.prekini_povezavo.Size = new System.Drawing.Size(114, 29);
            this.prekini_povezavo.TabIndex = 2;
            this.prekini_povezavo.Text = "Prekini povezavo";
            this.prekini_povezavo.UseVisualStyleBackColor = true;
            this.prekini_povezavo.Click += new System.EventHandler(this.prekini_povezavo_Click);
            // 
            // povezi_button
            // 
            this.povezi_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.povezi_button.Location = new System.Drawing.Point(946, 0);
            this.povezi_button.Name = "povezi_button";
            this.povezi_button.Size = new System.Drawing.Size(137, 29);
            this.povezi_button.TabIndex = 0;
            this.povezi_button.Text = "Poveži se s ploščico";
            this.povezi_button.UseVisualStyleBackColor = true;
            this.povezi_button.Click += new System.EventHandler(this.povezi_button_Click);
            // 
            // stevilo_shranjenih_bytov_label
            // 
            this.stevilo_shranjenih_bytov_label.Location = new System.Drawing.Point(772, 495);
            this.stevilo_shranjenih_bytov_label.Name = "stevilo_shranjenih_bytov_label";
            this.stevilo_shranjenih_bytov_label.Size = new System.Drawing.Size(314, 29);
            this.stevilo_shranjenih_bytov_label.TabIndex = 1;
            this.stevilo_shranjenih_bytov_label.Text = "status";
            this.stevilo_shranjenih_bytov_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // output_RTB
            // 
            this.output_RTB.Location = new System.Drawing.Point(772, 244);
            this.output_RTB.Name = "output_RTB";
            this.output_RTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.output_RTB.Size = new System.Drawing.Size(305, 248);
            this.output_RTB.TabIndex = 0;
            this.output_RTB.Text = "";
            this.output_RTB.TextChanged += new System.EventHandler(this.output_RTB_TextChanged);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // WaveViewer
            // 
            this.WaveViewer.Location = new System.Drawing.Point(3, 244);
            this.WaveViewer.Name = "WaveViewer";
            this.WaveViewer.SamplesPerPixel = 128;
            this.WaveViewer.Size = new System.Drawing.Size(763, 280);
            this.WaveViewer.StartPosition = ((long)(0));
            this.WaveViewer.TabIndex = 5;
            this.WaveViewer.WaveStream = null;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datotekaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1098, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // datotekaToolStripMenuItem
            // 
            this.datotekaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.odpriToolStripMenuItem});
            this.datotekaToolStripMenuItem.Name = "datotekaToolStripMenuItem";
            this.datotekaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.datotekaToolStripMenuItem.Text = "Datoteka";
            // 
            // odpriToolStripMenuItem
            // 
            this.odpriToolStripMenuItem.Name = "odpriToolStripMenuItem";
            this.odpriToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.odpriToolStripMenuItem.Text = "Odpri";
            this.odpriToolStripMenuItem.Click += new System.EventHandler(this.odpriToolStripMenuItem_Click);
            // 
            // clear_errors
            // 
            this.clear_errors.Dock = System.Windows.Forms.DockStyle.Left;
            this.clear_errors.Location = new System.Drawing.Point(0, 0);
            this.clear_errors.Name = "clear_errors";
            this.clear_errors.Size = new System.Drawing.Size(120, 29);
            this.clear_errors.TabIndex = 1;
            this.clear_errors.Text = "Pobrisi errorje";
            this.clear_errors.UseVisualStyleBackColor = true;
            this.clear_errors.Click += new System.EventHandler(this.clear_errors_Click);
            // 
            // error_RTB
            // 
            this.error_RTB.BackColor = System.Drawing.SystemColors.Window;
            this.error_RTB.Location = new System.Drawing.Point(772, 27);
            this.error_RTB.Name = "error_RTB";
            this.error_RTB.Size = new System.Drawing.Size(305, 211);
            this.error_RTB.TabIndex = 4;
            this.error_RTB.Text = "";
            this.error_RTB.TextChanged += new System.EventHandler(this.output_RTB_TextChanged);
            // 
            // chart
            // 
            chartArea7.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart.Legends.Add(legend7);
            this.chart.Location = new System.Drawing.Point(12, 27);
            this.chart.Name = "chart";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chart.Series.Add(series7);
            this.chart.Size = new System.Drawing.Size(754, 211);
            this.chart.TabIndex = 8;
            this.chart.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 560);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.stevilo_shranjenih_bytov_label);
            this.Controls.Add(this.WaveViewer);
            this.Controls.Add(this.output_RTB);
            this.Controls.Add(this.error_RTB);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glavno okno";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button povezi_button;
        private System.Windows.Forms.Label stevilo_shranjenih_bytov_label;
        private System.Windows.Forms.Button prekini_povezavo;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.RichTextBox output_RTB;
        private NAudio.Gui.WaveViewer WaveViewer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem datotekaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odpriToolStripMenuItem;
        private System.Windows.Forms.Button clear_errors;
        private System.Windows.Forms.RichTextBox error_RTB;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Timer timer1;
    }
}


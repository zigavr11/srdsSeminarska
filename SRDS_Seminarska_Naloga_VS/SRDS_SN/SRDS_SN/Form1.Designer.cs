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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.shrani_button = new System.Windows.Forms.Button();
            this.prekini_povezavo = new System.Windows.Forms.Button();
            this.clear_errors = new System.Windows.Forms.Button();
            this.povezi_button = new System.Windows.Forms.Button();
            this.stevilo_shranjenih_bytov_label = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.datotekaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odpriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamingAudioPCM = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.recordedAudioPCM = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.recordedAudioWAV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.output_RTB = new System.Windows.Forms.RichTextBox();
            this.error_RTB = new System.Windows.Forms.RichTextBox();
            this.streamingAudioWAV = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.streamingAudioPCM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordedAudioPCM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordedAudioWAV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamingAudioWAV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.shrani_button);
            this.panel1.Controls.Add(this.prekini_povezavo);
            this.panel1.Controls.Add(this.clear_errors);
            this.panel1.Controls.Add(this.povezi_button);
            this.panel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panel1.Location = new System.Drawing.Point(3, 657);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 29);
            this.panel1.TabIndex = 0;
            // 
            // shrani_button
            // 
            this.shrani_button.Dock = System.Windows.Forms.DockStyle.Left;
            this.shrani_button.Location = new System.Drawing.Point(120, 0);
            this.shrani_button.Name = "shrani_button";
            this.shrani_button.Size = new System.Drawing.Size(108, 29);
            this.shrani_button.TabIndex = 3;
            this.shrani_button.Text = "Shrani v Wav";
            this.shrani_button.UseVisualStyleBackColor = true;
            this.shrani_button.Click += new System.EventHandler(this.shrani_button_Click);
            // 
            // prekini_povezavo
            // 
            this.prekini_povezavo.Dock = System.Windows.Forms.DockStyle.Right;
            this.prekini_povezavo.Location = new System.Drawing.Point(910, 0);
            this.prekini_povezavo.Name = "prekini_povezavo";
            this.prekini_povezavo.Size = new System.Drawing.Size(114, 29);
            this.prekini_povezavo.TabIndex = 2;
            this.prekini_povezavo.Text = "Prekini povezavo";
            this.prekini_povezavo.UseVisualStyleBackColor = true;
            this.prekini_povezavo.Click += new System.EventHandler(this.prekini_povezavo_Click);
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
            // povezi_button
            // 
            this.povezi_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.povezi_button.Location = new System.Drawing.Point(1024, 0);
            this.povezi_button.Name = "povezi_button";
            this.povezi_button.Size = new System.Drawing.Size(137, 29);
            this.povezi_button.TabIndex = 0;
            this.povezi_button.Text = "Poveži se s ploščico";
            this.povezi_button.UseVisualStyleBackColor = true;
            this.povezi_button.Click += new System.EventHandler(this.povezi_button_Click);
            // 
            // stevilo_shranjenih_bytov_label
            // 
            this.stevilo_shranjenih_bytov_label.Location = new System.Drawing.Point(772, 622);
            this.stevilo_shranjenih_bytov_label.Name = "stevilo_shranjenih_bytov_label";
            this.stevilo_shranjenih_bytov_label.Size = new System.Drawing.Size(314, 29);
            this.stevilo_shranjenih_bytov_label.TabIndex = 1;
            this.stevilo_shranjenih_bytov_label.Text = "status";
            this.stevilo_shranjenih_bytov_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
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
            this.menuStrip1.Size = new System.Drawing.Size(1176, 24);
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
            this.odpriToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.odpriToolStripMenuItem.Text = "Odpri";
            this.odpriToolStripMenuItem.Click += new System.EventHandler(this.odpriToolStripMenuItem_Click);
            // 
            // streamingAudioPCM
            // 
            chartArea1.Name = "ChartArea1";
            this.streamingAudioPCM.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.streamingAudioPCM.Legends.Add(legend1);
            this.streamingAudioPCM.Location = new System.Drawing.Point(3, 27);
            this.streamingAudioPCM.Name = "streamingAudioPCM";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Zvok";
            series1.YValuesPerPoint = 6;
            this.streamingAudioPCM.Series.Add(series1);
            this.streamingAudioPCM.Size = new System.Drawing.Size(840, 155);
            this.streamingAudioPCM.TabIndex = 8;
            this.streamingAudioPCM.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // recordedAudioPCM
            // 
            chartArea2.Name = "ChartArea1";
            this.recordedAudioPCM.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.recordedAudioPCM.Legends.Add(legend2);
            this.recordedAudioPCM.Location = new System.Drawing.Point(3, 408);
            this.recordedAudioPCM.Name = "recordedAudioPCM";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Zvok";
            series2.YValuesPerPoint = 6;
            this.recordedAudioPCM.Series.Add(series2);
            this.recordedAudioPCM.Size = new System.Drawing.Size(840, 116);
            this.recordedAudioPCM.TabIndex = 9;
            this.recordedAudioPCM.Text = "chart1";
            // 
            // recordedAudioWAV
            // 
            chartArea3.Name = "ChartArea1";
            this.recordedAudioWAV.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.recordedAudioWAV.Legends.Add(legend3);
            this.recordedAudioWAV.Location = new System.Drawing.Point(3, 530);
            this.recordedAudioWAV.Name = "recordedAudioWAV";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Zvok";
            series3.YValuesPerPoint = 6;
            this.recordedAudioWAV.Series.Add(series3);
            this.recordedAudioWAV.Size = new System.Drawing.Size(840, 121);
            this.recordedAudioWAV.TabIndex = 10;
            this.recordedAudioWAV.Text = "chart2";
            // 
            // output_RTB
            // 
            this.output_RTB.Location = new System.Drawing.Point(859, 371);
            this.output_RTB.Name = "output_RTB";
            this.output_RTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.output_RTB.Size = new System.Drawing.Size(305, 248);
            this.output_RTB.TabIndex = 0;
            this.output_RTB.Text = "";
            this.output_RTB.TextChanged += new System.EventHandler(this.output_RTB_TextChanged);
            // 
            // error_RTB
            // 
            this.error_RTB.BackColor = System.Drawing.SystemColors.Window;
            this.error_RTB.Location = new System.Drawing.Point(859, 43);
            this.error_RTB.Name = "error_RTB";
            this.error_RTB.Size = new System.Drawing.Size(305, 322);
            this.error_RTB.TabIndex = 4;
            this.error_RTB.Text = "";
            this.error_RTB.TextChanged += new System.EventHandler(this.output_RTB_TextChanged);
            // 
            // streamingAudioWAV
            // 
            chartArea4.Name = "ChartArea1";
            this.streamingAudioWAV.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.streamingAudioWAV.Legends.Add(legend4);
            this.streamingAudioWAV.Location = new System.Drawing.Point(3, 188);
            this.streamingAudioWAV.Name = "streamingAudioWAV";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Zvok";
            series4.YValuesPerPoint = 6;
            this.streamingAudioWAV.Series.Add(series4);
            this.streamingAudioWAV.Size = new System.Drawing.Size(840, 155);
            this.streamingAudioWAV.TabIndex = 11;
            this.streamingAudioWAV.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 698);
            this.Controls.Add(this.streamingAudioWAV);
            this.Controls.Add(this.recordedAudioWAV);
            this.Controls.Add(this.recordedAudioPCM);
            this.Controls.Add(this.streamingAudioPCM);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.stevilo_shranjenih_bytov_label);
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
            ((System.ComponentModel.ISupportInitialize)(this.streamingAudioPCM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordedAudioPCM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordedAudioWAV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamingAudioWAV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button povezi_button;
        private System.Windows.Forms.Label stevilo_shranjenih_bytov_label;
        private System.Windows.Forms.Button prekini_povezavo;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem datotekaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odpriToolStripMenuItem;
        private System.Windows.Forms.Button clear_errors;
        private System.Windows.Forms.DataVisualization.Charting.Chart streamingAudioPCM;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button shrani_button;
        private System.Windows.Forms.DataVisualization.Charting.Chart recordedAudioPCM;
        private System.Windows.Forms.DataVisualization.Charting.Chart recordedAudioWAV;
        private System.Windows.Forms.RichTextBox output_RTB;
        private System.Windows.Forms.RichTextBox error_RTB;
        private System.Windows.Forms.DataVisualization.Charting.Chart streamingAudioWAV;
    }
}


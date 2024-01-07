
namespace thesis_3
{
    partial class AlarmUI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Level_trend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.UpdateValue = new System.Windows.Forms.Timer(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.Level_trend)).BeginInit();
            this.SuspendLayout();
            // 
            // Level_trend
            // 
            chartArea3.Name = "ChartArea1";
            this.Level_trend.ChartAreas.Add(chartArea3);
            this.Level_trend.Cursor = System.Windows.Forms.Cursors.Arrow;
            legend3.Name = "Legend1";
            this.Level_trend.Legends.Add(legend3);
            this.Level_trend.Location = new System.Drawing.Point(23, 12);
            this.Level_trend.Name = "Level_trend";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.Level_trend.Series.Add(series3);
            this.Level_trend.Size = new System.Drawing.Size(750, 410);
            this.Level_trend.TabIndex = 1;
            this.Level_trend.Text = "chart1";
            // 
            // UpdateValue
            // 
            this.UpdateValue.Interval = 500;
            this.UpdateValue.Tick += new System.EventHandler(this.UpdateValue_Tick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(23, 455);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // AlarmUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 884);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Level_trend);
            this.Name = "AlarmUI";
            this.Text = "AlarmUI";
            this.Load += new System.EventHandler(this.AlarmUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Level_trend)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Level_trend;
        private System.Windows.Forms.Timer UpdateValue;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
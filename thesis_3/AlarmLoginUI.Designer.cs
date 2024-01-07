
namespace thesis_3
{
    partial class AlarmLoginUI
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
            this.Alarm_Login_view = new System.Windows.Forms.DataGridView();
            this.UpdateValue = new System.Windows.Forms.Timer(this.components);
            this.TimeNow = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.Alarm_Login_view)).BeginInit();
            this.SuspendLayout();
            // 
            // Alarm_Login_view
            // 
            this.Alarm_Login_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Alarm_Login_view.Location = new System.Drawing.Point(13, 28);
            this.Alarm_Login_view.Name = "Alarm_Login_view";
            this.Alarm_Login_view.RowHeadersWidth = 51;
            this.Alarm_Login_view.RowTemplate.Height = 24;
            this.Alarm_Login_view.Size = new System.Drawing.Size(775, 410);
            this.Alarm_Login_view.TabIndex = 0;
            // 
            // UpdateValue
            // 
            this.UpdateValue.Enabled = true;
            this.UpdateValue.Tick += new System.EventHandler(this.UpdateValue_Tick);
            // 
            // TimeNow
            // 
            this.TimeNow.Location = new System.Drawing.Point(13, 449);
            this.TimeNow.Name = "TimeNow";
            this.TimeNow.Size = new System.Drawing.Size(200, 22);
            this.TimeNow.TabIndex = 1;
            // 
            // AlarmLoginUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.TimeNow);
            this.Controls.Add(this.Alarm_Login_view);
            this.Name = "AlarmLoginUI";
            this.Text = "AlarmLoginUI";
            ((System.ComponentModel.ISupportInitialize)(this.Alarm_Login_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Alarm_Login_view;
        private System.Windows.Forms.Timer UpdateValue;
        private System.Windows.Forms.DateTimePicker TimeNow;
    }
}
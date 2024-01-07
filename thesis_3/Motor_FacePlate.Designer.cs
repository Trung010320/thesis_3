
namespace thesis_3
{
    partial class Motor_FacePlate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Motor_FacePlate));
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.Local_time_lb = new System.Windows.Forms.Label();
            this.localTime_tbx = new System.Windows.Forms.TextBox();
            this.Rt_acc_tbx = new System.Windows.Forms.TextBox();
            this.Runtime_lb = new System.Windows.Forms.Label();
            this.setting_btn = new thesis_3.CustomizedBtn();
            this.Home_btn = new thesis_3.CustomizedBtn();
            this.Mode_tbx = new System.Windows.Forms.TextBox();
            this.pBRunFeedBack = new System.Windows.Forms.PictureBox();
            this.Update_value = new System.Windows.Forms.Timer(this.components);
            this.Fault_rdbt = new System.Windows.Forms.RadioButton();
            this.RunCmd_rdbt = new System.Windows.Forms.RadioButton();
            this.Stop_btn = new thesis_3.CustomizedBtn();
            this.Start_btn = new thesis_3.CustomizedBtn();
            this.RT_acc_lb = new System.Windows.Forms.Label();
            this.Trip_rdbtn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pBRunFeedBack)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 250;
            // 
            // Local_time_lb
            // 
            this.Local_time_lb.AutoSize = true;
            this.Local_time_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Local_time_lb.Location = new System.Drawing.Point(10, 180);
            this.Local_time_lb.Name = "Local_time_lb";
            this.Local_time_lb.Size = new System.Drawing.Size(92, 20);
            this.Local_time_lb.TabIndex = 11;
            this.Local_time_lb.Text = "Local Time";
            // 
            // localTime_tbx
            // 
            this.localTime_tbx.Location = new System.Drawing.Point(70, 214);
            this.localTime_tbx.Name = "localTime_tbx";
            this.localTime_tbx.ReadOnly = true;
            this.localTime_tbx.Size = new System.Drawing.Size(194, 22);
            this.localTime_tbx.TabIndex = 9;
            // 
            // Rt_acc_tbx
            // 
            this.Rt_acc_tbx.Location = new System.Drawing.Point(61, 120);
            this.Rt_acc_tbx.Name = "Rt_acc_tbx";
            this.Rt_acc_tbx.ReadOnly = true;
            this.Rt_acc_tbx.Size = new System.Drawing.Size(194, 22);
            this.Rt_acc_tbx.TabIndex = 9;
            // 
            // Runtime_lb
            // 
            this.Runtime_lb.AutoSize = true;
            this.Runtime_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Runtime_lb.Location = new System.Drawing.Point(10, 47);
            this.Runtime_lb.Name = "Runtime_lb";
            this.Runtime_lb.Size = new System.Drawing.Size(122, 24);
            this.Runtime_lb.TabIndex = 8;
            this.Runtime_lb.Text = "Running time";
            // 
            // setting_btn
            // 
            this.setting_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(138)))), ((int)(((byte)(174)))));
            this.setting_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("setting_btn.BackgroundImage")));
            this.setting_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.setting_btn.FlatAppearance.BorderSize = 0;
            this.setting_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setting_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(138)))), ((int)(((byte)(174)))));
            this.setting_btn.Location = new System.Drawing.Point(61, 3);
            this.setting_btn.Name = "setting_btn";
            this.setting_btn.Size = new System.Drawing.Size(49, 39);
            this.setting_btn.TabIndex = 7;
            this.setting_btn.UseVisualStyleBackColor = false;
            this.setting_btn.Click += new System.EventHandler(this.setting_btn_Click);
            // 
            // Home_btn
            // 
            this.Home_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(138)))), ((int)(((byte)(174)))));
            this.Home_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Home_btn.BackgroundImage")));
            this.Home_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Home_btn.FlatAppearance.BorderSize = 0;
            this.Home_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Home_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(138)))), ((int)(((byte)(174)))));
            this.Home_btn.Location = new System.Drawing.Point(6, 3);
            this.Home_btn.Name = "Home_btn";
            this.Home_btn.Size = new System.Drawing.Size(49, 39);
            this.Home_btn.TabIndex = 6;
            this.Home_btn.UseVisualStyleBackColor = false;
            this.Home_btn.Click += new System.EventHandler(this.Home_btn_Click);
            // 
            // Mode_tbx
            // 
            this.Mode_tbx.Location = new System.Drawing.Point(143, 42);
            this.Mode_tbx.Name = "Mode_tbx";
            this.Mode_tbx.Size = new System.Drawing.Size(121, 22);
            this.Mode_tbx.TabIndex = 5;
            this.Mode_tbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Mode_tbx_KeyDown);
            this.Mode_tbx.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Mode_tbx_MouseDoubleClick_1);
            this.Mode_tbx.MouseLeave += new System.EventHandler(this.Mode_tbx_MouseLeave_1);
            // 
            // pBRunFeedBack
            // 
            this.pBRunFeedBack.Location = new System.Drawing.Point(10, 42);
            this.pBRunFeedBack.Name = "pBRunFeedBack";
            this.pBRunFeedBack.Size = new System.Drawing.Size(120, 100);
            this.pBRunFeedBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBRunFeedBack.TabIndex = 4;
            this.pBRunFeedBack.TabStop = false;
            // 
            // Update_value
            // 
            this.Update_value.Enabled = true;
            // 
            // Fault_rdbt
            // 
            this.Fault_rdbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fault_rdbt.Location = new System.Drawing.Point(135, 180);
            this.Fault_rdbt.Name = "Fault_rdbt";
            this.Fault_rdbt.Size = new System.Drawing.Size(120, 31);
            this.Fault_rdbt.TabIndex = 3;
            this.Fault_rdbt.TabStop = true;
            this.Fault_rdbt.Text = "Fault";
            this.Fault_rdbt.UseVisualStyleBackColor = true;
            // 
            // RunCmd_rdbt
            // 
            this.RunCmd_rdbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunCmd_rdbt.Location = new System.Drawing.Point(10, 180);
            this.RunCmd_rdbt.Name = "RunCmd_rdbt";
            this.RunCmd_rdbt.Size = new System.Drawing.Size(120, 31);
            this.RunCmd_rdbt.TabIndex = 3;
            this.RunCmd_rdbt.TabStop = true;
            this.RunCmd_rdbt.Text = "Run";
            this.RunCmd_rdbt.UseVisualStyleBackColor = true;
            // 
            // Stop_btn
            // 
            this.Stop_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(138)))), ((int)(((byte)(174)))));
            this.Stop_btn.FlatAppearance.BorderSize = 0;
            this.Stop_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stop_btn.ForeColor = System.Drawing.Color.White;
            this.Stop_btn.Location = new System.Drawing.Point(143, 108);
            this.Stop_btn.Name = "Stop_btn";
            this.Stop_btn.Size = new System.Drawing.Size(121, 34);
            this.Stop_btn.TabIndex = 2;
            this.Stop_btn.Text = "Stop";
            this.Stop_btn.UseVisualStyleBackColor = false;
            // 
            // Start_btn
            // 
            this.Start_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(138)))), ((int)(((byte)(174)))));
            this.Start_btn.FlatAppearance.BorderSize = 0;
            this.Start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_btn.ForeColor = System.Drawing.Color.White;
            this.Start_btn.Location = new System.Drawing.Point(143, 71);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(121, 34);
            this.Start_btn.TabIndex = 1;
            this.Start_btn.Text = "Start";
            this.Start_btn.UseVisualStyleBackColor = false;
            // 
            // RT_acc_lb
            // 
            this.RT_acc_lb.AutoSize = true;
            this.RT_acc_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RT_acc_lb.Location = new System.Drawing.Point(22, 92);
            this.RT_acc_lb.Name = "RT_acc_lb";
            this.RT_acc_lb.Size = new System.Drawing.Size(115, 20);
            this.RT_acc_lb.TabIndex = 12;
            this.RT_acc_lb.Text = "Runtime_ACC";
            // 
            // Trip_rdbtn
            // 
            this.Trip_rdbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trip_rdbtn.Location = new System.Drawing.Point(135, 214);
            this.Trip_rdbtn.Name = "Trip_rdbtn";
            this.Trip_rdbtn.Size = new System.Drawing.Size(120, 30);
            this.Trip_rdbtn.TabIndex = 3;
            this.Trip_rdbtn.TabStop = true;
            this.Trip_rdbtn.Text = "Trip";
            this.Trip_rdbtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Local_time_lb);
            this.panel1.Controls.Add(this.localTime_tbx);
            this.panel1.Controls.Add(this.Rt_acc_tbx);
            this.panel1.Controls.Add(this.Runtime_lb);
            this.panel1.Controls.Add(this.setting_btn);
            this.panel1.Controls.Add(this.Home_btn);
            this.panel1.Controls.Add(this.Mode_tbx);
            this.panel1.Controls.Add(this.pBRunFeedBack);
            this.panel1.Controls.Add(this.Fault_rdbt);
            this.panel1.Controls.Add(this.Trip_rdbtn);
            this.panel1.Controls.Add(this.RunCmd_rdbt);
            this.panel1.Controls.Add(this.Stop_btn);
            this.panel1.Controls.Add(this.Start_btn);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 307);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Motor_FacePlate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 354);
            this.Controls.Add(this.RT_acc_lb);
            this.Controls.Add(this.panel1);
            this.Name = "Motor_FacePlate";
            this.Text = "Motor_FacePlate";
            ((System.ComponentModel.ISupportInitialize)(this.pBRunFeedBack)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Label Local_time_lb;
        private System.Windows.Forms.TextBox localTime_tbx;
        private System.Windows.Forms.TextBox Rt_acc_tbx;
        private System.Windows.Forms.Label Runtime_lb;
        private CustomizedBtn setting_btn;
        private CustomizedBtn Home_btn;
        private System.Windows.Forms.TextBox Mode_tbx;
        private System.Windows.Forms.PictureBox pBRunFeedBack;
        private System.Windows.Forms.Timer Update_value;
        private System.Windows.Forms.RadioButton Fault_rdbt;
        private System.Windows.Forms.RadioButton RunCmd_rdbt;
        private CustomizedBtn Stop_btn;
        private CustomizedBtn Start_btn;
        private System.Windows.Forms.Label RT_acc_lb;
        private System.Windows.Forms.RadioButton Trip_rdbtn;
        private System.Windows.Forms.Panel panel1;
    }
}
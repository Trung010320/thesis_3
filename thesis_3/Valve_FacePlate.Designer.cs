
namespace thesis_3
{
    partial class Valve_FacePlate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Valve_FacePlate));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Local_time_tbx = new System.Windows.Forms.TextBox();
            this.RT_Acc_tbx = new System.Windows.Forms.TextBox();
            this.Runtime_lb = new System.Windows.Forms.Label();
            this.setting_btn = new thesis_3.CustomizedBtn();
            this.Home_btn = new thesis_3.CustomizedBtn();
            this.mode_tbx = new System.Windows.Forms.TextBox();
            this.fpl_valve_ptb = new System.Windows.Forms.PictureBox();
            this.Fault_rdbt = new System.Windows.Forms.RadioButton();
            this.Trip_rdbtn = new System.Windows.Forms.RadioButton();
            this.Close_rdbt = new System.Windows.Forms.RadioButton();
            this.Open_valve_rdbt = new System.Windows.Forms.RadioButton();
            this.Close_btn = new thesis_3.CustomizedBtn();
            this.Open_btn = new thesis_3.CustomizedBtn();
            this.Update_value = new System.Windows.Forms.Timer(this.components);
            this.RT_acc_lb = new System.Windows.Forms.Label();
            this.Local_time_lb = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpl_valve_ptb)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Local_time_tbx);
            this.panel1.Controls.Add(this.RT_Acc_tbx);
            this.panel1.Controls.Add(this.Runtime_lb);
            this.panel1.Controls.Add(this.setting_btn);
            this.panel1.Controls.Add(this.Home_btn);
            this.panel1.Controls.Add(this.mode_tbx);
            this.panel1.Controls.Add(this.fpl_valve_ptb);
            this.panel1.Controls.Add(this.Fault_rdbt);
            this.panel1.Controls.Add(this.Trip_rdbtn);
            this.panel1.Controls.Add(this.Close_rdbt);
            this.panel1.Controls.Add(this.Open_valve_rdbt);
            this.panel1.Controls.Add(this.Close_btn);
            this.panel1.Controls.Add(this.Open_btn);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 307);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Local_time_tbx
            // 
            this.Local_time_tbx.Location = new System.Drawing.Point(70, 214);
            this.Local_time_tbx.Name = "Local_time_tbx";
            this.Local_time_tbx.ReadOnly = true;
            this.Local_time_tbx.Size = new System.Drawing.Size(194, 22);
            this.Local_time_tbx.TabIndex = 9;
            // 
            // RT_Acc_tbx
            // 
            this.RT_Acc_tbx.Location = new System.Drawing.Point(61, 120);
            this.RT_Acc_tbx.Name = "RT_Acc_tbx";
            this.RT_Acc_tbx.ReadOnly = true;
            this.RT_Acc_tbx.Size = new System.Drawing.Size(194, 22);
            this.RT_Acc_tbx.TabIndex = 9;
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
            // mode_tbx
            // 
            this.mode_tbx.Location = new System.Drawing.Point(143, 42);
            this.mode_tbx.Name = "mode_tbx";
            this.mode_tbx.Size = new System.Drawing.Size(121, 22);
            this.mode_tbx.TabIndex = 5;
            this.mode_tbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mode_tbx_KeyDown);
            this.mode_tbx.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mode_tbx_MouseDoubleClick);
            this.mode_tbx.MouseLeave += new System.EventHandler(this.mode_tbx_MouseLeave);
            // 
            // fpl_valve_ptb
            // 
            this.fpl_valve_ptb.Location = new System.Drawing.Point(10, 42);
            this.fpl_valve_ptb.Name = "fpl_valve_ptb";
            this.fpl_valve_ptb.Size = new System.Drawing.Size(120, 100);
            this.fpl_valve_ptb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fpl_valve_ptb.TabIndex = 4;
            this.fpl_valve_ptb.TabStop = false;
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
            // Close_rdbt
            // 
            this.Close_rdbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_rdbt.Location = new System.Drawing.Point(10, 215);
            this.Close_rdbt.Name = "Close_rdbt";
            this.Close_rdbt.Size = new System.Drawing.Size(120, 28);
            this.Close_rdbt.TabIndex = 3;
            this.Close_rdbt.TabStop = true;
            this.Close_rdbt.Text = "Close";
            this.Close_rdbt.UseVisualStyleBackColor = true;
            // 
            // Open_valve_rdbt
            // 
            this.Open_valve_rdbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Open_valve_rdbt.Location = new System.Drawing.Point(10, 180);
            this.Open_valve_rdbt.Name = "Open_valve_rdbt";
            this.Open_valve_rdbt.Size = new System.Drawing.Size(120, 31);
            this.Open_valve_rdbt.TabIndex = 3;
            this.Open_valve_rdbt.TabStop = true;
            this.Open_valve_rdbt.Text = "Open";
            this.Open_valve_rdbt.UseVisualStyleBackColor = true;
            // 
            // Close_btn
            // 
            this.Close_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(138)))), ((int)(((byte)(174)))));
            this.Close_btn.FlatAppearance.BorderSize = 0;
            this.Close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_btn.ForeColor = System.Drawing.Color.White;
            this.Close_btn.Location = new System.Drawing.Point(143, 108);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(121, 34);
            this.Close_btn.TabIndex = 2;
            this.Close_btn.Text = "Close";
            this.Close_btn.UseVisualStyleBackColor = false;
            this.Close_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Close_btn_MouseDown);
            this.Close_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Close_btn_MouseUp);
            // 
            // Open_btn
            // 
            this.Open_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(138)))), ((int)(((byte)(174)))));
            this.Open_btn.FlatAppearance.BorderSize = 0;
            this.Open_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Open_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Open_btn.ForeColor = System.Drawing.Color.White;
            this.Open_btn.Location = new System.Drawing.Point(143, 71);
            this.Open_btn.Name = "Open_btn";
            this.Open_btn.Size = new System.Drawing.Size(121, 34);
            this.Open_btn.TabIndex = 1;
            this.Open_btn.Text = "Open";
            this.Open_btn.UseVisualStyleBackColor = false;
            this.Open_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Open_btn_MouseDown);
            this.Open_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Open_btn_MouseUp);
            // 
            // Update_value
            // 
            this.Update_value.Enabled = true;
            // 
            // RT_acc_lb
            // 
            this.RT_acc_lb.AutoSize = true;
            this.RT_acc_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RT_acc_lb.Location = new System.Drawing.Point(12, 82);
            this.RT_acc_lb.Name = "RT_acc_lb";
            this.RT_acc_lb.Size = new System.Drawing.Size(115, 20);
            this.RT_acc_lb.TabIndex = 9;
            this.RT_acc_lb.Text = "Runtime_ACC";
            // 
            // Local_time_lb
            // 
            this.Local_time_lb.AutoSize = true;
            this.Local_time_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Local_time_lb.Location = new System.Drawing.Point(12, 182);
            this.Local_time_lb.Name = "Local_time_lb";
            this.Local_time_lb.Size = new System.Drawing.Size(92, 20);
            this.Local_time_lb.TabIndex = 9;
            this.Local_time_lb.Text = "Local Time";
            // 
            // Valve_FacePlate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 312);
            this.Controls.Add(this.Local_time_lb);
            this.Controls.Add(this.RT_acc_lb);
            this.Controls.Add(this.panel1);
            this.Name = "Valve_FacePlate";
            this.Text = "Valve_FacePlate";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpl_valve_ptb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomizedBtn Close_btn;
        private CustomizedBtn Open_btn;
        private System.Windows.Forms.RadioButton Fault_rdbt;
        private System.Windows.Forms.RadioButton Trip_rdbtn;
        private System.Windows.Forms.RadioButton Close_rdbt;
        private System.Windows.Forms.RadioButton Open_valve_rdbt;
        private System.Windows.Forms.PictureBox fpl_valve_ptb;
        private System.Windows.Forms.Timer Update_value;
        private System.Windows.Forms.TextBox mode_tbx;
        private CustomizedBtn Home_btn;
        private CustomizedBtn setting_btn;
        private System.Windows.Forms.Label Runtime_lb;
        private System.Windows.Forms.Label RT_acc_lb;
        private System.Windows.Forms.Label Local_time_lb;
        private System.Windows.Forms.TextBox RT_Acc_tbx;
        private System.Windows.Forms.TextBox Local_time_tbx;
    }
}
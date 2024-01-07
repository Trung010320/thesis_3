using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace thesis_3
{
    public partial class Motor_FacePlate : Form
    {
        bool isEdit = false ;
        TimeSpan rtaccTs;
        string runtime;
        
        Image pump_green = Image.FromFile(@"Image\Pump_ON.png");
        Image pump_red = Image.FromFile(@"Image\Pump_OFF_1.png");
        private Pen blkpen = new Pen(Color.FromArgb(19, 101, 138), 3);
        private Pen blkpen1 = new Pen(Color.FromArgb(72, 138, 174), 2);
        private Pen blkpen2 = new Pen(Color.FromArgb(72, 138, 174), 1);
        private PanelState currentState = PanelState.Home;

        public Motor parent = null;
        System.Timers.Timer updateTimer = null;
        public Motor_FacePlate(Motor _parent)   
        {
            InitializeComponent();
            parent = _parent;
            updateTimer = new System.Timers.Timer(250);
            updateTimer.Elapsed += UpdateValue;
            updateTimer.Enabled = true;
        }

        private void UpdateValue(object sender, ElapsedEventArgs e)
        {
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // draw border fpl
            e.Graphics.DrawRectangle(blkpen, 2, 2, 200, 246);
            //draw border component

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(2, 2, 10, 10);
            gp.AddRectangle(rect);


            // draw  solid
            Graphics gr = e.Graphics;
            Color customColor = Color.FromArgb(72, 138, 174);
            using (Brush customBrush = new SolidBrush(customColor))
            {
                gr.FillRectangle(customBrush, 2, 2, 199, 30);

            }
            gr.DrawLine(blkpen2, 10, 145, 190, 145);
            if (parent != null)
            {
                if (!parent.RunCmd)
                {
                    pBRunFeedBack.BackgroundImage = pump_red;
                    pBRunFeedBack.BackColor = Color.Transparent;
                    pBRunFeedBack.BackgroundImageLayout = ImageLayout.Stretch;
                    RunCmd_rdbt.Checked = false;
                }
                else
                {
                    pBRunFeedBack.BackgroundImage = pump_green;
                    pBRunFeedBack.BackColor = Color.Transparent;
                    pBRunFeedBack.BackgroundImageLayout = ImageLayout.Stretch;
                    RunCmd_rdbt.Checked = true;
                }
                
                if(parent.trip)
                {
                    Trip_rdbtn.Checked = true;
                }
                else
                {
                    Trip_rdbtn.Checked = false;
                }
                if (!isEdit)
                {
                    try
                    {
                        Mode_tbx.Text = parent.mode.ToString();
                        Console.WriteLine(Mode_tbx.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }

                }
                Console.WriteLine(isEdit.ToString());

            }
            if (parent.runTimeAcc > 0)
            {
                rtaccTs = TimeSpan.FromMilliseconds(parent.runTimeAcc);
                runtime = rtaccTs.ToString();
                Rt_acc_tbx.Text = runtime;

            }
            localTime_tbx.Text = DateTime.Now.ToString();
            switch (currentState)
            {
                case PanelState.Home:
                    DrawHomeContent(e.Graphics);
                    break;

                case PanelState.Settings:
                    DrawSettingsContent(e.Graphics);
                    break;


            }
        }

        private void DrawSettingsContent(Graphics g)
        {

            Start_btn.Visible = false;
            Stop_btn.Visible = false;
            
            RunCmd_rdbt.Visible = false;

            Fault_rdbt.Visible = false;
            Trip_rdbtn.Visible = false;
            Mode_tbx.Visible = false;
            Runtime_lb.Visible = true;
            RT_acc_lb.Visible = true;
            Local_time_lb.Visible = true;
            pBRunFeedBack.Visible = false;


            Rt_acc_tbx.Visible = true; 
            localTime_tbx.Visible = true;
            g.DrawLine(blkpen2, 10, 60, 190, 60);
        }

        private void DrawHomeContent(Graphics g)
        {
            g.DrawRectangle(blkpen1, 4, 33, 100, 100);
            Start_btn.Visible = true;
            Stop_btn.Visible = true;
            RunCmd_rdbt.Visible = true;

            Fault_rdbt.Visible = true;
            Trip_rdbtn.Visible = true;
            Mode_tbx.Visible = true;
            Runtime_lb.Visible = false;
            RT_acc_lb.Visible = false;
            Local_time_lb.Visible = false;
            pBRunFeedBack.Visible = true;


            Rt_acc_tbx.Visible = false;
            localTime_tbx.Visible = false;
        }


        

        private void Start_btn_MouseDown(object sender, MouseEventArgs e)
        {
            parent.WritePump("Start", true);
        }

        private void Start_btn_MouseUp(object sender, MouseEventArgs e)
        {
            parent.WritePump("Start", false);
        }

        private void Stop_btn_MouseDown(object sender, MouseEventArgs e)
        {
            parent.WritePump("Stop", true);
        }

        private void Stop_btn_MouseUp(object sender, MouseEventArgs e)
        {
            parent.WritePump("Stop", false);
        }

        private void Mode_tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ushort temp;
                bool ret = ushort.TryParse(Mode_tbx.Text, out temp);
                if (ret)
                {
                    parent.WritePump("MODE", temp);
                }
                else
                {
                    MessageBox.Show("Please enter the value again", "Error");
                }
            }
        }


        private enum PanelState
        {
            Home,
            Settings
        }

        private void Home_btn_Click(object sender, EventArgs e)
        {
            currentState = PanelState.Home;

            panel1.Invalidate(); // Trigger a repaint
        }

        private void setting_btn_Click(object sender, EventArgs e)
        {
            currentState = PanelState.Settings;

            panel1.Invalidate(); // Trigger a repaint
        }

        private void Mode_tbx_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            isEdit = true;

        }

        private void Mode_tbx_MouseLeave_1(object sender, EventArgs e)
        {
            isEdit = false;
        }
    }
}

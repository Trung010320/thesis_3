using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace thesis_3
{
    public partial class Valve_FacePlate : Form
    {
        bool isedit = false;


        TimeSpan rtaccTs;
        string runtime;
        Image Valve_OFF = Image.FromFile(@"Image\Valve_OFF_1.png");
        Image Valve_ON = Image.FromFile(@"Image\Valve_ON.png");
        System.Timers.Timer updateTimer = null;
        public Valve parent = null;
        private Pen blkpen = new Pen(Color.FromArgb(19, 101, 138), 3);
        private Pen blkpen1 = new Pen(Color.FromArgb(72, 138, 174), 2);
        private Pen blkpen2 = new Pen(Color.FromArgb(72, 138, 174), 1);


        private PanelState currentState = PanelState.Home;
        public Valve_FacePlate(Valve _parent)
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
            e.Graphics.DrawRectangle(blkpen,2,2, 200, 246);
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
                if (parent.closeCmd)
                {
                    fpl_valve_ptb.BackgroundImage = Valve_OFF;
                    fpl_valve_ptb.BackColor = Color.Transparent;
                    fpl_valve_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    Open_valve_rdbt.Checked = false;
                    Close_rdbt.Checked = true;
                }
                if (parent.openCmd)
                {
                    fpl_valve_ptb.BackgroundImage = Valve_ON;
                    fpl_valve_ptb.BackColor = Color.Transparent;
                    fpl_valve_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    Open_valve_rdbt.Checked = true;
                    Close_rdbt.Checked = false;
                }
                if (parent.trip)
                {
                    Trip_rdbtn.Checked = true;

                }
                else
                {
                    Trip_rdbtn.Checked = false;
                }
                if (!isedit)
                {
                    try
                    {
                        mode_tbx.Text = parent.mode.ToString();
                        Console.WriteLine(mode_tbx.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, " Error");
                    }
                }
                Console.WriteLine(isedit);

                
            }
            if (parent.runTimeAcc > 0)
            {
                rtaccTs = TimeSpan.FromMilliseconds(parent.runTimeAcc);
                runtime = rtaccTs.ToString();
                RT_Acc_tbx.Text = runtime;
            }
            Local_time_tbx.Text = DateTime.Now.ToString();
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
        private void DrawHomeContent(Graphics g)
        {
            g.DrawRectangle(blkpen1, 4, 33, 100, 100);
            Open_btn.Visible = true;
            Close_btn.Visible = true;
            Open_valve_rdbt.Visible = true;
            Close_rdbt.Visible = true;
            Fault_rdbt.Visible = true;
            Trip_rdbtn.Visible = true;
            mode_tbx.Visible = true;
            Runtime_lb.Visible = false;
            RT_acc_lb.Visible = false;
            Local_time_lb.Visible = false;
            fpl_valve_ptb.Visible = true;
            RT_Acc_tbx.Visible = false;
            Local_time_tbx.Visible = false;
                

        }
        private void DrawSettingsContent(Graphics g)
        {

            mode_tbx.Visible = false;
            Open_btn.Visible = false;
            Close_btn.Visible = false;
            Open_valve_rdbt.Visible = false;
            Close_rdbt.Visible = false;
            Fault_rdbt.Visible = false;
            Trip_rdbtn.Visible = false;
            fpl_valve_ptb.Visible = false;
            Runtime_lb.Visible = true;
            RT_acc_lb.Visible = true;
            Local_time_lb.Visible = true;
            RT_Acc_tbx.Visible = true;
            Local_time_tbx.Visible = true;
            g.DrawLine(blkpen2, 10, 60, 190, 60);


        }



        private void Open_btn_MouseDown(object sender, MouseEventArgs e)
        {
            parent.WriteValve("OPEN", true);
        }

        private void Open_btn_MouseUp(object sender, MouseEventArgs e)
        {
            parent.WriteValve("OPEN", false);
        }

        private void Close_btn_MouseDown(object sender, MouseEventArgs e)
        {
            parent.WriteValve("CLOSE", true);
        }

        private void Close_btn_MouseUp(object sender, MouseEventArgs e)
        {
            parent.WriteValve("CLOSE", false);
        }

        private void mode_tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ushort temp;
                bool ret = ushort.TryParse(mode_tbx.Text, out temp);
                if (ret)
                {
                    parent.WriteValve("MODE", temp);
                }
                else
                {
                    MessageBox.Show("Please enter the value again", "Error");
                }
            }
        }

        private void mode_tbx_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            isedit = true;
        }

        private void mode_tbx_MouseLeave(object sender, EventArgs e)
        {
            isedit = false;
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
        private enum PanelState
        {
            Home,
            Settings
        }
    }
}

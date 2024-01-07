using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using S7.Net;
using System.Data.SqlClient;
using OfficeOpenXml;
using S7.Net.Types;
using DateTime = System.DateTime;

namespace thesis_3
{
    public partial class Clientform : Form
    {
        string strCon = @"Data Source=tcp:sqlplcdatademo.database.windows.net,1433;Initial Catalog=PLCdemo;Persist Security Info=False;User ID=Duan;Password=123456789@Dd";
        SqlConnection sqlCon = null;
        public Motor mParent = null;
        public Valve vParent = null;
        public string motor_name;
        public string value_name;
        public Device device;
        
        int hStg;
        int hChe;
        int hFw1;
        int hFw2;
        int hHw;
        int hNw;



        // Image
        Image Valve_ON = Image.FromFile(@"Image\Valve_ON.png");
        Image Valve_OFF = Image.FromFile(@"Image\Valve_OFF_1.png");
        Image Valve_270_ON = Image.FromFile(@"Image\Valve_270_ON.png");
        Image Valve_270_OFF = Image.FromFile(@"Image\valve_270.png");
        Image PUMP_ON = Image.FromFile(@"Image\Pump_ON.png");
        Image PUMP_OFF = Image.FromFile(@"Image\Pump_OFF_1.png");
        Image red_lv = Image.FromFile(@"Image\red.png");
        Image blue_lv = Image.FromFile(@"Image\blue.png");





        bool isconnected = false;
        bool isCbxEdited = false;
        bool isBoilcbxEdited = false;

        public Clientform()
        {
            SCADA scada = new SCADA();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            InitializeComponent();
            realStroage_wtlv_ptb.BackgroundImage = blue_lv;
            realChe_wtlv_ptb.BackgroundImage = blue_lv;
            realFW1_wtlv_ptb.BackgroundImage = blue_lv;
            realFW2_wtlv_ptb.BackgroundImage = blue_lv;

            realNW_wtlv_ptb.BackgroundImage = blue_lv;


            stg_wtlvBg_ptb.BackgroundImage = red_lv;
            Che_wtlv_Bg_ptb.BackgroundImage = red_lv;
            FW1_wtlv_Bg_ptb.BackgroundImage = red_lv;
            FW2_wtlv_Bg_ptb.BackgroundImage = red_lv;

            NW_wtlv_Bg_ptb.BackgroundImage = red_lv;

            realStroage_wtlv_ptb.Size = new Size(21, 150);
            stg_wtlvBg_ptb.Size = new Size(21, 150);
            hStg = realStroage_wtlv_ptb.Height;
            
            realChe_wtlv_ptb.Size = new Size(21, 150); 
            Che_wtlv_Bg_ptb.Size = new Size(21, 150);
            hChe = realChe_wtlv_ptb.Height;

            realFW1_wtlv_ptb.Size = new Size(21, 150);
            FW1_wtlv_Bg_ptb.Size = new Size(21, 150);
            hFw1 = realFW1_wtlv_ptb.Height;

            realFW2_wtlv_ptb.Size = new Size(21, 150);
            FW2_wtlv_Bg_ptb.Size = new Size(21, 150);
            hFw2 = realFW2_wtlv_ptb.Height;



            realNW_wtlv_ptb.Size = new Size(21, 200);
            NW_wtlv_Bg_ptb.Size = new Size(21, 200);
            hNw = realNW_wtlv_ptb.Height;

            HMI_screen.Enabled = false;
            tabPage1.Enabled = false;

                


        }

 
        #region SQL Connection






        // timer for levels of 5 tanks
        private void timer2_Tick(object sender, EventArgs e)
        {
            string connectionString = "Server=tcp:sqlplcdatademo.database.windows.net,1433;Initial Catalog=PLCdemo;Persist Security Info=False;" +
                "User ID=Duan;Password=123456789@Dd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
       //"Data Source=sqlplcdatademo.database.windows.net;" +
       //"Initial Catalog=PLCdemo;" +
       //"User id=Duan;" +
       //"Password=123456789@Dd;";


            string insertQuery = "INSERT INTO Table_5 (Storage, Chemical, Fresh_water_1, Fresh_water_2, Normal_tank) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Console.WriteLine("Connection2: " + connection.State.ToString());
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    int value1 = SCADA.root.stg;
                    int value2 = SCADA.root.che;
                    int value3 = SCADA.root.fw1;
                    int value4 = SCADA.root.fw2;
                    int value5 = SCADA.root.nw;

                    command.Parameters.AddWithValue("@Value1", value1);
                    command.Parameters.AddWithValue("@Value2", value2);

                    command.Parameters.AddWithValue("@Value3", value3);
                    command.Parameters.AddWithValue("@Value4", value4);

                    command.Parameters.AddWithValue("@Value5", value5);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        //Console.WriteLine($"{rowsAffected} row(s) inserted successfully at {e.SignalTime}");
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error SEND SQL Table5:: {ex.Message}");
                    }
                }
            }
        }
        // timer for States and Modes of Pumps
        private void timer3_Tick(object sender, EventArgs e)
        {

            string connectionString = "Server=tcp:sqlplcdatademo.database.windows.net,1433;Initial Catalog=PLCdemo;Persist Security Info=False;User ID=Duan;Password=123456789@Dd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
       //"Data Source=sqlplcdatademo.database.windows.net;" +
       //"Initial Catalog=PLCdemo;" +
       //"User id=Duan;" +
       //"Password=123456789@Dd;";

            
            string insertQuery = "INSERT INTO mtr_pump_table (Pump1_Mode, Pump1_State, Pump2_Mode, Pump2_State, Pump3_Mode, Pump3_State, Pump4_Mode, Pump4_State, Pump5_Mode, Pump5_State, Pump6_Mode, Pump6_State, Pump7_Mode, Pump7_State) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7, @Value8, @Value9, @Value10, @Value11, @Value12, @Value13, @Value14)";

            using (SqlConnection connection = new SqlConnection(connectionString))
                
            {
                Console.WriteLine("Connection: " + connection.StatisticsEnabled.ToString());
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {

                    int value1 = device.mtr_Pump_1_Data.Mode;
                    bool value2 = device.mtr_Pump_1_Data.Runcmd;
                    int value3 = device.mtr_Pump_2_Data.Mode;
                    bool value4 = device.mtr_Pump_2_Data.Runcmd;
                    int value5 = device.mtr_Pump_3_Data.Mode;
                    bool value6 = device.mtr_Pump_3_Data.Runcmd;
                    int value7 = device.mtr_Pump_4_Data.Mode;
                    bool value8 = device.mtr_Pump_4_Data.Runcmd;
                    int value9 = device.mtr_Pump_5_Data.Mode;
                    bool value10 = device.mtr_Pump_5_Data.Runcmd;
                    int value11 = device.mtr_Pump_6_Data.Mode;
                    bool value12 = device.mtr_Pump_6_Data.Runcmd;
                    int value13 = device.mtr_Pump_7_Data.Mode;
                    bool value14 = device.mtr_Pump_7_Data.Runcmd;



                    command.Parameters.AddWithValue("@Value1", value1);
                    command.Parameters.AddWithValue("@Value2", value2);

                    command.Parameters.AddWithValue("@Value3", value3);
                    command.Parameters.AddWithValue("@Value4", value4);

                    command.Parameters.AddWithValue("@Value5", value5);
                    command.Parameters.AddWithValue("@Value6", value6);

                    command.Parameters.AddWithValue("@Value7", value7);
                    command.Parameters.AddWithValue("@Value8", value8);

                    command.Parameters.AddWithValue("@Value9", value9);
                    command.Parameters.AddWithValue("@Value10", value10);

                    command.Parameters.AddWithValue("@Value11", value11);
                    command.Parameters.AddWithValue("@Value12", value12);

                    command.Parameters.AddWithValue("@Value13", value13);
                    command.Parameters.AddWithValue("@Value14", value14);
                   





                    try
                    {
                        connection.Open();
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        //Console.WriteLine($"{rowsAffected} row(s) inserted successfully at {e.SignalTime}");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error SEND SQL mtr_pump_table: {ex.Message}");
                        Console.WriteLine(ex.Message);
                    }
                    finally { connection.Close(); }
                }
                
            }
        }
        // Timer for States of Valves
        private void timer4_Tick(object sender, EventArgs e)
        {

            string connectionString = "Server=tcp:sqlplcdatademo.database.windows.net,1433;Initial Catalog=PLCdemo;Persist Security Info=False;User ID=Duan;Password=123456789@Dd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //"Data Source=sqlplcdatademo.database.windows.net;" +
            //"Initial Catalog=PLCdemo;" +
            //"User id=Duan;" +
            //"Password=123456789@Dd;";


            string insertQuery = "INSERT INTO mtr_valve_table (Valve1_State, Valve2_State, Valve3_State, Valve4_State, Valve5_State, Valve6_State, Valve7_State, Valve8_State, Valve9_State, Valve10_State, Valve11_State, Valve12_State, Valve14_State) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7, @Value8, @Value9, @Value10, @Value11, @Value12, @Value13)";

            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                Console.WriteLine("Connection: " + connection.StatisticsEnabled.ToString());
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {

                    bool value1 = device.valve_1_data.OpenCmd;
                    bool value2 = device.valve_2_data.OpenCmd;
                    bool value3 = device.valve_3_data.OpenCmd;
                    bool value4 = device.valve_4_data.OpenCmd;
                    bool value5 = device.valve_5_data.OpenCmd;
                    bool value6 = device.valve_6_data.OpenCmd;
                    bool value7 = device.valve_7_data.OpenCmd;
                    bool value8 = device.valve_8_data.OpenCmd;
                    bool value9 = device.valve_9_data.OpenCmd;
                    bool value10 = device.valve_10_data.OpenCmd;
                    bool value11 = device.valve_11_data.OpenCmd;
                    bool value12 = device.valve_12_data.OpenCmd;
                    bool value13 = device.valve_14_data.OpenCmd;


                    command.Parameters.AddWithValue("@Value1", value1);
                    command.Parameters.AddWithValue("@Value2", value2);

                    command.Parameters.AddWithValue("@Value3", value3);
                    command.Parameters.AddWithValue("@Value4", value4);

                    command.Parameters.AddWithValue("@Value5", value5);
                    command.Parameters.AddWithValue("@Value6", value6);

                    command.Parameters.AddWithValue("@Value7", value7);
                    command.Parameters.AddWithValue("@Value8", value8);

                    command.Parameters.AddWithValue("@Value9", value9);
                    command.Parameters.AddWithValue("@Value10", value10);

                    command.Parameters.AddWithValue("@Value11", value11);
                    command.Parameters.AddWithValue("@Value12", value12);

                    command.Parameters.AddWithValue("@Value13", value13);

                    try
                    {
                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();
                        //Console.WriteLine($"{rowsAffected} row(s) inserted successfully at {e.SignalTime}");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error SEND SQL mtr_valve_table: {ex.Message}");
                        Console.WriteLine(ex.Message);
                    }
                    finally { connection.Close(); }
                }

            }
        }
        // Timer for Modes of Valves
        private void timer5_Tick(object sender, EventArgs e)
        {
            string connectionString = "Server=tcp:sqlplcdatademo.database.windows.net,1433;Initial Catalog=PLCdemo;Persist Security Info=False;User ID=Duan;Password=123456789@Dd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //"Data Source=sqlplcdatademo.database.windows.net;" +
            //"Initial Catalog=PLCdemo;" +
            //"User id=Duan;" +
            //"Password=123456789@Dd;";


            string insertQuery = "INSERT INTO VALVE_MODE_TABLE (Valve1_MODE, Valve2_MODE, Valve3_MODE, Valve4_MODE, Valve5_MODE, Valve6_MODE, Valve7_MODE, Valve8_MODE, Valve9_MODE, Valve10_MODE, Valve11_MODE, Valve12_MODE, Valve14_MODE) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7, @Value8, @Value9, @Value10, @Value11, @Value12, @Value13)";

            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                Console.WriteLine("Connection: " + connection.StatisticsEnabled.ToString());
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {

                    int value1 = device.valve_1_data.Mode;
                    int value2 = device.valve_2_data.Mode;
                    int value3 = device.valve_3_data.Mode;
                    int value4 = device.valve_4_data.Mode;
                    int value5 = device.valve_5_data.Mode;
                    int value6 = device.valve_6_data.Mode;
                    int value7 = device.valve_7_data.Mode;
                    int value8 = device.valve_8_data.Mode;
                    int value9 = device.valve_9_data.Mode;
                    int value10 = device.valve_10_data.Mode;
                    int value11 = device.valve_11_data.Mode;
                    int value12 = device.valve_12_data.Mode;
                    int value13 = device.valve_14_data.Mode;





                    command.Parameters.AddWithValue("@Value1", value1);
                    command.Parameters.AddWithValue("@Value2", value2);

                    command.Parameters.AddWithValue("@Value3", value3);
                    command.Parameters.AddWithValue("@Value4", value4);

                    command.Parameters.AddWithValue("@Value5", value5);
                    command.Parameters.AddWithValue("@Value6", value6);

                    command.Parameters.AddWithValue("@Value7", value7);
                    command.Parameters.AddWithValue("@Value8", value8);

                    command.Parameters.AddWithValue("@Value9", value9);
                    command.Parameters.AddWithValue("@Value10", value10);

                    command.Parameters.AddWithValue("@Value11", value11);
                    command.Parameters.AddWithValue("@Value12", value12);

                    command.Parameters.AddWithValue("@Value13", value13);

                    try
                    {
                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();
                        //Console.WriteLine($"{rowsAffected} row(s) inserted successfully at {e.SignalTime}");

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error SEND SQL VALVE_MODE_TABLE: {ex.Message}");
                        Console.WriteLine(ex.Message);
                    }
                    finally { connection.Close(); }
                }
            }
        }
        private void S7SQL_Connect_btn_Click_1(object sender, EventArgs e)
        {
            if (isconnected == true)
            {
                timer2.Enabled = true;
                timer2.Interval = 3000;
                timer3.Enabled = true;
                timer3.Interval = 3000;
                timer4.Enabled = true;
                timer4.Interval = 3000;
                timer5.Enabled = true;
                timer5.Interval = 3000;

                MessageBox.Show("Transfer Data S7-SQL OK");
            }

               
           
        }

        private void S7SQL_Disconnect_btn_Click_1(object sender, EventArgs e)
        {
            timer2.Stop();
            timer2.Enabled = false;
            timer3.Stop();
            timer3.Enabled = false;
            timer4.Stop();
            timer4.Enabled = false;
            timer5.Stop();
            timer5.Enabled = false;
            MessageBox.Show("Stop Transfering Data");
        }
        #endregion

        #region S7s Connection



        private void S7s_Connect_btn_Click(object sender, EventArgs e)
        {
            if (ipAddress_tbx.Text == "")
            {
                MessageBox.Show("Please enter the IP Address", " Error");
            }
            else
            {
                try
                {
                    SCADA.Connection(ipAddress_tbx.Text);
                    isconnected = true;


                    if (SCADA.root.s71500PLC.IsConnected == true)
                    {
                        HMI_screen.Enabled = true;
                        tabPage1.Enabled = true;
                        plcStatus_lb.Text = "Connected";
                    }
                    else
                    {
                        plcStatus_lb.Text = "Disconnected";
                        MessageBox.Show("Please connect to PLC first", " Error");
                        return;

                    }


                    MessageBox.Show("Conenction Successful", "Status");

                }
                catch (PlcException plc)
                {
                    MessageBox.Show( plc.Message, "Error");
                }
            }



        }



        private void UpdateValue_Tick(object sender, EventArgs e)
        {
            //Update value of 5 tanks in SQLConnect tabpage
            Storage_value_tbx.Text = SCADA.root.stg.ToString();
            Chemical_value_tbx.Text = SCADA.root.che.ToString();
            FreshWater_1_tbx.Text = SCADA.root.fw1.ToString();
            FreshWater_2_tbx.Text = SCADA.root.fw2.ToString();
            NormalWater_tbx.Text = SCADA.root.nw.ToString();

            //Update value of 5 tanks in SCADA
            StorageSCADA.Text = SCADA.root.stg.ToString();
            ChemicalSCADA.Text = SCADA.root.che.ToString();
            FW1SCADA.Text = SCADA.root.fw1.ToString();
            FW2SCADA.Text = SCADA.root.fw2.ToString();
            NormalSCADA.Text = SCADA.root.nw.ToString();

        }


        private void S7s_Disconnect_btn_Click(object sender, EventArgs e)
        {
            try
            {
                SCADA.root.Disconnect();
                isconnected = false;
                MessageBox.Show("Disonnect to PLC", "Status");
                plcStatus_lb.Text = "Disconnected";
            }
            catch
            {
                MessageBox.Show("Cannnot disconect the PLC ", "Error");
            }
            
            MessageBox.Show("Disconnected", "Status");
            Storage_value_tbx.Clear();
            Chemical_value_tbx.Clear();
            FreshWater_1_tbx.Clear();
            FreshWater_2_tbx.Clear();
            NormalWater_tbx.Clear();
        }
        private void pump_1_ptb_Click(object sender, EventArgs e)
        {
            Motor_FacePlate fpl = new Motor_FacePlate(SCADA.root.FindMotor("Mtr_pump_1"));
            fpl.Show();
        }

        private void valve_1_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_1"));
            vfpl.Show();

        }

        private void pump_2_ptb_Click(object sender, EventArgs e)
        {
            Motor_FacePlate fpl = new Motor_FacePlate(SCADA.root.FindMotor("Mtr_pump_2"));
            fpl.Show();
        }

        private void valve_2_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_2"));
            vfpl.Show();
        }

        private void valve_4_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_4"));
            vfpl.Show();
        }

        private void valve_5_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_5"));
            vfpl.Show();
        }

        private void valve_3_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_3"));
            vfpl.Show();
        }

        private void pump_4_ptb_Click(object sender, EventArgs e)
        {
            Motor_FacePlate fpl = new Motor_FacePlate(SCADA.root.FindMotor("Mtr_pump_4"));
            fpl.Show();
        }

        private void pump_3_ptb_Click(object sender, EventArgs e)
        {
            Motor_FacePlate fpl = new Motor_FacePlate(SCADA.root.FindMotor("Mtr_pump_3"));
            fpl.Show();
        }

        private void valve_6_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_6"));
            vfpl.Show();
        }

        private void valve_7_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_7"));
            vfpl.Show();
        }

        private void valve_9_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_9"));
            vfpl.Show();
        }

        private void valve_8_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_8"));
            vfpl.Show();
        }

        private void valve_12_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_12"));
            vfpl.Show();
        }

        private void valve_11_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_11"));
            vfpl.Show();
        }

        private void valve_10_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_10"));
            vfpl.Show();
        }

        private void pump_5_ptb_Click(object sender, EventArgs e)
        {
            Motor_FacePlate fpl = new Motor_FacePlate(SCADA.root.FindMotor("Mtr_pump_5"));
            fpl.Show();
        }

        private void pump_6_ptb_Click(object sender, EventArgs e)
        {
            Motor_FacePlate fpl = new Motor_FacePlate(SCADA.root.FindMotor("Mtr_pump_6"));
            fpl.Show();
        }

        private void pump_7_ptb_Click(object sender, EventArgs e)
        {
            Motor_FacePlate fpl = new Motor_FacePlate(SCADA.root.FindMotor("Mtr_pump_7"));
            fpl.Show();
        }


        private void valve_14_ptb_Click(object sender, EventArgs e)
        {
            Valve_FacePlate vfpl = new Valve_FacePlate(SCADA.root.FindValve("Valve_14"));
            vfpl.Show();
        }
        private void UpdateModeFuncCbx(ushort value)
        {
            int selectedIdex = -1;

            switch (value)
            {
                case 1:
                    selectedIdex = 0;
                    break;
                case 2:
                    selectedIdex = 1;
                    break;
                case 3:
                    selectedIdex = 2;
                    break;


            }
            Mode_func_cbx.SelectedIndex = selectedIdex;
        }


        private void Mode_func_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selected = Mode_func_cbx.SelectedIndex;
                ushort mode;
                switch (selected)
                {
                    case 0:
                        mode = 1;
                        SCADA.root.s71500PLC.Write("MW60", mode);
                        break;
                    case 1:

                        mode = 2;
                        SCADA.root.s71500PLC.Write("MW60", mode);
                        break;
                    case 2:
                        mode = 3;
                        SCADA.root.s71500PLC.Write("MW60", mode);
                        break;
                }
            }
            catch (TPKTInvalidException tpkt)
            {
                MessageBox.Show(tpkt.Message);
            }

        }



        private void Alarm_btn_Click(object sender, EventArgs e)
        {
            AlarmLoginUI afplUI = new AlarmLoginUI(SCADA.root.FindDevice("PLC_1"));
            afplUI.Show();
        }

        private void Trend_btn_Click(object sender, EventArgs e)
        {
            AlarmUI afpl = new AlarmUI(SCADA.root.FindDevice("PLC_1"));
            afpl.Show();
        }

        private void Table_btn_Click(object sender, EventArgs e)
        {
            TableValue tbfpl = new TableValue(SCADA.root.FindDevice("PLC_1"));
            tbfpl.Show();
        }

        private void Start_auto_btn_Click(object sender, EventArgs e)
        {
            SCADA.root.s71500PLC.Write("M25.7", true);
            SCADA.root.s71500PLC.Write("M26.0", false);
        }

        private void Stop_all_btn_Click(object sender, EventArgs e)
        {
            SCADA.root.s71500PLC.Write("M26.0", true);
            SCADA.root.s71500PLC.Write("M25.7", false);
        }

        private void Mode_func_cbx_DropDown(object sender, EventArgs e)
        {
            isCbxEdited = true;
        }

        private void Boil_fnc_cbx_DropDown(object sender, EventArgs e)
        {
            isBoilcbxEdited = true;
        }


        private void UpdateValuePV_Tick(object sender, EventArgs e)
        {
            
            device = SCADA.root.FindDevice("PLC_1");
            


            if (isconnected == true)
            {
                #region valve_HMI
                //valve_1
                if (device.valve_1_data.OpenCmd == true)
                {
                    valve_1_ptb.BackgroundImage = Valve_ON;
                    valve_1_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_1_ptb.BackColor = Color.Transparent;
                    valve_1_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_1_ptb.BackgroundImage = Valve_OFF;
                    valve_1_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_1_ptb.BackColor = Color.Transparent;
                    valve_1_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                //valve_2

                if (device.valve_2_data.OpenCmd == true)
                {
                    valve_2_ptb.BackgroundImage = Valve_ON;
                    valve_2_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_2_ptb.BackColor = Color.Transparent;
                    valve_2_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_2_ptb.BackgroundImage = Valve_OFF;
                    valve_2_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_2_ptb.BackColor = Color.Transparent;
                    valve_2_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                //valve_3

                if (device.valve_3_data.OpenCmd == true)
                {
                    valve_3_ptb.BackgroundImage = Valve_ON;
                    valve_3_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_3_ptb.BackColor = Color.Transparent;
                    valve_3_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_3_ptb.BackgroundImage = Valve_OFF;
                    valve_3_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_3_ptb.BackColor = Color.Transparent;
                    valve_3_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                //valve_4

                if (device.valve_4_data.OpenCmd == true)
                {
                    valve_4_ptb.BackgroundImage = Valve_ON;
                    valve_4_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_4_ptb.BackColor = Color.Transparent;
                    valve_4_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_4_ptb.BackgroundImage = Valve_OFF;
                    valve_4_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_4_ptb.BackColor = Color.Transparent;
                    valve_4_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                //valve_5

                if (device.valve_5_data.OpenCmd == true)
                {
                    valve_5_ptb.BackgroundImage = Valve_ON;
                    valve_5_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_5_ptb.BackColor = Color.Transparent;
                    valve_5_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_5_ptb.BackgroundImage = Valve_OFF;
                    valve_5_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_5_ptb.BackColor = Color.Transparent;
                    valve_5_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                //valve_6

                if (device.valve_6_data.OpenCmd == true)
                {
                    valve_6_ptb.BackgroundImage = Valve_270_ON;
                    valve_6_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_6_ptb.BackColor = Color.Transparent;
                    valve_6_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_6_ptb.BackgroundImage = Valve_270_OFF;
                    valve_6_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_6_ptb.BackColor = Color.Transparent;
                    valve_6_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                // valve_7

                if (device.valve_7_data.OpenCmd == true)
                {
                    valve_7_ptb.BackgroundImage = Valve_270_ON;
                    valve_7_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_7_ptb.BackColor = Color.Transparent;
                    valve_7_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_7_ptb.BackgroundImage = Valve_270_OFF;
                    valve_7_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_7_ptb.BackColor = Color.Transparent;
                    valve_7_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                //valve_8

                if (device.valve_8_data.OpenCmd == true)
                {
                    valve_8_ptb.BackgroundImage = Valve_ON;
                    valve_8_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_8_ptb.BackColor = Color.Transparent;
                    valve_8_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_8_ptb.BackgroundImage = Valve_OFF;
                    valve_8_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_8_ptb.BackColor = Color.Transparent;
                    valve_8_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                //valve_9

                if (device.valve_9_data.OpenCmd == true)
                {
                    valve_9_ptb.BackgroundImage = Valve_270_ON;
                    valve_9_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_9_ptb.BackColor = Color.Transparent;
                    valve_9_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_9_ptb.BackgroundImage = Valve_270_OFF;
                    valve_9_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_9_ptb.BackColor = Color.Transparent;
                    valve_9_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                //valva_10

                if (device.valve_10_data.OpenCmd == true)
                {
                    valve_10_ptb.BackgroundImage = Valve_ON;
                    valve_10_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_10_ptb.BackColor = Color.Transparent;
                    valve_10_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_10_ptb.BackgroundImage = Valve_OFF;
                    valve_10_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_10_ptb.BackColor = Color.Transparent;
                    valve_10_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                //valve_11

                if (device.valve_11_data.OpenCmd == true)
                {
                    valve_11_ptb.BackgroundImage = Valve_ON;
                    valve_11_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_11_ptb.BackColor = Color.Transparent;
                    valve_11_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_11_ptb.BackgroundImage = Valve_OFF;
                    valve_11_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_11_ptb.BackColor = Color.Transparent;
                    valve_11_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                //valve_12

                if (device.valve_12_data.OpenCmd == true)
                {
                    valve_12_ptb.BackgroundImage = Valve_ON;
                    valve_12_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_12_ptb.BackColor = Color.Transparent;
                    valve_12_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_12_ptb.BackgroundImage = Valve_OFF;
                    valve_12_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_12_ptb.BackColor = Color.Transparent;
                    valve_12_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                //valve_14
                if (device.valve_14_data.OpenCmd == true)
                {
                    valve_14_ptb.BackgroundImage = Valve_270_ON;
                    valve_14_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_14_ptb.BackColor = Color.Transparent;
                    valve_14_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    valve_14_ptb.BackgroundImage = Valve_270_OFF;
                    valve_14_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    valve_14_ptb.BackColor = Color.Transparent;
                    valve_14_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                #endregion

                #region Pump
                //pump_1
                if (device.mtr_Pump_1_Data.Runcmd == true)
                {
                    pump_1_ptb.BackgroundImage = PUMP_ON;
                    pump_1_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_1_ptb.BackColor = Color.Transparent;
                    pump_1_ptb.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else
                {
                    pump_1_ptb.BackgroundImage = PUMP_OFF;
                    pump_1_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_1_ptb.BackColor = Color.Transparent;
                    pump_1_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                // pump_2
                if (device.mtr_Pump_2_Data.Runcmd == true)
                {
                    pump_2_ptb.BackgroundImage = PUMP_ON;
                    pump_2_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_2_ptb.BackColor = Color.Transparent;
                    pump_2_ptb.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else
                {
                    pump_2_ptb.BackgroundImage = PUMP_OFF;
                    pump_2_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_2_ptb.BackColor = Color.Transparent;
                    pump_2_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                // pump_3
                if (device.mtr_Pump_3_Data.Runcmd == true)
                {
                    pump_3_ptb.BackgroundImage = PUMP_ON;
                    pump_3_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_3_ptb.BackColor = Color.Transparent;
                    pump_3_ptb.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else
                {
                    pump_3_ptb.BackgroundImage = PUMP_OFF;
                    pump_3_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_3_ptb.BackColor = Color.Transparent;
                    pump_3_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                // pump_4
                if (device.mtr_Pump_4_Data.Runcmd == true)
                {
                    pump_4_ptb.BackgroundImage = PUMP_ON;
                    pump_4_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_4_ptb.BackColor = Color.Transparent;
                    pump_4_ptb.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else
                {
                    pump_4_ptb.BackgroundImage = PUMP_OFF;
                    pump_4_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_4_ptb.BackColor = Color.Transparent;
                    pump_4_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                //pump_5
                if (device.mtr_Pump_5_Data.Runcmd == true)
                {
                    pump_5_ptb.BackgroundImage = PUMP_ON;
                    pump_5_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_5_ptb.BackColor = Color.Transparent;
                    pump_5_ptb.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else
                {
                    pump_5_ptb.BackgroundImage = PUMP_OFF;
                    pump_5_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_5_ptb.BackColor = Color.Transparent;
                    pump_5_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                // pump_6
                if (device.mtr_Pump_6_Data.Runcmd == true)
                {
                    pump_6_ptb.BackgroundImage = PUMP_ON;
                    pump_6_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_6_ptb.BackColor = Color.Transparent;
                    pump_6_ptb.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else
                {
                    pump_6_ptb.BackgroundImage = PUMP_OFF;
                    pump_6_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_6_ptb.BackColor = Color.Transparent;
                    pump_6_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }


                // pump 7
                if (device.mtr_Pump_7_Data.Runcmd == true)
                {
                    pump_7_ptb.BackgroundImage = PUMP_ON;
                    pump_7_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_7_ptb.BackColor = Color.Transparent;
                    pump_7_ptb.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else
                {
                    pump_7_ptb.BackgroundImage = PUMP_OFF;
                    pump_7_ptb.BackgroundImageLayout = ImageLayout.Stretch;
                    pump_7_ptb.BackColor = Color.Transparent;
                    pump_7_ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                }




                #endregion


                ushort stg_lv = SCADA.root.stg;
                realStroage_wtlv_ptb.Size = new Size(realStroage_wtlv_ptb.Width,(hStg - stg_lv/4) );
                Console.WriteLine(realStroage_wtlv_ptb.Height.ToString());

                ushort che_lv = SCADA.root.che;
                realChe_wtlv_ptb.Size = new Size(realChe_wtlv_ptb.Width, hChe - che_lv * (6 / 5));

                ushort fw1_lv = SCADA.root.fw1;
                realFW1_wtlv_ptb.Size = new Size(realFW1_wtlv_ptb.Width, hFw1 - fw1_lv / 2);

                ushort fw2_lv = SCADA.root.fw2;
                realFW2_wtlv_ptb.Size = new Size(realFW2_wtlv_ptb.Width, hFw2 - fw2_lv / 2);



                ushort nw_lv = SCADA.root.nw;
                realNW_wtlv_ptb.Size = new Size(realNW_wtlv_ptb.Width, hNw - nw_lv / 5);
                if (!isCbxEdited)
                {
                    UpdateModeFuncCbx(device.mode_fnc);
                    
                }




                Console.WriteLine(isCbxEdited);
                Console.WriteLine(isBoilcbxEdited);





            }
        }


        private void ModeStatusValve_Pump_timer_Tick(object sender, EventArgs e)
        {
            
            if (device != null)
            {
                try {
                    //Update State & Mode of Pumps
                    modepump1.Text = device.mtr_Pump_1_Data.Mode.ToString();
                    statuspump1.Text = device.mtr_Pump_1_Data.Runcmd.ToString();

                    modepump2.Text = device.mtr_Pump_2_Data.Mode.ToString();
                    statuspump2.Text = device.mtr_Pump_2_Data.Runcmd.ToString();

                    modepump3.Text = device.mtr_Pump_3_Data.Mode.ToString();
                    statuspump3.Text = device.mtr_Pump_3_Data.Runcmd.ToString();

                    modepump4.Text = device.mtr_Pump_4_Data.Mode.ToString();
                    statuspump4.Text = device.mtr_Pump_4_Data.Runcmd.ToString();

                    modepump5.Text = device.mtr_Pump_5_Data.Mode.ToString();
                    statuspump5.Text = device.mtr_Pump_5_Data.Runcmd.ToString();

                    modepump6.Text = device.mtr_Pump_6_Data.Mode.ToString();
                    statuspump6.Text = device.mtr_Pump_6_Data.Runcmd.ToString();

                    modepump7.Text = device.mtr_Pump_7_Data.Mode.ToString();
                    statuspump7.Text = device.mtr_Pump_7_Data.Runcmd.ToString();

                    //Update State & Mode of Valves

                    modevalve1.Text = device.valve_1_data.Mode.ToString();
                    statusvalve1.Text = device.valve_1_data.OpenCmd.ToString();

                    modevalve2.Text = device.valve_2_data.Mode.ToString();
                    statusvalve2.Text = device.valve_2_data.OpenCmd.ToString();

                    modevalve3.Text = device.valve_3_data.Mode.ToString();
                    statusvalve3.Text = device.valve_3_data.OpenCmd.ToString();

                    modevalve4.Text = device.valve_4_data.Mode.ToString();
                    statusvalve4.Text = device.valve_4_data.OpenCmd.ToString();

                    modevalve5.Text = device.valve_5_data.Mode.ToString();
                    statusvalve5.Text = device.valve_5_data.OpenCmd.ToString();

                    modevalve6.Text = device.valve_6_data.Mode.ToString();
                    statusvalve6.Text = device.valve_6_data.OpenCmd.ToString();

                    modevalve7.Text = device.valve_7_data.Mode.ToString();
                    statusvalve7.Text = device.valve_7_data.OpenCmd.ToString();

                    modevalve8.Text = device.valve_8_data.Mode.ToString();
                    statusvalve8.Text = device.valve_8_data.OpenCmd.ToString();

                    modevalve9.Text = device.valve_9_data.Mode.ToString();
                    statusvalve9.Text = device.valve_9_data.OpenCmd.ToString();

                    modevalve10.Text = device.valve_10_data.Mode.ToString();
                    statusvalve10.Text = device.valve_10_data.OpenCmd.ToString();

                    modevalve11.Text = device.valve_11_data.Mode.ToString();
                    statusvalve11.Text = device.valve_11_data.OpenCmd.ToString();

                    modevalve12.Text = device.valve_12_data.Mode.ToString();
                    statusvalve12.Text = device.valve_12_data.OpenCmd.ToString();

                    modevalve14.Text = device.valve_14_data.Mode.ToString();
                    statusvalve14.Text = device.valve_14_data.OpenCmd.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("device is null", ex.Message);
                }
                }



        }








        #endregion




    }

}

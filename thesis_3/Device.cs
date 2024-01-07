using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;
using System.Timers;


namespace thesis_3
{
    
    #region Device
    public class Device
    {
        public string ip;
        public string name;
        
        
        Plc s71500plc = null;
        System.Timers.Timer updateTimer = null;
        public Motor_Data mtr_Pump_1_Data = new Motor_Data();
        public Motor_Data mtr_Pump_2_Data = new Motor_Data();
        public Motor_Data mtr_Pump_3_Data = new Motor_Data();
        public Motor_Data mtr_Pump_4_Data = new Motor_Data();
        public Motor_Data mtr_Pump_5_Data = new Motor_Data();
        public Motor_Data mtr_Pump_6_Data = new Motor_Data();
        public Motor_Data mtr_Pump_7_Data = new Motor_Data();
        public Valve_data valve_1_data = new Valve_data();
        public Valve_data valve_2_data = new Valve_data();
        public Valve_data valve_3_data = new Valve_data();
        public Valve_data valve_4_data = new Valve_data();
        public Valve_data valve_5_data = new Valve_data();
        public Valve_data valve_6_data = new Valve_data();
        public Valve_data valve_7_data = new Valve_data();
        public Valve_data valve_8_data = new Valve_data();
        public Valve_data valve_9_data = new Valve_data();
        public Valve_data valve_10_data = new Valve_data();
        public Valve_data valve_11_data = new Valve_data();
        public Valve_data valve_12_data = new Valve_data();

        public Valve_data valve_14_data = new Valve_data();
        public ushort mode_fnc;
        public ushort boil_fnc;

        public ushort Storage_water;
        public ushort Chemical_water;
        public ushort Fresh_water_1;
        public ushort Fresh_water_2;
        public ushort Hot_water;
        public ushort Normal_water;
        public Device(string _ip, string _name)
        {
            ip = _ip;
            name =_name;
            s71500plc = new Plc(CpuType.S71500, ip, 0, 1);
            s71500plc.Open();
            SCADA.root.s71500PLC = s71500plc;
            if (SCADA.root.s71500PLC.IsConnected == true)
            {
                updateTimer = new System.Timers.Timer(100);
                updateTimer.Elapsed += UpdateTimer_Elapsed;
                updateTimer.Enabled = true;
            }
            else
            {
                Console.WriteLine("PLC disconnect");
            }
            

            
            
        }






        private void UpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (s71500plc.IsConnected == true)
            {
                try
                {
                    s71500plc.ReadClass(mtr_Pump_1_Data, 4);
                    s71500plc.ReadClass(mtr_Pump_2_Data, 5);
                    s71500plc.ReadClass(mtr_Pump_3_Data, 3);
                    s71500plc.ReadClass(mtr_Pump_4_Data, 12);
                    s71500plc.ReadClass(mtr_Pump_5_Data, 13);
                    s71500plc.ReadClass(mtr_Pump_6_Data, 14);
                    s71500plc.ReadClass(mtr_Pump_7_Data, 15);
                    s71500plc.ReadClass(valve_1_data, 6);
                    s71500plc.ReadClass(valve_2_data, 7);
                    s71500plc.ReadClass(valve_3_data, 2);
                    s71500plc.ReadClass(valve_4_data, 16);
                    s71500plc.ReadClass(valve_5_data, 17);
                    s71500plc.ReadClass(valve_6_data, 18);
                    s71500plc.ReadClass(valve_7_data, 19);
                    s71500plc.ReadClass(valve_8_data, 20);
                    s71500plc.ReadClass(valve_9_data, 21);
                    s71500plc.ReadClass(valve_10_data, 22);
                    s71500plc.ReadClass(valve_11_data, 23);
                    s71500plc.ReadClass(valve_12_data, 24);
                    s71500plc.ReadClass(valve_14_data, 26);
                    mode_fnc = ((ushort)s71500plc.Read("MW60"));
                    boil_fnc =((ushort)s71500plc.Read("MW62"));
               
                    Storage_water = ((ushort)s71500plc.Read("DB1.DBW0.0"));
                    Chemical_water = ((ushort)s71500plc.Read("DB1.DBW2.0"));
                    Fresh_water_1 = ((ushort)s71500plc.Read("DB1.DBW4.0"));
                    Fresh_water_2 = ((ushort)s71500plc.Read("DB1.DBW6.0"));
                    Normal_water = ((ushort)s71500plc.Read("DB1.DBW8.0"));


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Cannot read the Class : {ex.Message}");
                }
                SCADA.root.stg = Storage_water;
                SCADA.root.che = Chemical_water;
                SCADA.root.fw1 = Fresh_water_1;
                SCADA.root.fw2 = Fresh_water_2;

                SCADA.root.nw = Normal_water;


            }
        }

        // write value for each pump
        public void WriteP(object value, string tagName)
        {
            string[] s = tagName.Split('.');
            switch (s[0])
            { 
                case "Mtr_pump_1":
                    switch (s[1])
                    {
                        case "Start":
                            s71500plc.Write("DB4.DBX2.0", value);
                            break;
                        case "Stop":
                            s71500plc.Write("DB4.DBX2.1", value);
                            break;
                        case "Reset":
                            s71500plc.Write("DB4.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB4.DBW0.0", value);
                            break;


                    }
                    break;

                case "Mtr_pump_2":
                    switch (s[1])
                    {
                        case "Start":
                            s71500plc.Write("DB5.DBX2.0", value);
                            break;
                        case "Stop":
                            s71500plc.Write("DB5.DBX2.1", value);
                            break;
                        case "Reset":
                            s71500plc.Write("DB5.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB5.DBW0.0", value);
                            break;



                    }
                    break;
                case "Mtr_pump_3":
                    switch (s[1])
                    {
                        case "Start":
                            s71500plc.Write("DB3.DBX2.0", value);
                            break;
                        case "Stop":
                            s71500plc.Write("DB3.DBX2.1", value);
                            break;
                        case "Reset":
                            s71500plc.Write("DB3.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB3.DBW0.0", value);
                            break;



                    }
                    break;
                case "Mtr_pump_4":
                    switch (s[1])
                    {
                        case "Start":
                            s71500plc.Write("DB12.DBX2.0", value);
                            break;
                        case "Stop":
                            s71500plc.Write("DB12.DBX2.1", value);
                            break;
                        case "Reset":
                            s71500plc.Write("DB12.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB12.DBW0.0", value);
                            break;



                    }
                    break;
                case "Mtr_pump_5":
                    switch (s[1])
                    {
                        case "Start":
                            s71500plc.Write("DB13.DBX2.0", value);
                            break;
                        case "Stop":
                            s71500plc.Write("DB13.DBX2.1", value);
                            break;
                        case "Reset":
                            s71500plc.Write("DB13.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB13.DBW0.0", value);
                            break;



                    }
                    break;
                case "Mtr_pump_6":
                    switch (s[1])
                    {
                        case "Start":
                            s71500plc.Write("DB14.DBX2.0", value);
                            break;
                        case "Stop":
                            s71500plc.Write("DB14.DBX2.1", value);
                            break;
                        case "Reset":
                            s71500plc.Write("DB14.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB14.DBW0.0", value);
                            break;



                    }
                    break;
                case "Mtr_pump_7":
                    switch (s[1])
                    {
                        case "Start":
                            s71500plc.Write("DB15.DBX2.0", value);
                            break;
                        case "Stop":
                            s71500plc.Write("DB15.DBX2.1", value);
                            break;
                        case "Reset":
                            s71500plc.Write("DB15.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB15.DBW0.0", value);
                            break;



                    }
                    break;
            }

        }
        // write value for each valve
        public void WriteV(object value, string tagname)
        {
            string[] s = tagname.Split('.');
            switch (s[0])
            {
                case "Valve_1":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB6.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB6.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB6.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB6.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_2":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB7.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB7.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB7.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB7.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_3":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB2.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB2.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB2.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB2.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_4":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB16.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB16.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB16.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB16.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_5":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB17.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB17.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB17.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB17.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_6":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB18.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB18.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB18.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB18.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_7":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB19.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB19.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB19.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB19.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_8":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB20.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB20.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB20.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB20.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_9":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB21.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB21.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB21.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB21.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_10":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB22.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB22.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB22.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB22.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_11":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB23.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB23.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB23.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB23.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_12":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB24.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB24.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB24.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB24.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_13":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB25.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB25.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB25.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB25.DBW0.0", value);
                            break;
                    }
                    break;
                case "Valve_14":
                    switch (s[1])
                    {
                        case "OPEN":
                            s71500plc.Write("DB26.DBX2.0", value);
                            break;
                        case "CLOSE":
                            s71500plc.Write("DB26.DBX2.1", value);
                            break;
                        case "RESET":
                            s71500plc.Write("DB26.DBX2.2", value);
                            break;
                        case "MODE":
                            s71500plc.Write("DB26.DBW0.0", value);
                            break;
                    }
                    break;
            }
        }
        #endregion

        public class Motor_Data
        {
            public ushort Mode { get; set; }
            public bool Start { get; set; }
            public bool Stop { get; set; }
            public bool Reset { get; set; }
            public bool Emergency { get; set; }

            public bool Run { get; set; }
            public bool Stopped { get; set; }

            public bool Runtcondition { get; set; }
            public bool Stopcondition { get; set; }
            public bool Trip { get; set; }
            public Boolean free1 { get; set; }
            public Boolean free2 { get; set; }
            public Boolean free3 { get; set; }
            public Boolean free4 { get; set; }
            public Boolean free5 { get; set; }
            public Boolean free6 { get; set; } 
            public Boolean free7 { get; set; }

            //public Byte Output { get; set; }
            public bool Runcmd { get; set; }
                
            public bool Fault { get; set; }
            public Int32 RUNTIME_ACC { get; set; }
            public Int32 RUNTIME_ACTUAL { get; set; }

        }
        public class Valve_data
        {
            public ushort Mode { get; set; }
            public bool Open { get; set; }
            public bool Close { get; set; }
            public bool Reset { get; set; }
            public bool Emergency { get; set; }
            public bool Opened{ get; set; }
            public bool Closed { get; set; }

            public bool Opencondition { get; set; }
            public bool Closecondition { get; set; }
            public bool Trip { get; set; }
            public Boolean free1 { get; set; }
            public Boolean free2 { get; set; }
            public Boolean free3 { get; set; }
            public Boolean free4 { get; set; }
            public Boolean free5 { get; set; }
            public Boolean free6 { get; set; }
            public Boolean free7 { get; set; }

            //public Byte Output { get; set; }
            public bool OpenCmd { get; set; }
            public bool CloseCmd { get; set; }

            public bool Fault { get; set; }
            public Int32 RUNTIME_ACC { get; set; }
            public Int32 RUNTIME_ACTUAL { get; set; }
        }


    }        
}



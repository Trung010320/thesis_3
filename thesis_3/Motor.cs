using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace thesis_3
{
    public class Motor
    {
        
        public string name;
        public string deviceName;
        public SCADA parent;
        public int period;
        Timer updateTimer = null;
        Timer monitorTimer = null;
        public ushort mode;
        public bool start;
        public bool stop;
        public bool RunCmd;
        public bool reset;
        public bool faullt;
        public bool trip;
        public Int32 runTimeAcc;


        public Motor(string _name, int _period, SCADA _parent, string _devName)
        {
            name = _name;
            period = _period;
            parent = _parent;
            deviceName = _devName;

            updateTimer = new Timer(_period);
            updateTimer.Elapsed += UpdateTimer_Elapsed;
            updateTimer.Enabled = true;

            monitorTimer = new Timer(1000);
            monitorTimer.Elapsed += MonitorTimer_Elapsed;
            monitorTimer.Enabled = true;
        }
        
        public void WritePump(string tagName, object value)
        {
            switch (tagName)
            {
                case "Start":
                    Device device = parent.FindDevice(deviceName);
                    device.WriteP(value, $"{name}.Start");
                    break;
                case "Stop":
                    device = parent.FindDevice(deviceName);
                    device.WriteP(value, $"{ name }.Stop");
                    break;
                case "Reset":
                    device = parent.FindDevice(deviceName);
                    device.WriteP(value, $"{ name }.Reset");
                    break;
                case "MODE":
                    device = parent.FindDevice(deviceName);
                    device.WriteP(value, $"{name}.MODE");
                    break;



            }

        }

        private void MonitorTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            


        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device device = parent.FindDevice(deviceName);


            if (device != null)
            {
                switch (name)
                {
                    case "Mtr_pump_1":
                        mode = device.mtr_Pump_1_Data.Mode;
                        RunCmd = device.mtr_Pump_1_Data.Runcmd;
                        runTimeAcc = device.mtr_Pump_1_Data.RUNTIME_ACC;
                        trip = device.mtr_Pump_1_Data.Trip;



                        break;
                    case "Mtr_pump_2":
                        mode = device.mtr_Pump_2_Data.Mode;
                        RunCmd = device.mtr_Pump_2_Data.Runcmd;
                        runTimeAcc = device.mtr_Pump_2_Data.RUNTIME_ACC;
                        trip = device.mtr_Pump_2_Data.Trip;

                        break;
                    case "Mtr_pump_3":
                        mode = device.mtr_Pump_3_Data.Mode;
                        RunCmd = device.mtr_Pump_3_Data.Runcmd;
                        runTimeAcc = device.mtr_Pump_3_Data.RUNTIME_ACC;
                        trip = device.mtr_Pump_3_Data.Trip;

                        break;
                    case "Mtr_pump_4":
                        mode = device.mtr_Pump_4_Data.Mode;
                        RunCmd = device.mtr_Pump_4_Data.Runcmd;
                        runTimeAcc = device.mtr_Pump_4_Data.RUNTIME_ACC;
                        trip = device.mtr_Pump_4_Data.Trip;

                        break;
                    case "Mtr_pump_5":
                        mode = device.mtr_Pump_5_Data.Mode;
                        RunCmd = device.mtr_Pump_5_Data.Runcmd;
                        runTimeAcc = device.mtr_Pump_5_Data.RUNTIME_ACC;
                        trip = device.mtr_Pump_5_Data.Trip;

                        break;
                    case "Mtr_pump_6":
                        mode = device.mtr_Pump_6_Data.Mode;
                        RunCmd = device.mtr_Pump_6_Data.Runcmd;
                        runTimeAcc = device.mtr_Pump_6_Data.RUNTIME_ACC;
                        trip = device.mtr_Pump_6_Data.Trip;

                        break;
                    case "Mtr_pump_7":
                        mode = device.mtr_Pump_7_Data.Mode;
                        RunCmd = device.mtr_Pump_7_Data.Runcmd;
                        runTimeAcc = device.mtr_Pump_7_Data.RUNTIME_ACC;
                        trip = device.mtr_Pump_7_Data.Trip;

                        break;


                }
            }
        }
    }

}
    


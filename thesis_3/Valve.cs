using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using S7.Net;

namespace thesis_3
{
    public class Valve
    {
        public string vName;
        public string deviceName;
        public SCADA parent;
        public int period;
        Timer updateTimer = null;

        public ushort mode;
        public bool open;
        public bool close;
        public bool closeCmd;
        public bool openCmd;
        public bool reset;
        public bool trip;
        public bool faullt;
        public Int32 runTimeAcc;
        public Valve (string _vName, int _period, SCADA _parent, string _devName)
        {
            vName = _vName;
            period = _period;
            parent = _parent;
            deviceName = _devName;
            updateTimer = new Timer(_period);
            updateTimer.Elapsed += UpdateTimer_Elapsed;
            updateTimer.Enabled = true;

        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device device = parent.FindDevice(deviceName);
            if (device != null)
            {
                switch (vName)
                {
                    case "Valve_1":
                        mode = device.valve_1_data.Mode;
                        openCmd = device.valve_1_data.OpenCmd;
                        closeCmd = device.valve_1_data.CloseCmd;
                        runTimeAcc = device.valve_1_data.RUNTIME_ACC;
                        trip = device.valve_1_data.Trip;
                        break;
                    case "Valve_2":
                        mode = device.valve_2_data.Mode;
                        openCmd = device.valve_2_data.OpenCmd;
                        closeCmd = device.valve_2_data.CloseCmd;
                        runTimeAcc = device.valve_2_data.RUNTIME_ACC;
                        trip = device.valve_2_data.Trip;
                        break;
                    case "Valve_3":
                        mode = device.valve_3_data.Mode;
                        openCmd = device.valve_3_data.OpenCmd;
                        closeCmd = device.valve_3_data.CloseCmd;
                        runTimeAcc = device.valve_3_data.RUNTIME_ACC;
                        trip = device.valve_3_data.Trip;
                        break;
                    case "Valve_4":
                        mode = device.valve_4_data.Mode;
                        openCmd = device.valve_4_data.OpenCmd;
                        closeCmd = device.valve_4_data.CloseCmd;
                        runTimeAcc = device.valve_4_data.RUNTIME_ACC;
                        trip = device.valve_4_data.Trip;
                        break;
                    case "Valve_5":
                        mode = device.valve_5_data.Mode;
                        openCmd = device.valve_5_data.OpenCmd;
                        closeCmd = device.valve_5_data.CloseCmd;
                        runTimeAcc = device.valve_5_data.RUNTIME_ACC;
                        trip = device.valve_5_data.Trip;
                        break;
                    case "Valve_6":
                        mode = device.valve_6_data.Mode;
                        openCmd = device.valve_6_data.OpenCmd;
                        closeCmd = device.valve_6_data.CloseCmd;
                        runTimeAcc = device.valve_1_data.RUNTIME_ACC;
                        trip = device.valve_6_data.Trip;
                        break;
                    case "Valve_7":
                        mode = device.valve_7_data.Mode;
                        openCmd = device.valve_7_data.OpenCmd;
                        closeCmd = device.valve_7_data.CloseCmd;
                        runTimeAcc = device.valve_7_data.RUNTIME_ACC;
                        trip = device.valve_7_data.Trip;
                        break;
                    case "Valve_8":
                        mode = device.valve_8_data.Mode;
                        openCmd = device.valve_8_data.OpenCmd;
                        closeCmd = device.valve_8_data.CloseCmd;
                        runTimeAcc = device.valve_1_data.RUNTIME_ACC;
                        trip = device.valve_8_data.Trip;
                        break;
                    case "Valve_9":
                        mode = device.valve_9_data.Mode;
                        openCmd = device.valve_9_data.OpenCmd;
                        closeCmd = device.valve_9_data.CloseCmd;
                        runTimeAcc = device.valve_9_data.RUNTIME_ACC;
                        trip = device.valve_9_data.Trip;
                        break;
                    case "Valve_10":
                        mode = device.valve_10_data.Mode;
                        openCmd = device.valve_10_data.OpenCmd;
                        closeCmd = device.valve_10_data.CloseCmd;
                        runTimeAcc = device.valve_10_data.RUNTIME_ACC;
                        trip = device.valve_10_data.Trip;
                        break;
                    case "Valve_11":
                        mode = device.valve_11_data.Mode;
                        openCmd = device.valve_11_data.OpenCmd;
                        closeCmd = device.valve_11_data.CloseCmd;
                        runTimeAcc = device.valve_11_data.RUNTIME_ACC;
                        trip = device.valve_11_data.Trip;
                        break;
                    case "Valve_12":
                        mode = device.valve_12_data.Mode;
                        openCmd = device.valve_12_data.OpenCmd;
                        closeCmd = device.valve_12_data.CloseCmd;
                        runTimeAcc = device.valve_12_data.RUNTIME_ACC;
                        trip = device.valve_12_data.Trip;
                        break;
                    case "Valve_14":
                        mode = device.valve_14_data.Mode;
                        openCmd = device.valve_14_data.OpenCmd;
                        closeCmd = device.valve_14_data.CloseCmd;
                        runTimeAcc = device.valve_14_data.RUNTIME_ACC;
                        trip = device.valve_14_data.Trip;
                        break;
                }

            }
        }
        public void  WriteValve ( string tagname, object value)
        {
            switch (tagname)
            {
                case "OPEN":
                    Device device = parent.FindDevice(deviceName);
                    device.WriteV(value, $"{vName}.OPEN");
                    break;
                case "CLOSE":
                     device = parent.FindDevice(deviceName);
                    device.WriteV(value, $"{vName}.CLOSE");
                    break;
                case "RESET":
                     device = parent.FindDevice(deviceName);
                    device.WriteV(value, $"{vName}.RESET");
                    break;
                case "MODE":
                    device = parent.FindDevice(deviceName);
                    device.WriteV(value, $"{vName}.MODE");
                    break;

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

namespace HIC_FireDetectReceiver_Manager
{
    public class Global_Variable
    {
        public static P2000_Data oP2000_Data = new P2000_Data();
        public static Alarm_In_Table oAlarmIn_Table = new Alarm_In_Table();
        public static Alarm_Out_Table oAlarmOut_Table = new Alarm_Out_Table();
        public static OutGroup_Table oOutGroup_Table = new OutGroup_Table();
        public static AreaAlarm_Table oAreaAlarm_Table = new AreaAlarm_Table();
        public static EmergencyAlarm_Table oEmergencyAlarm_Table = new EmergencyAlarm_Table();

        public static string test;
        public static SerialPort oSP;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIC_FireDetectReceiver_Manager.Src
{
    class Serial_Provision
    {
        //private string TransferData()
        //{
        //    string tmp_str = "";
        //    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate
        //    {
        //        string test1 = txb_DEVICEID.Text;

        //        string split_str = "/";
        //        tmp_str += txb_DEVICEID.Text + split_str;
        //        tmp_str += txb_HMI_PHNUM.Text + split_str;
        //        tmp_str += txb_MY_CDMANUM.Text + split_str;
        //        tmp_str += txb_SM_cnt.Text + split_str;
        //        tmp_str += txb_SM_num1.Text + split_str;
        //        tmp_str += txb_SM_num2.Text + split_str;
        //        tmp_str += txb_SM_num3.Text + split_str;
        //        tmp_str += txb_SM_num4.Text + split_str;
        //        tmp_str += txb_SM_num5.Text + split_str;

        //        tmp_str += txb_SEN_BOARDS.Text + split_str;
        //        tmp_str += txb_REL_BOARDS.Text + split_str;
        //        tmp_str += txb_DIS_BOARDS.Text + split_str;
        //        tmp_str += txb_onoff_BOARDS.Text + split_str;
        //        tmp_str += txb_auto_BOARDS.Text;
        //    }));


        //    return tmp_str;
        //}
        //string get_sRecvData = String.Empty;

        //string serial_buffer = String.Empty;

        //void Serial_Receive(object sender, SerialDataReceivedEventArgs e)
        //{
        //    try
        //    {
        //        Helper.Serial serial = new Helper.Serial();

        //        get_sRecvData = serial.Read();

        //        if ((get_sRecvData != string.Empty)) // && (g_sRecvData.Contains('\n')))
        //        {
        //            serial_buffer += get_sRecvData + "/";

        //            if (get_sRecvData.Contains("$e"))
        //            {
        //                //serial_buffer += get_sRecvData;
        //                SetText(serial_buffer);
        //                serial_buffer = String.Empty;
        //            }
        //            else if (get_sRecvData.Contains("$mw"))
        //            {
        //                serial.Write(TransferData());
        //                serial_buffer = String.Empty;
        //            }
        //            else if (get_sRecvData.Contains("$mrcplt"))
        //            {
        //                System.Windows.MessageBox.Show("불러오기 완료");
        //                serial_buffer = String.Empty;
        //            }
        //            else if (get_sRecvData.Contains("$complate"))
        //            {
        //                System.Windows.MessageBox.Show("ok");
        //                serial_buffer = String.Empty;
        //            }
        //            else if (get_sRecvData.Contains("$ce"))
        //            {
        //                serial_buffer = String.Empty;
        //            }
        //        }
        //    }
        //    catch (TimeoutException)
        //    {
        //        get_sRecvData = string.Empty;
        //    }
        //}

        //delegate void SetTextCallBack(String text);

        //private void SetText(string text)
        //{
        //    string[] split_text = text.Split('/');
        //    Global_Variable.oP2000_Data.DEVICE_ID = split_text[0];
        //    Global_Variable.oP2000_Data.HMI_PHNUM = split_text[1];
        //    Global_Variable.oP2000_Data.MY_CDMANUM = split_text[2];
        //    Global_Variable.oP2000_Data.SMART_PHNUMS = split_text[3];
        //    Global_Variable.oP2000_Data.SMART_PHNUM0 = split_text[4];
        //    Global_Variable.oP2000_Data.SMART_PHNUM1 = split_text[5];
        //    Global_Variable.oP2000_Data.SMART_PHNUM2 = split_text[6];
        //    Global_Variable.oP2000_Data.SMART_PHNUM3 = split_text[7];
        //    Global_Variable.oP2000_Data.SMART_PHNUM4 = split_text[8];
        //    Global_Variable.oP2000_Data.SENSOR_BOARDS = split_text[9];
        //    Global_Variable.oP2000_Data.RELAY_BOARDS = split_text[10];
        //    Global_Variable.oP2000_Data.DISPLAY_BOARDS = split_text[11];
        //    Global_Variable.oP2000_Data.ONOFF_BOARDS = split_text[12];
        //    Global_Variable.oP2000_Data.AUTO_BOARDS = split_text[13];

        //    try
        //    {
        //        Mapping_Data();
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}
        //private void Mapping_Data()
        //{
        //    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate
        //    {
        //        txb_DEVICEID.Text = Global_Variable.oP2000_Data.DEVICE_ID;
        //        txb_HMI_PHNUM.Text = Global_Variable.oP2000_Data.HMI_PHNUM;
        //        txb_MY_CDMANUM.Text = Global_Variable.oP2000_Data.MY_CDMANUM;
        //        txb_SM_cnt.Text = Global_Variable.oP2000_Data.SMART_PHNUMS;
        //        txb_SM_num1.Text = Global_Variable.oP2000_Data.SMART_PHNUM0;
        //        txb_SM_num2.Text = Global_Variable.oP2000_Data.SMART_PHNUM1;
        //        txb_SM_num3.Text = Global_Variable.oP2000_Data.SMART_PHNUM2;
        //        txb_SM_num4.Text = Global_Variable.oP2000_Data.SMART_PHNUM3;
        //        txb_SM_num5.Text = Global_Variable.oP2000_Data.SMART_PHNUM4;

        //        txb_SEN_BOARDS.Text = Global_Variable.oP2000_Data.SENSOR_BOARDS;
        //        txb_REL_BOARDS.Text = Global_Variable.oP2000_Data.RELAY_BOARDS;
        //        txb_DIS_BOARDS.Text = Global_Variable.oP2000_Data.DISPLAY_BOARDS;
        //        txb_onoff_BOARDS.Text = Global_Variable.oP2000_Data.ONOFF_BOARDS;
        //        txb_auto_BOARDS.Text = Global_Variable.oP2000_Data.AUTO_BOARDS;
        //    }
        //        ));
        //}
    }
}

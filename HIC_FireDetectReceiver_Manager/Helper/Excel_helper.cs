using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;



namespace HIC_FireDetectReceiver_Manager
{
    public class Excel_helper
    {
        Excel.Application excelApp = null;//엑셀 app 객체
        Excel.Workbook wb = null; //엑셀 파일 관련 객체
        Excel.Worksheet ws1 = null;//엑셀 파일의 시트 관련 객체
        Excel.Worksheet ws2 = null;
        Excel.Worksheet ws3 = null;
        Excel.Worksheet ws4 = null;

        #region Device
        Excel.Range cell_DEVICE_ID;
        Excel.Range cell_HMI_PHNUM;
        Excel.Range cell_MY_CDMANUM;

        Excel.Range cell_SMART_PHNUMS;
        Excel.Range cell_SMART_PHNUM0;
        Excel.Range cell_SMART_PHNUM1;
        Excel.Range cell_SMART_PHNUM2;
        Excel.Range cell_SMART_PHNUM3;
        Excel.Range cell_SMART_PHNUM4;

        Excel.Range cell_SENSOR_BOARDS;
        Excel.Range cell_RELAY_BOARDS;
        Excel.Range cell_DISPLAY_BOARDS;
        Excel.Range cell_ONOFF_BOARDS;
        Excel.Range cell_AUTO_BOARDS;

        Excel.Range cell_DEVICE_ID_value;
        Excel.Range cell_HMI_PHNUM_value;
        Excel.Range cell_MY_CDMANUM_value;

        Excel.Range cell_SMART_PHNUMS_value;
        Excel.Range cell_SMART_PHNUM0_value;
        Excel.Range cell_SMART_PHNUM1_value;
        Excel.Range cell_SMART_PHNUM2_value;
        Excel.Range cell_SMART_PHNUM3_value;
        Excel.Range cell_SMART_PHNUM4_value;

        Excel.Range cell_SENSOR_BOARDS_value;
        Excel.Range cell_RELAY_BOARDS_value;
        Excel.Range cell_DISPLAY_BOARDS_value;
        Excel.Range cell_ONOFF_BOARDS_value;
        Excel.Range cell_AUTO_BOARDS_value;

        Excel.Range title_device_Range0;
        Excel.Range title_device_Range1;
        Excel.Range title_device_Range2;
        Excel.Range value_Range;
        #endregion

        #region InOut
        Excel.Range column_in_BoardNo;
        Excel.Range column_in_Circuit;
        Excel.Range column_in_Code;
        Excel.Range column_in_msg1;
        Excel.Range column_in_msg2;
        Excel.Range column_in_msg3;
        Excel.Range column_in_msg4;
        Excel.Range column_in_control1;
        Excel.Range column_in_control2;

        Excel.Range column_out_BoardNo;
        Excel.Range column_out_Circuit;
        Excel.Range column_out_msg1;
        Excel.Range column_out_msg2;
        Excel.Range column_out_msg3;
        Excel.Range column_out_msg4;
        Excel.Range column_out_pushstop;

        Excel.Range column_in_range;
        Excel.Range column_out_range;
        #endregion

        #region OutGroup
        Excel.Range column_outgroup_groupNo;
        Excel.Range column_outgroup_groupName;
        Excel.Range column_outgroup_Out1;
        Excel.Range column_outgroup_Out2;
        Excel.Range column_outgroup_Out3;
        Excel.Range column_outgroup_Out4;
        Excel.Range column_outgroup_Out5;
        Excel.Range column_outgroup_Out6;
        Excel.Range column_outgroup_Out7;
        Excel.Range column_outgroup_Out8;
        Excel.Range column_outgroup_Out9;
        Excel.Range column_outgroup_Out10;
        Excel.Range column_outgroup_Out11;
        Excel.Range column_outgroup_Out12;
        Excel.Range column_outgroup_Out13;
        Excel.Range column_outgroup_Out14;
        Excel.Range column_outgroup_Out15;
        Excel.Range column_outgroup_Out16;
        Excel.Range column_outgroup_Range;
        #endregion

        #region Broadcast
        Excel.Range column_broadArea_controlNo;
        Excel.Range column_broadArea_EmergIn;
        Excel.Range column_broadArea_Msg1;
        Excel.Range column_broadArea_Msg2;
        Excel.Range column_broadArea_Msg3;
        Excel.Range column_broadArea_Msg4;
        Excel.Range column_broadArea_FireFloor;
        Excel.Range column_broadArea_TopFloor;

        Excel.Range column_broadEmerg_controlNo;
        Excel.Range column_broadEmerg_EmergIn;
        Excel.Range column_broadEmerg_Msg1;
        Excel.Range column_broadEmerg_Msg2;
        Excel.Range column_broadEmerg_Msg3;
        Excel.Range column_broadEmerg_Msg4;
        Excel.Range column_broadEmerg_FireFloor;
        Excel.Range column_broadEmerg_TopFloor;

        Excel.Range column_broadArea_Range;
        Excel.Range column_broadEmerg_Range;
        #endregion

        string sDeviceSheet = "입출력명세서";
        string sInOutSheet = "연동 스위치";
        string sOutGroupSheet = "출력 그룹등록";
        string sBroadSheet = "경보출력제어";

        public void FileCreate(string filepath)
        {
            excelApp = new Excel.Application();
            excelApp.DisplayAlerts = false;//ture일 경우 메시지 발생.

            wb = excelApp.Workbooks.Add();//엑셀 기본 생성
            ws1 = wb.Worksheets.Add(Type.Missing, wb.Worksheets[1]); //기본 시트 후에 생성
            ws1.Name = sDeviceSheet;

            ws2 = wb.Worksheets.Add(Type.Missing, wb.Worksheets[2]); //기본 시트 후에 생성
            ws2.Name = sInOutSheet;

            ws3 = wb.Worksheets.Add(Type.Missing, wb.Worksheets[3]); //기본 시트 후에 생성
            ws3.Name = sOutGroupSheet;

            ws4 = wb.Worksheets.Add(Type.Missing, wb.Worksheets[4]); //기본 시트 후에 생성
            ws4.Name = sBroadSheet;

            Excel_Ranges();
            Excel_Form();
            Excel_Export();

            wb.SaveAs(filepath, Excel.XlFileFormat.xlOpenXMLWorkbook);

            wb.Close(true);
            excelApp.Quit();
        }
        private void Excel_Ranges()
        {
            Deivce_Ranges();
            InOut_Ranges();
            OutGroup_Ranges();
            Broadcast_Ranges();
        }
        private void Excel_Form()
        {
            Device_Form();
            InOut_Form();
            OutGroup_Form();
            Broadcast_Form();
        }
        private void Excel_Export()
        {
            Device_Export();
            InOut_Export();
            OutGroup_Export();
            Broadcast_Export();
        }
        public void Excel_Import(string filepath)
        {

            Global_Variable.oAlarmIn_Table.Clear();
            Global_Variable.oAlarmOut_Table.Clear();
            Global_Variable.oOutGroup_Table.Clear();

            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            wb = application.Workbooks.Open(filepath);

            //wb = excelApp.Workbooks.Open(filepath);
            ws1 = wb.Worksheets.get_Item(sDeviceSheet);
            ws2 = wb.Worksheets.get_Item(sInOutSheet);
            ws3 = wb.Worksheets.get_Item(sOutGroupSheet);
            ws4 = wb.Worksheets.get_Item(sBroadSheet);

            Excel_Ranges();

            Device_Import();
            InOut_Import();
            OutGroup_Import();
            Broadcast_Import();

            wb.Close(true);
            application.Quit();
        }
        private void Deivce_Ranges()
        {
            cell_DEVICE_ID = ws1.Cells[1, 1];
            cell_HMI_PHNUM = ws1.Cells[2, 1];
            cell_MY_CDMANUM = ws1.Cells[3, 1];

            cell_SMART_PHNUMS = ws1.Cells[5, 1];
            cell_SMART_PHNUM0 = ws1.Cells[6, 1];
            cell_SMART_PHNUM1 = ws1.Cells[7, 1];
            cell_SMART_PHNUM2 = ws1.Cells[8, 1];
            cell_SMART_PHNUM3 = ws1.Cells[9, 1];
            cell_SMART_PHNUM4 = ws1.Cells[10, 1];

            cell_SENSOR_BOARDS = ws1.Cells[12, 1];
            cell_RELAY_BOARDS = ws1.Cells[13, 1];
            cell_DISPLAY_BOARDS = ws1.Cells[14, 1];
            cell_ONOFF_BOARDS = ws1.Cells[15, 1];
            cell_AUTO_BOARDS = ws1.Cells[16, 1];
            //--------------------------------------------------
            cell_DEVICE_ID_value = ws1.Cells[1, 2];
            cell_HMI_PHNUM_value = ws1.Cells[2, 2];
            cell_MY_CDMANUM_value = ws1.Cells[3, 2];

            cell_SMART_PHNUMS_value = ws1.Cells[5, 2];
            cell_SMART_PHNUM0_value = ws1.Cells[6, 2];
            cell_SMART_PHNUM1_value = ws1.Cells[7, 2];
            cell_SMART_PHNUM2_value = ws1.Cells[8, 2];
            cell_SMART_PHNUM3_value = ws1.Cells[9, 2];
            cell_SMART_PHNUM4_value = ws1.Cells[10, 2];

            cell_SENSOR_BOARDS_value = ws1.Cells[12, 2];
            cell_RELAY_BOARDS_value = ws1.Cells[13, 2];
            cell_DISPLAY_BOARDS_value = ws1.Cells[14, 2];
            cell_ONOFF_BOARDS_value = ws1.Cells[15, 2];
            cell_AUTO_BOARDS_value = ws1.Cells[16, 2];

            title_device_Range0 = ws1.Range[ws1.Cells[1, 1], ws1.Cells[3, 2]];
            title_device_Range1 = ws1.Range[ws1.Cells[5, 1], ws1.Cells[10, 2]];
            title_device_Range2 = ws1.Range[ws1.Cells[12, 1], ws1.Cells[16, 2]];
        }

        private void InOut_Ranges()
        {
            column_in_BoardNo = ws2.Cells[1, 1];
            column_in_Circuit = ws2.Cells[1, 2];
            column_in_Code = ws2.Cells[1, 3];
            column_in_msg1 = ws2.Cells[1, 4];
            column_in_msg2 = ws2.Cells[1, 5];
            column_in_msg3 = ws2.Cells[1, 6];
            column_in_msg4 = ws2.Cells[1, 7];
            column_in_control1 = ws2.Cells[1, 8];
            column_in_control2 = ws2.Cells[1, 9];

            column_out_BoardNo = ws2.Cells[1, 11];
            column_out_Circuit = ws2.Cells[1, 12];
            column_out_msg1 = ws2.Cells[1, 13];
            column_out_msg2 = ws2.Cells[1, 14];
            column_out_msg3 = ws2.Cells[1, 15];
            column_out_msg4 = ws2.Cells[1, 16];
            column_out_pushstop = ws2.Cells[1, 17];

            column_in_range = ws2.Range[ws2.Cells[1, 1], ws2.Cells[1, 9]];
            column_out_range = ws2.Range[ws2.Cells[1, 11], ws2.Cells[1, 17]];
        }

        private void OutGroup_Ranges()
        {
            column_outgroup_groupNo=ws3.Cells[1, 1];
            column_outgroup_groupName= ws3.Cells[1, 2];
            column_outgroup_Out1 = ws3.Cells[1, 3];
            column_outgroup_Out2 = ws3.Cells[1, 4];
            column_outgroup_Out3 = ws3.Cells[1, 5];
            column_outgroup_Out4 = ws3.Cells[1, 6];
            column_outgroup_Out5 = ws3.Cells[1, 7];
            column_outgroup_Out6 = ws3.Cells[1, 8];
            column_outgroup_Out7 = ws3.Cells[1, 9];
            column_outgroup_Out8 = ws3.Cells[1, 10];
            column_outgroup_Out9 = ws3.Cells[1, 11];
            column_outgroup_Out10 = ws3.Cells[1, 12];
            column_outgroup_Out11 = ws3.Cells[1, 13];
            column_outgroup_Out12 = ws3.Cells[1, 14];
            column_outgroup_Out13 = ws3.Cells[1, 15];
            column_outgroup_Out14 = ws3.Cells[1, 16];
            column_outgroup_Out15 = ws3.Cells[1, 17];
            column_outgroup_Out16 = ws3.Cells[1, 18];
            column_outgroup_Range=ws3.Range[ws3.Cells[1, 1], ws3.Cells[1, 18]];
        }

        private void Broadcast_Ranges()
        {
            column_broadArea_controlNo = ws4.Cells[1, 1];
            column_broadArea_EmergIn = ws4.Cells[1, 2];
            column_broadArea_Msg1 = ws4.Cells[1, 3];
            column_broadArea_Msg2 = ws4.Cells[1, 4];
            column_broadArea_Msg3 = ws4.Cells[1, 5];
            column_broadArea_Msg4 = ws4.Cells[1, 6];
            column_broadArea_FireFloor = ws4.Cells[1, 7];
            column_broadArea_TopFloor = ws4.Cells[1, 8];

            column_broadEmerg_controlNo = ws4.Cells[1, 10];
            column_broadEmerg_EmergIn = ws4.Cells[1, 11];
            column_broadEmerg_Msg1 = ws4.Cells[1, 12];
            column_broadEmerg_Msg2 = ws4.Cells[1, 13];
            column_broadEmerg_Msg3 = ws4.Cells[1, 14];
            column_broadEmerg_Msg4 = ws4.Cells[1, 15];
            column_broadEmerg_FireFloor = ws4.Cells[1, 16];
            column_broadEmerg_TopFloor = ws4.Cells[1, 17];

            column_broadArea_Range = ws4.Range[ws4.Cells[1, 1], ws4.Cells[1, 8]];
            column_broadEmerg_Range = ws4.Range[ws4.Cells[1, 10], ws4.Cells[1, 17]];

        }

        private void Device_Form()
        {
            cell_DEVICE_ID.Value = "Device ID";
            cell_HMI_PHNUM.Value = "HMI 폰번호";
            cell_MY_CDMANUM.Value = "My CDMA 폰번호";
            cell_SMART_PHNUMS.Value = "스마트폰 번호 카운트";
            cell_SMART_PHNUM0.Value = "스마트폰 번호1";
            cell_SMART_PHNUM1.Value = "스마트폰 번호2";
            cell_SMART_PHNUM2.Value = "스마트폰 번호3";
            cell_SMART_PHNUM3.Value = "스마트폰 번호4";
            cell_SMART_PHNUM4.Value = "스마트폰 번호5";
            cell_SENSOR_BOARDS.Value = "센서보드 수량";
            cell_RELAY_BOARDS.Value = "릴레이보드 수량";
            cell_DISPLAY_BOARDS.Value = "디스플레이 보드 수량";
            cell_ONOFF_BOARDS.Value = "온오프보드 수량";
            cell_AUTO_BOARDS.Value = "자동보드 수량";

            cell_DEVICE_ID.ColumnWidth = 20;
            cell_DEVICE_ID_value.ColumnWidth = 20;

            title_device_Range0.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
            title_device_Range1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
            title_device_Range2.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
        }

        private void InOut_Form()
        {
            column_in_BoardNo.Value = "보드번호";
            column_in_Circuit.Value = "회로";
            column_in_Code.Value = "회로";
            column_in_msg1.Value = "메세지1";
            column_in_msg2.Value = "메세지2";
            column_in_msg3.Value = "메세지3";
            column_in_msg4.Value = "메세지4";
            column_in_control1.Value = "층화재제어";
            column_in_control2.Value = "설비제어";

            column_out_BoardNo.Value = "보드번호";
            column_out_Circuit.Value = "회로";
            column_out_msg1.Value = "메세지1";
            column_out_msg2.Value = "메세지2";
            column_out_msg3.Value = "메세지3";
            column_out_msg4.Value = "메세지4";
            column_out_pushstop.Value = "설비제어";

            column_in_range.ColumnWidth = 10;
            column_out_range.ColumnWidth = 10;
            column_in_range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
            column_out_range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
        }

        private void OutGroup_Form()
        {
            column_outgroup_groupNo.Value = "그룹번호";
            column_outgroup_groupName.Value = "그룹명";
            column_outgroup_Out1.Value = "출력1";
            column_outgroup_Out2.Value = "출력2";
            column_outgroup_Out3.Value = "출력3";
            column_outgroup_Out4.Value = "출력4";
            column_outgroup_Out5.Value = "출력5";
            column_outgroup_Out6.Value = "출력6";
            column_outgroup_Out7.Value = "출력7";
            column_outgroup_Out8.Value = "출력8";
            column_outgroup_Out9.Value = "출력9";
            column_outgroup_Out10.Value = "출력10";
            column_outgroup_Out11.Value = "출력11";
            column_outgroup_Out12.Value = "출력12";
            column_outgroup_Out13.Value = "출력13";
            column_outgroup_Out14.Value = "출력14";
            column_outgroup_Out15.Value = "출력15";
            column_outgroup_Out16.Value = "출력16";

            column_outgroup_Range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
        }

        private void Broadcast_Form()
        {
            column_broadArea_controlNo.Value = "제어번호";
            column_broadArea_EmergIn.Value = "경보입력";
            column_broadArea_Msg1.Value = "메세지1";
            column_broadArea_Msg2.Value = "메세지2";
            column_broadArea_Msg3.Value = "메세지3";
            column_broadArea_Msg4.Value = "메세지4";
            column_broadArea_FireFloor.Value = "화재층제어";
            column_broadArea_TopFloor.Value = "직상층제어";

            column_broadEmerg_controlNo.Value = "제어번호";
            column_broadEmerg_EmergIn.Value = "경보입력";
            column_broadEmerg_Msg1.Value = "메세지1";
            column_broadEmerg_Msg2.Value = "메세지2";
            column_broadEmerg_Msg3.Value = "메세지3";
            column_broadEmerg_Msg4.Value = "메세지4";
            column_broadEmerg_FireFloor.Value = "화재층제어";
            column_broadEmerg_TopFloor.Value = "직상층제어";

            column_broadArea_Range.ColumnWidth = 10;
            column_broadEmerg_Range.ColumnWidth = 10;
            column_broadArea_Range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
            column_broadEmerg_Range.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.WhiteSmoke);
        }

        private void Device_Export()
        {
            cell_DEVICE_ID_value.Value = Global_Variable.oP2000_Data.DEVICE_ID;
            cell_HMI_PHNUM_value.Value = Global_Variable.oP2000_Data.HMI_PHNUM;
            cell_MY_CDMANUM_value.Value = Global_Variable.oP2000_Data.MY_CDMANUM;
            cell_SMART_PHNUMS_value.Value = Global_Variable.oP2000_Data.SMART_PHNUMS;
            cell_SMART_PHNUM0_value.Value = Global_Variable.oP2000_Data.SMART_PHNUM0;
            cell_SMART_PHNUM1_value.Value = Global_Variable.oP2000_Data.SMART_PHNUM1;
            cell_SMART_PHNUM2_value.Value = Global_Variable.oP2000_Data.SMART_PHNUM2;
            cell_SMART_PHNUM3_value.Value = Global_Variable.oP2000_Data.SMART_PHNUM3;
            cell_SMART_PHNUM4_value.Value = Global_Variable.oP2000_Data.SMART_PHNUM4;
            cell_SENSOR_BOARDS_value.Value = Global_Variable.oP2000_Data.SENSOR_BOARDS;
            cell_RELAY_BOARDS_value.Value = Global_Variable.oP2000_Data.RELAY_BOARDS;
            cell_DISPLAY_BOARDS_value.Value = Global_Variable.oP2000_Data.DISPLAY_BOARDS;
            cell_ONOFF_BOARDS_value.Value = Global_Variable.oP2000_Data.ONOFF_BOARDS;
            cell_AUTO_BOARDS_value.Value = Global_Variable.oP2000_Data.AUTO_BOARDS;
        }

        private void InOut_Export()
        {
            int in_cnt = 1;
            int out_cnt = 1;

            foreach (Alarm_In item in Global_Variable.oAlarmIn_Table)
            {
                in_cnt++;
                ws2.Cells[in_cnt, 1].Value = item.mBoardNo;
                ws2.Cells[in_cnt, 2].Value = item.mCircuit;
                ws2.Cells[in_cnt, 3].Value = item.mCode;
                ws2.Cells[in_cnt, 4].Value = item.mMassage1;
                ws2.Cells[in_cnt, 5].Value = item.mMassage2;
                ws2.Cells[in_cnt, 6].Value = item.mMassage3;
                ws2.Cells[in_cnt, 7].Value = item.mMassage4;
                ws2.Cells[in_cnt, 8].Value = item.mControl1;
                ws2.Cells[in_cnt, 9].Value = item.mControl2;
            }

            foreach (Alarm_Out item in Global_Variable.oAlarmOut_Table)
            {
                out_cnt++;
                ws2.Cells[out_cnt, 11].Value = item.mBoardNo;
                ws2.Cells[out_cnt, 12].Value = item.mCircuit;
                ws2.Cells[out_cnt, 13].Value = item.mMassage1;
                ws2.Cells[out_cnt, 14].Value = item.mMassage2;
                ws2.Cells[out_cnt, 15].Value = item.mMassage3;
                ws2.Cells[out_cnt, 16].Value = item.mMassage4;
                ws2.Cells[out_cnt, 17].Value = item.mPushStop;
            }

        }

        private void OutGroup_Export()
        {
            int outgroup_cnd = 1;
            foreach (OutGroup item in Global_Variable.oOutGroup_Table)
            {
                outgroup_cnd++;
                ws3.Cells[outgroup_cnd, 1].Value = item.mGroupNo;
                ws3.Cells[outgroup_cnd, 2].Value = item.mGroupName;
                ws3.Cells[outgroup_cnd, 3].Value = item.mOutput1;
                ws3.Cells[outgroup_cnd, 4].Value = item.mOutput2;
                ws3.Cells[outgroup_cnd, 5].Value = item.mOutput3;
                ws3.Cells[outgroup_cnd, 6].Value = item.mOutput4;
                ws3.Cells[outgroup_cnd, 7].Value = item.mOutput5;
                ws3.Cells[outgroup_cnd, 8].Value = item.mOutput6;
                ws3.Cells[outgroup_cnd, 9].Value = item.mOutput7;
                ws3.Cells[outgroup_cnd, 10].Value = item.mOutput8;
                ws3.Cells[outgroup_cnd, 11].Value = item.mOutput9;
                ws3.Cells[outgroup_cnd, 12].Value = item.mOutput10;
                ws3.Cells[outgroup_cnd, 13].Value = item.mOutput11;
                ws3.Cells[outgroup_cnd, 14].Value = item.mOutput12;
                ws3.Cells[outgroup_cnd, 15].Value = item.mOutput13;
                ws3.Cells[outgroup_cnd, 16].Value = item.mOutput14;
                ws3.Cells[outgroup_cnd, 17].Value = item.mOutput15;
                ws3.Cells[outgroup_cnd, 18].Value = item.mOutput16;

            }
        }

        private void Broadcast_Export()
        {
            int in_cnt = 1;
            int out_cnt = 1;

            foreach (AreaAlarm item in Global_Variable.oAreaAlarm_Table)
            {
                in_cnt++;
                ws4.Cells[in_cnt, 1].Value = item.mControlNo;
                ws4.Cells[in_cnt, 2].Value = item.mEmerg_input;
                ws4.Cells[in_cnt, 3].Value = item.mMassage1;
                ws4.Cells[in_cnt, 4].Value = item.mMassage2;
                ws4.Cells[in_cnt, 5].Value = item.mMassage3;
                ws4.Cells[in_cnt, 6].Value = item.mMassage4;
                ws4.Cells[in_cnt, 7].Value = item.mFireFloor;
                ws4.Cells[in_cnt, 8].Value = item.mTopFloor;
            }

            foreach (EmergencyAlarm item in Global_Variable.oEmergencyAlarm_Table)
            {
                out_cnt++;
                ws4.Cells[out_cnt, 10].Value = item.mControlNo;
                ws4.Cells[out_cnt, 11].Value = item.mEmerg_input;
                ws4.Cells[out_cnt, 12].Value = item.mMassage1;
                ws4.Cells[out_cnt, 13].Value = item.mMassage2;
                ws4.Cells[out_cnt, 14].Value = item.mMassage3;
                ws4.Cells[out_cnt, 15].Value = item.mMassage4;
                ws4.Cells[out_cnt, 16].Value = item.mFireFloor;
                ws4.Cells[out_cnt, 17].Value = item.mTopFloor;
            }

        }

        private void Device_Import()
        {
            Global_Variable.oP2000_Data.DEVICE_ID = Convert.ToString(cell_DEVICE_ID_value.Value);
            Global_Variable.oP2000_Data.HMI_PHNUM = Convert.ToString(cell_HMI_PHNUM_value.Value);
            Global_Variable.oP2000_Data.MY_CDMANUM = Convert.ToString(cell_MY_CDMANUM_value.Value);
            Global_Variable.oP2000_Data.SMART_PHNUMS = Convert.ToString(cell_SMART_PHNUMS_value.Value);
            Global_Variable.oP2000_Data.SMART_PHNUM0 = Convert.ToString(cell_SMART_PHNUM0_value.Value);
            Global_Variable.oP2000_Data.SMART_PHNUM1 = Convert.ToString(cell_SMART_PHNUM1_value.Value);
            Global_Variable.oP2000_Data.SMART_PHNUM2 = Convert.ToString(cell_SMART_PHNUM2_value.Value);
            Global_Variable.oP2000_Data.SMART_PHNUM3 = Convert.ToString(cell_SMART_PHNUM3_value.Value);
            Global_Variable.oP2000_Data.SMART_PHNUM4 = Convert.ToString(cell_SMART_PHNUM4_value.Value);
            Global_Variable.oP2000_Data.SENSOR_BOARDS = Convert.ToString(cell_SENSOR_BOARDS_value.Value);
            Global_Variable.oP2000_Data.RELAY_BOARDS = Convert.ToString(cell_RELAY_BOARDS_value.Value);
            Global_Variable.oP2000_Data.DISPLAY_BOARDS = Convert.ToString(cell_DISPLAY_BOARDS_value.Value);
            Global_Variable.oP2000_Data.ONOFF_BOARDS = Convert.ToString(cell_ONOFF_BOARDS_value.Value);
            Global_Variable.oP2000_Data.AUTO_BOARDS = Convert.ToString(cell_AUTO_BOARDS_value.Value);
        }

        private void InOut_Import()
        {
            for (int i = 2; i < 1000; i++)
            {
                if(ws2.Cells[i, 1].Value!= null)
                {
                    Alarm_In alarm_In = new Alarm_In();
                    alarm_In.mBoardNo = Convert.ToString(ws2.Cells[i, 1].Value);
                    alarm_In.mCircuit = Convert.ToString(ws2.Cells[i, 2].Value);
                    alarm_In.mCode = Convert.ToString(ws2.Cells[i, 3].Value);
                    alarm_In.mMassage1 = Convert.ToString(ws2.Cells[i, 4].Value);
                    alarm_In.mMassage2 = Convert.ToString(ws2.Cells[i, 5].Value);
                    alarm_In.mMassage3 = Convert.ToString(ws2.Cells[i, 6].Value);
                    alarm_In.mMassage4 = Convert.ToString(ws2.Cells[i, 7].Value);
                    alarm_In.mControl1 = Convert.ToString(ws2.Cells[i, 8].Value);
                    alarm_In.mControl2 = Convert.ToString(ws2.Cells[i, 9].Value);
                    Global_Variable.oAlarmIn_Table.Add(alarm_In);
                }
                else
                {
                    break;
                }
            }

            for (int i = 2; i < 1000; i++)
            {
                if (ws2.Cells[i, 11].Value != null)
                {
                    Alarm_Out alarm_Out = new Alarm_Out();
                    alarm_Out.mBoardNo = Convert.ToString(ws2.Cells[i, 11].Value);
                    alarm_Out.mCircuit = Convert.ToString(ws2.Cells[i, 12].Value);
                    alarm_Out.mMassage1 = Convert.ToString(ws2.Cells[i, 13].Value);
                    alarm_Out.mMassage2 = Convert.ToString(ws2.Cells[i, 14].Value);
                    alarm_Out.mMassage3 = Convert.ToString(ws2.Cells[i, 15].Value);
                    alarm_Out.mMassage4 = Convert.ToString(ws2.Cells[i, 16].Value);
                    alarm_Out.mPushStop = Convert.ToString(ws2.Cells[i, 17].Value);
                    Global_Variable.oAlarmOut_Table.Add(alarm_Out);
                }
                else
                {
                    break;
                }
            }
        }

        private void OutGroup_Import()
        {
            for (int i = 2; i < 1000; i++)
            {
                if (ws3.Cells[i, 1].Value != null)
                {
                    OutGroup outGroup = new OutGroup();
                    outGroup.mGroupNo = Convert.ToString(ws3.Cells[i, 1].Value);
                    outGroup.mGroupName = Convert.ToString(ws3.Cells[i, 2].Value);
                    outGroup.mOutput1 = Convert.ToString(ws3.Cells[i, 3].Value);
                    outGroup.mOutput2 = Convert.ToString(ws3.Cells[i, 4].Value);
                    outGroup.mOutput3 = Convert.ToString(ws3.Cells[i, 5].Value);
                    outGroup.mOutput4 = Convert.ToString(ws3.Cells[i, 6].Value);
                    outGroup.mOutput5 = Convert.ToString(ws3.Cells[i, 7].Value);
                    outGroup.mOutput6 = Convert.ToString(ws3.Cells[i, 8].Value);
                    outGroup.mOutput7 = Convert.ToString(ws3.Cells[i, 9].Value);
                    outGroup.mOutput8 = Convert.ToString(ws3.Cells[i, 10].Value);
                    outGroup.mOutput9 = Convert.ToString(ws3.Cells[i, 11].Value);
                    outGroup.mOutput10 = Convert.ToString(ws3.Cells[i, 12].Value);
                    outGroup.mOutput11 = Convert.ToString(ws3.Cells[i, 13].Value);
                    outGroup.mOutput12 = Convert.ToString(ws3.Cells[i, 14].Value);
                    outGroup.mOutput13 = Convert.ToString(ws3.Cells[i, 15].Value);
                    outGroup.mOutput14 = Convert.ToString(ws3.Cells[i, 16].Value);
                    outGroup.mOutput15 = Convert.ToString(ws3.Cells[i, 17].Value);
                    outGroup.mOutput16 = Convert.ToString(ws3.Cells[i, 18].Value);
                    Global_Variable.oOutGroup_Table.Add(outGroup);
                }
                else
                {
                    break;
                }
            }
        }

        private void Broadcast_Import()
        {
            for (int i = 2; i < 1000; i++)
            {
                if (ws4.Cells[i, 1].Value != null)
                {
                    AreaAlarm areaAlarm = new AreaAlarm();
                    areaAlarm.mControlNo = Convert.ToString(ws4.Cells[i, 1].Value);
                    areaAlarm.mEmerg_input = Convert.ToString(ws4.Cells[i, 2].Value);
                    areaAlarm.mMassage1 = Convert.ToString(ws4.Cells[i, 3].Value);
                    areaAlarm.mMassage2 = Convert.ToString(ws4.Cells[i, 4].Value);
                    areaAlarm.mMassage3 = Convert.ToString(ws4.Cells[i, 5].Value);
                    areaAlarm.mMassage4 = Convert.ToString(ws4.Cells[i, 6].Value);
                    areaAlarm.mFireFloor = Convert.ToString(ws4.Cells[i, 7].Value);
                    areaAlarm.mTopFloor = Convert.ToString(ws4.Cells[i, 8].Value);
                    Global_Variable.oAreaAlarm_Table.Add(areaAlarm);
                }
                else
                {
                    break;
                }
            }

            for (int i = 2; i < 1000; i++)
            {
                if (ws2.Cells[i, 11].Value != null)
                {
                    EmergencyAlarm emergencyAlarm = new EmergencyAlarm();
                    emergencyAlarm.mControlNo = Convert.ToString(ws4.Cells[i, 10].Value);
                    emergencyAlarm.mEmerg_input = Convert.ToString(ws4.Cells[i, 11].Value);
                    emergencyAlarm.mMassage1 = Convert.ToString(ws4.Cells[i, 12].Value);
                    emergencyAlarm.mMassage2 = Convert.ToString(ws4.Cells[i, 13].Value);
                    emergencyAlarm.mMassage3 = Convert.ToString(ws4.Cells[i, 14].Value);
                    emergencyAlarm.mMassage4 = Convert.ToString(ws4.Cells[i, 15].Value);
                    emergencyAlarm.mFireFloor = Convert.ToString(ws4.Cells[i, 16].Value);
                    emergencyAlarm.mTopFloor = Convert.ToString(ws4.Cells[i, 17].Value);
                    Global_Variable.oEmergencyAlarm_Table.Add(emergencyAlarm);
                }
                else
                {
                    break;
                }
            }
        }
    }

}

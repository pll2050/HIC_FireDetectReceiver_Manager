using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HIC_FireDetectReceiver_Manager
{
    public class Alarm_In_Table : ObservableCollection<Alarm_In> { }
    public class Alarm_Out_Table : ObservableCollection<Alarm_Out> { }
    public class Alarm_In : INotifyPropertyChanged, IEditableObject
    {
        private string _BoardNo;
        private string _Circuit;
        private string _Code;
        private string _Massage1;
        private string _Massage2;
        private string _Massage3;
        private string _Massage4;
        private string _Control1;
        private string _Control2;

        public string mBoardNo
        {
            get { return _BoardNo; }
            set { _BoardNo = value; }
        }
        public string mCircuit
        {
            get { return _Circuit; }
            set { _Circuit = value; }
        }
        public string mCode
        {
            get { return _Code; }
            set { _Code = value; }
        }
        public string mMassage1
        {
            get { return _Massage1; }
            set { _Massage1 = value; }
        }
        public string mMassage2
        {
            get { return _Massage2; }
            set { _Massage2 = value; }
        }
        public string mMassage3
        {
            get { return _Massage3; }
            set { _Massage3 = value; }
        }
        public string mMassage4
        {
            get { return _Massage4; }
            set { _Massage4 = value; }
        }
        public string mControl1
        {
            get { return _Control1; }
            set { _Control1 = value; }
        }
        public string mControl2
        {
            get { return _Control2; }
            set { _Control2 = value; }
        }
        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;

        // Data for undoing canceled edits.
        private Alarm_In temp_Task = null;
        private bool m_Editing = false;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Implement IEditableObject interface.
        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Task = this.MemberwiseClone() as Alarm_In;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this._BoardNo = temp_Task.mBoardNo;
                this._Circuit = temp_Task.mCircuit;
                this._Code = temp_Task.mCode;
                this._Massage1 = temp_Task._Massage1;
                this._Massage2 = temp_Task._Massage2;
                this._Massage3 = temp_Task._Massage3;
                this._Massage4 = temp_Task._Massage4;
                this._Control1 = temp_Task._Control1;
                this._Control2 = temp_Task._Control2;
                m_Editing = false;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                temp_Task = null;
                m_Editing = false;
            }
        }
    }

    public class Alarm_Out : INotifyPropertyChanged, IEditableObject
    {
        private string _BoardNo;
        private string _Circuit;
        private string _Massage1;
        private string _Massage2;
        private string _Massage3;
        private string _Massage4;
        private string _PushStop;

        public string mBoardNo
        {
            get { return _BoardNo; }
            set { _BoardNo = value; }
        }
        public string mCircuit
        {
            get { return _Circuit; }
            set { _Circuit = value; }
        }

        public string mMassage1
        {
            get { return _Massage1; }
            set { _Massage1 = value; }
        }
        public string mMassage2
        {
            get { return _Massage2; }
            set { _Massage2 = value; }
        }
        public string mMassage3
        {
            get { return _Massage3; }
            set { _Massage3 = value; }
        }
        public string mMassage4
        {
            get { return _Massage4; }
            set { _Massage4 = value; }
        }
        public string mPushStop
        {
            get { return _PushStop; }
            set { _PushStop = value; }
        }

        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;

        // Data for undoing canceled edits.
        private Alarm_Out temp_Task = null;
        private bool m_Editing = false;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // Implement IEditableObject interface.
        public void BeginEdit()
        {
            if (m_Editing == false)
            {
                temp_Task = this.MemberwiseClone() as Alarm_Out;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this._BoardNo = temp_Task.mBoardNo;
                this._Circuit = temp_Task.mCircuit;
                this._Massage1 = temp_Task._Massage1;
                this._Massage2 = temp_Task._Massage2;
                this._Massage3 = temp_Task._Massage3;
                this._Massage4 = temp_Task._Massage4;
                this._PushStop = temp_Task._PushStop;
                m_Editing = false;
            }
        }

        public void EndEdit()
        {
            if (m_Editing == true)
            {
                temp_Task = null;
                m_Editing = false;
            }
        }

    }
}

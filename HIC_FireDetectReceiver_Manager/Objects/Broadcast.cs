using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HIC_FireDetectReceiver_Manager
{
    public class AreaAlarm_Table : ObservableCollection<AreaAlarm> { }
    public class EmergencyAlarm_Table : ObservableCollection<EmergencyAlarm> { }
    public class AreaAlarm
    {
        private string _ControlNo;
        private string _Emerg_input;
        private string _Massage1;
        private string _Massage2;
        private string _Massage3;
        private string _Massage4;
        private string _FireFloor;
        private string _TopFloor;

        public string mControlNo
        {
            get { return _ControlNo; }
            set { _ControlNo = value; }
        }
        public string mEmerg_input
        {
            get { return _Emerg_input; }
            set { _Emerg_input = value; }
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
        public string mFireFloor
        {
            get { return _FireFloor; }
            set { _FireFloor = value; }
        }
        public string mTopFloor
        {
            get { return _TopFloor; }
            set { _TopFloor = value; }
        }

        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;

        // Data for undoing canceled edits.
        private AreaAlarm temp_Task = null;
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
                temp_Task = this.MemberwiseClone() as AreaAlarm;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this._ControlNo = temp_Task._ControlNo;
                this._Emerg_input = temp_Task._Emerg_input;
                this._Massage1 = temp_Task._Massage1;
                this._Massage2 = temp_Task._Massage2;
                this._Massage3 = temp_Task._Massage3;
                this._Massage4 = temp_Task._Massage4;
                this._FireFloor = temp_Task._FireFloor;
                this._TopFloor= temp_Task._TopFloor;
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
    public class EmergencyAlarm
    {
        private string _ControlNo;
        private string _Emerg_input;
        private string _Massage1;
        private string _Massage2;
        private string _Massage3;
        private string _Massage4;
        private string _FireFloor;
        private string _TopFloor;

        public string mControlNo
        {
            get { return _ControlNo; }
            set { _ControlNo = value; }
        }
        public string mEmerg_input
        {
            get { return _Emerg_input; }
            set { _Emerg_input = value; }
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
        public string mFireFloor
        {
            get { return _FireFloor; }
            set { _FireFloor = value; }
        }
        public string mTopFloor
        {
            get { return _TopFloor; }
            set { _TopFloor = value; }
        }
        // Implement INotifyPropertyChanged interface.
        public event PropertyChangedEventHandler PropertyChanged;

        // Data for undoing canceled edits.
        private EmergencyAlarm temp_Task = null;
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
                temp_Task = this.MemberwiseClone() as EmergencyAlarm;
                m_Editing = true;
            }
        }

        public void CancelEdit()
        {
            if (m_Editing == true)
            {
                this._ControlNo = temp_Task._ControlNo;
                this._Emerg_input = temp_Task._Emerg_input;
                this._Massage1 = temp_Task._Massage1;
                this._Massage2 = temp_Task._Massage2;
                this._Massage3 = temp_Task._Massage3;
                this._Massage4 = temp_Task._Massage4;
                this._FireFloor = temp_Task._FireFloor;
                this._TopFloor = temp_Task._TopFloor;
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

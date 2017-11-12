using System;
using System.ComponentModel;

namespace VMLibrary
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _custName;
        private string _add1;
        private string _add2;
        private string _city;
        private string _zip;
        private string _phone;

        public string CustName {
        get { return _custName; }
            set {
                _custName = value;
                TextBoxCustNameChanged("CustName");
            }
        }
        public string Add1
        {
            get { return _add1; }
            set
            {
                _add1 = value;
                TextBoxAdd1Changed("Add1");
            }
        }
        public string Add2
        {
            get { return _add2; }
            set
            {
                _add2 = value;
                TextBoxAdd2Changed("Add2");
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                TextBoxCityChanged("City");
            }
        }
        public string ZipCode
        {
            get { return _zip; }
            set
            {
                _zip = value;
                TextBoxZipChanged("ZipCode");
            }
        }

        public string PhoneNum
        {
            get { return _phone; }
            set
            {
                _phone = value;
                TextBoxPhoneNumChanged("PhoneNum");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TextBoxCustNameChanged(string EventArgs)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(EventArgs));
        }
        private void TextBoxAdd1Changed(string EventArgs)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(EventArgs));
        }
        private void TextBoxAdd2Changed(string EventArgs)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(EventArgs));
        }
        private void TextBoxCityChanged(string EventArgs)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(EventArgs));
        }
        private void TextBoxZipChanged(string EventArgs)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(EventArgs));
        }
        private void TextBoxPhoneNumChanged(string EventArgs)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(EventArgs));
        }

    }
}

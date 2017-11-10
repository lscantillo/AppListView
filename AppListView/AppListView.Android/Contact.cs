using System;
using System.ComponentModel;

namespace AppListView
{
    public class Contact: INotifyPropertyChanged
    {
        public string uid;
        public string fullName;
        public string name;

        public Contact(String fullName, String name)
        {
            FullName = fullName;
            Name = name;
            Uid = "";
          
        }

        public String Uid
        {
            set {
                if(uid!=value)
                {
                    uid = value;
                    if (PropertyChanged!= null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Uid"));

                    }

                }

            }

            get
            {
                return uid;
            }

        }

        public String FullName
        {
            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("FullName"));

                    }

                }

            }

            get
            {
                return fullName;
            }

        }

        public String Name
        {
            set
            {
                if (name != value)
                {
                    name = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Name"));

                    }

                }

            }

            get
            {
                return name;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
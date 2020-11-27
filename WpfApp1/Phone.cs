using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Phone : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }

        private string _surname;
        public string SurName
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }

        private string _phone;
        public string Phon
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullInfo));
                }
            }
        }

        public string FullInfo => $"{Name}; {SurName}; {Age}; {Phon}";
        public override string ToString()
        {
            return Name + " ; " + SurName + " ; " + Age + " ; " + Phon;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using _00_Start.Models;
using _00_Start;

namespace _00_Start.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged //using System.ComponentModel;
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string PropertyName = null) // CallerMemberName <- using System.Runtime.CompilerServices;
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private int num1;
        public int Num1 
        {
            get => num1;
            set
            {
                num1 = value;
                OnPropertyChanged();
            }
        }

        private int num2;
        public int Num2
        {
            get => num2;
            set
            {
                num2 = value;
                OnPropertyChanged();
            }
        }

        private int num3;
        public int Num3
        {
            get => num3;
            set
            {
                num3 = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p)
        {
            Num3 = Arihp.Add(Num1, Num2);
        }
        private bool CanAddCommandExecuted(object p)
        {
            if (Num1 != 0 || Num2 != 0)
            {
                return true;
            }
            return false;
        }
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }
    }
}

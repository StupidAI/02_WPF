using _01_CircleLenght.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _01_CircleLenght.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged //using System.ComponentModel;
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null) // CallerMemberName <- using System.Runtime.CompilerServices;
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

        private double num2;
        public double Num2
        {
            get => num2;
            set
            {
                num2 = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p)
        {
            Num2 = MyMath.CircleLength(Num1);
        }
        private bool CanAddCommandExecuted(object p)
        {
            if (Num1 >= 0)
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

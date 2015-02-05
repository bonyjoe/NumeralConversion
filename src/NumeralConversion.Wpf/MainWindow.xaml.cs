using NumeralConversion.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NumeralConversion.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Int32 _currentValue;
        private String _currentNumeral;
        private Random _rand = new Random();

        public Int32 CurrentValue
        {
            get { return _currentValue; }
            set
            {
                _currentValue = value;
                RaisePropertyChanged();
            }
        }

        public String CurrentNumeral
        {
            get { return _currentNumeral; }
            set
            {
                _currentNumeral = value;
                RaisePropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadRandomNumeral();
        }

        private void LoadRandomNumeral()
        {
            CurrentValue = _rand.Next(5000);
            CurrentNumeral = NumeralConverter.ConvertToNumerals(CurrentValue);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadRandomNumeral();
        }

        #region INotifyPropertyChanged Implementation
        private void RaisePropertyChanged([CallerMemberName]String propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged; 

        #endregion
    }
}

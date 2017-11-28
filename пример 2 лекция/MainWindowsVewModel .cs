using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace пример_2_лекция
{
    class MainWindowsVewModel: INotifyPropertyChanged
    {
        public int Pricemin { get; set; }
        public int Pricemax { get; set; }

        public int Areamin { get; set; }
        public int Areamax { get; set; }

        public Dictionary<string,Color> Metro { get; set; }

        private KeyValuePair<string, Color> _selectedMetro;
        public KeyValuePair<string,Color> selectedMetro
        {
            get { return _selectedMetro; }
            set
            {
                _selectedMetro = value;
                DoPropertyChanged("selectedMetro");
            }
        }

        private Brush _lineColor;
        public Brush selectedLineColor

        {
            get {return _lineColor; }
            set { _lineColor = value;
                DoPropertyChanged("selectedLineColor");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(string Name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
            }
        }

        public ObservableCollection<FlatViewModel> flats { get; set; }

        public ICommand Filter { get; set; }

        public MainWindowsVewModel()
        {
            FillStation();
            FillFlats();
            Filter = new Command();
        }
        private void FillStation()
        {

            Metro = new Dictionary<string, Color>();
            Metro.Add("Академическая", Colors.Orange);
            Metro.Add("Шаболовская", Colors.Orange);
            Metro.Add("Китай-город", Colors.Orange);
            Metro.Add("Новокузнецкая", Colors.Green);
            Metro.Add("Театральная", Colors.Green);
        }
        private void FillFlats()

        {
            flats = new ObservableCollection<FlatViewModel>();
            flats.Add(new FlatViewModel()
            {
                adress = "Дом № 7",
                area = 70,
                metro = "Театральная",
                price = 7000

            });
            flats.Add(new FlatViewModel()
            {
                adress = "Дом № 666",
                area = 10,
                metro = "Театральная",
                price = 1000

            });
            flats.Add(new FlatViewModel()
            {
                adress = "Красивая",
                area = 40,
                metro = "Академическая",
                price = 1500

            });

        }
    }
   
}

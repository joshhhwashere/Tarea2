using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnologicoApp.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private readonly CalculatorService _calculatorService;

        private double _result;
        public double Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        public CalculatorViewModel(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public void PerformCalculation(double a, double b, string operation)
        {
            switch (operation)
            {
                case "Add":
                    Result = _calculatorService.Add(a, b);
                    break;
                case "Subtract":
                    Result = _calculatorService.Subtract(a, b);
                    break;
                case "Multiply":
                    Result = _calculatorService.Multiply(a, b);
                    break;
                case "Divide":
                    Result = _calculatorService.Divide(a, b);
                    break;
                default:
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
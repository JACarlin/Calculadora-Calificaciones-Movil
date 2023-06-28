using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDMPW_411_3P_Ex.MVVM.Models;

namespace TDMPW_411_3P_Ex.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class SemestreViewModel
    {
        public Semestre Semestre { get; set; }
        private ObservableCollection<string> _opciones;
        public ObservableCollection<string> Opciones
        {
            get { return _opciones; }
            set
            {
                if (_opciones != value)
                {
                    _opciones = value;

                }
            }
        }
        private string selectedStepString;
        public string SelectedStepString
        {
            get => selectedStepString;
            set
            {
                selectedStepString = value;
                updateSteppers();
            }
        }
        private int step;
        public int Step
        {
            get => step;
            set
            {
                step = value;

                updateSteppers();
            }
        }
        public ICommand ClickCommand { get; }

        public SemestreViewModel()
        {
            Opciones = new ObservableCollection<string>
            {
                "1",
                "5"
               ,"10"
            };
            
            Semestre = new Semestre()
            {
                FinalGrade6 = 0,
                FinalGrade10 = 0
            };
            SelectedStepString = Opciones[1];
            ClickCommand = new Command(() =>
            {
                if (validatePercentage())
                {
                    calculateGrade();
                }
                else
                {
                    App.Current.MainPage.
                    DisplayAlert("Error", "Los porcentaje no completan el 100%", "OK");
                }

            }
           );
        }
        public bool validatePercentage()
        {
            double total = 0;
            total = Semestre.FirstPercentage + Semestre.SecondPercentage + Semestre.ThirdPercentage ; 
            if (total != 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void calculateGrade()
        {
            double primerPorcentaje = 0;
            double segundoPorcentajeMin = 0;
            double segundoPorcentajeMax = 0;
            primerPorcentaje = (Semestre.FirstGrade * Semestre.FirstPercentage/10) + (Semestre.SecondGrade * Semestre.SecondPercentage / 10);
            
            if (primerPorcentaje < 60)
            {
                segundoPorcentajeMin = 60 - primerPorcentaje;
                Semestre.FinalGrade6 = Math.Round((segundoPorcentajeMin * 10 / Semestre.ThirdPercentage),2);
                App.Current.MainPage.DisplayAlert("Para el 6", "Todavia se puede", "OK");
            }
            else
            {
                Semestre.FinalGrade6 = 0;
                App.Current.MainPage.DisplayAlert("Para el 6", "Puedes relajarte", "OK");
            }
            segundoPorcentajeMax = 95 - primerPorcentaje;
            if (segundoPorcentajeMax > Semestre.ThirdPercentage)
            {
                Semestre.FinalGrade10 = 0;
                App.Current.MainPage.DisplayAlert("Para el 10", "Talvez el 10 no es lo tuyo", "OK");
            }
            else
            {
                Semestre.FinalGrade10 = Math.Round((segundoPorcentajeMax * 10 / Semestre.ThirdPercentage), 2);
                App.Current.MainPage.DisplayAlert("Para el 10", "Se confia", "OK");
            }

        }
        public void updateSteppers()
        {
            Step = int.Parse(selectedStepString);
            Semestre.Step = Step;
            //App.Current.MainPage.DisplayAlert("COMMANDO","", "OK");

        }
    }
}

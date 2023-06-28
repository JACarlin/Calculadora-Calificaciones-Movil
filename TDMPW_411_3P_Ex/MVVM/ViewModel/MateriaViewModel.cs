using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDMPW_411_3P_Ex.MVVM.Models;

namespace TDMPW_411_3P_Ex.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MateriaViewModel 
    {
        public Materia Materia { get; set; }
        private List<Rubro> rumbros = new List<Rubro>();
        public List<Rubro> rubrostemp = new List<Rubro>();

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
        public List<Rubro> Rumbros
        {
            get => rumbros;
            set
            {
                rumbros.Clear();
                rumbros.AddRange(value);
                updateRubros();
            }
        }
        public string nombre { get; set; }
        private int cantidad;
        public int Cantidad { get => cantidad;
        set
            {
                cantidad= value;
                updateCantidad();
            }
        }

        public ICommand NameCmd => new Command(() => nombre = Materia.Name);
        public ICommand ClickCommand { get; }

        public MateriaViewModel()
        {
            //Rubros.Add(new Rubro());
            Opciones = new ObservableCollection<string>
            {
                "1",
                "5"
               ,"10"
            };
            SelectedStepString = Opciones[1];
            Materia = new Materia()
            {
                Name = nombre,
                Quantity = Cantidad,
                Rubros = rumbros
            };
            updateRubros();
            ClickCommand = new Command(() =>
            {
                if (validatePercentage())
                {
                    calculateGrade();
                }
                else
                {
                    App.Current.MainPage.
                    DisplayAlert("Error","Los porcentaje no completan el 100%", "OK");
                }
                
            }
           );
        }
        public bool validatePercentage()
        {
            int total = 0;
            foreach (Rubro item in Rumbros){
                total += (int)item.Percentage;
            }
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
            double sumaPorcentajes = 0;
            foreach (Rubro item in Rumbros)
            {
                double preSuma = 0;
                double percentageConverted = 0;
                percentageConverted = item.Percentage/100;
                preSuma = item.Grade * percentageConverted;
                sumaPorcentajes += preSuma;
            }
            Materia.FinalGrade = sumaPorcentajes;
        }

        public async void updateCantidad()
        {
            Materia.Quantity = Cantidad;
            if(cantidad < Rumbros.Count)
            {
                Rumbros.RemoveAt(Rumbros.Count-1);
               /* await App.Current.MainPage.
                     DisplayAlert("COMMANDO", Rubros.Count+"", "OK");*/
            }
            else
            {
                Rumbros.Add(new Rubro() { Id = Rumbros.Count , Step = Step});
               /* await App.Current.MainPage.
                    DisplayAlert("COMMANDO", Rubros.Count + "", "OK");*/
            }
            Rumbros = new List<Rubro>(Rumbros);
            

        }

        public void updateRubros()
        {
            //App.Current.MainPage.DisplayAlert("COMMANDO","", "OK");
            Materia.Rubros = new List<Rubro>(rumbros);
        }
        public void updateSteppers()
        {
            Step = int.Parse(selectedStepString);
            foreach (Rubro item in Rumbros)
            {
                item.Step = Step;
                updateRubros();
            }
            
            //App.Current.MainPage.DisplayAlert("COMMANDO","", "OK");

        }
        public void juan()
        {
            //App.Current.MainPage.DisplayAlert("COMMANDO", "Juan", "OK");
        }
    }
}
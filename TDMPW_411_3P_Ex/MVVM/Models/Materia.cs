using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDMPW_411_3P_Ex.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Materia
    {
        public string Name { get; set; }
        public double FinalGrade { get; set; }
        public int Quantity { get; set; }
        public List<Rubro> Rubros { get; set; }
        public Materia()
        {

        }
    }
}

using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDMPW_411_3P_Ex.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Rubro
    {
        public int Id { get; set; }
        public int Step { get; set; }
        public double Grade { get; set; }
        public double Percentage { get; set; }
        public Rubro()
        {

        }
    }
}

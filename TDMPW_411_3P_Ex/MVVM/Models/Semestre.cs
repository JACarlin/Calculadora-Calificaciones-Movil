using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDMPW_411_3P_Ex.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Semestre
    {
        public string Name { get; set; }
        public double FirstPercentage { get; set; }
        public double SecondPercentage { get; set; }
        public double ThirdPercentage { get; set; }
        public double FirstGrade { get; set; }
        public double SecondGrade { get; set; }
        public double ThirdGrade { get; set; }
        public double FinalGrade6 { get; set; }
        public double FinalGrade10 { get; set; }
        public int Step { get; set; }
        public Semestre()
        {

        }
    }
}

using TDMPW_411_3P_Ex.MVVM.ViewModel;
using System.ComponentModel;
namespace TDMPW_411_3P_Ex.MVVM.Views;

public partial class MateriaView : ContentPage , INotifyPropertyChanged
{
	public MateriaView()
	{
		InitializeComponent();
		BindingContext = new MateriaViewModel();
	}

}
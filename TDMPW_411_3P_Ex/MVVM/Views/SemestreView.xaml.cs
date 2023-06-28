namespace TDMPW_411_3P_Ex.MVVM.Views;
using TDMPW_411_3P_Ex.MVVM.ViewModel;

public partial class SemestreView : ContentPage
{
	public SemestreView()
	{
		InitializeComponent();
		BindingContext = new SemestreViewModel();
	}
}
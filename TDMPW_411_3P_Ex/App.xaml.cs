using TDMPW_411_3P_Ex.MVVM.Views;

namespace TDMPW_411_3P_Ex;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainTabbedPage();
	}
}

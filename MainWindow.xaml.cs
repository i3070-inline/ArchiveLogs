using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArchiveLogs
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Viewmodel DC => (Viewmodel)DataContext;
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new Viewmodel();
		}

		private void Close(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (((Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt)) && Keyboard.IsKeyDown(Key.F4))  || (Mouse.LeftButton == MouseButtonState.Released ))
			{
				MessageBoxResult answer = MessageBox.Show("Do you want to exit ?", Application.Current.MainWindow.Title, MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (answer == MessageBoxResult.Yes)
				{

				

					Application.Current.Shutdown();

				}
				else
				{
					e.Cancel = true;
				}
			}
			else
			{
				e.Cancel = true;
			}
		}
	}
}

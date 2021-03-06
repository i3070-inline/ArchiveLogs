using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ArchiveLogs
{
	class ExitButton : ICommand
	{
		event EventHandler ICommand.CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
			}
		}

		bool ICommand.CanExecute(object parameter)
		{
			return true;
		}

		void ICommand.Execute(object parameter)
		{
			Application.Current.MainWindow.Close();
		}
	}
}

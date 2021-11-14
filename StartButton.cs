using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ArchiveLogs
{
	class StartButton : ICommand
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
			if (parameter is Viewmodel data)
			{
				if (string.IsNullOrWhiteSpace(data.PathtoLog) || string.IsNullOrWhiteSpace(data.PathforArchive) || string.IsNullOrWhiteSpace(data.NameArchive))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return false;
			}
		}

		void ICommand.Execute(object parameter)
		{
			if (parameter is Viewmodel data)
			{
				data.ArchiveCommand.MaxProg = 0;
				data.ArchiveCommand.Percent = 0;
				data.ArchiveCommand.CheckLines(data.PathtoLog, data.PathforArchive, data.NameArchive);
			}
		}
	}
}


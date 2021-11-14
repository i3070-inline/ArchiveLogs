using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveLogs
{
#pragma warning disable CS0436 // Type conflicts with imported type
	[PropertyChanged.AddINotifyPropertyChangedInterface]
#pragma warning restore CS0436 // Type conflicts with imported type
	class Viewmodel
	{
		public Viewmodel()
		{
			StartButton = new StartButton();
			ExitButton = new ExitButton();
			ClearButton = new ClearButton();
			ArchiveCommand = new ArchiveCommand();
		}

		public StartButton StartButton { get; set; }
		public ExitButton ExitButton { get; set; }
		public ClearButton ClearButton { get; set; }
		public ArchiveCommand ArchiveCommand { get; set; }


		public string PathtoLog { get; set; }
		public string PathforArchive { get; set; }
		public string NameArchive { get; set; }


		
	}
}

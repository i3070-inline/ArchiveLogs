using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArchiveLogs
{

#pragma warning disable CS0436 // Type conflicts with imported type
	[PropertyChanged.AddINotifyPropertyChangedInterface]
#pragma warning restore CS0436 // Type conflicts with imported type
	class ArchiveCommand
	{
		public bool IsStop { get; set; } = true;
		public int MaxProg { get; set; } 

		public int Percent { get; set; } = 0;



		public async void CheckLines(string logsPath, string archivePath, string nameArchive)
		{


			DirectoryInfo directoryErr = new DirectoryInfo(logsPath);
			FileInfo[] Files = null;
			try
			{
				 Files = directoryErr.GetFiles("*");
			}
			catch (Exception)
			{

				MessageBox.Show(@""""+ logsPath +@"""" +" has been not found", "Archive", MessageBoxButton.OK, MessageBoxImage.Exclamation);
				IsStop = true;
			}
			var archive = Path.GetDirectoryName(archivePath);
			var name = Path.GetFileNameWithoutExtension(archivePath);
			var archivePathName = Path.Combine(archive, name ,nameArchive+".zip");

			try
			{
				MaxProg = Files.Length;
			} 
			catch (Exception)
			{
				IsStop = true;
				return;

			}
			if (MaxProg > 0)
			{
				try
				{
					using (ZipArchive zip = ZipFile.Open(archivePathName, ZipArchiveMode.Create))
					{
						foreach (var file in Files)
						{
							Percent++;
							IsStop = false;
							zip.CreateEntryFromFile(Path.Combine(logsPath, Path.GetFileName(file.Name)), Path.GetFileName(file.Name));
							await Task.Delay(1);
						}
						MessageBox.Show("You will find zip archive :"+@"""" +archivePathName+@"""", "Archive", MessageBoxButton.OK, MessageBoxImage.Information);
						IsStop = true;
					}
				}
				catch (Exception)
				{
					MessageBox.Show("Has been not found "+@"""" + archivePath +@"""" , "Archive", MessageBoxButton.OK, MessageBoxImage.Exclamation);
					IsStop = true;
				}
				finally
				{
					Directory.CreateDirectory(archivePath);
					MessageBox.Show(@"""" + archivePath + @"""" + " has been created", "Archive", MessageBoxButton.OK, MessageBoxImage.Information);
					using (ZipArchive zip = ZipFile.Open(archivePathName, ZipArchiveMode.Create))
					{
						foreach (var file in Files)
						{
							Percent++;
							IsStop = false;
							zip.CreateEntryFromFile(Path.Combine(logsPath, Path.GetFileName(file.Name)), Path.GetFileName(file.Name));
							await Task.Delay(1);
						}
						MessageBox.Show("You will find zip archive :" + @"""" + archivePathName + @"""", "Archive", MessageBoxButton.OK, MessageBoxImage.Information);
						IsStop = true;
					}

				}

			}
			else
			{
				MessageBox.Show("Path to logs is empty", "Archive",MessageBoxButton.OK, MessageBoxImage.Exclamation);
				IsStop = true;
			}
		}
	}
}

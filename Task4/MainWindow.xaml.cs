using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.IO;
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

namespace Task4
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private const string FileName = "data.txt";

		public MainWindow()
		{
			InitializeComponent();
		}

		private void SaveData_Click(object sender, RoutedEventArgs e)
		{
			string data = dataTextBox.Text;

			using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
			{
				using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(FileName, FileMode.Create, isolatedStorage))
				{
					using (StreamWriter writer = new StreamWriter(stream))
					{
						writer.Write(data);
					}
				}
			}

			MessageBox.Show("Дані збережено в ізольованому сховищі.");
		}

		private void LoadData_Click(object sender, RoutedEventArgs e)
		{
			using (IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly())
			{
				if (isolatedStorage.FileExists(FileName))
				{
					using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(FileName, FileMode.Open, isolatedStorage))
					{
						using (StreamReader reader = new StreamReader(stream))
						{
							string data = reader.ReadToEnd();
							dataTextBox.Text = data;
						}
					}
				}
				else
				{
					MessageBox.Show("Файл з даними не знайдено.");
				}
			}
		}
	}
}

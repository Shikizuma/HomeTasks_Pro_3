namespace Task6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string baseDirectory = "C:\\Users\\myros\\source\\repos\\HomeTasks_Pro_3\\Temp"; 

			
			for (int i = 0; i < 100; i++)
			{
				string directoryPath = Path.Combine(baseDirectory, $"Folder_{i}");
				Directory.CreateDirectory(directoryPath);
			}

			Console.WriteLine("100 директорій створено.");

			Console.ReadKey();
			
			for (int i = 0; i < 100; i++)
			{
				string directoryPath = Path.Combine(baseDirectory, $"Folder_{i}");
				Directory.Delete(directoryPath);
			}

			Console.WriteLine("100 директорій видалено.");

		}
	}
}
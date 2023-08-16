using System.IO.Compression;

namespace Task3
{
	internal class Program
	{
		static void Main()
		{
			Console.Write("Введіть шлях до файлу: ");
			string filePath = Console.ReadLine();

			if (File.Exists(filePath))
			{
				Console.WriteLine($"Файл {filePath} знайдено.");
				ViewFileContents(filePath);
				Console.WriteLine("Бажаєте стиснути цей файл? (y/n): ");
				string response = Console.ReadLine();
				if (response.ToLower() == "y")
				{
					CompressFile(filePath);
				}
			}
			else
			{
				Console.WriteLine($"Файл {filePath} не знайдено.");
			}
		}

		static void ViewFileContents(string filePath)
		{
			Console.WriteLine($"Зміст файлу {filePath}:");
			using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
			{
				using (StreamReader reader = new StreamReader(fileStream))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						Console.WriteLine(line);
					}
				}
			}
		}

		static void CompressFile(string filePath)
		{
			string compressedFilePath = Path.ChangeExtension(filePath, "zip");

			using (FileStream originalFileStream = new FileStream(filePath, FileMode.Open))
			{
				using (FileStream compressedFileStream = File.Create(compressedFilePath))
				{
					using (ZipArchive archive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create))
					{
						ZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(filePath), CompressionLevel.Optimal);

						using (Stream entryStream = entry.Open())
						{
							originalFileStream.CopyTo(entryStream);
						}
					}
				}
			}

			Console.WriteLine($"Файл {filePath} стиснуто та збережено у файлі {compressedFilePath}");
		}
	}
}
using System.IO;
using System.IO.Pipes;

namespace HomeTasks_Pro_3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string filename = "txt.txt";

			WriteToFile(filename);		
			ReadFile(filename);
		}

		static void WriteToFile(string filename)
		{
			using (FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write))
			{
				using (StreamWriter writer = new StreamWriter(fileStream))
				{
					writer.WriteLine("Hello");
					writer.WriteLine("WORLD!!!!");
					fileStream.Seek(0, SeekOrigin.Begin);
				}
			}	
		}

		static void ReadFile(string filename)
		{
			string result = "";
			using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
			{
				using (StreamReader reader = new StreamReader(fileStream))
				{
					result = reader.ReadToEnd();
				}
			}
            Console.WriteLine(result);
        }
	}
}
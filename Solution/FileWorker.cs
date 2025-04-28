using System.Diagnostics;
using System.Text;
using FromAIGenTextToReadable.Infrastructure;

namespace FromAIGenTextToReadable.Solution
{
    class FileWorker
    {
        public StringBuilder ReadTextInFile(string pathInput)
        {
            string? line;
            StringBuilder strFromFile = new StringBuilder();
            try
            {

                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(pathInput);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    // Console.WriteLine(line);
                    strFromFile.AppendLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                // Console.WriteLine(strFromFile);

            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return strFromFile;
        }

        public void OutputTextInFile(string pathOutput, StringBuilder strInFile)
        {
            // Проверка на null
            if (strInFile == null)
            {
                throw new ArgumentNullException(nameof(strInFile), "StringBuilder не может быть null");
            }

            // Запись в файл
            string[] lines = strInFile.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            using (StreamWriter file = new StreamWriter(pathOutput))
            {
                foreach (string line in lines)
                {
                    file.WriteLine(line); // выводим построчно
                }
            }
        }

        public static void OpenFile(string pathToFile)
        {
            Process.Start("notepad.exe", pathToFile);
        }
    }
}
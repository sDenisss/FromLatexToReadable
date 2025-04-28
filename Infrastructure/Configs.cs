namespace FromAIGenTextToReadable.Infrastructure
{
    public class Configs 
    {
        public string InputPath { get; }
        public string OutputPath { get; }
        public string HelpPath { get; }

        public Configs() 
        {
            InputPath = GetProjectRootPath("input.txt");
            OutputPath = GetProjectRootPath("output.txt");
            HelpPath = GetProjectRootPath("help.txt");

        }

        private static string GetProjectRootPath(string fileName)
        {
            string binPath = AppContext.BaseDirectory;
            string projectRoot = binPath[..binPath.IndexOf("bin")];
            return Path.Combine(projectRoot, fileName);
        }
    }
}
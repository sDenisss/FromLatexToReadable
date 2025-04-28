using System.Runtime.InteropServices;
using System.Text;
using FromAIGenTextToReadable.Solution;

namespace FromAIGenTextToReadable.Infrastructure
{
    class StartProgram
    {
        public void RunProgram()
        {
            ChooseWayToUse();
            Convert();
        }

        public void Convert()
        {
            var configs = new Configs();
            var fileWorker = new FileWorker();
            var formatter = new Formatter();

            var resultText = fileWorker.ReadTextInFile(configs.InputPath);
            resultText = formatter.Format(resultText);
            fileWorker.OutputTextInFile(configs.OutputPath, resultText);
        }

        public void ChooseWayToUse()
        {
            bool isProcessing = false;
            var configs = new Configs();

            Console.WriteLine("Select how you want to use the converter:");

            while (!isProcessing)
            {
                Console.WriteLine("1. Edit text in file (input.txt → output.txt)");
                Console.WriteLine("2. Help");
                Console.Write("Your choice: ");
                string? inputWay = Console.ReadLine();

                switch (inputWay)
                {
                    case "1":
                        FileWorker.OpenFile(configs.InputPath);

                        bool waitingForContinue = true;
                        while (waitingForContinue)
                        {
                            Console.WriteLine("\nFiles opened.");
                            Console.WriteLine("1. Continue conversion");
                            Console.WriteLine("2. Back to menu");
                            Console.Write("Your choice: ");
                            var choice = Console.ReadLine();

                            if (choice == "1")
                            {
                                // isProcessing = true;
                                waitingForContinue = false;
                                Convert();
                                FileWorker.OpenFile(configs.OutputPath);
                            }
                            else if (choice == "2")
                            {
                                waitingForContinue = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Try again.");
                            }
                        }
                        break;

                    case "2":
                        FileWorker.OpenFile(configs.HelpPath);
                        break;

                    default:
                        Console.WriteLine("Invalid option. What’s wrong with you? Are you stupid monkey?");
                        Console.WriteLine("You were given exactly 3 choices, and you entered something else. Try again!");
                        break;
                }
            }
        }
    }
}

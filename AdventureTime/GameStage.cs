using System;
using System.Collections.Generic;

namespace AdventureTime
{
    class GameStage
    {
        private string areaName;
        public static string currentArea;

        public GameStage(string areaName)
        {
            this.areaName = areaName;
        }

        public void dialog(string text)
        {
            Console.WriteLine(text);
        }

        public string ask(List<string> allQuestions)
        {
            foreach (string question in allQuestions)
            {
                int optionNumber = allQuestions.IndexOf(question) + 1;
                Console.WriteLine(optionNumber + " - " + question);
            }

            return Console.ReadLine();
        }

        public void enter()
        {
            currentArea = areaName;
        }

        public void confirm()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}

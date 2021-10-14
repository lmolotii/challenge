using System;
using System.Linq;
using Profile.Challenge.Algorithm.Parser;

namespace Profile.Challenge.Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert your text here:");
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Nothing to do here.");
            }

            var parser = new WordParser();
            var calc = new WordCounter();
            
            var words = parser.ParseWords(input);
            var counters = calc.CountWords(words);

            var orderedItems = counters.OrderByDescending(t => t.count);
            int outputCount = 1;
            const int limit = 5;
            foreach (var item in orderedItems)
            {
                if(outputCount > limit)
                    break;
                
                Console.WriteLine($"{item.word} - {item.count}");
                outputCount++;
            }
        }
    }
}
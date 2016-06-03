using System.Collections.Generic;
using System.Linq;

namespace TestProject
{
    public class Program
    {
        private const string InputFilePath = @"./wordcount.txt";
        private const string OutputFilePath = @"./wordcount.out";

        static void Main()
        {
            var text = System.IO.File.ReadAllText(InputFilePath);
            text = text.Replace('"', ' ');
            text = text.Replace('.', ' ');
            text = text.Replace(',', ' ');
            text = text.ToLower();

            char[] delimeters = {' ', '\t', '\n', '\r'};
            var words = text.Split(delimeters);
            var dictionary = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (word == string.Empty)
                    continue;

                if (dictionary.ContainsKey(word))
                    dictionary[word] += 1;
                else
                {
                    dictionary.Add(word, 1);
                }
            }

            var dictionaryAslist = dictionary.ToList().OrderByDescending(x => x.Value);

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(OutputFilePath))
            {
                foreach (var keyValuePair in dictionaryAslist)
                {
                    file.WriteLine($"{keyValuePair.Key} - {keyValuePair.Value}");
                }
            }

        }
    }
}
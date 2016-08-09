using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace chsarp_study
{
    public class Markov
    {
        private string sourceText;
        private int order;
        private Dictionary<string, List<string>> probabilityTable;
        private Random random = new Random();
        private string LoadFile(string filename)
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string levelFilePath = Path.Combine(projectPath, filename);
            return File.ReadAllText(levelFilePath, Encoding.UTF8);
        }

        private void GenerateProbabilityTable()
        {
            probabilityTable = new Dictionary<string, List<string>>();
            for (int i = 0; i < sourceText.Length - order + 1 - 1; i++)
            {
                string key = sourceText.Substring(i, order);
                string value = sourceText.Substring(i + order, 1);
                List<string> values;
                if (probabilityTable.TryGetValue(key, out values))
                {
                    values.Add(value);
                }
                else
                {
                    probabilityTable[key] = new List<string>();
                    probabilityTable[key].Add(value);
                }
            }
        }

        private string FindMostFrequentKey()
        {
            // Finds the key with maximum value size
            return probabilityTable.Aggregate((l, r) => l.Value.Count > r.Value.Count ? l : r).Key;
        }

        public string GenerateText(int length)
        {
            string seed = FindMostFrequentKey();
            Console.WriteLine("Using seed : " + seed);
            StringBuilder text = new StringBuilder(seed);
            for (int i = 0; i < length - order + 1; i++)
            {
                string key = text.ToString(i, order);
                List<string> values;
                if (probabilityTable.TryGetValue(key, out values))
                {
                    text.Append(values[random.Next(values.Count)]);
                }
                else
                {
                    // If lookup fails, just end early
                    break;
                }
            }
            return text.ToString();
        }

        public Markov(string filename, int order)
        {
            sourceText = LoadFile(filename);
            this.order = order;
            GenerateProbabilityTable();
        }

        public static void Main()
        {
            Markov markov = new Markov("lorem.txt", 3);
            Console.WriteLine(markov.GenerateText(2000));
        }
    }
}

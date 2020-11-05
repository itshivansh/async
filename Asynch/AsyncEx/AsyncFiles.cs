using System.IO;
using System.Threading.Tasks;

namespace AsyncEx
{
    class AsyncFiles
    {
        public static string ReadVowelWords(string filename)
        {
            string filepath = $@"C:\Users\shivansh\Desktop\CGI_fsd\exercise-async-programming\{filename}";
            using StreamReader reader = new StreamReader(filepath);
            string content = reader.ReadToEnd();
            string[] words = content.Split(" ");
            string vowel = null;
            foreach (string word in words)
            {
                if (word.StartsWith('a') || word.StartsWith('e') || word.StartsWith('i') || word.StartsWith('o') || word.StartsWith('u') || word.StartsWith('A') || word.StartsWith('E') || word.StartsWith('I') || word.StartsWith('O') || word.StartsWith('U'))
                {
                    vowel += word;
                    vowel += " ";
                }
            }
            reader.Close();
            return vowel;
        }
        public static string ReadConsonantWords(string filename)
        {
            string filepath = $@"C:\Users\shivansh\Desktop\CGI_fsd\exercise-async-programming\{filename}";
            using StreamReader reader = new StreamReader(filepath);
            string content = reader.ReadToEnd();
            string[] words = content.Split(" ");
            //string[] words= wordss.
            string consonant = null;
            foreach (string word in words)
            {
                if (!word.StartsWith('a') && !word.StartsWith('e') && !word.StartsWith('i') && !word.StartsWith('o') && !word.StartsWith('u') && !word.StartsWith('A') && !word.StartsWith('E') && !word.StartsWith('I') && !word.StartsWith('O') && !word.StartsWith('U'))
                {
                    consonant += word;
                    consonant += " ";
                }
            }
            reader.Close();
            return consonant;

        }
        public static void MergeFiles(string vowel, string consonants, string filename)
        {
            string filepath = $@"C:\Users\shivansh\Desktop\CGI_fsd\exercise-async-programming\{filename}";
            StreamWriter sw = new StreamWriter(filepath);
            sw.Write($"{vowel} {consonants}");
            sw.Close();
        }
        public static void Check()
        {
            var task_1 = Task.Run(() => { return AsyncFiles.ReadVowelWords(@"sample.txt"); });
            var task_2 = Task.Run(() => { return AsyncFiles.ReadConsonantWords(@"sample.txt"); });
            Task.WaitAll(task_1, task_2);
            
            var result_1 = task_1.GetAwaiter().GetResult();
            var result_2 = task_2.GetAwaiter().GetResult();
            AsyncFiles.MergeFiles(result_1, result_2,@"Write.txt");
        }


    }
}

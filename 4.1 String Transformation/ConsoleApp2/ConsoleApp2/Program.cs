using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static List<String> transformationResult = new List<String>();

        static void Main(string[] args)
        {
            Console.WriteLine("4.1 Transforming a string into another");

            var E = new List<String>();
            E.Add("band");
            E.Add("bond");
            E.Add("bear");
            E.Add("cars");
            E.Add("fond");
            E.Add("food");
            E.Add("foot");
            E.Add("hand");
            E.Add("head");

            Console.WriteLine("Enter M1 value: ");
            var M1Value = Console.ReadLine();

            Console.WriteLine("Enter M2 value: ");
            var M2Value = Console.ReadLine();

            if(!E.Contains(M1Value))
            {
                Console.WriteLine(@"The value {M1Value} does not exist in the collection!");
                return;
            }
            if (!E.Contains(M2Value))
            {
                Console.WriteLine(@"The value {M2Value} does not exist in the collection!");
                return;
            }

            Transform(M1Value, M2Value, E);

            Console.WriteLine("================================");
            Console.WriteLine("RESULTS: ");
            transformationResult.ForEach(o => Console.WriteLine(o));
        }

        static void Transform(String M1, String M2, List<String> E)
        {
            var queue = new List<String>();
            queue.Add(M1);

            while (queue.Count != 0)
            {
                for (int x = 0; x < queue.Count; ++x)
                {
                    // get the first word.
                    char[] word = queue[0].ToCharArray();
                    queue.RemoveAt(0);

                    for (int w = 0; w < M1.Length; ++w)
                    {
                        // store the first character.
                        char firstCharacter = word[w];

                        // replace every character.
                        for (char ch = 'a'; ch <= 'z'; ++ch)
                        {
                            word[w] = ch;
                            var newWord = String.Join("", word);
                            if (!E.Contains(newWord))
                            {
                                continue;
                            }

                            E.Remove(newWord);
                            queue.Add(newWord);

                            if(!transformationResult.Contains(newWord))
                            {
                                transformationResult.Add(newWord);
                            }
                        }

                        // return the first character.
                        word[w] = firstCharacter;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//Jonathan Jacildo
//Paragraph Analysis Class
namespace Paragraph_Analysis
{
    class ParagraphAnalysis
    {
        //instance variables
        private string text;
        private readonly char[] delimiters = { ' ', '.', '\t', '\n' };//for words
        private readonly char[] delimiter = { '.', '\n', '\t' };//for sentences
        //constructor
        public ParagraphAnalysis(string text)
        {
            this.text = text;
        }

        private string[] WordSplit()
        {
            //splits the text, using delimiters, and removes duplicate elements to be stored into an array
            string[] words = text.ToLower().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            //sorts the array in an ascending order
            Array.Sort<string>(words);
            //return a sorted string array of words from the text
            return words;
        }

        private string[] SentenceSplit()
        {
            //splits the text into sentences to be stored into an array
            string[] sentences = text.ToLower().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            //returns a string of array containing sentences from the text
            return sentences;
        }

        private int[] WordCount()
        {
            string[] arr = WordSplit();
            //Store each word in a <Key, Value> where Key is the word, this helps eliminate duplicates because Keys must be unique, and adds a value of +1.
            //Meanwhile, when a Key is found in the Dictionary, TryGetValue for that Key and set Value to increment by 1.
            Dictionary<string, int> map = new Dictionary<string, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int value;
                if (!map.ContainsKey(arr[i]))
                {
                    map.Add(arr[i], 1);
                }
                else
                {

                    if (map.TryGetValue(arr[i], out value))
                    {
                        map[arr[i]] = value + 1;
                    }
                }
            }
            var wordCount = map.Values.ToArray();
            return wordCount;
        }
        
        private string[] WordFoundAtSentence()
        {
            int len = WordSplit().Distinct().ToArray().Length;
            string[] word = WordSplit().Distinct().ToArray();
            string[] sentence = SentenceSplit();
            string[] sentenceCount = new string[len];
            //loop for distint values of words
            for (int i = 0; i < len; i++)
            {
                string loc = "";
                //loop for an array which contains sentences as the element 
                for (int j = 0; j < SentenceSplit().Length; j++)
                {   
                    //condition if a word is found in a sentence, we add that value to a string
                    if (sentence[j].Split(delimiters).Contains($"{word[i]}"))
                    {
                        loc += $"{j+ 1}" + $" ";
                        continue;
                    }
                }
                //an array where we add the string representation of all the location of a word from the sentences
                sentenceCount[i] = loc;
            }
            return sentenceCount;
        }

        public IEnumerable<string> Results()
        {
            string[] words = WordSplit().Distinct().ToArray();
            int[] count = WordCount();
            string[] foundAt = WordFoundAtSentence();
            string result = "";
            Console.WriteLine("------------------------------------");
            Console.WriteLine(String.Format("{0, -15} | {1, 5} | {2, -10}", "Word", "Count", "Sentence"));
            Console.WriteLine("------------------------------------");
            for (int i = 0; i < WordCount().Length; i++)
            {
                result += String.Format("{0, -15} | {1,-5} | {2, -10}" + "\n", words[i], count[i], foundAt[i]);
            }
            

            yield return result;
        }
    }
}

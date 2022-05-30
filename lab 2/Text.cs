using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace lab_2
{
    class Text
    {
        public string textForWork;
        private string author;
        private string bookSource; 
        //public int textCount;

        public Text(string aText, string aAuthor, string aBookSourse)
        {
            textForWork = aText;
            Author = aAuthor;
            BookSource = aBookSourse;
            //textCount++;
        }
        public Text() { }

        public string BookSource
        {
            
            private set {
            if(value=="Luke"||value=="1 Corinthians"|| value=="2 Timothy" || value == "Philipians")
                {
                    bookSource = value;
                }
                else
                {
                    bookSource = "365 days";
                }
            }
            get { return bookSource; }
        }
        public string Author
        {
            get { return author; }
            set {
                if (value == "Paul" ||( value == "Luke"&&BookSource=="Luke"))
                {
                    author = value;
                }
                else
                {
                    author = "Max Lucado";
                }
            }
        }
        public string Add(string sentence)
        {
            textForWork= textForWork + " " + sentence;
            return textForWork;
        }
        public string Delete(byte numberOfSentence)
        {
            string[] sentences = textForWork.Split(new char[] { '.', '!', '?' });
            string textWithoutDeletedSentence = "";
            for(int n=1; n<=sentences.Length; n++)
            {
                if (n != numberOfSentence)
                {
                    textWithoutDeletedSentence += sentences[n-1];
                    if (n != sentences.Length)
                    {
                        textWithoutDeletedSentence += '.';
                    }
                }
            }
            textForWork = textWithoutDeletedSentence;
            return textForWork;
        }
        public string Insert(string inserting, int numbafter)
        {
            string[] sentences = textForWork.Split(new char[] { '.', '!', '?' });
            string textWithInsertedSEntence = "";
            for (int n = 1; n <= sentences.Length; n++)
            {
                
                textWithInsertedSEntence += sentences[n-1];
                if (n ==numbafter)
                {
                    textWithInsertedSEntence +='.'+inserting;
                }
                if (n != sentences.Length)
                {
                    textWithInsertedSEntence += '.'+" ";
                }
            }
            textForWork = textWithInsertedSEntence;
            return textForWork;
        }
        public void CountAll()
        {
            string[] sentences = textForWork.Split(new char[] { '.', '!', '?' }) ;
            Console.WriteLine($"number of sentences - {sentences.Length-1}");
            string[] words = textForWork.Split(' ');
            Console.WriteLine($"number of words - {words.Length }");
            int c = 0;
            for (int n= 0; n< words.Length; n++)
            {
                c += words[n].Count<char>();
            }
            Console.WriteLine($"number of letters - {c}");
        }
        public void SentenceNumber(byte numbofsent)
        {
            string[] sentences = textForWork.Split(new char[] { '.', '!', '?' });
            if (numbofsent > sentences.Length - 1)
            {
                Console.WriteLine("There's not a sentence with such a number");
            }
            else
            {
                Console.WriteLine($"Sentence number {numbofsent} :");
                Console.WriteLine(sentences[numbofsent-1]);
            }
        }
        public void LongestSentence()
        {
            string[] sentences = textForWork.Split(new char[] { '.', '!', '?' });
            int indexofmax = 0;
            for(int a = 0; a < sentences.Length; a++)
            {
                if (sentences[a].Count<char>() > sentences[indexofmax].Count<char>())
                {
                    indexofmax = a;
                }
            }
            Console.WriteLine($"The longest sentence's number is {indexofmax+1}. The sentence is:");
            Console.WriteLine(sentences[indexofmax]);
        }
        public void ShortestSentence()
        {
            string[] sentences = textForWork.Split(new char[] { '.', '!', '?' });
            int indexofmin = 0;
            for (int a = 0; a < sentences.Length-1; a++)
            {
                if (sentences[a].Count<char>() < sentences[indexofmin].Count<char>())
                {
                    indexofmin = a;
                }
            }
            Console.WriteLine($"The shortest sentence's number is {indexofmin + 1}. The sentence is:");
            Console.WriteLine(sentences[indexofmin]);
        }
        public bool ExcistingSentence(string checkingsent)
        {
            string[] sentences = textForWork.Split(new char[] { '.', '!', '?' });
            for(int a = 0; a < sentences.Length; a++)
            {
                if (checkingsent == sentences[a])
                {
                    return true;
                }
            }
            return false;
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);

        }
        static public Text FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Text>(json);
        }
    }
}

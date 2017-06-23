using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakAndSpell.Model.Services
{
    public class ServiceWord
    {
        /// <summary>
        /// On charge aléatoirement une fiche
        /// </summary>
        /// <returns></returns>
        public Word ChargerOK()
        {
            List<Word> lstLine = new List<Word>();
            lstLine.Add(new Word { ID = 2, Word_French = "Bonjour", Word_English = "Hello", Word_Picture = @"..\Resources\SpeakAndSpellSpeaker.jpg", Word_Response = "réponse" });
            lstLine.Add(new Word { ID = 2, Word_French = "Au revoir", Word_English = "Good bye", Word_Picture = @"..\Resources\SpeakAndSpellSpeaker.jpg", Word_Response = "réponse" });
            lstLine.Add(new Word { ID = 1, Word_French = "Un yaourt", Word_English = "a yogurt", Word_Picture = @"..\Resources\Pictures\yogurt.jpg", Word_Response = "réponse" });
            lstLine.Add(new Word { ID = 2, Word_French = "une chèvre", Word_English = "a goat", Word_Picture = @"..\Resources\Goat.jpg", Word_Response = "réponse" });
            lstLine.Add(new Word { ID = 3, Word_French = "Du beurre", Word_English = "butter", Word_Picture = @"..\Resources\Pictures\butter.jpg", Word_Response = "réponse" });
            lstLine.Add(new Word { ID = 3, Word_French = "Du fromage", Word_English = "Cheeses", Word_Picture = @"..\Resources\Pictures\cheeses.jpg", Word_Response = "réponse" });
            lstLine.Add(new Word { ID = 3, Word_French = "De la crème", Word_English = "Cream", Word_Picture = @"..\Resources\Pictures\cream.jpg", Word_Response = "réponse" });
            lstLine.Add(new Word { ID = 3, Word_French = "un petit suisse", Word_English = "Cream cheese dessert", Word_Picture = @"..\Resources\Pictures\creamcheeseDessert.jpg", Word_Response = "réponse" });
            lstLine.Add(new Word { ID = 3, Word_French = "Crème dessert", Word_English = "Cream Pudding", Word_Picture = @"..\Resources\Pictures\creamPudding.jpg", Word_Response = "réponse" });
            lstLine.Add(new Word { ID = 3, Word_French = "Du lait", Word_English = "Milk", Word_Picture = @"..\Resources\Pictures\milk.jpg", Word_Response = "réponse" });
            int randomSex = GetRandomValue(0, lstLine.Count);
            return lstLine[randomSex];
        }

        //public Word ChargerFile()
        public Word Charger()
        {
            
            String readStr = "";
            //List<string> lstLine = new List<string>();
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"C:\Users\Utilisateur\Documents\Visual Studio 2015\Projects\SpeakAndSpell\Sources\SpeakAndSpell\Resources\Files\TestMotsFr.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    readStr = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            string[] read = readStr.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int randomSex = GetRandomValue(0, read.Length);

            Word word = new Word();
            word.ID = randomSex;
            word.Word_French = read[randomSex];
            word.Word_English = read[randomSex];
            word.Word_Picture = @"..\Resources\SpeakAndSpellSpeaker.jpg";
            word.Word_Response = "Try Again";
            return word;
        }
        /// <summary>
        /// Obtient de façon aléatoire un booléen
        /// </summary>
        /// <returns></returns>
        private bool GetRandomBooleanValue()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            int randomValue = rnd.Next(0, 100);

            if (randomValue > 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// GetRandomValue
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private int GetRandomValue(int min=0, int max=1000)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int randomValue = rnd.Next(min, max);
            return randomValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CzechLearning.Models
{
    public class WordnikRandomWordProvider : IRandomWordProvider
    {
        // see http://developer.wordnik.com/docs.html#!/words/getRandomWord_get_4 for 
        // TODO: move key to config, and pass params as a name value collection
        protected const string WORDNIK_API_URL = "http://api.wordnik.com/v4/words.json/randomWord";
        protected const string WORDNIK_API_PARAMS = "?minCorpusCount=100000&api_key=";
        protected const string WORDNIK_API_KEY = "c04b416c90a06bfd0600f0e683e0114b709bb8ebe7bcaf128";

        public WordnikRandomWordProvider ()
        {

        }

        public Word GetNext ()
        {
            var wordString = GetWordViaApi();

            JToken token = JObject.Parse(wordString);

            string word = (string)token.SelectToken("word");

            return new Word() { English = word };
        }

        protected static Uri GetUri ()
        {
            return new Uri (WORDNIK_API_URL + WORDNIK_API_PARAMS + WORDNIK_API_KEY);
        }

        /// <summary>
        /// Gets a random word via the Wordnik API
        /// </summary>
        /// <returns>A JSON representation of a Wordnik word</returns>
        protected String GetWordViaApi ()
        {
            string word;
            var request = (HttpWebRequest)WebRequest.Create(GetUri().ToString());
            var response = request.GetResponse();

            using (var responseStream = response.GetResponseStream())
            {
                using (var reader = new StreamReader (responseStream))
                {
                    word = reader.ReadToEnd();
                }
            }

            return word;
        }
    }
}
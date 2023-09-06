using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScreenTranslator
{
    class Translator
    {
        static Translator()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// Translates the given text to english, first from cache if available and using web API if a translation is not available in the cache
        /// </summary>
        /// <param name="originalText">Original text to be translated to english</param>
        /// <returns></returns>
        public static string TranslateToEnglish(string originalText)
        {
            string engVersion = TranslationCache.Translate(originalText);
            if (string.IsNullOrEmpty(engVersion))
            {
                engVersion = Translate(originalText);
            }
            return engVersion;

        }

        /// <summary>
        /// Use web API to translate given text to english
        /// </summary>
        /// <param name="originalText">The text to translate to english</param>
        /// <returns>The english translation of the provided text</returns>
        private static string Translate(string originalText)
        {
            string retval="";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    FormUrlEncodedContent queryBody = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string, string>("source","zh"),
                    new KeyValuePair<string, string>("target","en"),
                    new KeyValuePair<string, string>("q",originalText)
                });

                    Task<HttpResponseMessage> responseMessageTask = httpClient.PostAsync("https://translate.argosopentech.com/translate", queryBody);
                    HttpResponseMessage responseMessage = responseMessageTask.Result;

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        HttpContent httpContent = responseMessage.Content;

                        string responseString = httpContent.ReadAsStringAsync().Result;
                        retval = GetOutputFromJson(responseString);

                        TranslationCache.SaveTranslation(originalText, retval); // save the translation entry to cache for future
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }


            return retval;
        }

        /// <summary>
        /// Returns only the actual translated text from the full JSON text containing the translated text.
        /// </summary>
        /// <param name="jsonOutput">The JSON text</param>
        /// <returns></returns>
        private static string GetOutputFromJson(string jsonOutput)
        {
            string retval = jsonOutput.Trim(); // first, trim
            retval = retval.Substring(1, retval.Length - 2); // then skip the first and the last curly braces
            retval = retval.Replace("\"translatedText\":", "");
            retval = retval.Trim();
            retval = retval.Substring(1, retval.Length - 2); // skip the first and the last double quotes
            return retval;
        }
    }
}

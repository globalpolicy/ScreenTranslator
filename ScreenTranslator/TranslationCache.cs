using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ScreenTranslator
{
    class TranslationCache
    {
        private const string CACHE_FILE = "TranslationCache.dat";
        private const int CACHE_SAVE_INTERVAL = 10000;
        private static Dictionary<string, string> translationCache;
        private static Thread cacheSaveThread;
        private static object lockObj = new object();
        private static volatile bool cacheSaveThreadKillSwitch = false; // set to true to kill the thread

        static TranslationCache()
        {
            LoadCacheFromFile();
            StartPeriodicCacheSave();
        }

        ~TranslationCache()
        {
            DumpCacheToFile();
        }

        /// <summary>
        /// Starts a thread that periodically saves the translation cache to file
        /// </summary>
        private static void StartPeriodicCacheSave()
        {
            cacheSaveThread = new Thread(new ThreadStart(() =>
              {
                  while (!cacheSaveThreadKillSwitch)
                  {
                      DumpCacheToFile();
                      Thread.Sleep(CACHE_SAVE_INTERVAL);
                  }

              }));
            cacheSaveThread.IsBackground = true;
            cacheSaveThread.Start();
        }

        /// <summary>
        /// Dumps whatever is in translationCache to the cache file, no questions asked
        /// </summary>
        private static void DumpCacheToFile()
        {
            lock (lockObj)
            {
                try
                {
                    StringBuilder textToDump = new StringBuilder();
                    foreach (KeyValuePair<string, string> entry in translationCache)
                    {
                        string encodedOriginalText = Convert.ToBase64String(Encoding.UTF8.GetBytes(entry.Key));
                        string encodedEnglishText = Convert.ToBase64String(Encoding.UTF8.GetBytes(entry.Value));
                        textToDump.AppendLine($"{encodedOriginalText}:{encodedEnglishText}");
                    }
                    File.WriteAllText(CACHE_FILE, textToDump.ToString());
                }
                catch (Exception ex)
                {

                }
            }
        }

        /// <summary>
        /// Returns the english translation of the provided text. Returns empty string if no cache exists.
        /// </summary>
        /// <param name="otherLanguageText">The text to translate to english</param>
        /// <returns></returns>
        public static string Translate(string otherLanguageText)
        {
            string retval = "";
            if (translationCache.ContainsKey(otherLanguageText))
                retval = translationCache[otherLanguageText];
            return retval;
        }

        /// <summary>
        /// Loads up translationCache with the translation cache from file
        /// </summary>
        private static void LoadCacheFromFile()
        {
            translationCache = new Dictionary<string, string>();

            try
            {
                string[] entries = File.ReadAllLines(CACHE_FILE); // one line = one entry
                foreach (string entry in entries)
                {
                    string[] tokens = entry.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if (tokens.Length == 2) // each entry has to be in the format - base64(originalText):base64(engTranslation)
                    {
                        string originalText = Encoding.UTF8.GetString(Convert.FromBase64String(tokens[0]));
                        string engTranslation = Encoding.UTF8.GetString(Convert.FromBase64String(tokens[1]));
                        translationCache.Add(originalText, engTranslation);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Saves into cache file the given original text and its english translation
        /// </summary>
        /// <param name="originalText">Original text</param>
        /// <param name="engTranslation">English translation of the original text</param>
        public static void SaveTranslation(string originalText, string engTranslation)
        {
            translationCache.Add(originalText, engTranslation);
        }
    }
}

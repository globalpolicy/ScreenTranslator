using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ScreenTranslator
{
    class Settings
    {
        private const string SETTINGS_FILE = "settings.dat";

        private static int yOffset;
        private static int xOffset;
        private static bool overlayAsTextBox = true; // default is true
        private static bool translateEntireWindow = true; // default is true
        private static int triggerDelay;
        private static string sourceLanguage;
        private static bool minimizeToTray;
        private static bool autoStart;
        private static bool topMost;
        private static bool balloonTips;

        public static int YOffset
        {
            get => yOffset;
            set
            {
                yOffset = value;
                WriteSettingsToFile();
            }
        }

        public static int XOffset
        {
            get => xOffset;
            set
            {
                xOffset = value;
                WriteSettingsToFile();
            }
        }

        public static bool OverlayAsTextBox
        {
            get => overlayAsTextBox;
            set
            {
                overlayAsTextBox = value;
                WriteSettingsToFile();
            }
        }

        public static bool TranslateEntireWindow
        {
            get => translateEntireWindow;
            set
            {
                translateEntireWindow = value;
                WriteSettingsToFile();
            }
        }

        public static int TriggerDelay
        {
            get => triggerDelay;
            set
            {
                triggerDelay = value;
                WriteSettingsToFile();
            }
        }

        public static string SourceLanguage
        {
            get => sourceLanguage;
            set
            {
                sourceLanguage = value;
                WriteSettingsToFile();
            }
        }

        public static bool MinimizeToTray
        {
            get => minimizeToTray;
            set
            {
                minimizeToTray = value;
                WriteSettingsToFile();
            }
        }

        public static bool AutoStart
        {
            get => autoStart;
            set
            {
                autoStart = value;
                WriteSettingsToFile();
            }
        }

        public static bool TopMost
        {
            get => topMost;
            set
            {
                topMost = value;
                WriteSettingsToFile();
            }
        }

        public static bool BalloonTips
        {
            get => balloonTips;
            set
            {
                balloonTips = value;
                WriteSettingsToFile();
            }
        }

        /// <summary>
        /// Writes the settings fields to file
        /// </summary>
        private static void WriteSettingsToFile()
        {
            try
            {
                StringBuilder settingsOutput = new StringBuilder();
                settingsOutput.AppendLine($"yOffset:{yOffset}")
                    .AppendLine($"xOffset:{xOffset}")
                    .AppendLine($"overlayAsTextBox:{overlayAsTextBox}")
                    .AppendLine($"translateEntireWindow:{translateEntireWindow}")
                    .AppendLine($"triggerDelay:{triggerDelay}")
                    .AppendLine($"sourceLanguage:{sourceLanguage}")
                    .AppendLine($"minimizeToTray:{minimizeToTray}")
                    .AppendLine($"autoStart:{autoStart}")
                    .AppendLine($"topMost:{topMost}")
                    .Append($"balloonTips:{balloonTips}");
                File.WriteAllText(SETTINGS_FILE, settingsOutput.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        static Settings()
        {
            RefreshSettingsFromFile();
        }

        /// <summary>
        /// Reads settings from file and loads up the setting fields
        /// </summary>
        public static void RefreshSettingsFromFile()
        {
            try
            {
                string[] settingsLines = File.ReadAllLines(SETTINGS_FILE);
                foreach (string settingLine in settingsLines)
                {
                    try
                    {
                        string[] tokens = settingLine.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        string parameter = tokens[0];
                        string value = tokens[1];

                        switch (parameter)
                        {
                            case "yOffset":
                                yOffset = int.Parse(value);
                                break;
                            case "xOffset":
                                xOffset = int.Parse(value);
                                break;
                            case "overlayAsTextBox":
                                overlayAsTextBox = bool.Parse(value);
                                break;
                            case "translateEntireWindow":
                                translateEntireWindow = bool.Parse(value);
                                break;
                            case "triggerDelay":
                                triggerDelay = int.Parse(value);
                                break;
                            case "sourceLanguage":
                                sourceLanguage = value;
                                break;
                            case "minimizeToTray":
                                minimizeToTray = bool.Parse(value);
                                break;
                            case "autoStart":
                                autoStart = bool.Parse(value);
                                break;
                            case "topMost":
                                topMost = bool.Parse(value);
                                break;
                            case "balloonTips":
                                balloonTips = bool.Parse(value);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}

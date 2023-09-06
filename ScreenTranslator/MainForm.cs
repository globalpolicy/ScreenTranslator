using Interop.UIAutomationClient;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenTranslator
{
    public partial class MainForm : Form
    {
        private Thread translationThread;
        private HashSet<IntPtr> translatedHwnds = new HashSet<IntPtr>();
        private bool disableFunctionality = false;
        private bool firstTimeWritingToStatusTextbox = true;

        public MainForm()
        {
            InitializeComponent();
        }

        struct TextElement
        {
            public tagRECT rectangle;
            public string originalText;
            public string translatedText;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetCorrectWorkingDirectory();
            UpdateGUIFromSettings();
            this.TopMost = Settings.TopMost;

            // ref: https://stackoverflow.com/questions/218732/how-do-i-execute-code-after-a-form-has-loaded
            if (Settings.MinimizeToTray)
                this.BeginInvoke(new Action(() =>
                {
                    this.WindowState = FormWindowState.Minimized;
                }));

            MouseWatcher.MiddleClickEventHandler += MouseClickWatcher_MiddleClickEventHandler;
            MouseWatcher.CursorMovedToTopLeftCorner += MouseWatcher_CursorMovedToTopLeftCorner;
        }

        /// <summary>
        /// Sets the working directory to the application exe path. This is important coz when running on user logon, the working directory isn't what you'd expect. This means our program is unaware of the settings file
        /// ref: https://stackoverflow.com/questions/13225841/starting-application-on-start-up-using-the-wrong-path-to-load
        /// </summary>
        private void SetCorrectWorkingDirectory()
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
        }

        /// <summary>
        /// Updates the state of setting-related elements in GUI from the settings file (whose contents are refelected in the Settings class)
        /// </summary>
        private void UpdateGUIFromSettings()
        {
            numericUpDownXOffset.Value = Settings.XOffset;
            numericUpDownYOffset.Value = Settings.YOffset;
            if (Settings.OverlayAsTextBox)
                radioButtonTextbox.Checked = true;
            else
                radioButtonLabel.Checked = true;
            comboBoxTranslationBehavior.Text = Settings.TranslateEntireWindow ? "Entire parent window" : "Single element";
            textBoxTrigger.Text = Settings.TriggerDelay.ToString();
            comboBoxSourceLanguage.Text = Settings.SourceLanguage;
            checkBoxMinimizeToTray.Checked = Settings.MinimizeToTray;
            checkBoxStartup.Checked = Settings.AutoStart;
            checkBoxTopMost.Checked = Settings.TopMost;
            toolStripMenuItemBalloonTips.Checked = Settings.BalloonTips;
        }


        #region GUI event handlers

        private void numericUpDownYOffset_ValueChanged(object sender, EventArgs e)
        {
            Settings.YOffset = (int)numericUpDownYOffset.Value;
        }

        private void numericUpDownXOffset_ValueChanged(object sender, EventArgs e)
        {
            Settings.XOffset = (int)numericUpDownXOffset.Value;
        }

        private void radioButtonTextbox_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTextbox.Checked)
                Settings.OverlayAsTextBox = true;
            else
                Settings.OverlayAsTextBox = false;
        }

        private void comboBoxTranslationBehavior_SelectedValueChanged(object sender, EventArgs e)
        {
            Settings.TranslateEntireWindow = comboBoxTranslationBehavior.Text == "Entire parent window";
        }

        private void textBoxTrigger_TextChanged(object sender, EventArgs e)
        {
            Settings.TriggerDelay = int.Parse(textBoxTrigger.Text);
        }

        private void comboBoxSourceLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            Settings.SourceLanguage = comboBoxSourceLanguage.Text;
        }

        private void checkBoxMinimizeToTray_CheckedChanged(object sender, EventArgs e)
        {
            Settings.MinimizeToTray = checkBoxMinimizeToTray.Checked;
        }

        private void checkBoxStartup_CheckedChanged(object sender, EventArgs e)
        {
            Settings.AutoStart = checkBoxStartup.Checked;
            SetStartup(checkBoxStartup.Checked);
        }

        private void checkBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            Settings.TopMost = checkBoxTopMost.Checked;
            this.TopMost = checkBoxTopMost.Checked;
        }

        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItemDisable_Click(object sender, EventArgs e)
        {
            disableFunctionality = true;
            notifyIcon1.Text = "ScreenTranslator is disabled";
            toolStripMenuItemDisable.Enabled = false;
            toolStripMenuItemEnable.Enabled = true;
        }

        private void toolStripMenuItemEnable_Click(object sender, EventArgs e)
        {
            disableFunctionality = false;
            notifyIcon1.Text = "ScreenTranslator is enabled";
            toolStripMenuItemDisable.Enabled = true;
            toolStripMenuItemEnable.Enabled = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (Settings.MinimizeToTray)
                {
                    this.Hide();
                    notifyIcon1.Visible = true;
                    if (Settings.BalloonTips)
                        notifyIcon1.ShowBalloonTip(10000);
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false; // remove ghost tray icon upon exit
        }

        private void toolStripMenuItemBalloonTips_CheckedChanged(object sender, EventArgs e)
        {
            Settings.BalloonTips = toolStripMenuItemBalloonTips.Checked;
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(() =>
            {
                for (int i = this.Height; i <= 684; i += 2)
                {
                    this.Invoke(new Action(() =>
                    {
                        this.Height = i;
                    }));
                    Thread.Sleep(10);
                }

            })).Start();

        }
        #endregion

        #region Settings logic

        /// <summary>
        /// Adds or removes program from startup
        /// </summary>
        /// <param name="autoStart">True for adding self to startup, false for not</param>
        private void SetStartup(bool autoStart)
        {
            RegistryKey runKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (autoStart)
                runKey.SetValue("ScreenTranslator", Application.ExecutablePath);
            else
                runKey.DeleteValue("ScreenTranslator", false);
        }

        #endregion

        #region Trigger handlers

        /// <summary>
        /// Called when mouse middle click occurs. Runs in a new thread
        /// </summary>
        private void MouseClickWatcher_MiddleClickEventHandler()
        {
            Debug.Print("Mouse middle button clicked!");

            if (disableFunctionality)
                return;

            Thread.Sleep(Settings.TriggerDelay);

            Point cursorPos;
            Win32Funcs.GetCursorPos(out cursorPos);

            if (Settings.TranslateEntireWindow)
            {
                IntPtr hwnd = Win32Funcs.WindowFromPoint(cursorPos);


                if (!translatedHwnds.Contains(hwnd)) // if this window hasn't been translated already, start a new translation thread
                {
                    WriteLineToStatusTextbox($"Translate window 0x{hwnd.ToString("X")}");
                    this.translationThread = new Thread(new ParameterizedThreadStart(TranslateWindow));
                    this.translationThread.Start(hwnd);
                    translatedHwnds.Add(hwnd);
                }
                else // if this window has already been translated, remove translation overlays for this window
                {
                    WriteLineToStatusTextbox($"Remove overlays for window 0x{hwnd.ToString("X")}");
                    translatedHwnds.Remove(hwnd);
                    this.Invoke(new Action(() =>
                    {
                        TextOverlayer.RemoveAllTextsForWindow(hwnd);
                    }));

                }

            }
            else
            {
                var automation = new CUIAutomation();

                tagPOINT point = new tagPOINT() { x = cursorPos.X, y = cursorPos.Y };
                IUIAutomationElement element = automation.ElementFromPoint(point);


                WriteLineToStatusTextbox($"Translate element @ ({cursorPos.X}, {cursorPos.Y})");
                TranslateElement(element);

            }
        }

        /// <summary>
        /// Called when the mouse cursor is moved to the top left corner of the screen. Runs in a new thread
        /// </summary>
        private void MouseWatcher_CursorMovedToTopLeftCorner()
        {
            if (disableFunctionality)
                return;

            WriteLineToStatusTextbox("Remove all overlays");
            translatedHwnds.Clear();
            this.Invoke(new Action(() =>
            {
                TextOverlayer.RemoveAllTexts();
            }));

        }

        #endregion


        /// <summary>
        /// Translate the given element (element-level translation)
        /// </summary>
        /// <param name="element">The element to translate</param>
        private void TranslateElement(IUIAutomationElement element)
        {
            try
            {
                string name = (string)element.GetCurrentPropertyValue(UIA_PropertyIds.UIA_NamePropertyId);
                string translation = Translator.TranslateToEnglish(name.Replace("\"", "").Replace("“", "").Replace("”", ""));

                WriteLineToStatusTextbox($"{name}   =>  {translation}");

                this.Invoke(new Action(() =>
                {
                    TextOverlayer.WriteText(element.CurrentBoundingRectangle.left + Settings.XOffset, element.CurrentBoundingRectangle.top + Settings.YOffset, translation, Settings.OverlayAsTextBox, IntPtr.Zero);
                }));

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Translate all the elements inside the given window handle (hwnd-level translation). Runs in a new thread
        /// </summary>
        /// <param name="hwnd_">The window handle whose elements are to be translated</param>
        private void TranslateWindow(object hwnd_)
        {
            try
            {
                var automation = new CUIAutomation();

                IntPtr hwnd = (IntPtr)hwnd_;
                var automationElement = automation.ElementFromHandle(hwnd);
                var nonEmptyNames = automationElement.FindAll(TreeScope.TreeScope_Descendants, automation.CreateNotCondition(automation.CreatePropertyCondition(UIA_PropertyIds.UIA_NamePropertyId, "")));

                if (nonEmptyNames == null || nonEmptyNames.Length == 0) // can be null if hwnd doesn't have any descendants (such as in web browsers), so get its parent hwnd, then do a FindAll()
                {
                    IntPtr earliestParentOfHwnd = Win32Funcs.GetEarliestParent(hwnd);
                    automationElement = automation.ElementFromHandle(hwnd);
                    nonEmptyNames = automationElement.FindAll(TreeScope.TreeScope_Descendants, automation.CreateNotCondition(automation.CreatePropertyCondition(UIA_PropertyIds.UIA_NamePropertyId, "")));
                }

                List<TextElement> textElements = new List<TextElement>();
                for (int i = 0; i < nonEmptyNames.Length; i++)
                {
                    IUIAutomationElement element = nonEmptyNames.GetElement(i);
                    tagRECT rect = element.CurrentBoundingRectangle;
                    string name = (string)nonEmptyNames.GetElement(i).GetCurrentPropertyValue(UIA_PropertyIds.UIA_NamePropertyId);
                    if (name == null || string.IsNullOrEmpty(name.Trim()))
                        continue;
                    if (!IsElementInWindow(element, hwnd))
                        continue;
                    textElements.Add(new TextElement() { rectangle = rect, originalText = name });
                    Debug.WriteLine(name);
                }

                WriteLineToStatusTextbox($"{textElements.Count} eligible text(s) found for window 0x{hwnd.ToString("X")}");

                int doneElementsCounter = 0;
                Parallel.For(0, textElements.Count, index =>
                {
                    TextElement textElement = textElements[index];
                    textElement.translatedText = Translator.TranslateToEnglish(textElement.originalText.Replace("\"", "").Replace("“", "").Replace("”", ""));
                    textElements[index] = textElement;

                    Debug.WriteLine($"{textElement.originalText}   =>    {textElement.translatedText} @ ({textElement.rectangle.left},{textElement.rectangle.top})");

                    this.Invoke(new Action(() =>
                    {
                        TextOverlayer.WriteText(textElement.rectangle.left + Settings.XOffset, textElement.rectangle.top + Settings.YOffset, textElement.translatedText, Settings.OverlayAsTextBox, hwnd);
                    }));

                    Interlocked.Increment(ref doneElementsCounter);
                    WriteLineToStatusTextbox($"Translated {doneElementsCounter}/{textElements.Count}");
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }


        }

        /// <summary>
        /// Checks if the given element is inside the given window
        /// </summary>
        /// <param name="element">The element to check</param>
        /// <param name="hwnd">The window to check inside</param>
        /// <returns></returns>
        private bool IsElementInWindow(IUIAutomationElement element, IntPtr hwnd)
        {
            Win32Funcs.RECT windowRect;
            Win32Funcs.GetWindowRect(hwnd, out windowRect);

            tagRECT elementRect = element.CurrentBoundingRectangle;
            if (elementRect.bottom < windowRect.Bottom && elementRect.left < windowRect.Right && elementRect.top > windowRect.Top)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Writes the given text as a line to the status text box
        /// </summary>
        /// <param name="text"></param>
        private void WriteLineToStatusTextbox(string text)
        {
            this.Invoke(new Action(() =>
            {
                if (firstTimeWritingToStatusTextbox)
                {
                    textBoxStatus.Clear();
                    firstTimeWritingToStatusTextbox = false;
                }

                textBoxStatus.Text += text + "\r\n";
                textBoxStatus.SelectionLength = 0;
                textBoxStatus.SelectionStart = textBoxStatus.Text.Length;
                textBoxStatus.ScrollToCaret();
            }));
        }


    }
}

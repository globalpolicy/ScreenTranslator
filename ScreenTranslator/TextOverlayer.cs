using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenTranslator
{
    /// <summary>
    /// This class is responsible for creating windows/overlays of translated text over the locations of foreign-language texts
    /// </summary>
    class TextOverlayer
    {
        private static object lockObj = new object();
        private static Dictionary<IntPtr, HashSet<Form>> hwndOverlayFormDict = new Dictionary<IntPtr, HashSet<Form>>();
        private static HashSet<Form> overlayForms = new HashSet<Form>();
        public static void WriteText(int x, int y, string text, bool showAsTextBox, IntPtr hwnd)
        {
            Form overlayForm = new Form();

            if (!showAsTextBox)
            {
                Label label = new Label();
                label.Text = text;
                label.AutoSize = true;
                overlayForm.Controls.Add(label);
            }
            else
            {
                TextBox textBox = new TextBox();
                textBox.TextChanged += TextBox_TextChanged;
                textBox.Text = text;
                overlayForm.Controls.Add(textBox);
            }

            overlayForm.StartPosition = FormStartPosition.Manual;
            overlayForm.FormBorderStyle = FormBorderStyle.None;
            overlayForm.Location = new System.Drawing.Point(x, y);
            overlayForm.ShowInTaskbar = false;
            overlayForm.TopMost = true;
            overlayForm.AutoSize = true;
            overlayForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Win32Funcs.SetTopMost(overlayForm.Handle);
            overlayForm.Show();



            if (hwnd != IntPtr.Zero) // means entire window translation mode
            {

                if (!hwndOverlayFormDict.ContainsKey(hwnd))
                    hwndOverlayFormDict.Add(hwnd, new HashSet<Form>());
                hwndOverlayFormDict[hwnd].Add(overlayForm);


            }
            else // means single element translation mode
            {

                overlayForms.Add(overlayForm);
            }

        }

        /// <summary>
        /// Removes all overlays for the given hwnd (hwnd-level overlays for the given hwnd)
        /// </summary>
        /// <param name="hwnd">The window handle to remove overlays for</param>
        public static void RemoveAllTextsForWindow(IntPtr hwnd)
        {
            if (hwndOverlayFormDict.ContainsKey(hwnd))
            {
                foreach (Form overlayForm in hwndOverlayFormDict[hwnd])
                    overlayForm.Close();
                hwndOverlayFormDict.Remove(hwnd);
            }


        }

        /// <summary>
        /// Removes all text overlays in all windows and all elements
        /// </summary>
        public static void RemoveAllTexts()
        {
            // clear all window-level overlays
            foreach (var entry in hwndOverlayFormDict)
            {
                IntPtr hwnd = entry.Key;
                HashSet<Form> overlayForms = entry.Value;
                foreach (Form overlayForm in overlayForms)
                    overlayForm.Close();
            }
            hwndOverlayFormDict.Clear();

            // clear all element-level overlays
            foreach (Form overlayForm in overlayForms)
                overlayForm.Close();
            overlayForms.Clear();
        }

        // ref: http://www.csharphelper.com/howtos/howto_resize_textbox_to_fit.html
        private static void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            const int x_margin = 0;
            const int y_margin = 2;
            Size size = TextRenderer.MeasureText(txt.Text, txt.Font);
            txt.ClientSize =
                new Size(size.Width + x_margin, size.Height + y_margin);
        }
    }
}

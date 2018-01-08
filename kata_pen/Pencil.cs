using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kata_pen
{
    public class Pencil
    {
        public int length = 0;
        // The sheet of paper we're writing on.
        private string sheet;

        private int _durability;
        // durability of a sharpened point.
        public int Durability
        {
            private get
            {
                return _durability;
            }
            set
            {
                _durability = value;
                currentDurability = value;
            }
        }

        private int currentDurability = 4000;

        /// <summary>
        /// Sharpen the pencil point and decrease it's length.
        /// </summary>
        public void sharpen()
        {
            if (length > 0)
            {
                currentDurability = _durability;
                --length;
            }
        }
        /// <summary>
        /// Erase the passed in text from the sheet.
        /// </summary>
        /// <param name="textToErase"></param>
        public void erase(string textToErase)
        {
            int lastIndex = indexOfLast(textToErase);
            if (lastIndex == -1)
                return;
            sheet = sheet.Remove(lastIndex, textToErase.Length);
            for (int i = 0; i < textToErase.Length; ++i)
                sheet = sheet.Insert(lastIndex, " ");
        }

        /// <summary>
        /// Find last occurance of pass in string.
        /// </summary>
        /// <param name="text">
        /// String to search for.
        /// </param>
        /// <returns>
        /// The index of the last occurance of the passed in text string or -1 if there are no occurances.
        /// </returns>
        private int indexOfLast(string text)
        {
            int lastLocation = 0;
            int location = 0;
            
            do
            {
                // Set lastLocation to -1 for the first run incase
                // the text isn't found at all.
                lastLocation = location == 0 ? -1 : location;
                // We are searching just after our last search find, but
                // if that is beyond the end of the sheet than we've already
                // found the last text (or none existed).
                if (location + 1 + text.Length > sheet.Length)
                    location = -1;
                else
                    location = sheet.IndexOf(text, location + 1);
            } while (location >= 0);

            return lastLocation;
        }
        /// <summary>
        /// Write on paper.
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public string write(string inputText)
        {
            foreach (char c in inputText)
            {
                if (c == ' ' || c == '\n')
                {
                    sheet += c;
                    continue;
                }
                // Upper case characters are twice as degradating.
                if (char.IsUpper(c))
                    currentDurability--;
                currentDurability--;
                if (currentDurability >= 0)
                    sheet += c;
            }
            return sheet;
        }
    }
}


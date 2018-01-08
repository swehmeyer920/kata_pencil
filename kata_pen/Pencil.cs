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
        public string sheet
        {
            get;
            private set;
        }

        private int _leadDurability;
        // durability of a sharpened point.
        public int LeadDurability
        {
            private get
            {
                return _leadDurability;
            }
            set
            {
                _leadDurability = value;
                currentLeadDurability = value;
            }
        }

        private int currentLeadDurability = 4000;

        public int eraserDurability = 4000;

        /// <summary>
        /// Sharpen the pencil point and decrease it's length.
        /// </summary>
        public void sharpen()
        {
            if (length > 0)
            {
                currentLeadDurability = _leadDurability;
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
            // Erase from right to left.
            for (int i = textToErase.Length - 1; i >= 0 ; --i)
            {
                if (eraserDurability <= 0)
                    return;
                --eraserDurability;
                sheet = sheet.Remove(lastIndex + i, 1);
                sheet = sheet.Insert(lastIndex + i, " ");
            }
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
        /// Put text at index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="text"></param>
        public void edit(int index, string text)
        {
            for (int i = 0; i < text.Length; ++i)
            {
                sheet = sheet.Remove(index + i, 1);
                sheet = sheet.Insert(index + i, new string(text[i], 1));
            }
        }

        /// <summary>
        /// Write on sheet.
        /// </summary>
        /// <param name="inputText"></param>
        public void write(string inputText)
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
                    currentLeadDurability--;
                currentLeadDurability--;
                if (currentLeadDurability >= 0)
                    sheet += c;
            }
        }
    }
}


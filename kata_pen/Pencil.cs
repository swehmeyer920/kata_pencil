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
        string sheet;

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

        public void sharpen()
        {
            if (length > 0)
            {
                currentDurability = _durability;
                --length;
            }
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


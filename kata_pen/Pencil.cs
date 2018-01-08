using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kata_pen
{
    public class Pencil
    {
        // The sheet of paper we're writing on.
        string sheet;
        public int durability = 4000;

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
                    durability--;
                durability--;
                if (durability >= 0)
                    sheet += c;
            }
            return sheet;
        }
    }
}


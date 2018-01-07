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

        /// <summary>
        /// Write on paper.
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public string write(string inputText)
        {
            sheet += inputText;
            return sheet;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Spelling
{

    public class CheckT9Spelling
    {

        private static List<string> alphas = new List<string>() {
        "a",
        "b",
        "c",
        "d",
        "e",
        "f",
        "g",
        "h",
        "i",
        "j",
        "k",
        "l",
        "m",
        "n",
        "o",
        "p",
        "q",
        "r",
        "s",
        "t",
        "u",
        "v",
        "w",
        "x",
        "y",
        "z"
        };

        Dictionary<string, string> keyPad = new Dictionary<string,string>();

        public void buildDictionary()
        {
            //Make a Dictionary of all patterns and store it in 'key_pad'.
            //keyPad['b'] = '22'

            int digits = 2;
            int iteAlpha = 0;

            int nTimes = 1;
            int timesLimit;

            while (iteAlpha < 26)
            {
                if (digits == 7 || digits == 9)
                {
                    timesLimit = 4;
                }
                else
                {
                    timesLimit = 3;
                }
                nTimes = 1;
                while (nTimes <= timesLimit && iteAlpha < 26)
                {
                    keyPad[alphas[iteAlpha]] = repeatChars(digits.ToString(), nTimes);
                    nTimes += 1;
                    iteAlpha += 1;
                }
                digits += 1;
            }
            keyPad[" "] = "0"; 
        }

        public string getPattern(string inputStr)
        {
            if (String.IsNullOrEmpty(inputStr))
                return String.Empty;

            StringBuilder answer = new StringBuilder();
            int presentKey;
            int previous_key = -1;

            //for every character in the input string, just retrieve its corresponding pattern from dictionary.
            foreach (var alpha in inputStr)
            {
                presentKey = Convert.ToInt32(keyPad[alpha.ToString()][0]);
                //if present key was same as previous, add space
                if (presentKey == previous_key)
                {
                    answer.Append(" ");
                }

                answer.Append(keyPad[alpha.ToString()]);
                previous_key = presentKey;
            }
            return answer.ToString();
        }

        private string repeatChars(string alpha, int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
                sb.Append(alpha);

            return sb.ToString();
        }
    
    }
}

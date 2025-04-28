using System.Text;
using System.Text.RegularExpressions;

namespace FromAIGenTextToReadable.Solution
{
    class Formatter
    {
        public StringBuilder Format(StringBuilder strFromFile)
        {
            StringBuilder result = strFromFile;
            // result = ChangeSymbolsInPairsLatex(result);
            result = new StringBuilder(ParseLatexFractionsRecursively(result.ToString()));

            foreach(var pairs in Dictionaries.changer)
            {
                result.Replace(pairs.Key, pairs.Value);
            }
            ChangeSuperOrSubStringCommon(result);
            System.Console.WriteLine(result);
            return result;
        }
        public StringBuilder ChangeSuperOrSubStringCommon(StringBuilder strFromFile)
        {
            StringBuilder result = strFromFile;

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '^')
                {
                  ChangeSuperOrSubString(result, Dictionaries.superscript, i);
                }
                else if (result[i] == '_')
                {
                  ChangeSuperOrSubString(result, Dictionaries.subscript, i);
                }
            }
            return result;
        }
        public void ChangeSuperOrSubString(StringBuilder result, Dictionary<string, string> somethingScript, int i)
        {
            int start = i + 1;
            int end = start;

            // Ищем конец степени — до пробела, знака препинания и т.д.
            while (end < result.Length && !char.IsWhiteSpace(result[end]) && !char.IsPunctuation(result[end]))
                end++;

            string exponent = result.ToString(start, end - start);

            // Преобразуем в надстрочный
            StringBuilder superOrSub = new StringBuilder();
            foreach (char c in exponent)
            {
                if (somethingScript.ContainsKey(c.ToString()))
                    superOrSub.Append(somethingScript[c.ToString()]);
                else
                    superOrSub.Append(c); // если нет в словаре — оставить как есть
            }

            // Заменяем ^ + степень на надстрочную версию
            result.Remove(i, end - i); // удалить ^ и степень
            result.Insert(i, superOrSub.ToString()); // вставить замену
        }
        private string ReplaceWithScript(string input, Dictionary<string, string> someScript)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                string s = c.ToString();
                result.Append(someScript.ContainsKey(s) ? someScript[s] : s);
            }
            return result.ToString();
        }

        public string ParseLatexFractionsRecursively(string input)
        {
            string pattern = @"\\frac\{([^{}]+)\}\{([^{}]+)\}";
            Regex regex = new Regex(pattern);

            while (regex.IsMatch(input))
            {
                input = regex.Replace(input, match =>
                {
                    string numerator = match.Groups[1].Value;
                    string denominator = match.Groups[2].Value;

                    // Рекурсивный вызов для вложенных frac
                    numerator = ParseLatexFractionsRecursively(numerator);
                    denominator = ParseLatexFractionsRecursively(denominator);

                    string numScript = ReplaceWithScript(numerator, Dictionaries.superscript);
                    string denScript = ReplaceWithScript(denominator, Dictionaries.subscript);

                    return $"({numScript})/({denScript})";
                });
            }
            return input;
        }
        // public StringBuilder ChangeSymbolsInPairsLatex(StringBuilder strFromFile)
        // {
        //     string pattern = @"\\frac\{([^{}]+)\}\{([^{}]+)\}";
        //     Regex regex = new Regex(pattern);

        //     string replaced = regex.Replace(strFromFile.ToString(), match =>
        //     {
        //         string numerator = match.Groups[1].Value;
        //         string denominator = match.Groups[2].Value;

        //         // Заменяем символы в числителе и знаменателе
        //         string numeratorScript = ReplaceWithScript(numerator, Dictionaries.superscript);
        //         string denominatorScript = ReplaceWithScript(denominator, Dictionaries.subscript);

        //         return $"({numeratorScript})/({denominatorScript})";
        //     });

        //     return new StringBuilder(replaced);
        // }

    }
}
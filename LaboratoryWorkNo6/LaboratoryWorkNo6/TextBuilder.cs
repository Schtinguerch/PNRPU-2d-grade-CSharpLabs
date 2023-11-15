using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using static System.Console;

namespace LaboratoryWorkNo6
{
    public class TextBuilder
    {
        private const int MinRandomCount = 1;
        private const int MaxRandomCount = 12;

        private string _text;
        private readonly Random _random = new Random();

        public void CreateNewTextByUserInput()
        {
            _text = ConsoleReadString("Введите текст: ");
        }

        private string ConsoleReadString(string message = "")
        {
            Write(message);
            var text = "";

            while (string.IsNullOrWhiteSpace(text = ReadLine()))
                Write("Внимание, с пустой строкой делать нечего\n" +
                    "Повторите ввод\n\n >>> ");

            return text;
        }

        public void CreateNewTextByRandom()
        {
            var text = "";
            int wordCount = _random.Next(MinRandomCount, MaxRandomCount);

            for (int i = 0; i < wordCount; i++)
                text += RandomRussianWord() + " ";

            _text = text;
            PrintText();
        }
        
        private string RandomRussianWord()
        {
            var word = "";
            int wordLength = _random.Next(MinRandomCount, MaxRandomCount);

            const int codeA = 1072;
            const int codeYa = 1103;

            for (int i = 0; i < wordLength; i++)
                word += (char) _random.Next(codeA, codeYa + 1);

            return word;
        }

        public void PrintText()
        {
            WriteLine($"Текст: \"{_text}\"");
            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }

        public void DeleteWordsWhichBeginAndEndSameChar()
        {
            if (_text == null || _text.Length == 0)
            {
                WriteLine("Строка пустая, на выходе та же пустая строка");

                ConsoleMenu.WaitForKey(ConsoleKey.Enter);
                return;
            }

            var oldText = _text;
            var allWordMatches = Regex.Matches(_text, "\\w+");

            for (int i = 0; i < allWordMatches.Count; i++)
            {
                var word = allWordMatches[i].Value;

                if (word.ToLower().First() == word.ToLower().Last())
                    _text = _text.Replace(word, string.Empty);
            }

            WriteLine($"До:    \"{oldText}\"");
            WriteLine($"После: \"{_text}\"");
            ConsoleMenu.WaitForKey(ConsoleKey.Enter);
        }
    }
}

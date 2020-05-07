using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GuideTest
{
    static class Program
    {
        private static string[] noName = {"da", "de", "do", "das", "dos"};

        private static string[] parentNameList = {"filho", "filha", "neto", "neta", "sobrinho", "sobrinha", "junior"};

        static void Main()
        {
            if (!Int32.TryParse(Console.ReadLine(), out var number))
            {
                Console.WriteLine("ERROR: First input needs to be a number, bye!");
                return;
            }

            var names = new string[number];

            for (var i = 0; i < number; i++)
            {
                names[i] = Regex.Replace(Console.ReadLine() ?? "", @"\s+", " ").Trim();
                names[i] = FormatName(names[i].ToLower());
            }

            for (var i = 0; i < number; i++)
            {
                Console.WriteLine(names[i]);
            }
        }

        private static string FormatName(string name)
        {
            string[] names = separateFirstFromLastName(name);
            if (names.Length > 1)
            {
                names[1] = capitalizeWords(names[1]);
                return $"{names[0]}, {names[1]}";
            }

            return names[0];

            string[] separateFirstFromLastName(string fullname)
            {
                var splitName = fullname.Split(' ');

                if (splitName.Length == 1)
                {
                    return new[] {splitName[0].ToUpper()};
                }

                var firstNamePart = splitName[^1];

                if (parentNameList.Contains(firstNamePart) && splitName.Length > 2)
                {
                    firstNamePart = $"{splitName[^2]} {firstNamePart}";
                }

                var lastPart = fullname.Substring(0, fullname.Length - firstNamePart.Length);

                return new[] {firstNamePart.ToUpper().Trim(), lastPart.Trim()};
            }

            string capitalizeWords(string phrase)
            {
                var splitName = phrase.Split(' ');
                for (int i = 0; i < splitName.Length; i++)
                {
                    if (!noName.Contains(splitName[i]))
                    {
                        splitName[i] = char.ToUpper(splitName[i][0]) + splitName[i].Substring(1);
                    }
                }

                return string.Join(" ", splitName);
            }
        }
    }
}
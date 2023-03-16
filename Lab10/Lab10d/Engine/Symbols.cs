using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public static class Symbols
    {

        public static string[] CharsToBinaryText(char[] symbols)
        {
            var result = new List<string>();

            foreach (var symbol in symbols)
            {
                var success = dict.TryGetValue(symbol, out string symbolAsBinaryText);
                if (!success)
                {
                    throw new Exception($"Input symbol '{symbol}' not found in the dictionary");
                }

                result.Add(symbolAsBinaryText);
            }

            return result.ToArray();
        }
        
        public static char[] EncryptedBinaryToText(string text, int blockLength)
        {
            if (text.Length % blockLength != 0)
                throw new Exception($"Input binary text length '{text.Length}' is not multiple of '{blockLength}'");

            var result = new List<char>();

            for (int i = 0; i < text.Length / blockLength; i++)
            {
                var currentWord = text.Substring(i * blockLength, blockLength);
                var symbolAsChar = dict.First(kv => kv.Value.Equals(currentWord)).Key;
                result.Add(symbolAsChar);
            }

            return result.ToArray();
        }

        public static Dictionary<char, string> dict = new Dictionary<char, string>()
            {
                { 'а', "000000" },
                { 'б', "000001" },
                { 'в', "000010" },
                { 'г', "000011" },
                { 'ґ', "000100" },
                { 'д', "000101" },
                { 'е', "000110" },
                { 'є', "000111" },
                { 'ж', "001000" },
                { 'з', "001001" },
                { 'и', "001010" },
                { 'і', "001011" },
                { 'ї', "001100" },
                { 'й', "001101" },
                { 'к', "001110" },
                { 'л', "001111" },
                { 'м', "010000" },
                { 'н', "010001" },
                { 'о', "010010" },
                { 'п', "010011" },
                { 'р', "010100" },
                { 'с', "010101" },
                { 'т', "010110" },
                { 'у', "010111" },
                { 'ф', "011000" },
                { 'х', "011001" },
                { 'ц', "011010" },
                { 'ч', "011011" },
                { 'ш', "011100" },
                { 'щ', "011101" },
                { 'ь', "011110" },
                { 'ю', "011111" },
                { 'я', "100000" },
                { ' ', "100001" },
                { 'А', "100010" },
                { 'Б', "100011" },
                { 'В', "100100" },
                { 'Г', "100101" },
                { 'Ґ', "100110" },
                { 'Д', "100111" },
                { 'Е', "101000" },
                { 'Є', "101001" },
                { 'Ж', "101010" },
                { 'З', "101011" },
                { 'І', "101100" },
                { 'Ї', "101101" },
                { 'К', "101110" },
                { 'Л', "101111" },
                { 'М', "110000" },
                { 'Н', "110001" },
                { 'О', "110010" },
                { 'П', "110011" },
                { 'Р', "110100" },
                { 'С', "110101" },
                { 'Т', "110110" },
                { 'У', "110111" },
                { 'Ф', "111000" },
                { 'Х', "111001" },
                { 'Ц', "111010" },
                { 'Ч', "111011" },
                { 'Ш', "111100" },
                { 'Щ', "111101" },
                { 'Ю', "111110" },
                { 'Я', "111111" }

            };

    }
}

using Lab10d.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Lab10d.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Lab10Controller : ControllerBase
    {
        private int blockHeight = 4;
        private int blockWidth = 9;
        private int symbolBinaryLength = 6;

        private readonly ILogger<Lab10Controller> _logger;

        public Lab10Controller(ILogger<Lab10Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Decrypt")]
        public string Get(string text, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("Key is empty");
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("Text is empty");
            }

            char[] allowedKeyChars = new char[] { '1', '2', '3', '4', '5', '6' };
            if (key.Length % allowedKeyChars.Length != 0)
            {
                throw new Exception($"Key length '{key.Length}' must multiply by {allowedKeyChars.Length}");
            }

            if (!key.All(c => allowedKeyChars.Contains(c)))
            {
                throw new Exception("Only next symbols are allowed in key: " + string.Join(',', allowedKeyChars));
            }

            for (int i = 0; i < key.Length; i += allowedKeyChars.Length)
            {
                var chunk = key.Substring(i, allowedKeyChars.Length);
                var keyChunkSymblos = chunk.Select(c => c).OrderBy(c => c).ToArray();
                if (new string(keyChunkSymblos) != new string(allowedKeyChars))
                {
                    throw new Exception($"Group #{i / allowedKeyChars.Length + 1} '{new string(keyChunkSymblos)}' is not correct. It must contain each of next symbols and only once: " + string.Join(',', allowedKeyChars));
                }

            }

            char[] allowedTextChars = new char[] { 'а', 'б', 'в', 'г', 'ґ', 'д', 'е', 'є', 'ж', 'з', 'и', 'і', 'ї', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ю', 'я', ' ', 'А', 'Б', 'В', 'Г', 'Ґ', 'Д', 'Е', 'Є', 'Ж', 'З', 'І', 'Ї', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ю', 'Я' };
            List<char> disallowedChars = new List<char>();

            foreach (var textChar in text)
            {
                if (!allowedTextChars.Contains(textChar))
                {
                    disallowedChars.Add(textChar);
                }
            }

            if (disallowedChars.Count > 0)
            {
                throw new Exception("Next symbols are not allowed in the text: " + string.Join(',', disallowedChars));
            }
            
            if ((text.Length * symbolBinaryLength) % (blockHeight * blockWidth) != 0)
            {
                throw new Exception($"Text length {text.Length} must multiply by {blockHeight * blockWidth / symbolBinaryLength}. Looks like you provide not encrypted text");
            }
            
            var dh = new DecryptHandler(key, _logger);


            return dh.Decrypt(text, blockHeight, blockWidth, symbolBinaryLength);
        }
    }
}
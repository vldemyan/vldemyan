using Lab10;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Lab10d.Handlers
{
    public class DecryptHandler
    {
        private readonly ILogger _logger;
        private readonly string _key;
        public DecryptHandler(string key, ILogger logger)
        {
            _logger = logger;
            _key = key ?? throw new ArgumentNullException(nameof(key));
            if (key.Length % 6 != 0)
            {
                _logger.LogError($"Key length '{key.Length}' must multiply by 6");
                throw new ArgumentException($"Key length '{key.Length}' must multiply by 6");
            }
        }

        public string Decrypt(string text, int blockHeight, int blockWidth, int symbolBinaryLength)
        {
            if (string.IsNullOrEmpty(text))
            {
                _logger.LogError($"Key '{_key}': Text is null or empty");
                throw new ArgumentException($"Text is empty");
            }
            
            var decriptedText = Orchestrator.DecryptText(text, symbolBinaryLength, _key, blockHeight, blockWidth);
            return decriptedText;
        }
    }
}

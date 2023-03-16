using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public static class Orchestrator
    {
        public static string DecryptText(string inputText, int messageLength, string key, int blockHeight, int blockWidth)
        {
            var binaryTextsArray = Symbols.CharsToBinaryText(inputText.ToCharArray());
            var encriptedBits = BlockOperations.EncriptedTextToBits(string.Join("", binaryTextsArray));
            var blockOperations = new BlockOperations(blockHeight, blockWidth);
            var blocks = blockOperations.TransportateBack(encriptedBits);
            var shiftedText = blockOperations.GetBinaryTextFromBlocks(blocks, messageLength);
            var unshiftedTextResult = Crypto.DecryptText(shiftedText, messageLength, key);
            
            
            return string.Join("", Symbols.EncryptedBinaryToText(unshiftedTextResult, messageLength));
        }
    }
}

namespace Lab10
{
    public static class Crypto
    {
        public static string DecryptText(string shiftedBinaryText, int blockLength, string key)
        {
            if (shiftedBinaryText.Length % blockLength != 0)
                throw new Exception($"text length '{shiftedBinaryText.Length}' is not multiply by block size '{blockLength}'");

            var blocksCount = shiftedBinaryText.Length / blockLength;

            var unshiftedTextResult = string.Empty;

            var row = new Row(blockLength, key);

            for (int i = 0; i < blocksCount; i++)
            {
                var symbolAsBinaryText = shiftedBinaryText.Substring(i * blockLength, blockLength);
                var unshiftedText = row.UnShiftSymbols(symbolAsBinaryText, row.GetSubKey(i));
                unshiftedTextResult += unshiftedText;
            }

            return unshiftedTextResult;
        }

    }
}

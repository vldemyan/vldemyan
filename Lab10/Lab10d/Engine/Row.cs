namespace Lab10
{
    public class Row
    {
        private int _size;
        private string _key;
        private int _blocksCount;

        public Row(int size, string key)
        {
            _size = size;
            _key = key;

            if (key.Length % size != 0)
                throw new ArgumentException($"Key length '{key.Length}' is not multyply by block size {size}");

            _blocksCount = key.Length / size;
        }

        public string GetSubKey(int i)
        {
            int blockNumber = i < _blocksCount ? i : i % _blocksCount;
            return _key.Substring(blockNumber * _size, _size);
        }

        public string UnShiftSymbols(string inputMessage, string subKey)
        {
            var resultArray = new char[_size];
            var inputArray = inputMessage.ToCharArray();
            if (inputArray.Length != _size)
            {
                throw new ArgumentException($"Input message length {inputArray.Length} must be 6");
            }

            var subKeyArray = subKey.ToCharArray();
            if (subKeyArray.Length != _size)
            {
                throw new ArgumentException($"Sub Key length {subKeyArray.Length} must be 6");
            }

            var subKeyIntArray = subKeyArray.Select(e => int.Parse(e.ToString())).ToArray();

            for (int i = 0; i < _size; i++)
            {
                resultArray[subKeyIntArray[i] - 1] = inputArray[i]; // sub key counts from 1
            }

            return string.Join(string.Empty, resultArray);
        }

    }
}

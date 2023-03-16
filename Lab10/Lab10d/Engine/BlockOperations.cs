using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class BlockOperations
    {
        private readonly int _blockWidth;
        private readonly int _blockHeight;

        public BlockOperations(int blockHeight, int blockWidth)
        {
            _blockHeight = blockHeight;
            _blockWidth = blockWidth;
        }

        public int CalculateBlocksCount(int messageLength)
        {
            return messageLength % (_blockHeight * _blockWidth) == 0 ?
                messageLength / (_blockHeight * _blockWidth) :
                messageLength / (_blockHeight * _blockWidth) + 1;
        }
        
        public string GetBinaryTextFromBlocks(Block[] blocks, int messageLength)
        {
            var blocksAsBinaryText = new List<string>();

            foreach (var block in blocks)
            {
                var blockAsText = string.Empty;
                for (int h = 0; h < _blockHeight; h++)
                {
                    for (int w = 0; w < _blockWidth; w++)
                    {
                        blockAsText += block.Matrix[h, w] ? "1" : "0";
                    }
                }
                blocksAsBinaryText.Add(blockAsText);
            }

            var firstBlock = blocksAsBinaryText.First();
            var lastBlock = blocksAsBinaryText.Last();

            var lastBlockWithoutTail = GetLastBlockWithoutTail(firstBlock, lastBlock, messageLength);

            var result = string.Empty;

            for (int i = 0; i < blocksAsBinaryText.Count; i++)
            {
                if (i == blocksAsBinaryText.Count - 1)
                {
                    result += lastBlockWithoutTail;
                }
                else
                {
                    result += blocksAsBinaryText[i];
                }
            }

            return result;
        }

        private string GetLastBlockWithoutTail(string firstBlock, string lastBlock, int messageLength)
        {
            var firstBlockStart = firstBlock.Substring(0, firstBlock.Length - messageLength);
            while (firstBlockStart.Length > 0)
            {
                if (lastBlock.EndsWith(firstBlockStart, StringComparison.Ordinal))
                {
                    return lastBlock.Substring(0, lastBlock.Length - firstBlockStart.Length);
                }

                firstBlockStart = firstBlockStart.Substring(0, firstBlockStart.Length - messageLength);
            }

            return lastBlock;
        }

        public Block[] TransportateBack(bool[] symbols)
        {
            if (symbols.Length % (_blockHeight * _blockWidth) != 0)
                throw new Exception($"symbols length '{symbols.Length}' is not multiply by block size '{_blockHeight * _blockWidth}'");

            int blocksCount = CalculateBlocksCount(symbols.Length);

            var result = new List<Block>();
            for (int i = 0; i < blocksCount; i++)
            {
                result.Add(new Block(_blockHeight, _blockWidth));
            }

            for (int i = 0; i < symbols.Length; i++)
            {
                var currentBlockNo = (i + 1) / (_blockHeight * _blockWidth);
                if ((i + 1) % (_blockHeight * _blockWidth) != 0)
                    currentBlockNo++;

                currentBlockNo--; // method above gives block No starting from 1

                var currentIndexInBlock = i - currentBlockNo * _blockHeight * _blockWidth;
                var currentColumn = (currentIndexInBlock + 1) / _blockHeight;
                if ((currentIndexInBlock + 1) % _blockHeight != 0)
                    currentColumn++;

                currentColumn--; // method above gives column No starting from 1

                var currentRow = (currentIndexInBlock) % _blockHeight;

                result[currentBlockNo].Matrix[currentRow, currentColumn] = symbols[i];
            }

            return result.ToArray();
        }

        public static bool[] EncriptedTextToBits(string inputText)
        {
            var result = new bool[inputText.Length];
            var inputAsChar = inputText.ToCharArray();

            for (int i = 0; i < inputText.Length; i++)
            {
                if (inputAsChar[i] == '1')
                {
                    result[i] = true;
                }
                else if (inputAsChar[i] == '0')
                {
                    result[i] = false;
                }
                else
                {
                    throw new Exception($"Unsupported char '{inputAsChar[i]}'");
                }

            }

            return result;
        }
    }
}

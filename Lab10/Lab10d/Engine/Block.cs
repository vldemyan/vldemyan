using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Block
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public bool[,] Matrix { get; set; }

        public Block(int height, int width)
        {
            Height = height;
            Width = width;
            Matrix = new bool[height, width];
        }

    }
}

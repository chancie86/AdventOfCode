using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Day8
{
    public class Layer
    {
        private readonly int[] _data;

        public Layer(int[] data, int width, int height)
        {
            _data = data;
            Width = width;
            Height = height;
        }

        public int Width { get; }

        public int Height { get; }

        public static Layer Parse(string rawData, int startIndex, int width, int height)
        {
            var numPixels = width * height;

            if (startIndex + numPixels > rawData.Length)
            {
                throw new InvalidDataException($"Not enough data to parse layer. Data length: {rawData.Length}, startIndex: {startIndex}, Width: {width}, Height: {height}");
            }

            var data = new int[numPixels];

            for (var i = 0; i < data.Length; i++)
            {
                data[i] = int.Parse(rawData[startIndex + i].ToString());
            }

            return new Layer(data, width, height);
        }

        public int GetPixel(int x, int y)
        {
            if (x >= Width)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            if (y >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }

            return _data[y * Width + x];
        }
    }
}

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
            if (data.Length != width * height)
            {
                throw new ArgumentException($"data buffer is the wrong size. Expected {width * height} but was {data.Length}");
            }

            _data = data;
            Width = width;
            Height = height;
            ReadOnly = true;
        }

        public int Width { get; }

        public int Height { get; }

        public bool ReadOnly { get; set; }

        private static Layer Parse(string rawData, int startIndex, int width, int height)
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

        public static IList<Layer> Parse(string data, int width, int height)
        {
            int numPixels = width * height;

            int currentIndex = 0;
            var layers = new List<Layer>();

            while (currentIndex < data.Length)
            {
                layers.Add(Parse(data, currentIndex, width, height));
                currentIndex += numPixels;
            }

            return layers;
        }

        public static Layer CreateTransparentLayer(int width, int height)
        {
            var layer = new Layer(new int[width * height], width, height)
            {
                ReadOnly = false
            };

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    layer.SetPixel(x, y, Constants.Transparent);
                }
            }

            return layer;
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

        public void SetPixel(int x, int y, int value)
        {
            if (ReadOnly)
            {
                throw new InvalidOperationException("Cannot write to layer because it is readonly");
            }

            _data[y * Width + x] = value;
        }
    }
}

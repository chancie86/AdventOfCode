using System;
using System.Collections.Generic;
using System.Text;

namespace Day8
{
    internal static class Part2
    {
        

        public static void Run(IList<Layer> layers)
        {
            var output = Layer.CreateTransparentLayer(layers[0].Width, layers[0].Height);

            foreach (var layer in layers)
            {
                MergeLayer(layer, output);
            }

            PrintLayer(output);
        }

        private static void MergeLayer(Layer input, Layer output)
        {
            if (input.Width != output.Width
                || input.Height != output.Height)
            {
                throw new ArgumentException("Layer sizes to not match");
            }

            for (var y = 0; y < output.Height; y++)
            {
                for (var x = 0; x < output.Width; x++)
                {
                    switch (output.GetPixel(x, y))
                    {
                        case Constants.Transparent:
                            output.SetPixel(x, y, input.GetPixel(x, y));
                            break;
                    }
                }
            }
        }

        private static void PrintLayer(Layer layer)
        {
            for (var y = 0; y < layer.Height; y++)
            {
                var rowData = new char[layer.Width];

                for (var x = 0; x < layer.Width; x++)
                {
                    rowData[x] = layer.GetPixel(x, y) == Constants.Black ? ' ' : '*';
                }

                Console.WriteLine(string.Join("", rowData));
            }
        }
    }
}

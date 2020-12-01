using System;
using System.Collections.Generic;
using System.Text;

namespace Day8
{
    internal static class Part1
    {
        public static void Run(IList<Layer> layers)
        {
            int numZeros = int.MaxValue;
            Layer layerWithLeastZeros = null;
            foreach (var layer in layers)
            {
                var numZerosTemp = CountNumberOfDigits(layer, 0);

                if (numZerosTemp < numZeros)
                {
                    numZeros = numZerosTemp;
                    layerWithLeastZeros = layer;

                }
            }

            if (layerWithLeastZeros == null)
            {
                throw new Exception("No layer with zeroes found");
            }

            var numberOfOnes = CountNumberOfDigits(layerWithLeastZeros, 1);
            var numberOfTwos = CountNumberOfDigits(layerWithLeastZeros, 2);

            Console.WriteLine("Part 1: " + numberOfOnes * numberOfTwos);
        }

        private static int CountNumberOfDigits(Layer layer, int digit)
        {
            var count = 0;

            for (var y = 0; y < layer.Height; y++)
            {
                for (var x = 0; x < layer.Width; x++)
                {
                    if (layer.GetPixel(x, y) == digit)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}

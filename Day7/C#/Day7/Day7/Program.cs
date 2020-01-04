using System;
using System.Linq;

namespace chancies.adventofcode.day7
{
    class Program
    {
        private static ILog _logger = new Logger();

        static void Main(string[] args)
        {
            var inputData = new [] {3, 8, 1001, 8, 10, 8, 105, 1, 0, 0, 21, 38, 59, 76, 89, 106, 187, 268, 349, 430, 99999, 3, 9, 1002, 9, 3, 9, 101, 2, 9, 9, 1002, 9, 4, 9, 4, 9, 99, 3, 9, 1001, 9, 5, 9, 1002, 9, 5, 9, 1001, 9, 2, 9, 1002, 9, 3, 9, 4, 9, 99, 3, 9, 1001, 9, 4, 9, 102, 4, 9, 9, 1001, 9, 3, 9, 4, 9, 99, 3, 9, 101, 4, 9, 9, 1002, 9, 5, 9, 4, 9, 99, 3, 9, 1002, 9, 3, 9, 101, 5, 9, 9, 1002, 9, 3, 9, 4, 9, 99, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 99, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 99, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 99 };
            //Part1Tests();
            Part1(inputData);
        }

        private static int Part1Execute(int[] program, int[] phaseSettings)
        {
            var param = 0;

            var computer = new Computer(_logger);
            computer.OutputData += (sender, data) => { param = data; };

            foreach (var phaseSetting in phaseSettings)
            {
                computer.AddDataToInputPipeline(phaseSetting, param);
                computer.Run(program);
            }

            return param;
        }

        private static void Part1Tests()
        {
            var program = new [] {3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0};
            var phaseSettings = new [] { 4, 3, 2, 1, 0 };
            var result = Part1Execute(program, phaseSettings);
            AssertEquals(result, 43210);

            program = new [] { 3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0 };
            phaseSettings = new [] { 0, 1, 2, 3, 4 };
            result = Part1Execute(program, phaseSettings);
            AssertEquals(result, 54321);

            program = new [] { 3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0 };
            phaseSettings = new [] { 1, 0, 4, 3, 2 };
            result = Part1Execute(program, phaseSettings);
            AssertEquals(result, 65210);
        }

        private static void Part1(int[] program)
        {
            var currentPhaseSetting = IncrementPhaseSetting(new[] { 0, 0, 0, 0, 0 });
            var maxPhaseSettings = (int[])currentPhaseSetting.Clone();

            int lastFirstDigit, maxValue = 0;

            do
            {
                _logger.TraceDebug($"Trying {string.Join(',', currentPhaseSetting)}");
                lastFirstDigit = currentPhaseSetting[0];
                var result = Part1Execute(program, currentPhaseSetting);

                if (result > maxValue)
                {
                    maxValue = result;
                    maxPhaseSettings = (int[])currentPhaseSetting.Clone();

                    _logger.TraceDebug($"Updating max phase setting: {string.Join(',', maxPhaseSettings)} results in {maxValue}");
                }

                currentPhaseSetting = IncrementPhaseSetting(currentPhaseSetting);
            } while (lastFirstDigit <= currentPhaseSetting[0]);
            
            _logger.TraceMsg($"Max phase setting: {string.Join(',', maxPhaseSettings)}, Signal value: {maxValue}");
        }

        private static int[] IncrementPhaseSetting(int[] phaseSettings)
        {
            bool hasAllDigits;
            var result = (int[])phaseSettings.Clone();

            do
            {
                bool incrementNext;
                var i = 4;

                do
                {
                    incrementNext = result[i] == 4 && i > 0;
                    result[i] = (result[i] + 1) % 5;
                    i--;
                } while (incrementNext);

                hasAllDigits = result.Contains(0)
                               && result.Contains(1)
                               && result.Contains(2)
                               && result.Contains(3)
                               && result.Contains(4);
            } while (!hasAllDigits);

            return result;
        }

        private static void AssertEquals(object actual, object expected)
        {
            var success = expected.Equals(actual);

            if (success)
            {
                _logger.TraceMsg($"ASSERT Expected: {expected}, Actual: {actual}, Result: {success}");
                return;
            }

            throw new Exception($"ASSERT Expected: {expected}, Actual: {actual}");
        }

        private class Logger
            : ILog
        {
            public void TraceMsg(string msg, params object[] args)
            {
                Console.WriteLine(msg, args);
            }

            public void TraceDebug(string msg, params object[] args)
            { 
                //Console.WriteLine(msg, args);
            }

            public void TraceError(string msg, params object[] args)
            {
                Console.Error.WriteLine(msg, args);
            }
        }
    }
}

using System;
using System.Linq;

namespace chancies.adventofcode.day7
{
    static class Helpers
    {
        public static ILog Log = new Logger();

        public static int[] IncrementPhaseSetting(int[] phaseSettings)
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

        public static void AssertEquals(object actual, object expected)
        {
            var success = expected.Equals(actual);

            if (success)
            {
                Log.TraceMsg($"ASSERT Expected: {expected}, Actual: {actual}, Result: {success}");
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

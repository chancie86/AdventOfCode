namespace chancies.adventofcode.day7
{
    static class Part1
    {
        private static int Execute(int[] program, int[] phaseSettings)
        {
            var param = 0;

            var computer = new Computer(Helpers.Log, "A");
            computer.OutputData += (sender, data) => { param = data; };

            foreach (var phaseSetting in phaseSettings)
            {
                computer.AddDataToInputPipeline(phaseSetting, param);
                computer.Run(program);
            }

            return param;
        }

        public static void RunTests()
        {
            var program = new[] { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 };
            var phaseSettings = new[] { 4, 3, 2, 1, 0 };
            var result = Execute(program, phaseSettings);
            Helpers.AssertEquals(result, 43210);

            program = new[] { 3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0 };
            phaseSettings = new[] { 0, 1, 2, 3, 4 };
            result = Execute(program, phaseSettings);
            Helpers.AssertEquals(result, 54321);

            program = new[] { 3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0 };
            phaseSettings = new[] { 1, 0, 4, 3, 2 };
            result = Execute(program, phaseSettings);
            Helpers.AssertEquals(result, 65210);
        }

        public static void Run(int[] program)
        {
            Helpers.Log.TraceMsg($"Running Part 1");

            var currentPhaseSetting = Helpers.IncrementPhaseSetting(new[] { 0, 0, 0, 0, 0 });
            var maxPhaseSettings = (int[])currentPhaseSetting.Clone();

            int lastFirstDigit, maxValue = 0;

            do
            {
                Helpers.Log.TraceDebug($"Trying {string.Join(',', currentPhaseSetting)}");
                lastFirstDigit = currentPhaseSetting[0];
                var result = Execute(program, currentPhaseSetting);

                if (result > maxValue)
                {
                    maxValue = result;
                    maxPhaseSettings = (int[])currentPhaseSetting.Clone();

                    Helpers.Log.TraceDebug($"Updating max phase setting: {string.Join(',', maxPhaseSettings)} results in {maxValue}");
                }

                currentPhaseSetting = Helpers.IncrementPhaseSetting(currentPhaseSetting);
            } while (lastFirstDigit <= currentPhaseSetting[0]);

            Helpers.Log.TraceMsg($"Max phase setting: {string.Join(',', maxPhaseSettings)}, Signal value: {maxValue}");
        }
    }
}

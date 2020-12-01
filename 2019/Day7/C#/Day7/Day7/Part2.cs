using System.Linq;
using System.Threading.Tasks;

namespace chancies.adventofcode.day7
{
    static class Part2
    {
        private static int Execute(int[] program, int[] phaseSettings)
        {
            int outputFromLastAmp = int.MinValue;

            // Create the amps
            var id = 'A';
            var amplifiers = phaseSettings.Select(setting =>
            {
                var amp = new Computer(Helpers.Log, id++.ToString());
                amp.AddDataToInputPipeline(setting);
                return amp;
            }).ToArray();

            // Feedback loop is bootstrapped by sending 0 to the first amp
            amplifiers[0].AddDataToInputPipeline(0);

            // Hook up the output pipeline from one amp to the next one
            for (var i = 0; i < amplifiers.Length; i++)
            {
                var amp = amplifiers[i];
                var nextAmp = amplifiers[(i + 1) % amplifiers.Length];
                amp.OutputData += (sender, signal) => { nextAmp.AddDataToInputPipeline(signal); };
            }

            amplifiers.Last().OutputData += (sender, signal) => outputFromLastAmp = signal;

            Task.WaitAll(amplifiers.Select(async amp => await amp.RunAsync((int[])program.Clone())).ToArray());

            return outputFromLastAmp;
        }

        public static void RunTests()
        {
            var program = new[] { 3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5 };
            var phaseSettings = new[] { 9, 8, 7, 6, 5 };
            var result = Execute(program, phaseSettings);
            Helpers.AssertEquals(result, 139629729);

            program = new[] { 3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10 };
            phaseSettings = new[] { 9, 7, 8, 5, 6 };
            result = Execute(program, phaseSettings);
            Helpers.AssertEquals(result, 18216);
        }

        private static int[] ShiftedPhaseSettings(int[] phaseSettings)
        {
            return phaseSettings.Select(x => x + 5).ToArray();
        }

        public static void Run(int[] program)
        {
            Helpers.Log.TraceMsg($"Running Part 2");

            var currentPhaseSetting = Helpers.IncrementPhaseSetting(new[] { 0, 0, 0, 0, 0 });

            var maxPhaseSettings = (int[])currentPhaseSetting.Clone();

            int lastFirstDigit, maxValue = 0;

            do
            {
                Helpers.Log.TraceDebug($"Trying {string.Join(',', currentPhaseSetting)}");
                lastFirstDigit = currentPhaseSetting[0];
                var result = Execute(program, ShiftedPhaseSettings(currentPhaseSetting));

                if (result > maxValue)
                {
                    maxValue = result;
                    maxPhaseSettings = (int[])currentPhaseSetting.Clone();

                    Helpers.Log.TraceDebug($"Updating max phase setting: {string.Join(',', ShiftedPhaseSettings(maxPhaseSettings))} results in {maxValue}");
                }

                currentPhaseSetting = Helpers.IncrementPhaseSetting(currentPhaseSetting);
            } while (lastFirstDigit <= currentPhaseSetting[0]);

            Helpers.Log.TraceMsg($"Max phase setting: {string.Join(',', ShiftedPhaseSettings(maxPhaseSettings))}, Signal value: {maxValue}");
        }
    }
}

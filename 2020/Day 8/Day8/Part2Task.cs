using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Day8
{
    public class Part2Task
        : Task
    {
        public Part2Task(IList<string> testData) : base(testData)
        {
        }

        public override void Run()
        {
            for (var i = 0; i < TestData.Count; i++)
            {
                if (TestData[i].StartsWith("nop"))
                {
                    var program = GetModifiedProgram(i, "jmp");
                    if (Test(program))
                    {
                        return;
                    }
                }
                else if (TestData[i].StartsWith("jmp"))
                {
                    var program = GetModifiedProgram(i, "nop");
                    if (Test(program))
                    {
                        return;
                    }
                }
            }

            throw new Exception("Valid program not found");
        }

        private IReadOnlyList<string> GetModifiedProgram(int index, string newOp)
        {
            var currentInstruction = TestData[index];
            var copiedProgram = new List<string>(TestData);
            copiedProgram[index] = $"{newOp} {currentInstruction.Substring(4, currentInstruction.Length - 4)}";
            return new ReadOnlyCollection<string>(copiedProgram);
        }

        private bool Test(IReadOnlyList<string> program)
        {
            var computer = new Computer(program);

            var visitedInstructions = new HashSet<int>();
            computer.StartExecuteInstruction += (sender, args) => { visitedInstructions.Add(computer.InstructionPointer); };

            computer.Run(sender => computer.InstructionPointer >= program.Count
                || visitedInstructions.Contains(computer.InstructionPointer));

            if (computer.InstructionPointer >= program.Count)
            {
                Result = computer.Output;
                return true;
            }

            return false;
        }
    }
}

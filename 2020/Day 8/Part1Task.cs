using System.Collections.Generic;

namespace Day8
{
    public class Part1Task
        : Task
    {
        public Part1Task(IList<string> testData) : base(testData)
        {
        }

        public override void Run()
        {
            var computer = new Computer(TestData);
            var visitedInstructions = new HashSet<int>();

            computer.StartExecuteInstruction += (sender, args) => { visitedInstructions.Add(computer.InstructionPointer); };

            computer.Run(sender => visitedInstructions.Contains(computer.InstructionPointer));
            Result = computer.Output;
        }
    }
}

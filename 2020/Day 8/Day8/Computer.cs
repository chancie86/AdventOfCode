using System;
using System.Collections.Generic;

namespace Day8
{
    public class Computer
    {
        private readonly IReadOnlyList<string> _program;

        public event EventHandler StartExecuteInstruction;

        public Computer(IReadOnlyList<string> program)
        {
            _program = program;
            InstructionPointer = 0;
            Output = 0;
        }

        public int Output { get; private set; }

        public int InstructionPointer { get; private set; }

        public void Run(Func<Computer, bool> exitCondition)
        {
            while (!exitCondition(this))
            {
                StartExecuteInstruction?.Invoke(this, new EventArgs());

                var split = _program[InstructionPointer].Split(' ');
                var op = split[0];
                var val = ParseValue(split[1]);

                ExecuteOperation(op, val);
            }
        }

        private void ExecuteOperation(string op, int val)
        {
            switch (op)
            {
                case "acc":
                    Output += val;
                    InstructionPointer += 1;
                    break;
                case "jmp":
                    InstructionPointer += val;
                    break;
                case "nop":
                    InstructionPointer += 1;
                    break;
            }
        }

        private int ParseValue(string input)
        {
            var number = int.Parse(input.Substring(1, input.Length-1));

            if (input[0] == '-')
            {
                return 0 - number;
            }

            return number;
        }
    }
}

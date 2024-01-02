using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Instructions
    {
        private readonly Instruction[] _instructions;
        private int _currentIndex = 0;

        public Instructions(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Must be a non empty string consisting of L and R characters", nameof(input));
            }

            _instructions = Parse(input);
        }

        private Instruction[] Parse(string input)
        {
            var result = new Instruction[input.Length];

            for (var i = 0; i < result.Length; i++)
            {
                switch (input[i])
                {
                    case 'L':
                        result[i] = Instruction.Left;
                        break;
                    case 'R':
                        result[i] = Instruction.Right;
                        break;
                    default:
                        throw new InvalidOperationException($"{input[i]} is not a valid character");
                }
            }

            return result;
        }

        public Instruction Pop()
        {
            var result = _instructions[_currentIndex++];

            if (_currentIndex == _instructions.Length)
            {
                // Loop back to beginning of instructions
                _currentIndex = 0;
            }

            return result;
        }
    }
}

﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace chancies.adventofcode
{
    public class Computer
        : IDisposable
    {
        private readonly ManualResetEvent _mre;
        private readonly ILog _log;
        private readonly string _id;

        private Pipeline _inputPipeline;
        private Pipeline _outputPipeline;

        public Computer(ILog logger, string id)
        {
            _log = logger;
            _id = id;
            _mre = new ManualResetEvent(false);
            _inputPipeline = new Pipeline();
            _outputPipeline = new Pipeline();
        }

        public event EventHandler<int> OutputData;

        public async Task RunAsync(int[] program)
        {
            await Task.Run(() => Run(program));
        }

        public void Run(int[] program)
        {
            TraceMsg("Starting int computer");

            var opPointer = 0;

            while (true)
            {
                var opCode = program[opPointer].ToString("D5");
                var operation = int.Parse(opCode.Substring(3));
                var parameterModes = opCode.Substring(0, 3);

                switch (operation)
                {
                    case 1:
                        Add(program, ref opPointer, parameterModes);
                        break;
                    case 2:
                        Multiply(program, ref opPointer, parameterModes);
                        break;
                    case 3:
                        Input(program, ref opPointer);
                        break;
                    case 4:
                        Output(program, ref opPointer, parameterModes);
                        break;
                    case 5:
                        Jump(program, ref opPointer, parameterModes, JumpMode.JumpIfTrue);
                        break;
                    case 6:
                        Jump(program, ref opPointer, parameterModes, JumpMode.JumpIfFalse);
                        break;
                    case 7:
                        SetIfSize(program, ref opPointer, parameterModes, SetMode.LessThan);
                        break;
                    case 8:
                        SetIfSize(program, ref opPointer, parameterModes, SetMode.Equals);
                        break;
                    case 99:
                        TraceDebug("HALT");
                        TraceMsg("int computer exiting");
                        return;
                    default:
                        throw new InvalidOperationException($"Invalid op code {program[opPointer]}");
                }
            }
        }

        public void AddDataToInputPipeline(params int[] data)
        {
            foreach (var datum in data)
            {
                _inputPipeline.Write(datum);
            }

            _mre.Set();
        }

        private void Run(object o)
        {
            var program = (int[]) o;
            Run(program);
        }

        private int GetValue(int[] program, int opPointer, int parameterNumber, string parameterModes)
        {
            var modeIndex = 3 - parameterNumber;

            if (parameterModes[modeIndex] == '0')
            {
                // Position mode
                return program[program[opPointer + parameterNumber]];
            }
            else
            {
                // Immediate mode
                return program[opPointer + parameterNumber];
            }
        }

        private void Add(int[] program, ref int opPointer, string parameterModes)
        {
            var param1 = GetValue(program, opPointer, 1, parameterModes);
            var param2 = GetValue(program, opPointer, 2, parameterModes);

            var resultPointer = program[opPointer + 3];
            program[resultPointer] = param1 + param2;

            TraceDebug($"ADD p[{resultPointer}] = {param1} + {param2}");

            opPointer += 4;
        }

        private void Multiply(int[] program, ref int opPointer, string parameterModes)
        {
            var param1 = GetValue(program, opPointer, 1, parameterModes);
            var param2 = GetValue(program, opPointer, 2, parameterModes);

            var resultPointer = program[opPointer + 3];
            program[resultPointer] = param1 * param2;

            TraceDebug($"MULTIPLY p[{resultPointer}] = {param1} x {param2}");

            opPointer += 4;
        }

        private void Input(int[] program, ref int opPointer)
        {
            var value = ReadInputFromPipeline();

            var resultPointer = program[opPointer + 1];
            program[resultPointer] = value;

            TraceDebug($"INPUT p[{resultPointer}] = {value}");

            opPointer += 2;
        }

        private int ReadInputFromPipeline()
        {
            if (!_inputPipeline.CanRead)
            {
                _mre.WaitOne();
            }

            var result = _inputPipeline.Read();

            if (!_inputPipeline.CanRead)
            {
                _mre.Reset();
            }

            return result;
        }

        private void Output(int[] program, ref int opPointer, string parameterModes)
        {
            var result = GetValue(program, opPointer, 1, parameterModes);

            TraceDebug($"OUTPUT {result}");

            _outputPipeline.Write(result);

            OutputData?.Invoke(this, result);

            opPointer += 2;
        }

        private void Jump(int[] program, ref int opPointer, string parameterModes, JumpMode mode)
        {
            var param1 = GetValue(program, opPointer, 1, parameterModes);
            var param2 = GetValue(program, opPointer, 2, parameterModes);

            switch (mode)
            {
                case JumpMode.JumpIfTrue:
                    TraceDebug($"JUMP-IFTRUE {param1} == {param2}");

                    if (param1 != 0)
                    {
                        opPointer = param2;
                    }
                    else
                    {
                        opPointer += 3;
                    }
                    break;
                case JumpMode.JumpIfFalse:
                    TraceDebug($"JUMP-IFFALSE{param1} != {param2}");
                    if (param1 == 0)
                    {
                        opPointer = param2;
                    }
                    else
                    {
                        opPointer += 3;
                    }
                    break;
            }
        }

        private void SetIfSize(int[] program, ref int opPointer, string parameterModes, SetMode mode)
        {
            var param1 = GetValue(program, opPointer, 1, parameterModes);
            var param2 = GetValue(program, opPointer, 2, parameterModes);

            var resultPointer = program[opPointer + 3];

            switch (mode)
            {
                case SetMode.LessThan:
                    TraceDebug($"SET-LESSTHAN {param1} < {param2}");
                    if (param1 < param2)
                    {
                        program[resultPointer] = 1;
                    }
                    else
                    {
                        program[resultPointer] = 0;
                    }
                    break;
                case SetMode.Equals:
                    TraceDebug($"SET-EQUALS {param1} == {param2}");
                    if (param1 == param2)
                    {
                        program[resultPointer] = 1;
                    }
                    else
                    {
                        program[resultPointer] = 0;
                    }
                    break;
            }

            opPointer += 4;
        }

        public void Dispose()
        {
            _mre?.Dispose();
            _inputPipeline?.Dispose();
            _outputPipeline?.Dispose();
        }

        private void TraceDebug(string msg, params object[] args)
        {
            _log.TraceDebug($"COMPUTER {_id}: {msg}", args);
        }

        private void TraceMsg(string msg, params object[] args)
        {
            _log.TraceMsg($"COMPUTER {_id}: {msg}", args);
        }

        private enum JumpMode
        {
            JumpIfTrue,
            JumpIfFalse
        }

        private enum SetMode
        {
            LessThan,
            Equals
        }
    }
}

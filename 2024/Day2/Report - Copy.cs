//namespace Day2
//{
//    public class Report
//    {
//        private readonly string _data;
//        private readonly List<int> _levels;
//        private bool _dampened = false;

//        public Report(string data)
//        {
//            _data = data;
//            var levelsRaw = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//            _levels = levelsRaw.Select(int.Parse).ToList();
//        }

//        public bool Dampened => _dampened;

//        public bool IsSafe(bool useDampener)
//        {
//            try
//            {
//                return IsSafeInternal(useDampener);
//            }
//            catch (DifferenceTooLargeException exception)
//            {
//                return false;
//            }
//            catch (IncorrectModeException exception)
//            {
//                return false;
//            }
//        }

//        private bool IsSafeInternal(bool useDampener)
//        {
//            if (_levels.Count < 2)
//            {
//                throw new InvalidDataException("Must be 2 or more levels");
//            }

//            var mode = _levels[0] > _levels[1]
//                ? Mode.Decreasing
//                : Mode.Increasing;

//            bool Dampen(int index)
//            {
//                // Special handling for first and last values
//                if (index == 1)
//                {
//                    try
//                    {
//                        var alternateModeReport = new Report(_data);
//                        alternateModeReport._levels.RemoveAt(1);
//                        alternateModeReport._dampened = true;
//                        return alternateModeReport.IsSafeInternal(false);
//                    }
//                    catch (Exception)
//                    {
//                        // Keep calm, carry on
//                    }
//                }
//                else if (index == _levels.Count - 2)
//                {
//                    try
//                    {
//                        var alternateModeReport = new Report(_data);
//                        alternateModeReport._levels.RemoveAt(_levels.Count - 1);
//                        alternateModeReport._dampened = true;
//                        return alternateModeReport.IsSafeInternal(false);
//                    }
//                    catch (Exception)
//                    {
//                        // Keep calm, carry on
//                    }
//                }

//                var newReport = new Report(_data);
//                newReport._levels.RemoveAt(index);
//                newReport._dampened = true;

//                return newReport.IsSafeInternal(false);
//            }

//            for (var i = 0; i < _levels.Count - 1; i++)
//            {
//                var currentLevel = _levels[i];
//                var nextLevel = _levels[i + 1];

//                var difference = nextLevel - currentLevel;
//                var absoluteDifference = Math.Abs(difference);

//                if (absoluteDifference < 1
//                    || absoluteDifference > 3)
//                {
//                    if (useDampener)
//                    {
//                        return Dampen(i + 1);
//                    }

//                    throw new DifferenceTooLargeException();
//                }

//                switch (mode)
//                {
//                    case Mode.Increasing:
//                        if (difference < 0)
//                        {
//                            if (useDampener)
//                            {
//                                return Dampen(i + 1);
//                            }

//                            throw new IncorrectModeException();
//                        }
//                        break;
//                    case Mode.Decreasing:
//                        if (difference > 0)
//                        {
//                            if (useDampener)
//                            {
//                                return Dampen(i + 1);
//                            }

//                            throw new IncorrectModeException();
//                        }
//                        break;
//                }
//            }

//            return true;
//        }

//        public override string ToString()
//        {
//            return _data;
//        }

//        private enum Mode
//        {
//            Increasing,
//            Decreasing
//        }

//        private class DifferenceTooLargeException
//            : Exception
//        {}

//        private class IncorrectModeException
//            : Exception
//        { }
//    }
//}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day_4
{
    public abstract class Task
    {
        private readonly string _batchData;

        public IList<Passport> Passports { get; private set; }

        protected Task(string batchData)
        {
            _batchData = batchData;
        }

        public abstract void Run();

        protected void Parse(bool validate)
        {
            var passportData = Regex.Split(_batchData, @"\r\n\r\n");

            var result = new List<Passport>(passportData.Length);

            foreach (var pd in passportData)
            {
                var fields = new Dictionary<string, string>();

                foreach (var kvp in Regex.Split(pd, @"[\s]+"))
                {
                    var splitKeyValue = kvp.Split(':');
                    fields[splitKeyValue[0]] = splitKeyValue[1];
                }

                if (Passport.TryParse(fields, validate, out Passport passport))
                {
                    result.Add(passport);
                }
            }

            Passports = result;
        }

        public override string ToString()
        {
            return $"{Passports.Count}";
        }
    }
}

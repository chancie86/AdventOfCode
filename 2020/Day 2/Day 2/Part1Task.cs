﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day_2
{
    public class Part1Task
        : Task
    {
        public Part1Task(IList<string> data)
            : base(data)
        {
        }

        protected override Password GetPassword(Match match)
        {
            var first = int.Parse(match.Groups["first"].Value);
            var second = int.Parse(match.Groups["second"].Value);
            var character = match.Groups["char"].Value[0];
            var password = match.Groups["password"].Value;

            var policy = new Part1Policy(first, second, character);

            return new Password(password, policy);
        }
    }
}

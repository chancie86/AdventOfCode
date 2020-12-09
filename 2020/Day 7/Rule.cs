using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day7
{
    public class Rule
    {
        public Rule(string input)
        {
            ContainedBags = new Dictionary<string, int>();
            ParseInput(input);
        }

        public string BagColour { get; private set; }

        public IDictionary<string, int> ContainedBags { get; private set; }

        private void ParseInput(string input)
        {
            var split = input.Split(" bags contain ");
            BagColour = split[0];

            ParseContainedBags(split[1]);
        }

        private void ParseContainedBags(string input)
        {
            if (input == "no other bags.")
            {
                return;
            }

            foreach (var containedBagsInput in input.Split(", "))
            {
                ParseContainedBag(containedBagsInput);
            }
        }

        private void ParseContainedBag(string input)
        {
            var matches = Regex.Match(input, @"(?<number>[\d]+)+ (?<colour>[a-z ]+)( bag[s]*[.]?)$");
            var number = int.Parse(matches.Groups["number"].Value);
            var colour = matches.Groups["colour"].Value;

            ContainedBags[colour] = number;
        }
    }
}

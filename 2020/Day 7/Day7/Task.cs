using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day7
{
    public abstract class Task
    {
        protected Task(IList<string> testData)
        {
            Parse(testData);
        }

        protected IList<Bag> Bags { get; private set; }

        protected IList<Rule> Rules { get; private set; }

        public int Result { get; protected set; }

        public abstract void Run();

        private void Parse(IList<string> testData)
        {
            Rules = ParseRules(testData);
            Bags = Rules.Select(rule => new Bag(rule)).ToList();
            var bagDict = Bags.ToDictionary(b => b.Colour);

            foreach (var bag in Bags)
            {
                foreach (var containedBagColour in bag.Rule.ContainedBags.Keys)
                {
                    bag.ContainedBags[bagDict[containedBagColour]] = bag.Rule.ContainedBags[containedBagColour];
                }
            }
        }

        private IList<Rule> ParseRules(IList<string> testData)
        {
            return testData.Select(x => new Rule(x)).ToList();
        }

        public override string ToString()
        {
            return $"{Result}";
        }
    }
}

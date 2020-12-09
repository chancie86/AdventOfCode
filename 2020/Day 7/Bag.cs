using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Day7
{
    public class Bag
    {
        private Dictionary<string, bool> _checkedColours;

        public Bag(Rule rule)
        {
            Rule = rule;
            ContainedBags = new Dictionary<Bag, int>(rule.ContainedBags.Count);
            _checkedColours = new Dictionary<string, bool>();
        }

        public string Colour => Rule.BagColour;

        public Rule Rule { get; }

        public IDictionary<Bag, int> ContainedBags { get; private set; }

        public int NumberOfSubBags
        {
            get
            {
                var count = 0;

                foreach (var kvp in ContainedBags)
                {
                    var bag = kvp.Key;
                    var number = kvp.Value;
                    count += number + number * bag.NumberOfSubBags;
                }

                return count;
            }
        }

        public bool Contains(string colour)
        {
            foreach (var bag in ContainedBags.Keys)
            {
                if (bag.Colour == colour
                    || bag.Contains(colour))
                {
                    _checkedColours[colour] = true;
                    return true;
                }
            }

            _checkedColours[colour] = false;
            return false;
        }
    }
}

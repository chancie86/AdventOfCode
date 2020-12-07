using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public class Group
    {
        private readonly IList<Person> _people;

        public Group(string input)
        {
            var peopleInput = input.Split("\r\n");
            _people = peopleInput.Select(pi => new Person(pi)).ToList();
        }

        public int UnionCount
        {
            get
            {
                var set = new HashSet<char>();
                foreach (var person in _people)
                {
                    foreach (var answer in person)
                    {
                        set.Add(answer);
                    }
                }

                return set.Count;
            }
        }

        public int IntersectCount
        {
            get
            {
                IEnumerable<char> current = _people.First().ToList();

                for (var i = 1; i < _people.Count; i++)
                {
                    current = current.Intersect(_people[i]);
                }

                return current.Count();
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day6
{
    public class Person
        : ICollection<char>
    {
        public readonly ISet<char> Answers;

        public Person(string input)
        {
            Answers = input.ToHashSet();
        }

        public IEnumerator<char> GetEnumerator()
        {
            return Answers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(char item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(char item) => Answers.Contains(item);

        public void CopyTo(char[] array, int arrayIndex)
        {
            Answers.CopyTo(array, arrayIndex);
        }

        public bool Remove(char item)
        {
            throw new NotImplementedException();
        }

        public int Count => Answers.Count;
        public bool IsReadOnly => true;
    }
}

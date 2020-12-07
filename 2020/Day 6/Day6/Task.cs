using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day6
{
    public abstract class Task
    {
        private readonly string _testData;
        
        protected Task(string testData)
        {
            _testData = testData;
        }

        public int Result { get; protected set; }

        public abstract void Run();

        protected IList<Group> Parse()
        {
            return _testData.Split("\r\n\r\n").Select(ParseGroup).ToList();
        }

        private Group ParseGroup(string groupAnswers)
        {
            return new Group(groupAnswers);
        }

        public override string ToString()
        {
            return $"{Result}";
        }
    }
}

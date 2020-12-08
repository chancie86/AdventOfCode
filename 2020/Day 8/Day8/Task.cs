using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Day8
{
    public abstract class Task
    {
        protected Task(IList<string> testData)
        {
            TestData = new ReadOnlyCollection<string>(testData);
        }

        public int Result { get; protected set; }

        protected IReadOnlyList<string> TestData { get; }

        public abstract void Run();

        public override string ToString()
        {
            return $"{Result}";
        }
    }
}

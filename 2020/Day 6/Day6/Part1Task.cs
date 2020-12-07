using System.Linq;

namespace Day6
{
    public class Part1Task
        : Task
    {
        public Part1Task(string testData) : base(testData)
        {
        }

        public override void Run()
        {
            var groups = Parse();
            Result = groups.Sum(g => g.UnionCount);
        }
    }
}

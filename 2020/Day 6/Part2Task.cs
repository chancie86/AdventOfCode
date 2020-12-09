using System.Linq;

namespace Day6
{
    public class Part2Task
        : Task
    {
        public Part2Task(string testData) : base(testData)
        {
        }

        public override void Run()
        {
            var groups = Parse();
            Result = groups.Sum(g => g.IntersectCount);
        }
    }
}

using Day5;

var mode = Mode.Production;
string inputPath;

switch (mode)
{
    case Mode.Example:
        Debug = true;
        inputPath = "example.txt";
        break;
    case Mode.Test:
        Debug = true;
        inputPath = "tests.txt";
        break;
    case Mode.Production:
        Debug = false;
        inputPath = "input.txt";
        break;
    default:
        throw new Exception("Invalid mode");
}

var input = await File.ReadAllLinesAsync(inputPath);
var rules = new List<Rule>();
var updates = new List<List<int>>();

// Read the rules
int i;
for (i = 0; i < input.Length;)
{
    var line = input[i++];
    if (string.IsNullOrWhiteSpace(line))
    {
        break;
    }

    rules.Add(new Rule(line));
}


for (; i < input.Length; i++)
{
    var line = input[i];
    var update = line.Split(',').Select(int.Parse).ToList();
    updates.Add(update);
}

//Part1(rules, updates);
Part2(rules, updates);

public partial class Program
{
    private static bool Debug;

    public static void Part1(List<Rule> rules, List<List<int>> updates)
    {
        var result = 0;

        foreach (var update in updates)
        {
            if (rules.All(r => r.Validate(update)))
            {
                // Get middle number
                var middleIndex = update.Count / 2;
                result += update[middleIndex];
            }
        }

        Console.WriteLine(result);
    }

    public static void Part2(List<Rule> rules, List<List<int>> updates)
    {
        var result = 0;

        foreach (var update in updates)
        {
            var fixedUpdate = false;
            bool changed;

            do
            {
                changed = false;

                foreach (var rule in rules)
                {
                    if (!rule.Validate(update))
                    {
                        fixedUpdate = true;
                        changed = true;

                        // Fix the update
                        var first = update.IndexOf(rule.After);
                        var second = update.IndexOf(rule.Before);

                        // Put second before first
                        update.RemoveAt(second);
                        update.Insert(first, rule.Before);

                        break;
                    }
                }
            } while (changed);

            if (fixedUpdate)
            {
                // Get middle number
                var middleIndex = update.Count / 2;
                result += update[middleIndex];
            }
        }

        Console.WriteLine(result);
    }

    private enum Mode
    {
        Example,
        Test,
        Production
    }
}
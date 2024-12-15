using System.Text.RegularExpressions;

namespace src;

public class Day03
{
    public static int Process(string input)
    {
        var commands = Regex.Matches(input, @"mul\(\d+,\d+\)");

        return commands.Select(command => Mul(command.Value)).Sum();
    }
    public static int ProcessWithConditions(string input)
    {
        var mulEnabled = true;
        var commandsWithConditions = Regex.Matches(input, @"(mul\(\d+,\d+\))|(don't\(\))|(do\(\))");

        List<string> commandsToProcess = new List<string>();
        foreach (Match commandOrCondition in commandsWithConditions)
        {
            var value = commandOrCondition.Value;
            if(value.StartsWith("mul") && mulEnabled)
                commandsToProcess.Add(value);
            if (value.Equals("don't()"))
                mulEnabled = false;
            if (value.Equals("do()"))
                mulEnabled = true;
        }

        return commandsToProcess.Select(Mul).Sum();
    }

    public static int Mul(string command)
    {
        var match = Regex.Matches(command, @".*\((\d+),(\d+)\).*");

        var left = int.Parse(match[0].Groups[1].Value);
        var right = int.Parse(match[0].Groups[2].Value);

        return left * right;
    }
}
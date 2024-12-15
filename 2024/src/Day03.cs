using System.Text.RegularExpressions;

namespace src;

public class Day03
{
    public static int Process(string input)
    {
        var commands = Regex.Matches(input, @"mul\(\d+,\d+\)");

        return commands.Select(command => Mul(command.Value)).Sum();
    }

    public static int Mul(string command)
    {
        var match = Regex.Matches(command, @".*\((\d+),(\d+)\).*");

        var left = int.Parse(match[0].Groups[1].Value);
        var right = int.Parse(match[0].Groups[2].Value);

        return left * right;
    }
}
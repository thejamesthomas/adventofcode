using src;
using FluentAssertions;

public class Day01Tests
{
    [Fact]
    public void Test1()
    {
        Day01.test().Should().BeTrue();
    }
}

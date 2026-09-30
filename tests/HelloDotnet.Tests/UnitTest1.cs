using HelloDotnet;
using Xunit;

namespace HelloDotnet.Tests;

public class GreetingTests
{
    [Theory]
    [InlineData("GitHub", "Hello, GitHub!")]
    [InlineData("Привет", "Hello, Привет!")]
    public void GreetReturnsExpectedMessage(string name, string expected)
    {
        Assert.Equal(expected, Greeting.Greet(name));
    }

    [Theory]
    [InlineData(1, 10, 55L)]
    [InlineData(1, 100, 5050L)]
    [InlineData(-2, 2, 0L)]
    [InlineData(10, 1, 0L)]
    public void SumRangeReturnsExpectedSum(int from, int to, long expected)
    {
        Assert.Equal(expected, Greeting.SumRange(from, to));
    }
}

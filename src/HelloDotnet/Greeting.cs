namespace HelloDotnet;

public static class Greeting
{
    public static string Greet(string name)
    {
        return $"Hello, {name}!";
    }

    public static long SumRange(int from, int to)
    {
        long sum = 0;

        for (long i = from; i <= to; i++)
        {
            sum += i;
        }

        return sum;
    }
}

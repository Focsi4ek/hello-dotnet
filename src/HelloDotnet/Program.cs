using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using HelloDotnet;

Console.OutputEncoding = Encoding.UTF8;

var version = typeof(Greeting).Assembly
    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
    .InformationalVersion ?? "dev";

var os = OperatingSystem.IsWindows() ? "windows"
    : OperatingSystem.IsMacOS() ? "darwin"
    : OperatingSystem.IsLinux() ? "linux"
    : "unknown";

Console.WriteLine($"hello-dotnet version {version}");
Console.WriteLine("Hello from C#/.NET! 🚀");
Console.WriteLine($"OS: {os}");
Console.WriteLine($"Arch: {RuntimeInformation.OSArchitecture.ToString().ToLowerInvariant()}");
Console.WriteLine(Greeting.Greet("GitHub"));
Console.WriteLine($"Sum 1..10 = {Greeting.SumRange(1, 10)}");

if (args.Length > 0)
{
    Console.WriteLine("Аргументы:");

    for (var i = 0; i < args.Length; i++)
    {
        Console.WriteLine($"  {i + 1}: {args[i]}");
    }
}

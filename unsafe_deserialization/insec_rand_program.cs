// System.Security.Cryptography.RandomNumberGenerator
// https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.randomnumbergenerator.create?view=net-8.0
using System.Security.Cryptography;


public class Program
{
    private static Random privateUsedOnlyOnce = new Random();
    public static Random publicUsedOnlyOnce = new Random();
    private static Random privateUsedTwice = new Random();

    static void Main(string[] args)
    {
        System.Console.WriteLine(GeneratePasswordOneVarNoArgs());
        System.Console.WriteLine(GeneratePasswordOneVarOneArg());
        System.Console.WriteLine(GeneratePasswordOneVarTwoArgs());
        System.Console.WriteLine(GeneratePasswordTwoVarsNoArgs());
        System.Console.WriteLine(GeneratePasswordPrivateFieldUsedOnce());
        System.Console.WriteLine(GeneratePasswordPrivateFieldUsedTwice());
        System.Console.WriteLine(GeneratePasswordPublicField());
        System.Console.WriteLine(GeneratePasswordDirectCallNoBrackets());
        System.Console.WriteLine(GeneratePasswordDirectCallWithBrackets());
        System.Console.WriteLine(GeneratePasswordCustomerLikeComplexExample());
        System.Console.WriteLine(GeneratePasswordSafe());
        System.Console.WriteLine(privateUsedTwice.Next());
    }

    static string GeneratePasswordOneVarNoArgs()
    {
        Random gen = new Random();
        string password = "mypassword" + gen.Next();

        return password;
    }

    static string GeneratePasswordOneVarOneArg()
    {
        Random gen = new Random();
        string password = "mypassword" + gen.Next(1000);

        return password;
    }

    static string GeneratePasswordOneVarTwoArgs()
    {
        Random gen = new Random();
        string password = "mypassword" + gen.Next(1000, 9999);

        return password;
    }

    static string GeneratePasswordTwoVarsNoArgs()
    {
        var gen = new Random();
        var a = "my" + gen.Next();
        var b = "password" + gen.Next();

        return a + b;
    }

    static string GeneratePasswordPrivateFieldUsedOnce()
    {
        return "mypassword" + privateUsedOnlyOnce.Next();
    }

    static string GeneratePasswordPrivateFieldUsedTwice()
    {
        return "mypassword" + privateUsedTwice.Next();
    }

    static string GeneratePasswordPublicField()
    {
        return "mypassword" + publicUsedOnlyOnce.Next();
    }

    static string GeneratePasswordDirectCallNoBrackets()
    {
        return "mypassword" + new Random().Next();
    }

    static string GeneratePasswordDirectCallWithBrackets()
    {
        return "mypassword" + (new Random()).Next();
    }

    private static Task GeneratePasswordCustomerLikeComplexExample(int a = 5)
    {
        Random rand = new Random();
        return Task.Run(() => TimeSpan.FromSeconds(Math.Pow(2, a))
                          + TimeSpan.FromMilliseconds(rand.Next(0, 1000)));
    }

    static string GeneratePasswordSafe()
    {
        return "mypassword" + RandomNumberGenerator.GetInt32(Int32.MaxValue);
    }
}

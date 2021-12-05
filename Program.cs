using Newtonsoft.Json;
using RestSharp;
using System.Configuration;

namespace RestSharpConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UsingRestsharp.CallTest();
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}


using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace _01._24;
public class FetchNumbers
{
    //A "Task" is an asynchronous operation which will run in the background without blocking the rest of the program.
    public static async Task FetchNumbersFromAoC()
    {
        if (!File.Exists("aoc_input.txt"))
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Go 3 levels up from bin/Debug/net9.0 (had issues with finding the .env file)
            string filePath = Path.Combine(baseDirectory, "..", "..", "..", ".env");

            filePath = Path.GetFullPath(filePath);
            EnvReader.Load(filePath);

            var url = Environment.GetEnvironmentVariable("URL");
            var sessionCookie = Environment.GetEnvironmentVariable("SESSION_COOKIE");

            // Client-handler to handle cookies
            var handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();
            handler.CookieContainer.Add(new Uri("https://adventofcode.com"), new Cookie("session", sessionCookie));

            using (HttpClient client = new HttpClient(handler))
            {
                try
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

                    string input = await client.GetStringAsync(url);

                    await File.WriteAllTextAsync("aoc_input.txt", input);

                    Console.WriteLine("Input is successfully fetched and saved into aoc_input.txt!");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error while downloading information: {ex.Message}");
                }
            }
        }
    }
}
namespace code;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;

public class Program
{
  public static string host { get; } = "https://adventofcode.com/";
  public static string path { get; } = "2022/day/3/input";
  public static string cookie { get; } = "";

  public Dictionary<char, int> priorities = new Dictionary<char, int>();
  public Program()
  {
    priorities.Add('\'', 0);
    var priority = 1;
    for (char i = 'a'; i <= 'z'; i++)
    {
      priorities.Add(i, priority);
      priority++;
    }
    for (char i = 'A'; i <= 'Z'; i++)
    {
      priorities.Add(i, priority);
      priority++;
    }
  }

  public async static Task Main(String[] args)
  {
    Program p = new Program();
    var input = await p.GetInput();
    Console.WriteLine($"Part 1\v{p.calculatePart1(input)}");
    Console.WriteLine($"Part 2\v{p.calculatePart2(input)}");
  }

  private Task<String> GetInput()
  {
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri(host);
    client.DefaultRequestHeaders.Add("Cookie", cookie);
    return client.GetStringAsync(path);
  }

  public int calculatePart1(String input)
  {
    return input.Split("\n")
    .Select(x => (x.Take(x.Length / 2), x.Skip(x.Length / 2)))
    .Aggregate(0, (cur, compartments) => findFirstAndGetPriority(cur, compartments.Item1, compartments.Item2.Contains));
  }

  public int calculatePart2(String input)
  {
    return input.Split("\n")
    .Select((rucksack, i) => new { rucksack, group = i / 3 })
    .GroupBy(x => x.group)
    .Select(group => group.Select(x => x.rucksack).ToArray())
    .Aggregate(0, (cur, group) => findFirstAndGetPriority(cur, group[0], c => group[1].Contains(c) && group[2].Contains(c)));
  }

  private int findFirstAndGetPriority(int current, IEnumerable<char> first, Func<char, bool> predicate)
  {
    return current + priorities[first.FirstOrDefault(predicate,'\'')];
  }
}

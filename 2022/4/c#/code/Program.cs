namespace code;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;

public class Program
{
  public static string host { get; } = "https://adventofcode.com/";
  public static string path { get; } = "2022/day/4/input";
  public static string cookie { get; } = "";

  public Program(){}

  public async static Task Main(String[] args)
  {
    Program p = new Program();
    var input = await p.GetInput();
    Console.WriteLine($"Part 1 {p.calculatePart1(input)}");
    Console.WriteLine($"Part 2 {p.calculatePart2(input)}");
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
    return transformInput(input)
      .Aggregate(0, (set, pair) => {
        var (x,y) = pair;
        if(x.SequenceContainsSubset(y) || y.SequenceContainsSubset(x)) return set + 1;
        else return set;
      });
  }

  public int calculatePart2(String input)
  {
    return transformInput(input)
      .Aggregate(0, (set, pair) => {
        var (x,y) = pair;
        if(x.SequenceContainsPartialSubset(y) || y.SequenceContainsPartialSubset(x)) return set + 1;
        return set;
      });
  }

  private IEnumerable<(IEnumerable<int>, IEnumerable<int>)> transformInput(String input){
    return input.Trim().Split("\n")
      .Select(pair => pair.Split(","))
      .Select(pair => (makeRange(pair.First().Split("-")), makeRange(pair.Last().Split("-"))));
  }

  private IEnumerable<int> makeRange(String[] startEnd){
      int start = int.Parse(startEnd[0]);
      int end = int.Parse(startEnd[1]);
      return makeRange(start, end);
  }
  private IEnumerable<int> makeRange(int start, int end){
      return Enumerable.Range(start, (end - start) + 1);
  }
}

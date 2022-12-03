namespace code;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;

public class Program
{
  public static string host { get; } = "https://adventofcode.com/";
  public static string path { get; } = "2022/day/2/input";
  public static string cookie { get; } = "";

  public Dictionary<int, char[]> choiceScore = new Dictionary<int, char[]>();
  public Dictionary<char[], bool?> truth = new Dictionary<char[], bool?>(new CharArrayComparer());
  public Dictionary<int, bool?> roundBonus = new Dictionary<int, bool?>();
  public Program()
  {
    choiceScore.Add(1, new[] { 'A', 'X' });
    choiceScore.Add(2,  new[] { 'B', 'Y' });
    choiceScore.Add(3, new[] { 'C', 'Z' });

    truth.Add(new[] { 'A', 'X' }, null);
    truth.Add(new[] { 'A', 'Z' }, false);
    truth.Add(new[] { 'A', 'Y' }, true); 

    truth.Add(new[] { 'B', 'Y' }, null);
    truth.Add(new[] { 'B', 'X' }, false);
    truth.Add(new[] { 'B', 'Z' }, true);

    truth.Add(new[] { 'C', 'Z' }, null);
    truth.Add(new[] { 'C', 'Y' }, false);
    truth.Add(new[] { 'C', 'X' }, true);

    roundBonus.Add(3, null);
    roundBonus.Add(6, true);
    roundBonus.Add(0, false);
  }

  public async static Task Main(String[] args)
  {
    Program p = new Program();
    var input = await p.GetInput();
    Console.WriteLine($"Sum of scores\v{p.calculatePart1(input)}");
    Console.WriteLine($"Sum of correct scores\v{p.calculatePart2(input)}");
  }

  private Task<String> GetInput()
  {
    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri(host);
    client.DefaultRequestHeaders.Add("Cookie", cookie);
    return client.GetStringAsync(path);
  }

  public int calculatePart1(string input)
  {
    return input.Trim().Split("\n")
                .Select(x => x.Replace(" ", "").ToUpperInvariant().ToCharArray())
                .Aggregate(0, (cur, game) => cur + calculateScore(game));
  }

  public int calculatePart2(string input)
  {
    return input.Trim().Split("\n")
                .Select(x => x.Replace(" ", "").ToUpperInvariant().ToCharArray())
                .Select(replaceToAchieve)
                .Aggregate(0, (cur, game) => cur +  calculateScore(game));
  }

  private int calculateScore(char[] chars)
  {
    var outcome = truth[chars]; // a possible keyNotDfound here -- if you dont have a full truth table.
    var bonus = roundBonus.Where(x => x.Value == outcome).First().Key;
    var score = choiceScore.Where(x => x.Value.Contains(chars[1])).First().Key;
    return bonus + score;
  }

  private char[] replaceToAchieve(char[] chars)
  {
    bool? goal;
    if (chars[1] == 'X') goal = false; else if (chars[1] == 'Y') goal = null; else goal = true;
    chars[1] = truth.Where(x => x.Key.Contains(chars[0]) && x.Value == goal).Select(x => x.Key[1]).First();
    return chars;
  }

  class CharArrayComparer : IEqualityComparer<char[]>
  {
    public bool Equals(char[] x, char[] y) => x.SequenceEqual(y);

    public int GetHashCode(char[] obj)
    {
      unchecked // possible overflow
      {
        int hash = 17;
        foreach (char character in obj)
        {
          hash = hash * 31 + character.GetHashCode();
        }

        return hash;
      }
    }
  }
}

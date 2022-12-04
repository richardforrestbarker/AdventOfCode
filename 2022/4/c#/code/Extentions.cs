

namespace code;

  public static class Extensions {
    public static bool SequenceContainsSubset<T>(this IEnumerable<T> sequence, IEnumerable<T> possibleSubset){
      return sequence.All(x => possibleSubset.Contains(x));
    }

    public static bool SequenceContainsPartialSubset<T>(this IEnumerable<T> sequence, IEnumerable<T> possibleSubset){
      return sequence.Any(x => possibleSubset.Contains(x));
    }
  }
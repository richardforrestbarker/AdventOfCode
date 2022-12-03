using Xunit;
using code;
using System;
using System.Collections.Generic;

namespace test;

public class UnitTest1
{

    Program subject ;
    public UnitTest1(){
        subject = new Program();
    }

    [Theory]
    [ClassData(typeof(RucksackTestData))]
    public void Test1(string input, int sum)
    {
        Assert.Equal(sum, subject.calculatePart1(input));
    }

    [Theory]
    [ClassData(typeof(BadgeTestData))]
    public void Test2(string input, int sum)
    {
        Assert.Equal(sum, subject.calculatePart2(input));
    }


    private class BadgeTestData : IEnumerable<object[]>
    {



        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg",  18  };
            yield return new object[] { "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw",  52  };
            yield return new object[] { "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw",  70  };
            
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
        throw new NotImplementedException();
        }
    }

    private class RucksackTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "vJrwpWtwJgWrhcsFMMfFFhFp",  16  };
            yield return new object[] { "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 38  };
            yield return new object[] { "PmmdzqPrVvPwwTWBwg", 42  };
            yield return new object[] { "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 22  };
            yield return new object[] { "ttgJtRGJQctTZtZT", 20  };
            yield return new object[] { "CrZsJsPPZsGzwwsLwLmpwMDw", 19  };
            yield return new object[] { "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg", 96  };
            yield return new object[] { "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw", 157 };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
        throw new NotImplementedException();
        }
  }
}
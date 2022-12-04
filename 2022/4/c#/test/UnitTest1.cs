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
    [ClassData(typeof(PairsTestData))]
    public void Test1(string input, int sum)
    {
        Assert.Equal(sum, subject.calculatePart1(input));
    }

    [Theory]
    [ClassData(typeof(Pairs2TestData))]
    public void Test2(string input, int sum)
    {
        Assert.Equal(sum, subject.calculatePart2(input));
    }


    private class PairsTestData : IEnumerable<object[]>
    {



        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8",  2 };
            yield return new object[] { "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8\n2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8",  4 };
            
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
        throw new NotImplementedException();
        }
    }

    private class Pairs2TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8",  4 };
            yield return new object[] { "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8\n2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8",  8 };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
        throw new NotImplementedException();
        }
  }
}
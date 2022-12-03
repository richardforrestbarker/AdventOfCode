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
    [ClassData(typeof(TestInputData))]
    public void Test1(string input, int sum)
    {
        Assert.Equal(sum, subject.calculatePart1(input));
    }

    [Theory]
    [ClassData(typeof(Test2InputData))]
    public void Test2(string input, int sum)
    {
        Assert.Equal(sum, subject.calculatePart2(input));
    }


    private class TestInputData : IEnumerable<object[]>
    {



        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "A Y\nB X\nC Z",  15  };
            yield return new object[] { "A Y\nB X\nC Z\nA Y\nB X\nC Z",  30  };
            yield return new object[] { "A X\nB Y\nC Z", 15  };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
        throw new NotImplementedException();
        }
    }

        private class Test2InputData : IEnumerable<object[]>
    {



        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "A Y\nB X\nC Z",  12  };
            yield return new object[] { "A Y\nB X\nC Z\nA Y\nB X\nC Z",  24  };
            yield return new object[] { "A Y\nB Y\nC Y", 15  };
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
        throw new NotImplementedException();
        }
    }

}
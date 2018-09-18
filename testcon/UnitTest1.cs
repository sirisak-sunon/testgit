using System;
using Xunit;
using cons;

namespace testcon
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1,2,3)]
        public void PassingTest(int n1 , int n2 , int expectedResult){
            var x = new Program();
            var y = x.add(n1 , n2);
            Assert.Equal(expectedResult , y);
        }

        [Theory]
        [InlineData(1,2,-1)]
        public void PassingTest2(int n1 , int n2 , int expectedResult){
            var x = new Program();
            var y = x.minus(n1 , n2);
            Assert.Equal(expectedResult , y);
        }

        [Theory]
        [InlineData(1,2,2)]

        public void PassingTest3(int n1 , int n2 , int expectedResult){
            var x = new Program();
            var y = x.multiply(n1 , n2);
            Assert.Equal(expectedResult , y);
        }

        [Theory]
        [InlineData(7,2,3)]

        public void PassingTest4(int n1 , int n2 , int expectedResult){
            var x = new Program();
            var y = x.divide(n1 , n2);
            Assert.Equal(expectedResult , y);
        }
    }
}

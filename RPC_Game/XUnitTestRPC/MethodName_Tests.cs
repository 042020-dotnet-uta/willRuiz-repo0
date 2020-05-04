//using RPC_Game;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestRPC
{
    public class MethodName_Tests
    {
        private readonly RPC_Game.Player _sut;   //system under test

        public MethodName_Tests()
        {
            _sut = new RPC_Game.Player();
        }
        [Fact(Skip = "This test is broken") ] //Fact method cannot have params...Example to skip a test

        public void AddTwoNumbersMakeSureTheyAreEqual()
        {
            _sut.Equals(4);
            Assert.Equal(4, 4);
        }
        [Theory] //Theory methods must have test data + can have params
        [InlineData(5,5)]
        [InlineData(-5, -5)]
        [InlineData(45, 45)]
        public void AddTwoNumbersMakeSureTheyAreEqual2(int num, int expected)
        {
            _sut.Equals(num);
            Assert.Equal(expected, num);
        }
    }
}

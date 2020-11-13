using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MartianRobots.Tests
{
    public class RobotManagerTests
    {
        [Fact]
        public void CrossFunctionalPositiveTest()
        {
            var data = @"5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL";
            var expected = @"1 1 E
3 3 N LOST
2 3 S";

            var parsed = InputData.TryParse(data, out var input);

            Assert.True(parsed);

            var output = new RobotManager().Run(input);
            var actual = output.ToString();

            Assert.Equal(expected, actual);
        }
    }
}

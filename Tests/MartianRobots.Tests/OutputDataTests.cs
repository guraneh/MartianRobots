using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MartianRobots.Tests
{
    public class OutputDataTests
    {
        [Fact]
        public void CheckToString()
        {
            var data = new OutputData
            {
                Robots = new List<RobotInfo>
                {
                    new RobotInfo(1, 1, Direction.E),
                    new RobotInfo(3, 3, Direction.N)
                    {
                        IsLost = true
                    },
                    new RobotInfo(2, 3, Direction.S)
                }
            };

            var expected = @"1 1 E
3 3 N LOST
2 3 S";

            var actual = data.ToString();

            Assert.Equal(expected, actual);
        }
    }
}

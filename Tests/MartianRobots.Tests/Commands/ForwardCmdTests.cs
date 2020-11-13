using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MartianRobots.Commands;
using Xunit;

namespace MartianRobots.Tests.Commands
{
    public class ForwardCmdTests
    {
        [Fact]
        public void ForwardInPlace()
        {
            var robot = new RobotInfo(1, 1, Direction.N);
            var context = new Context(2, 2);

            new ForwardCmd().Execute(context, robot);

            Assert.Equal(new Point(1, 2), robot.Position);
            Assert.Equal(Direction.N, robot.Direction);
            Assert.False(robot.IsLost);
        }

        [Fact]
        public void ForwardOutPlace()
        {
            var robot = new RobotInfo(1, 2, Direction.N);
            var context = new Context(2, 2);

            new ForwardCmd().Execute(context, robot);

            Assert.True(robot.IsLost);
        }

        [Fact]
        public void ForwardFromScentPoint()
        {
            var robot = new RobotInfo(1, 2, Direction.N);
            var context = new Context(2, 2)
            {
                ScentPoints = new List<(Point, Direction)>
                {
                    (new Point(1, 2), Direction.N)
                }
            };

            new ForwardCmd().Execute(context, robot);

            Assert.False(robot.IsLost);
            Assert.Equal(new Point(1, 2), robot.Position);
            Assert.Equal(Direction.N, robot.Direction);
        }

        [Fact]
        public void ForwardFromScentPoint_AnotherDirection()
        {
            var robot = new RobotInfo(2, 2, Direction.N);
            var context = new Context(2, 2)
            {
                ScentPoints = new List<(Point, Direction)>
                {
                    (new Point(1, 2), Direction.E)
                }
            };

            new ForwardCmd().Execute(context, robot);

            Assert.True(robot.IsLost);
        }
    }
}

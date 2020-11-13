using System;
using Xunit;
using MartianRobots;
using System.Linq;
using System.Drawing;

namespace MartianRobots.Tests
{
    public class InputDataTests
    {
        [Fact]
        public void ParseCorrect()
        {
            var data = @"5 3
1 1 E
RFRFRFRF
3 2 N
FRRFLLFFRRFLL
0 3 W
LLFFFLFLFL";

            var boolRes = InputData.TryParse(data, out var actual);

            Assert.True(boolRes);
            Assert.Equal(5, actual.MaxX);
            Assert.Equal(3, actual.MaxY);
            Assert.Equal(3, actual.Robots.Count);

            Assert.Equal(new Point(1, 1), actual.Robots[0].StartInfo.Position);
            Assert.Equal(Direction.E, actual.Robots[0].StartInfo.Direction);
            Assert.Equal("RFRFRFRF", string.Join("", actual.Robots[0].Commands.Select(x => x.ToString())));

            Assert.Equal(new Point(3, 2), actual.Robots[1].StartInfo.Position);
            Assert.Equal(Direction.N, actual.Robots[1].StartInfo.Direction);
            Assert.Equal("FRRFLLFFRRFLL", string.Join("", actual.Robots[1].Commands.Select(x => x.ToString())));

            Assert.Equal(new Point(0, 3), actual.Robots[2].StartInfo.Position);
            Assert.Equal(Direction.W, actual.Robots[2].StartInfo.Direction);
            Assert.Equal("LLFFFLFLFL", string.Join("", actual.Robots[2].Commands.Select(x => x.ToString())));
        }

        [Fact]
        public void CheckMaxValueForCoors_XOnBound()
        {
            var data = @"50 3";

            var boolRes = InputData.TryParse(data, out var actual);

            Assert.True(boolRes);
            Assert.Equal(50, actual.MaxX);
            Assert.Equal(3, actual.MaxY);
        }


        [Fact]
        public void CheckMaxValueForCoors_XOverBound()
        {
            var data = @"51 3";

            var boolRes = InputData.TryParse(data, out var actual);

            Assert.False(boolRes);
       }

        [Fact]
        public void CheckRobotPosition_Negative()
        {
            var data = @"5 3
-1 1 E
RFRFRFRF";

            var boolRes = InputData.TryParse(data, out var actual);

            Assert.False(boolRes);
        }

        [Fact]
        public void CheckRobotPosition_OverBound()
        {
            var data = @"5 3
10 1 E
RFRFRFRF";

            var boolRes = InputData.TryParse(data, out var actual);

            Assert.False(boolRes);
        }

        [Fact]
        public void CheckCmdCount_OnBound()
        {
            var data = @"5 3
1 1 E";
            data += Environment.NewLine
                + new string('F', 100);

            var boolRes = InputData.TryParse(data, out var actual);

            Assert.True(boolRes);
            Assert.Equal(100, actual.Robots[0].Commands.Count);
        }

        [Fact]
        public void CheckCmdCount_OverBound()
        {
            var data = @"5 3
1 1 E";
            data += Environment.NewLine
                + new string('F', 101);

            var boolRes = InputData.TryParse(data, out var actual);

            Assert.False(boolRes);
        }
    }
}

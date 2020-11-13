using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MartianRobots.Tests
{
    public class CommandTests
    {
        [Fact]
        public void CheckCommandList()
        {
            foreach (var item in Enum.GetValues(typeof(CommandAlias)))
            {
                var cmd = Command.Get((CommandAlias)item);

                Assert.NotNull(cmd);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Commands
{
    [Alias(CommandAlias.L)]
    public class LeftCmd : Command
    {
        public override void Execute(Context context, RobotInfo robot)
        {
            robot.Direction = robot.Direction switch
            {
                Direction.N => Direction.W,
                Direction.E => Direction.N,
                Direction.S => Direction.E,
                Direction.W => Direction.S,
                _ => throw new UnknownDirectionException(robot.Direction)
            };
        }
    }
}

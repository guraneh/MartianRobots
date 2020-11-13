using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Commands
{
    [Alias(CommandAlias.R)]
    public class RightCmd : Command
    {
        public override void Execute(Context context, RobotInfo robot)
        {
            robot.Direction = robot.Direction switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => throw new UnknownDirectionException(robot.Direction)
            };
        }
    }
}

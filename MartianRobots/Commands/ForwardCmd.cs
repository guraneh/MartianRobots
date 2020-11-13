using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MartianRobots.Commands
{
    [Alias(CommandAlias.F)]
    public class ForwardCmd : Command
    {
        public override void Execute(Context context, RobotInfo robot)
        {
            var targetPoint = robot.Direction switch
            {
                Direction.N => Point.Add(robot.Position, new Size(0, 1)),
                Direction.E => Point.Add(robot.Position, new Size(1, 0)),
                Direction.S => Point.Add(robot.Position, new Size(0, -1)),
                Direction.W => Point.Add(robot.Position, new Size(-1, 0)),
                _ => throw new UnknownDirectionException(robot.Direction)
            };

            if (!context.Place.Contains(targetPoint))
            {
                if (context.ScentPoints.Contains((robot.Position, robot.Direction)))
                    return;

                context.ScentPoints.Add((robot.Position, robot.Direction));
                robot.IsLost = true;
                return;
            }

            robot.Position = targetPoint;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots
{
    public class RobotManager
    {
        public OutputData Run(InputData input)
        {
            var result = new OutputData();
            var context = Context.Create(input);

            foreach (var task in input.Robots)
            {
                var robot = task.StartInfo.Clone();

                foreach (var cmdAlias in task.Commands)
                {
                    var cmd = Command.Get(cmdAlias);
                    cmd.Execute(context, robot);
                    if (robot.IsLost)
                        break;
                }

                result.Robots.Add(robot);
            }

            return result;
        }
    }
}

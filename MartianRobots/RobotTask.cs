using System.Collections.Generic;

namespace MartianRobots
{
    public class RobotTask
    {
        public RobotInfo StartInfo { get; set; }

        public List<CommandAlias> Commands { get; set; } = new List<CommandAlias>();
    }
}
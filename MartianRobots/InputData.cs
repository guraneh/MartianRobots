using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MartianRobots
{
    public class InputData
    {
        public const int MaxCmdCount = 100;

        public const int MaxPlaceSize = 50;

        public int MaxX { get; set; }

        public int MaxY { get; set; }

        public List<RobotTask> Robots { get; set; } = new List<RobotTask>();

        public static bool TryParse(string rawData, out InputData result)
        {
            result = null;
            var lines = rawData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length % 2 != 1)
                return false;

            var maxCoors = new Regex(@"^\s*(\d+)\s+(\d+)\s*$").Match(lines[0]);

            if (!maxCoors.Success)
                return false;

            var parsedData = new InputData
            {
                MaxX = int.Parse(maxCoors.Groups[1].Value),
                MaxY = int.Parse(maxCoors.Groups[2].Value)
            };

            if (parsedData.MaxX > MaxPlaceSize || parsedData.MaxY > MaxPlaceSize)
                return false;

            var positionRegex = new Regex($@"^\s*(\d+)\s+(\d+)\s+([{string.Join("", Enum.GetNames(typeof(Direction)))}])\s*$");
            var cmdRegex = new Regex($@"^\s*([{string.Join("", Enum.GetNames(typeof(CommandAlias)))}]*)\s*$");
            for (int i = 1; i < lines.Length; i += 2)
            {
                var robotPosition = positionRegex.Match(lines[i]);

                if (!robotPosition.Success)
                    return false;

                var robotTask = new RobotTask
                {
                    StartInfo = new RobotInfo(
                        int.Parse(robotPosition.Groups[1].Value),
                        int.Parse(robotPosition.Groups[2].Value),
                        Enum.Parse<Direction>(robotPosition.Groups[3].Value))
                };

                if (robotTask.StartInfo.Position.X > parsedData.MaxX
                    || robotTask.StartInfo.Position.Y > parsedData.MaxY)
                    return false;

                var robotCmd = cmdRegex.Match(lines[i + 1]);

                if (!robotCmd.Success || robotCmd.Groups[1].Value.Length > MaxCmdCount)
                    return false;

                robotTask.Commands.AddRange(
                    robotCmd.Groups[1].Value.Select(x => Enum.Parse<CommandAlias>(x.ToString())));

                parsedData.Robots.Add(robotTask);
            }

            result = parsedData;
            return true;
        }
    }
}

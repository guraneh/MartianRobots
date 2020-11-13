using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots
{
    public class UnknownDirectionException : Exception
    {
        public Direction Direction { get; set; }

        public UnknownDirectionException(Direction val) : base($"There is unknown direction value: \"{val}\"")
        {
            Direction = val;
        }
    }

    public class WrongCommandImplementationException : Exception
    {
        public WrongCommandImplementationException() { }
        public WrongCommandImplementationException(string message) : base(message) { }
    }
}

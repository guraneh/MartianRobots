using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MartianRobots
{
    public abstract class Command
    {
        private static Dictionary<CommandAlias, Command> _commands;
        public abstract void Execute(Context context, RobotInfo robot);

        static Command()
        {
            _commands = InitCommands();
        }

        private static Dictionary<CommandAlias, Command> InitCommands()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var commands = assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Command)))
                .Select(x =>
                {
                    var attr = x.GetCustomAttribute(typeof(AliasAttribute)) as AliasAttribute;
                    return new
                    {
                        Alias = attr?.Alias,
                        CommandType = x
                    };
                })
                .Where(x => x.Alias != null)
                .GroupBy(x => x.Alias, x => x.CommandType);

            if (commands.Any(x => x.Count() != 1))
                throw new WrongCommandImplementationException("More than one command for alias are found");

            if (commands.Count() != Enum.GetNames(typeof(CommandAlias)).Length)
                throw new WrongCommandImplementationException("Threre are commands with no implementation");

            return commands.ToDictionary(x => x.Key.Value, x => (Command)Activator.CreateInstance(x.Single()));
        }

        public static Command Get(CommandAlias alias)
        {
            return _commands[alias];
        }
    }
}
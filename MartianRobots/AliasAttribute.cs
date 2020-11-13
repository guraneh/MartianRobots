using System;

namespace MartianRobots
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class AliasAttribute : Attribute
    {
        public CommandAlias Alias { get; private set; }

        public AliasAttribute(CommandAlias alias)
        {
            Alias = alias;
        }
    }
}

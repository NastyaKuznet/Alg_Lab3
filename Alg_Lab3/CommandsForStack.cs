using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3
{
    public class CommandsForStack
    {
        public Commands Command { get; set; }
        public string Value { get; set; }

        public CommandsForStack(Commands command, string value = null) 
        { 
            this.Command = command;
            this.Value = value;
        }
       
    }

    public enum Commands
    {
        PUSH,
        POP,
        TOP,
        ISEMPTY,
        PRINT
    }
}

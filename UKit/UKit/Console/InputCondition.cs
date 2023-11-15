using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKit.Console
{
    public delegate bool Condition<T>(T comparableValue);

    public class InputCondition<T>
    {
        public string CommentMessage { get; set; }
        public Condition<T> IsSuit { get; set; }
    }
}

using Godot;
using System.Runtime.CompilerServices;

namespace CMC.DevelopmentTools
{
    public static class DevTools
    {
        public static void NullCheck<T>(T value, [CallerArgumentExpression("value")] string name = null)
        {
            if (value == null)
            { GD.PushError($"Argument '{name}' is null."); }
            else
            { GD.Print($"2 Argument '{name}' is not null"); }
        }
    }
}
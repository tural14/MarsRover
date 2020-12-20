using System.ComponentModel;

namespace MarsRover.Application.Common
{
    public enum Directions
    {
        [Description("North")]
        N = 1,
        [Description("Esat")]
        E = 2,
        [Description("South")]
        S = 3,
        [Description("West")]
        W = 4
    }
}
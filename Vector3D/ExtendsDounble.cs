using static System.Math;

namespace Vectors3D
{
    static public class ExtendedDounble
    {
        static public bool IsIdentical ( this double source, double target, double negligibleDifference )
        {
            return double.IsNaN( source ) && double.IsNaN( target ) ? true : Abs( source - target ) < negligibleDifference;
        }
    }
}

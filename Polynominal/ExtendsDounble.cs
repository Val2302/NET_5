using static System.Math;

namespace Polynominal
{
    static public class ExtendedDounble
    {
        static public bool IsIdentical ( this double source, double target, double negligibleDifference = 0.1 )
        {
			var isNan = double.IsNaN( source ) && double.IsNaN( target );
			return isNan ? true : Abs( source - target ) < negligibleDifference;
        }
    }
}

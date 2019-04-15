using System;
using System.Linq;
using static System.Math;

namespace Vectors3D
{
    public class Vector3D
    {
        private const int dimension = 3;
        private double[ ] coordinats;

        public double X => coordinats[ 0 ];
        public double Y => coordinats[ 1 ];
        public double Z => coordinats[ 2 ];

        public Vector3D ( )
        {
            coordinats = new Double[ dimension ];
        }

        public Vector3D ( double x, double y, double z ) : this( )
        {
            coordinats[ 0 ] = x;
            coordinats[ 1 ] = y;
            coordinats[ 2 ] = z;
        }

        public Vector3D ( Vector3D vector )
        {
            coordinats = vector.coordinats.Clone( ) as Double [ ];
        }

        public double Length ( )
        {
            return Sqrt( coordinats.Sum( x => x * x ) );
        }

        static public Vector3D operator + ( Vector3D vectorA, Vector3D vectorB )
        {
            if ( vectorA is null && vectorB is null )
            {
                throw new ArgumentNullException( "Vectors is null in operator vectors sum" );
            }

            var result = new Vector3D
            {
                coordinats = vectorA.coordinats.Zip(
                    vectorB.coordinats,
                    ( first, second ) => first + second
                ).ToArray( )
            };

            return result;
        }

        static public Vector3D operator - ( Vector3D vectorA, Vector3D vectorB )
        {
            if ( vectorA is null && vectorB is null )
            {
                throw new ArgumentNullException( "Vectors is null in operator vectors diff" );
            }

            var result = new Vector3D
            {
                coordinats = vectorA.coordinats.Zip(
                    vectorB.coordinats,
                    ( first, second ) => first - second
                ).ToArray( )
            };

            return result;
        }

        static public Vector3D operator * ( Vector3D vector, double number )
        {
            if ( vector is null )
            {
                throw new ArgumentNullException( "Vector is null in operator vector mull to number" );
            }

            var result = new Vector3D
            {
                coordinats = vector.coordinats.Select(
                    ( first ) => first * number
                ).ToArray( )
            };

            return result;
        }

        static public double operator * ( Vector3D vectorA, Vector3D vectorB )
        {
            if ( vectorA is null && vectorB is null )
            {
                throw new ArgumentNullException( "Vectors is null in operator vectors mull" );
            }

            return vectorA.coordinats.Zip(
                vectorB.coordinats,
                ( first, second ) => first * second
            ).Sum( );
        }

        static public Vector3D operator / ( Vector3D vector, double number )
        {
            if ( vector is null )
            {
                throw new ArgumentNullException( "Vector is null in operator vector div to number" );
            }

            if ( number == 0 )
            {
                throw new DivideByZeroException( "Divide by zero in operator vector div to number" );
            }

            var result = new Vector3D
            {
                coordinats = vector.coordinats.Select(
                    ( first ) => first / number
                ).ToArray( )
            };

            return result;
        }

        static public double operator ^ ( Vector3D vectorA, Vector3D vectorB )
        {
            if ( vectorA is null && vectorB is null )
            {
                throw new ArgumentNullException( "Vectors is null in operator angle between vectors" );
            }

            return Acos( vectorA * vectorB / ( vectorA.Length( ) * vectorB.Length( ) ) );
        }

        static public bool operator == ( Vector3D vectorA, Vector3D vectorB )
        {
            if ( vectorA is null && vectorB is null )
            {
                throw new ArgumentNullException( "Vectors is null in operator vectors compare" );
            }

            return vectorA.Equals( vectorB );
        }

        static public bool operator != ( Vector3D vectorA, Vector3D vectorB )
        {
            if ( vectorA is null && vectorB is null )
            {
                throw new ArgumentNullException( "Vectors is null in operator vectors not compare" );
            }

            return !vectorA.Equals( vectorB );
        }

        public override bool Equals ( object obj )
        {
            if ( obj != null || obj is Vector3D )
            {
                var vector = obj as Vector3D;
                return coordinats.Zip(
                    vector.coordinats,
                    ( first, second ) => first == second
                ).Count( x => x == true ) == dimension;
            }

            return false;
        }

        public override int GetHashCode ( )
        {
            return base.GetHashCode( );
        }

        public override string ToString ( )
        {
            return $"Vector3D {{ {X} ; {Y} ; {Z} }}";
        }
    }
}

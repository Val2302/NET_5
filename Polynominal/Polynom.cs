using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static Polynominal.ForKeyValuePairFunction;

namespace Polynominal
{
	public class Polynom : Dictionary<int, double>
	{
		public Polynom ( ) : base( )
		{

		}

		public Polynom ( IDictionary<int, double> iDictionary ) : base( iDictionary )
		{

		}

		public Polynom ( Polynom polynom ) : base( polynom )
		{

		}

		public void Add ( KeyValuePair<int, double> keyValuePair )
		{
			Add( keyValuePair.Key, keyValuePair.Value );
		}

		public double Calculate ( double variable )
		{
			return this.Sum( p => ForKeyValuePairFunction.Calculate( p, variable ) );
		}

		static public Polynom operator + ( Polynom polynomA, Polynom polynomB )
		{
			if ( polynomA is null || polynomB is null )
			{
				throw new ArgumentNullException( "In operator Sum of Polynom arguments is null" );
			}

			return new Polynom( polynomA.Zip( 
				polynomB,
				( first, second ) => Sum( first, second )
			).ToDictionary( x => x.Key, x => x.Value ) );
		}
		
		static public Polynom operator - ( Polynom polynomA, Polynom polynomB )
		{
			if ( polynomA is null || polynomB is null )
			{
				throw new ArgumentNullException( "In operator Dif of Polynom arguments is null" );
			}

			var negativePolynominal = polynomB.Select(
				m => new KeyValuePair<int, double>( m.Key, -m.Value )
			);

			return new Polynom( polynomA.Zip( 
				negativePolynominal,
				( first, second ) => Sum( first, second )
			).ToDictionary( x => x.Key, x => x.Value ) );
		}
		
		static public Polynom operator * ( Polynom polynom, double number )
		{
			if ( polynom is null )
			{
				throw new ArgumentNullException( "In operator Mul of Polynom argument is null" );
			}

			return new Polynom( polynom.Select(
				monom => Mul( monom, number )
			).ToDictionary( x => x.Key, x => x.Value ) );
		}
		
		static public Polynom operator / ( Polynom polynom, double number )
		{
			if ( number == 0 )
			{
				throw new DivideByZeroException( "In Polynom operator Div number is equal zero" );
			}

			return new Polynom( polynom.Select(
				monom => Div( monom, number )
			).ToDictionary( x => x.Key, x => x.Value ) );
		}
		static public bool operator == ( Polynom polynomA, Polynom polynomB )
		{
			if ( polynomA is null || polynomB is null )
			{
				return false;
			}

			return polynomA.SequenceEqual( polynomB );
		}

		static public bool operator != ( Polynom polynomA, Polynom polynomB )
		{
			return !( polynomA == polynomB );
		}

		public override bool Equals ( object obj )
		{
			if ( obj is Polynom )
			{
				return this == ( Polynom ) obj;
			}

			return false;
		}

		public override int GetHashCode ( )
		{
			return base.GetHashCode( );
		}

		public override string ToString ( )
		{
			var text = nameof( Polynom ) + " {\n";
			text += this.Aggregate(
				String.Empty,
				( accumulator, current ) => accumulator += $" {current.Value} * X ^ {current.Key}\n"
			);
			text += $"}}";
			return text;
		}
	}
}

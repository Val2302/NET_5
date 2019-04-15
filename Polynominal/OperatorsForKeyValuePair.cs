using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynominal
{
	public abstract class ForKeyValuePairFunction
	{
		static public double Calculate ( KeyValuePair<int, double> keyValuePair, double variable )
		{
			return keyValuePair.Value * Math.Pow( variable, keyValuePair.Key );
		}

		static public KeyValuePair<int, double> Sum ( KeyValuePair<int, double> keyValuePairA, KeyValuePair<int, double> keyValuePairB )
		{
			if ( keyValuePairA.Key != keyValuePairB.Key )
			{
				throw new ArgumentException( "In Sum function of Key value pair keys arguments is not equal" );
			}

			return new KeyValuePair<int, double>( keyValuePairA.Key, keyValuePairA.Value + keyValuePairB.Value );
		}

		static public KeyValuePair<int, double> Dif ( KeyValuePair<int, double> keyValuePairA, KeyValuePair<int, double> keyValuePairB )
		{
			if ( keyValuePairA.Key != keyValuePairB.Key )
			{
				throw new ArgumentException( "In Dif function of Key value pair keys arguments is not equal" );
			}

			return new KeyValuePair<int, double>( keyValuePairA.Key, keyValuePairA.Value + keyValuePairB.Value );
		}

		static public KeyValuePair<int, double> Mul ( KeyValuePair<int, double> keyValuePairA, double value )
		{
			return new KeyValuePair<int, double>( keyValuePairA.Key, keyValuePairA.Value * value );
		}

		static public KeyValuePair<int, double> Mul ( KeyValuePair<int, double> keyValuePairA, KeyValuePair<int, double> keyValuePairB )
		{
			return new KeyValuePair<int, double>( keyValuePairA.Key + keyValuePairB.Key, keyValuePairA.Value * keyValuePairB.Value );
		}

		static public KeyValuePair<int, double> Div ( KeyValuePair<int, double> keyValuePairA, double value )
		{
			if ( value != 0 )
			{
				throw new DivideByZeroException( "In Div function of Key value pair value is equal 0" );
			}

			return new KeyValuePair<int, double>( keyValuePairA.Key, keyValuePairA.Value / value );
		}

		static public KeyValuePair<int, double> Div ( KeyValuePair<int, double> keyValuePairA, KeyValuePair<int, double> keyValuePairB )
		{
			if ( keyValuePairB.Value != 0 )
			{
				throw new DivideByZeroException( "In Div function of Key value pair value of second param is equal 0" );
			}

			return new KeyValuePair<int, double>( keyValuePairA.Key + keyValuePairB.Key, keyValuePairA.Value * keyValuePairB.Value );
		}
	}
}

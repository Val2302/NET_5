using static System.Console;

namespace Polynominal
{
	public class Menu
	{
		public void Show ( )
		{
			WriteLine( "Program polynominal:" );

			WriteLine( );
			var polynominal = new Polynom( );
			WriteLine( polynominal );

			ReadKey( );
		}
	}
}

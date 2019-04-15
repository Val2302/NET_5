using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polynominal;
using static Polynominal.ForKeyValuePairFunction;

namespace TestPolynominal
{
	[TestClass]
	public class PolynominalTest
	{
		[TestMethod]
		public void CalculateTest_CalculateMonomsSum_ResultTrue ( )
		{
			var polynom = new Polynom( )
			{ 
				new KeyValuePair<int, double>( 0, 1 ),
				new KeyValuePair<int, double>( 1, 2 ),
			};

			var variable = 5;
			var calculatePolynominal = polynom.Calculate( variable );
			var controlCalculate = 11;
			
			Assert.IsTrue( calculatePolynominal.IsIdentical( controlCalculate ) );
		}

		[TestMethod]
		public void OperatorSumTest_CalculateSumPolynoms_ResultTrue ( )
		{
			var polynom = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 2 ),
				new KeyValuePair<int, double>( 1, 3 )
			};
			var calculatePolynom = polynom + polynom;

			var resultPolynom = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 4 ),
				new KeyValuePair<int, double>( 1, 6 )
			};

			Assert.AreEqual( calculatePolynom, resultPolynom );
		}
		
		[TestMethod]
		public void OperatorDifTest_CalculateDifPolynoms_ResultTrue ( )
		{
			var polynom = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 2 ),
				new KeyValuePair<int, double>( 1, 3 )
			};
			var calculatePolynom = polynom - polynom;

			var resultPolynom = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 0 ),
				new KeyValuePair<int, double>( 1, 0 )
			};

			Assert.AreEqual( calculatePolynom, resultPolynom );
		}
		
		[TestMethod]
		public void OperatorMulTest_CalculateMulPolynomAndNumber_ResultTrue ( )
		{
			var number = 3;

			var polynom = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 2 ),
				new KeyValuePair<int, double>( 1, 3 )
			};

			var calculatePolynom = polynom * number;

			var resultPolynom = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 6 ),
				new KeyValuePair<int, double>( 1, 9 )
			};

			Assert.AreEqual( calculatePolynom, resultPolynom );
		}

		[TestMethod]
		public void OperatorEqualTest_CalculateMulPolynomIsEqualPolynom_PolinomsIsEqual_ResultTrue ( )
		{
			var polynomA = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 2 ),
				new KeyValuePair<int, double>( 1, 3 )
			};

			var polynomB = new Polynom( polynomA );

			Assert.IsTrue( polynomA == polynomB );
		}

		[TestMethod]
		public void OperatorEqualTest_CalculateMulPolynomIsEqualPolynom_PolinomsIsNotEqual_ResultFalse ( )
		{
			var polynomA = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 2 ),
				new KeyValuePair<int, double>( 1, 3 )
			};

			var polynomB = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 3 ),
				new KeyValuePair<int, double>( 1, 2 )
			};

			Assert.IsFalse( polynomA == polynomB );
		}

		[TestMethod]
		public void OperatorEqualTest_CalculateMulPolynomIsNotEqualPolynom_PolinomsIsEqual_ResultFalse ( )
		{
			var polynomA = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 2 ),
				new KeyValuePair<int, double>( 1, 3 )
			};

			var polynomB = new Polynom( polynomA );

			Assert.IsFalse( polynomA != polynomB );
		}

		[TestMethod]
		public void OperatorEqualTest_CalculateMulPolynomIsNotEqualPolynom_PolinomsIsNotEqual_ResultTrue ( )
		{
			var polynomA = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 2 ),
				new KeyValuePair<int, double>( 1, 3 )
			};

			var polynomB = new Polynom( )
			{
				new KeyValuePair<int, double>( 0, 3 ),
				new KeyValuePair<int, double>( 1, 2 )
			};

			Assert.IsTrue( polynomA != polynomB );
		}
	}
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vectors3D;
using static System.Math;

namespace Vectors3DTest
{
    [TestClass]
    public class Vector3DTest
    {
        [TestMethod]
        public void LengthTest_VectorLength_ResultTrue ( )
        {
            double x = 1, y = 2, z = 3;
            var calculateVector = new Vector3D( x, y, z ).Length( );
            var calculateControl = Sqrt( x * x + y * y + z * z );

            Assert.IsTrue( calculateControl.IsIdentical( calculateVector, 0.1 ) );
        }

        [TestMethod]
        public void OperatorSumTest_VectorsSum_ResultTrue ( )
        {
            double x = 1, y = 2, z = 3;
            var vectorA = new Vector3D( x, y, z );
            var vectorB = new Vector3D( vectorA );
            var calculateVector = vectorA + vectorB;
            var calculateControl = new Vector3D( x + x, y + y, z + z );

            Assert.AreEqual( calculateControl, calculateVector );
        }

        [TestMethod]
        public void OperatorDiffTest_VectorsDiff_ResultTrue ( )
        {
            double x = 1, y = 2, z = 3;
            var vectorA = new Vector3D( x, y, z );
            var vectorB = new Vector3D( vectorA );
            var calculateVector = vectorA - vectorB;
            var calculateControl = new Vector3D( );

            Assert.AreEqual( calculateControl, calculateVector );
        }

        [TestMethod]
        public void OperatorMulTest_VectorMulToNumber_ResultTrue ( )
        {
            var number = 2;
            double x = 1, y = 2, z = 3;
            var vector = new Vector3D( x, y, z );
            var calculateVector = vector * number;
            var calculateControl = new Vector3D( x * 2, y * 2, z * 2 );

            Assert.AreEqual( calculateControl, calculateVector );
        }

        [TestMethod]
        public void OperatorMulTest_VectorMulToVector_ResultTrue ( )
        {
            double x = 1, y = 2, z = 3;
            var vectorA = new Vector3D( x, y, z );
            var vectorB = new Vector3D( vectorA );
            var calculateVector = vectorA * vectorB;
            var calculateControl = x * x + y * y + z * z;

            Assert.IsTrue( calculateControl.IsIdentical( calculateVector, 0.1 ) );
        }

        [TestMethod]
        public void OperatorDivTest_VectorDivToNumber_ResultTrue ( )
        {
            var number = 2.0;
            double x = 1, y = 2, z = 3;
            var vector = new Vector3D( x, y, z );
            var calculateVector = vector / number;
            var calculateControl = new Vector3D( 0.5, 1, 1.5 );

            Assert.AreEqual( calculateControl, calculateVector );
        }

        [TestMethod]
        public void OperatorAngleTest_AngleBetweenVectors_GeneralCase_ResultTrue ( )
        {
            var vectorA = new Vector3D( 1, 2, 3 );
            var vectorB = new Vector3D( 3, 2, 1 );
            var calculateVector = vectorA ^ vectorB;
            var calculateControl = Acos( vectorA * vectorB / ( vectorA.Length( ) * vectorB.Length( ) ) );

            Assert.IsTrue( calculateControl.IsIdentical( calculateVector, 0.1 ) );
        }

        [TestMethod]
        public void OperatorAngleTest_AngleBetweenVectors_ParallelVectors_ResultTrue ( )
        {
            var vectorA = new Vector3D( 1, 2, 3 );
            var vectorB = new Vector3D( vectorA );
            var calculateVector = vectorA ^ vectorB;
            var calculateControl = 0.0;

            Assert.IsTrue( calculateControl.IsIdentical( calculateVector, 0.1 ) );
        }

        [TestMethod]
        public void OperatorAngleTest_AngleBetweenVectors_PerpendicularVectors_ResultTrue ( )
        {
            var vectorA = new Vector3D( -1, 2, 1 );
            var vectorB = new Vector3D( 3, 2, -1 );
            var calculateVector = vectorA ^ vectorB;
            var calculateControl = PI / 2.0;

            Assert.IsTrue( calculateControl.IsIdentical( calculateVector, 0.1 ) );
        }

        [TestMethod]
        public void OperatorCompareTest_VectorsCompare_ResultTrue ( )
        {
            var vectorA = new Vector3D( 1, 2, 3 );
            var vectorB = new Vector3D( vectorA );

            Assert.IsTrue( vectorA == vectorB );
        }

		[TestMethod]
		public void OperatorCompareTest_VectorsCompare_ResultFalse ( )
		{
			var vectorA = new Vector3D( 1, 2, 3 );
			var vectorB = new Vector3D( 3, 2, 1 );

			Assert.IsFalse( vectorA == vectorB );
		}

		[TestMethod]
		public void OperatorCompareTest_VectorsNotCompare_ResultTrue ( )
        {
            var vectorA = new Vector3D( 1, 2, 3 );
            var vectorB = new Vector3D( 3, 2, 1 );

            Assert.IsTrue( vectorA != vectorB );
        }

		[TestMethod]
		public void OperatorCompareTest_VectorsNotCompare_ResultFalse ( )
		{
			var vectorA = new Vector3D( 1, 2, 3 );
			var vectorB = new Vector3D( vectorA );

			Assert.IsFalse( vectorA != vectorB );
		}
	}
}

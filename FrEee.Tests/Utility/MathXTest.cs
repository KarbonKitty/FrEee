using FrEee.Utility;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrEee.Tests.Utility
{
	/// <summary>
	/// Tests math.
	/// </summary>
	[TestClass]
	public class MathXTest
	{
		[TestMethod]
		public void Ceiling()
		{
			Assert.AreEqual(0, MathX.Ceiling(0, 0));
			Assert.AreEqual(1, MathX.Ceiling(0.1));
			Assert.AreEqual(0.1, MathX.Ceiling(0.01, 1));
		}
	}
}

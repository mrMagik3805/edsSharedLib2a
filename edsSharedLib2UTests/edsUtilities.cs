using System;
using NUnit.Framework;
using System.Globalization;

namespace edsSharedLib2UTests
{
	[TestFixture]
    public class edsUtilities
	{
		[Test]
		public void CovUTCToLocal()
		{
			DateTime dtwbsDate = DateTime.Now;
			DateTime wbsDate = dtwbsDate;
			CultureInfo ci = new CultureInfo ("en-NZ");
			string dtInp = wbsDate.ToString ("R", ci);
			DateTime convertedDate = DateTime.Parse (dtInp);
			var kind = convertedDate.Kind;
			DateTime convertedDate1 = DateTime.SpecifyKind (
				DateTime.Parse (dtInp),
				DateTimeKind.Utc);
			var kind1 = convertedDate1.Kind;
			DateTime dtUtc = convertedDate1.ToLocalTime ();
			Assert.AreEqual (dtInp, dtUtc, "Dates are equal");
			return;
		}
	}
}
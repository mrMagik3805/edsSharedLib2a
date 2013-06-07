using System;
 
namespace edsSharedLib2.edsUtilities
{
	public static class edsUtilities
	{

		public static string CovUTCToLocal(DateTime dtInp)
		{
				DateTime dpkrDate = dtInp;
				DateTime dpkrDateUtc = dpkrDate.ToUniversalTime();
				DateTime dtLocal = dpkrDateUtc.ToLocalTime();
				string strLocTime = dtLocal.ToString("hh:mm tt");

		return strLocTime;
		}
	}
}


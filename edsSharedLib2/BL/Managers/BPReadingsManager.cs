using System;
using System.Collections.Generic;
using edsSharedLib2.BL;

namespace edsSharedLib2.BL.BPReadingsManager
{
	public static class BPReadingsManager
	{
		static BPReadingsManager ()
		{
		}

		internal static void UpdateUserData(IList<BPReading> BPReadings)
		{
			DAL.BPReadingsDataManager.DeleteUsers();
			DAL.BPReadingsDataManager.SaveUsers(BPReadings);
		}

		public static IList<BPReading> GetUsers()
		{
			//			var iUsers = DAL.BPReadingsDataManager.GetUsers();
			//			var users = iUsers.ToList();
			//			users.Sort ((s1,s2) => s1.LName.CompareTo (s2.LName));
			//			return users;
			return new List<BPReading>(DAL.BPReadingsDataManager.GetUsers());

		}
		//		public static User GetUserBy_UserID (string usrID)
		//		{
		//			return DAL.BPReadingsDataManager.GetUserBy_UsrID(usrID);
		//		}

		public static BPReading GetUserBy_UsrDwnLdCode(string usrDwnLdCodeInp)
		{
			return DAL.BPReadingsDataManager.GetUserBy_UsrDwnLdCode(usrDwnLdCodeInp);
		}

		public static int SaveUser(BPReading item)
		{
			return DAL.BPReadingsDataManager.SaveUser (item);
		}






	}
}


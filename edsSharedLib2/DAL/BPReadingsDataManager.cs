using System;
using System.Collections.Generic;
using System.IO;
using edsSharedLib2.BL;

namespace edsSharedLib2.DAL
{
	/// <summary>
	/// [abstracts from the underLying data source(s)]
	/// [if multiple data sources, can agreggate/etc with BL knowing]
	/// [superflous if only one data source]
	/// </summary>
	public static class BPReadingsDataManager {
		#region BPReading

		public static IEnumerable<BPReading> GetUsers()
		{
			return DL.BPReadingsDatabase.GetUsers<BPReading> ();
		}

		public static BPReading GetUser (int id)
		{
			return DL.BPReadingsDatabase.GetUser(id);
		}



		public static IEnumerable<BPReading> GetUserDwnLdCodes()
		{
			return DL.BPReadingsDatabase.GetUserDwnLdCodes<BPReading> ();
		}


		public static BPReading GetUserBy_UsrDwnLdCode(string UsrDwnLdCode)
		{
			return DL.BPReadingsDatabase.GetUserBy_UsrDwCode<BPReading> (UsrDwnLdCode);
		}

		//		public static User GetUserBy_UsrID(string usrID)
		//		{
		//			return DL.BPReadingsDatabase.GetUsrBy_UsrID(usrID);
		//		}

		public static int SaveUser (BPReading item)
		{
			return DL.BPReadingsDatabase.SaveUser<BPReading> (item);
		}
		public static void SaveUsers (IEnumerable<BPReading> items)
		{
			DL.BPReadingsDatabase.SaveItems<BPReading> (items);
		}
		public static int DeleteUser(int id)
		{
			return DL.BPReadingsDatabase.DeleteItem<BPReading> (id);
		}
		public static void DeleteUsers()
		{
			DL.BPReadingsDatabase.ClearTable<BPReading>();
		}
		#endregion

	}
}



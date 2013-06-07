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
	public static class DataManager {
		#region User

		public static IEnumerable<User3> GetUsers()
		{
			return DL.BPMUserDatabase.GetUsers<User3> ();
		}

		public static User3 GetUser (int id)
		{
			return DL.BPMUserDatabase.GetUser(id);
		}



		public static IEnumerable<User3> GetUserDwnLdCodes()
		{
			return DL.BPMUserDatabase.GetUserDwnLdCodes<User3> ();
		}


		public static User3 GetUserBy_UsrDwnLdCode(string UsrDwnLdCode)
		{
			return DL.BPMUserDatabase.GetUserBy_UsrDwCode<User3> (UsrDwnLdCode);
		}

//		public static User GetUserBy_UsrID(string usrID)
//		{
//			return DL.BPMUserDatabase.GetUsrBy_UsrID(usrID);
//		}

		public static int SaveUser (User3 item)
		{
			return DL.BPMUserDatabase.SaveUser<User3> (item);
		}
		public static void SaveUsers (IEnumerable<User3> items)
		{
			DL.BPMUserDatabase.SaveItems<User3> (items);
		}
		public static int DeleteUser(int id)
		{
			return DL.BPMUserDatabase.DeleteItem<User3> (id);
		}
		public static void DeleteUsers()
		{
			DL.BPMUserDatabase.ClearTable<User3>();
		}
		#endregion

	}
}


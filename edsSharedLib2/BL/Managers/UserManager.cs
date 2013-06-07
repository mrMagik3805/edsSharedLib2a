using System;
using System.Collections.Generic;
using edsSharedLib2.BL;


namespace edsSharedLib2.BL.Manager
{
	public static class UserManager
	{

		static UserManager ()
		{
		}

		internal static void UpdateUserData(IList<User3> Users)
		{
			DAL.DataManager.DeleteUsers();
			DAL.DataManager.SaveUsers(Users);
		}

		public static IList<User3> GetUsers()
		{
//			var iUsers = DAL.DataManager.GetUsers();
//			var users = iUsers.ToList();
//			users.Sort ((s1,s2) => s1.LName.CompareTo (s2.LName));
//			return users;
			return new List<User3>(DAL.DataManager.GetUsers());
 
		}
//		public static User GetUserBy_UserID (string usrID)
//		{
//			return DAL.DataManager.GetUserBy_UsrID(usrID);
//		}

		public static User3 GetUserBy_UsrDwnLdCode(string usrDwnLdCodeInp)
		{
			return DAL.DataManager.GetUserBy_UsrDwnLdCode(usrDwnLdCodeInp);
		}

		public static int SaveUser(User3 item)
		{
			return DAL.DataManager.SaveUser (item);
		}
			



	}
}


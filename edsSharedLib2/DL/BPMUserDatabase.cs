using System;
using System.IO;
using System.Linq;
using edsSharedLib2.BL;
using System.Collections.Generic;
using edsSharedLib2.DL.SQLite;
using edsSharedLib2.Constants;


namespace edsSharedLib2.DL
{
	/// <summary>
	/// BPMUserDatabase builds on SQLite.Net and respresents a specific database, in this case, the bpUsers DB.
	/// It contains methods for retreival and persistance as well as db creation, all based on the 
	/// underlying ORM
	/// </summary>


	public class BPMUserDatabase : SQLiteConnection
	{
		protected static BPMUserDatabase me = null;
		protected static string dbLocation;

		public string UsrDBLocation { set; get;}

		static object locker = new object();

		// initalize a new instance of the database.
		// if it does not exist , it will create the database and all the tables.
		// param name='path'
		protected BPMUserDatabase (string path): base (path)
		{
			UsrDBLocation = dbLocation;
			// create the tables
			CreateTable<User3> ();

		}
		static BPMUserDatabase()
		{
			// set the d Location
			dbLocation = DatabaseFilePath;
			Cons.usrDatabasePath = dbLocation;

			// instantiate a new db
			me = new BPMUserDatabase(dbLocation);
		}

		public static string DatabaseFilePath {
			get {
				var sqliteFilename = "bpUsers.db3";
#if NETFX_CORE
				var path = Path.Combine(Windows.Storeage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else

#if SILVERLIGHT
				var path = sqliteFilename;
#else

#if _ANDROID_
				string libraryPath = Environment.GetFolderPath(Environment.Special.Folder.Personal);;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms'
				// (they don't want non-user generated data in Documents')
				string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				string libraryPath = Path.Combine(documentsPath, "../Library/");
#endif
				var path = Path.Combine(libraryPath, sqliteFilename);


#endif

#endif

				return path;
			}
		}

		public static IEnumerable<T> GetUsers<T> () where T : BL.Contracts.IBusinessEntity, new() 
		{
			lock(locker){
				return(from i in me.Table<T> ()select i).ToList();
			}
		}

		public static T GetItem<T> (int id) where T: BL.Contracts.IBusinessEntity, new() 
		{
			lock (locker) {
				// ---
				// return (from i in me.Table<T> ()
				//        where i.ID == id
				//        select i).FirstOrDefault ();

				// +++ To properly use Generic version and eliminate NotSupportedException
				// ("Cannot compile: " + expr.NodeType.ToString()); in SQLite.cs
				return me.Table<T>().FirstOrDefault(x=> x.ID == id);
			}
		}
		// Get a list of Users
		public static IEnumerable<T> GetUserDwnLdCodes<T> () where T : BL.Contracts.IBusinessEntity, new()
		{
			lock(locker){
				return (from i in me.Table<T> ()select i).ToList();
			}
		}
		// Gets a single User Rec that matches the UsrDwnLdCode input by the user
		public static T GetUserBy_UsrDwCode<T> (string UsrDwnLdCode) where T: BL.Contracts.IBusinessEntity, new()
		{
			lock (locker) {
				return me.Table<T>().FirstOrDefault(x=> x.UsrDwnLdCode == UsrDwnLdCode);
			}
		}

//		public static T GetUsrBy_UsrID<T> (string usrIDInp) where T: BL.Contracts.IBusinessEntity, new()
//		{
//			lock (locker) {
//				return me.Table<T>().FirstOrDefault(x=> x.UsrID == usrIDInp);
//			}
//		}
		public static int SaveUser<T> (T User3) where T : BL.Contracts.IBusinessEntity
		{
			lock (locker){
				if(User3.ID !=0){
					me.Update (User3);
					return User3.ID;
				} else {
					return me.Insert (User3);
				}
			}
		}

		public static void SaveItems<T> (IEnumerable<T> items) where T: BL.Contracts.IBusinessEntity
		{
			lock(locker) {
				me.BeginTransaction();

				foreach (T item in items) {
					SaveUser<T> (item);
				}

				me.Commit();
			}
		}

		public static int DeleteItem<T>(int id) where T : BL.Contracts.IBusinessEntity, new()
		{
			lock (locker){
				return me.Delete<T> (new T () {ID = id});
			}
		}

		public static void ClearTable<T>() where T : BL.Contracts.IBusinessEntity, new() 
		{
			lock (locker){
				me.Execute(string.Format("delete from \"{0}\"",typeof (T).Name));

				}
		}

		// helper for checking if database has been populated 
		public static int CountTable<T> () where T :  BL.Contracts.IBusinessEntity, new ()
		{
			lock (locker) {
				string sql = string.Format ("select count (*) from \"{0}\"",typeof (T).Name);
				var c = me.CreateCommand (sql, new object[0]);
				return c.ExecuteScalar<int>();
			}
		}
		public static User3 GetUser(int id)
		{
			lock (locker) {
				return (from s in me.Table<User3>()
				        where s.ID == id
				        select s).FirstOrDefault();
			}
		}
	}
}


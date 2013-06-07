using System;
using edsSharedLib2.BL.Contracts;
using edsSharedLib2.DL.SQLite;


namespace edsSharedLib2.BL
{
	public class User3 : IBusinessEntity
	{
		public User3 ()
		{
		}

		[PrimaryKey,AutoIncrement]
		public int ID { get; set; }
		[MaxLength(45)]
		[Indexed]
		public string UsrDwnLdCode {get;set;}
		[MaxLength(23)]
		public string FName {get;set;}
		[MaxLength(27)]
		public string LName {get;set;}
		public int UserStatus { get; set;}
		[MaxLength (12)]
		public string UserID { get; set;}
		[MaxLength(12)]
		public string UserPSW { get; set;}
		[MaxLength(16)]
		public string AppRegDateTime { get; set;}
		public int UserPaidStatus { get; set;}
		public int UserPaidType { get; set;}
		public int UserLicDays { get; set;}
		public string UserBirthDate { get; set;}
		public int UserAge { get; set;}
		public int UserSex { get; set;}
		public string RegSecretKey { get; set;}
		public string CopyRightAck { get; set;}
		public string CopyrightAckDT { get; set;}
		public string RecAddedDT { get; set;}
		public string RecLstAccessedDT { get; set;}
		public string RecAddedBy { get; set;}
		public string RecLstAccessedBy { get; set;}
	}
}
using System;
using edsSharedLib2.BL.Contracts;
using edsSharedLib2.DL.SQLite;


namespace edsSharedLib2.BL
{
	public class BPReading : IBusinessEntity
	{
		public BPReading ()
		{
		}

		[PrimaryKey,AutoIncrement]
		public int ID { get; set;}
		public string UsrDwnLdCode { get; set;}
		public int ReadingRecStatus { get; set;}
		[Indexed]
		public string ReadingDate {get;set;}
		[Indexed]
		public string ReadingTime { get; set;}
		public string ReadingSystolic {get;set;}
		public string ReadingDiaStolic {get;set;}
		public string ReadingPulse { get; set;}
		public int ReadingSevLvl { get; set;}
		public string RecAddedDT { get; set;}
		public string RecAddedBy { get; set;}
		public string RecLstAccDT { get; set;}
		public string RecLstAccBy { get; set;}

	}
}


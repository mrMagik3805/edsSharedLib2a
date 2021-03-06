using System;
using edsSharedLib2.DL.SQLite;

namespace edsSharedLib2.BL.Contracts
{
	/// <summary>
	/// Business entity base class. Provides the ID property.
	/// </summary>
	public abstract class BusinessEntityBase:IBusinessEntity
	{
		public BusinessEntityBase()
		{
		}

		/// <summary>
		/// Gets or sets the Database ID.
		/// </summary>
		///
		[PrimaryKey,AutoIncrement]
		public int ID { get; set; }
		public string UsrDwnLdCode { get; set;}
	}
}
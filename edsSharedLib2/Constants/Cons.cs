using System;

namespace edsSharedLib2.Constants
{
	public class Cons
	{
		public Cons ()
		{
		}

		public static string conUsrDwnLdCode { get; set;}
		public static string conAppOwnerName = "Willy Wonka Chocolate Works";
		public static string usrDatabasePath { get; set;}
		public static string RegSecKey { get; set;}

		private enum usrAuth : int 
		{
			usrAuthNoAccess,
			usrAuthSuperUsr,
			usrAuthAdmin,
			usrAuthModerate,
			usrAuthFullUsr,
			usrAuthRegUsr,
			usrAuthGuest

		}



		private string conUserID;
		private string conPassWd;
		/// <summary>
		/// Ps the user I.
		/// </summary>
		/// <returns>The user I.</returns>
		/// <param name="actReqested">Act reqested.</param>
		/// <param name="usrAuthInp">Usr auth inp.</param>
		/// <param name="usrIdInp">Usr identifier inp.</param>
		public string pUserID (int actReqested,
		                       int usrAuthInp = 0,
		                       string usrIdInp = "Nothing")
		{
			string setRetValue = "?????";
			switch (usrAuthInp)
			{
			case 0:
				// User has No access
				setRetValue = "XXXXX";
				break;
			case 2:
				// User is adminstrator
				switch (actReqested)
				{
					case 0:
						// Dummy not used
						setRetValue = "0000";
						break;
					case 1:
						// get UserID
						setRetValue = conUserID;
						break;
					case 2:
						// set UserID
						if (usrIdInp != "Nothing") 
						{
							conUserID = usrIdInp;
							setRetValue = "UsrID Set";
						}
						break;
					default:
						// handle unanticipated value
						setRetValue = "XXXXXX";
						break;
				}
				break;
			default:
				// handle unanticipated value
				setRetValue = "XXXXX";
				break;
			}
			return setRetValue;
		} 

		public void SetConUsrDwnLdCode (string CodeInp)
		{
			conUsrDwnLdCode = CodeInp;
		}
		public string GetConUsrDwnLdCode()
		{
			return conUsrDwnLdCode;
		}
	}
}


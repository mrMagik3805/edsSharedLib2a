using System;
using NUnit.Framework;

namespace edsSharedLib2UTests
{
	[TestFixture]
    public class SimpleAddSubtractToolTest
	{
		 string conUserID = "egEmpty";

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

		usrAuth uAuth;

		 
		/// <summary>
		/// This runs only once at the beginning of all test and is used for all test in the
		/// class.
		/// </summary>
		[TestFixtureSetUp]
		public void InitialSetup()
		{
			// Setup tests 
		


		}

		/// <summary>
		/// This runs only once at the end of all test and is used for all test in the class.
		/// </summary>
		[TestFixtureTearDown]
		public void FinalTearDown()
		{
			//
		}

		/// <summary>
		/// This setup function runs BEFORE each test method
		/// </summary>
		[SetUp]
		public void SetupForEachTest()
		{
			// setup for each test
		}

		/// <summary>
		/// This setup function runs AFTER each test method
		/// </summary>
		[TearDown]
		public void TearDownForEachTest()
		{
			// tear down after each test
		}

		// ========= my methods to test follow this line =========

		public string pUserID (int actReqested,
		                       int usrAuthInp,
		                       string usrIdInp = "eg3805237g")
		{

			string setRetValue = "?????";
			switch (usrAuthInp)
			{
				case 0:
				// User has No access
				setRetValue = "E1003:You have no access authority."+ "[" + usrAuthInp + "].";
				break;
				case 2:
				// User is adminstrator
				switch (actReqested)
				{
				case 0:
					// Dummy not used
					setRetValue = "E1005:Action requested not available." + "[" + actReqested + "].";
					break;
					case 1:
					// get UserID
					setRetValue = conUserID;
					break;
					case 2:
					// set UserID
					if (usrIdInp != "eg3805237g" && conUserID == "egEmpty")
					{
						conUserID = usrIdInp;
						setRetValue = "UsrID Set";
					}
					else
					{
						setRetValue = "E9000:UsrID CANNOT be set. " +
							"conUserID is [" + conUserID + "].";
					}
					break;
					default:
					// handle unanticipated value
					setRetValue = "E1007:Unanticipated action request. " + "[" + actReqested + "]";
					break;
				}
				break;
				default:
				// handle unanticipated value
				setRetValue = "E1004:Unrecognized Auth Code." + "[" + usrAuthInp + "].";
				break;
			}
			return setRetValue;
		} 

		[Test]
		public void pUserID_Test_SetUsrID ()
		{
			// Step 1 - Arrange 
			SimpleAddSubtractToolTest SimpASClass = new SimpleAddSubtractToolTest ();

			// Step 2 - Act
			// 2=Set UsrID,2=SysAdmin,"Bobby.Smith"=UserID to set
			string pUsrIdRetVal = SimpASClass.pUserID (2, 2,"Bobby.Smith");
		
			// Step 3 - Assert 
			string expected = "UsrID Set";
			Assert.AreEqual (expected, pUsrIdRetVal, "E9001:User NOT set" +
			                 "[" + pUsrIdRetVal + "].");
		}

		[Test]
		public void pUserID_Test_GetUsrID ()
		{
			// Step 1 - Arrange
			SimpleAddSubtractToolTest SimpASClass = new SimpleAddSubtractToolTest ();

			// Step 2 - Act
			// 1=Get UsrID,2=SysAdmin
			string pUsrIdRetVal = SimpASClass.pUserID (1, 2);

			// Step 3 - Assert
			string expected = "egEmpty";
			Assert.AreEqual (expected, pUsrIdRetVal, "User Returned NOT egEmpty" +
			                 "[" + pUsrIdRetVal + "].");

		}
		[Test]
		public void pUserID_Test_InvalidParms ()
		{
			// Step 1 - Arrange
			SimpleAddSubtractToolTest SimpASClass = new SimpleAddSubtractToolTest ();

			// Step 2 - Act
			// Junk Parms (9,9)
//			string pUsrIdRetVal = SimpASClass.pUserID (9,9);

			// Get User ID (1), no Access Auth=0
//			string pUsrIdRetVal = SimpASClass.pUserID (1,0);

			// Get User ID(1), Access Auth=1 (Registred User)
			string pUsrIdRetVal = SimpASClass.pUserID (1,(int)usrAuth.usrAuthRegUsr);

			// Step 3 - Assert
			string expected = "egEmpty";
			Assert.AreEqual (expected, pUsrIdRetVal, "User Returned NOT egEmpty" +
			                 "[" + pUsrIdRetVal + "].");

		}


	}
}

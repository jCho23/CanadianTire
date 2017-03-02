using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace CanadianTire
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void Register()
		{
			//Create Profile Page
			app.Tap("button2");
			Thread.Sleep(30000);
			app.Screenshot("We Denied Push Notifications");

			app.Tap("button2");
			Thread.Sleep(30000);
			app.Screenshot("We Denied Push Notifications again");

			app.Tap("tour_btnRegister");
			Thread.Sleep(30000);
			app.Screenshot("We Tapped on the 'Register' Button");

			app.WaitForElement(x => x.Marked("tnc_btnAccept"), timeout: TimeSpan.FromSeconds(80));
			app.Tap("tnc_btnAccept");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on 'Accept'");

			app.Tap("register_edtUsername");
			Thread.Sleep(30000);
			app.Screenshot("We Tapped on the Edit Username Text Field");

			app.EnterText("DrakeBeiber183");
			Thread.Sleep(30000);
			app.Screenshot("We entered our username");

			app.Tap("pin_edtPin");
			Thread.Sleep(30000);
			app.Screenshot("We Tapped on the First Access Code Field");

			app.DismissKeyboard();
			Thread.Sleep(30000);
			app.Screenshot("Dismissed Keyboard");

			app.EnterText("09876");
			Thread.Sleep(30000);
			app.Screenshot("We entered our Access Code");

			Thread.Sleep(4000);
			app.DismissKeyboard();
			Thread.Sleep(30000);
			app.Screenshot("Dismissed Keyboard");

			app.Tap("register_edtConfPin");
			Thread.Sleep(30000);
			app.Screenshot("We Tapped on the Second Access Code Field");

			Thread.Sleep(4000);
			app.EnterText("09876");
			Thread.Sleep(30000);
			app.Screenshot("We confirmed our Access Code");

			app.Tap("register_btnCreate");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on the Create Profile Button");
			Thread.Sleep(4000);

			//Add Card Page
			app.Tap("addCard_step1_CardName");
			Thread.Sleep(30000);
			app.Screenshot("We Tapped on our Credit Card");

			app.Tap("register_imgPinToolTip");
			Thread.Sleep(30000);
			app.Screenshot("We Tapped 'Options Mastercard'");

			app.Tap("addCard_step1_edtBlock2");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on the Credit Card Field");

			app.EnterText("1225");
			Thread.Sleep(30000);
			app.Screenshot("We Entered the second set of digits");

			app.EnterText("2413");
			Thread.Sleep(30000);
			app.Screenshot("We Entered the third set of digits");

			app.EnterText("7414");
			Thread.Sleep(30000);
			app.Screenshot("We Entered in our last set of digits");

			app.Tap("addCard_step1_CVCNumber");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on the field for our 3 digit CVC2 code");

			app.EnterText("276");
			Thread.Sleep(30000);
			app.Screenshot("We entered in our code");

			app.Tap("addCard_step1_btnAddCard");
			Thread.Sleep(30000);
			app.Screenshot("We confirmed our card");

			app.Tap("register_imgPinToolTip");
			Thread.Sleep(30000);
			app.Screenshot("We successfully added our card");

			app.EnterText("1234");
			Thread.Sleep(30000);
			app.Screenshot("We entered in our Pin for our card");

			app.Tap("addCard_step2_btnAddPin");
			Thread.Sleep(30000);
			app.Screenshot("We confirmed our card");

			//Secure Profile Page
			app.Tap("securityQnA_txtQues1");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on the first question field");

			app.Tap("text1");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on the first field");

			app.EnterText("Microsoft");
			Thread.Sleep(30000);
			app.Screenshot("We entered our answer, 'Microsoft'");

			app.Tap("securityQnA_txtQues2");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on the second question field");

			app.Tap("text1");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on the second field");

			app.EnterText("Berkeley");
			Thread.Sleep(30000);
			app.Screenshot("We entered our answer, 'Berkeley'");

			app.Tap("securityQnA_txtQues3");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on the third question field");

			app.Tap("text1");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on the third field");

			app.EnterText("Batman");
			Thread.Sleep(30000);
			app.Screenshot("We entered our answer, 'Batman'");

			app.Tap("addCard_step3_btnFinish");
			Thread.Sleep(30000);
			app.Screenshot("We completed the Card Registration");

			app.EnterText("09876");
			Thread.Sleep(30000);
			app.Screenshot("We confirmed our Access Code");
		}

		[Test]
		public void SignIn()
		{
			app.Tap("button2");
			Thread.Sleep(30000);
			app.Screenshot("We Denied Push Notifications");

			app.Tap("button2");
			Thread.Sleep(30000);
			app.Screenshot("We Denied Push Notifications again");

			app.Tap("tour_btnSignIn");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on 'Sign In' Button");

			app.Tap("tnc_btnAccept");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on 'Accept'");

			app.Tap("reload_edtUsername");
			Thread.Sleep(30000);
			app.Screenshot("Tapped on Username Field");

			app.EnterText("DrakeBeiber2");
			Thread.Sleep(30000);
			app.Screenshot("We entered our username");

			app.DismissKeyboard();
			Thread.Sleep(30000);
			app.Screenshot("Dismissed Keyboard");

			app.Tap("reload_btnSignInStep1");
			Thread.Sleep(30000);
			app.Screenshot("We Tapped on 'Sign In' Button");

			string FirstJobQues = "What is the name of the company of your first job?";
			string FriendQues = "What is the name of your favorite childhood friend?";
			//string SchoolQues = "What is the name of the first school you attended?";

			int QuestionIndex = 1;

			while (QuestionIndex != 3)
			{
						app.Tap(x=>x.Marked($"reload_edtAns{QuestionIndex}"));		

						if (app.Query(x=>x.Marked($"reload_txtQues{QuestionIndex}").Text(FirstJobQues)).Any())
						{
					//First Job = Microsoft
							app.EnterText("Microsoft");
							app.DismissKeyboard();
						}

						else if (app.Query(x => x.Marked($"reload_txtQues{QuestionIndex}").Text(FriendQues)).Any())
						{
							//Childhood Friend= Batman
							//app.Tap("reload_edtAns1"
							app.EnterText("Batman");
							app.DismissKeyboard();
						}

						else //if(app.Query(x => x.Marked("reload_txtQues1").Text("What is the name of the first school you attended?")).Any())
						{
							//First School = Berkeley
							app.EnterText("Berkeley");
							app.DismissKeyboard();
					}
				app.Screenshot($"Answer Question {QuestionIndex}");
				QuestionIndex++;
			}
			 
			app.Tap("reload_btnSignInStep2");
			Thread.Sleep(30000);
			app.Screenshot("We Tapped on Sign In Button");

			app.Tap("pin_edtPin");
			Thread.Sleep(30000);
			app.Screenshot("We tapped on the first Access Code Field");

			app.EnterText("10293");
			app.Screenshot("We entered in our Pin");

			app.DismissKeyboard();
			app.Screenshot("We Dismissed the keyboard");

			Thread.Sleep(30000);
			app.Tap(x => x.Class("android.widget.EditText").Index(4));
			app.Screenshot("Then we tapped on the second Access Code Field");

			app.EnterText("10293");
			Thread.Sleep(30000);
			app.Screenshot("We confirmed our Pin");

			Thread.Sleep(30000);
			app.Tap("resetPin_btnSubmit");
			Thread.Sleep(30000);
			app.Screenshot("Then tapped on the 'Reset Access Code'  Button");

			app.Tap("button1");
			Thread.Sleep(30000);
			app.Screenshot("Let's Transfer our profile and launch Home Page");

		}

	}
}

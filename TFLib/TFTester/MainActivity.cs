using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using MonoDroid.TestFlightLib;

namespace TFTester
{
	[Application (Name = "com.davincium.tftester.TFTester.AppDelegate")]			
	public class AppDelegate : Application
	{
		public override void OnCreate ()
		{
			base.OnCreate ();

			TestFlight.TakeOff (this,"some-kind-of-uid");
		}

		#region MonoDroid Hacks
		// MonoDroid Hacks for a Sub-Classed Application
		//public AppDelegate(IntPtr handle) : base (handle){}
		protected AppDelegate(IntPtr a,JniHandleOwnership b):base(a,b){} 

		#endregion
	}

	[Activity (Label = "JarTester", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);



			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate
			{
				TestFlight.LogEvent("Clicked Button");
				button.Text = string.Format ("{0} clicks!", count++);
			};
		}
	}
}

using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.App;

namespace MonoDroid.TestFlightLib
{
	public static class TestFlight
	{
		public static void TakeOff(Application app,String tfTeamToken)
		{
			try
			{
				IntPtr TF_Class = JNIEnv.FindClass("com/testflightapp/lib/TestFlight");
				IntPtr TF_TAKEOFF = JNIEnv.GetStaticMethodID (TF_Class, "takeOff", "(Landroid/app/Application;Ljava/lang/String;)V");
				Java.Lang.String key = new Java.Lang.String(tfTeamToken);
				JNIEnv.CallStaticVoidMethod(TF_Class,TF_TAKEOFF,new JValue(app),new JValue(key));
			}
			catch(Exception er)
			{
				Log.Debug("TestFlight","TestFlight failed to start session: " + er.Message);
			}
		}

		public static void LogEvent(String eventName)
		{
			try
			{
				IntPtr TF_Class = JNIEnv.FindClass("com/testflightapp/lib/TestFlight");
				IntPtr TF_Method = JNIEnv.GetStaticMethodID (TF_Class, "passCheckpoint", "(Ljava/lang/String;)V");
				Java.Lang.String key = new Java.Lang.String(eventName);
				JNIEnv.CallStaticVoidMethod(TF_Class,TF_Method,new JValue(key));
			}
			catch(Exception er)
			{
				Log.Debug("TestFlight","TestFlight failed to log checkpoint: " + er.Message);
			}
		}
	}
}

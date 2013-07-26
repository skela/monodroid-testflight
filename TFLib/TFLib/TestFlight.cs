using System;
using Android.Content;
using Android.Runtime;
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
				LogError("TestFlight failed to start session: " + er.Message);
			}
		}

		public static void PassCheckpoint(String checkpointName)
		{
			try
			{
				IntPtr TF_Class = JNIEnv.FindClass("com/testflightapp/lib/TestFlight");
				IntPtr TF_Method = JNIEnv.GetStaticMethodID (TF_Class, "passCheckpoint", "(Ljava/lang/String;)V");
				Java.Lang.String key = new Java.Lang.String(checkpointName);
				JNIEnv.CallStaticVoidMethod(TF_Class,TF_Method,new JValue(key));
			}
			catch(Exception er)
			{
				LogError("TestFlight failed to log checkpoint: " + er.Message);
			}
		}

		public static void Log(String msg)
		{
			try
			{
				IntPtr TF_Class = JNIEnv.FindClass("com/testflightapp/lib/TestFlight");
				IntPtr TF_Method = JNIEnv.GetStaticMethodID (TF_Class, "log", "(Ljava/lang/String;)V");
				Java.Lang.String key = new Java.Lang.String(msg);
				JNIEnv.CallStaticVoidMethod(TF_Class,TF_Method,new JValue(key));
			}
			catch(Exception er)
			{
				LogError("TestFlight failed to log checkpoint: " + er.Message);
			}
		}

		private static void LogError(String msg)
		{
			Android.Util.Log.Debug ("TestFlight", msg);
		}
	}
}

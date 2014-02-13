package com.davincium.jartester;

import android.app.Application;
import android.util.Log;

import com.testflightapp.lib.TestFlight;

public class JarApp extends Application
{
    @Override
    public void onCreate()
    {
        super.onCreate();
        Log.d("App", "Starting app");

        TestFlight.takeOff(this, "some-kind-of-uid");
    }
}

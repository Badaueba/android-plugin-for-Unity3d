package com.alan.flashlightlib;

import android.content.Intent;
import android.content.pm.PackageManager;
import android.hardware.Camera;
import android.provider.Settings;

import com.unity3d.player.UnityPlayerActivity;

public class MainActivity extends UnityPlayerActivity {

    public boolean isActiveFlashlight;
    private Camera _cameraHardware;
    String debugMSG = "DEBUG: Acessing android Native Functions!";

    public void shareText (String subject, String body) {
        debugMSG = "Share Text";
        Intent sharingIntent = new Intent(android.content.Intent.ACTION_SEND);
        sharingIntent.setType("text/plain");
        sharingIntent.putExtra(android.content.Intent.EXTRA_SUBJECT, subject);
        sharingIntent.putExtra(android.content.Intent.EXTRA_TEXT, body);
        startActivity(Intent.createChooser(sharingIntent, "Share via"));

    }

    public String debugMessage () {
        return debugMSG;
    }


    public boolean HardwareHasFlashlight () {
        return (
                this.getPackageManager().hasSystemFeature(
                        PackageManager.FEATURE_CAMERA_FLASH
                )
        );
    }

    public void ActiveFlashlight(String msg) {
        debugMSG = msg;

        if (HardwareHasFlashlight()) {
            isActiveFlashlight = true;
            _cameraHardware = Camera.open();
            Camera.Parameters params =  _cameraHardware.getParameters();
            params.setFlashMode(Camera.Parameters.FLASH_MODE_TORCH);
            _cameraHardware.setParameters(params);

            //turn on flashlight
            _cameraHardware.startPreview();

        }
        else {
            debugMSG = "No Flashlight support";
        }
    }

    public void deactiveFlashlight (String msg) {
        debugMSG = msg;
        if (HardwareHasFlashlight()) {
            isActiveFlashlight = false;
            //turn off
            _cameraHardware.stopPreview();
            _cameraHardware.release();
        }
        else {
            debugMSG = "No Flashlight support";
        }
    }

    public boolean isActiveFlashlight () {
        debugMSG = "isActive?";
        return isActiveFlashlight;

    }

}
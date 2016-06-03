using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//#if !UNITY_EDITOR && UNITY_ANDROID 

/// <summary>
/// Test.
/// Access android library methods
/// </summary>
public class Test : MonoBehaviour {
	public Text debugMessage;
	private bool flashActive;
	private AndroidJavaClass unity;
	AndroidJavaObject currentActivity;
	/// <summary>
	/// Actives the flashlight.
	/// Method to call "ActiveFlashLight" that 
	/// is built in android library "FlashlightLib"
	/// </summary>
	/// 
	void Awake () {
		unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		currentActivity = GetCurrentActivity ();
		debugMessage.text = currentActivity.Call<string> ("debugMessage");
	}
	//Access unityPlayer activity in library to get current activity running on device
	AndroidJavaObject GetCurrentActivity () {
		return unity.GetStatic<AndroidJavaObject> ("currentActivity");
	}
	//Turn On flashlight camera
	public void ActiveFlashlight(){
		currentActivity = GetCurrentActivity ();
		currentActivity.Call ("ActiveFlashlight", "Flashlight ON");
		debugMessage.text = currentActivity.Call<string> ("debugMessage");
	}
	//Turn Off flashlight camera
	public void DeactiveFlashlight () {
		currentActivity = GetCurrentActivity ();
		currentActivity.Call ("deactiveFlashlight", "Flashlight OFF");
		debugMessage.text = currentActivity.Call<string> ("debugMessage");
	}
	//toggle ActiveFlashlight/DeactiveFlahsligh Call 
	public void ManageFlashlight () {
		currentActivity = GetCurrentActivity ();
		flashActive = currentActivity.Call <bool> ("isActiveFlashlight");
		if (flashActive)
			DeactiveFlashlight ();
		else
			ActiveFlashlight ();
	}
	//Share intent Call
	public void ShareText(){
		currentActivity = GetCurrentActivity ();
		string subject = "Access native android functionality with a library (plugin) in Unity 3d";
		string body = "Available in: https://github.com/Badaueba/share-plugin-for-Unity3d";
		currentActivity.Call ("shareText", subject, body);
	}

}
//#endif
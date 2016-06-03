using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Test.
/// Access android library methods
/// </summary>
public class Test : MonoBehaviour {
	public Text debugMessage;
	private bool flashActive;
	/// <summary>
	/// Actives the flashlight.
	/// Method to call "ActiveFlashLight" that 
	/// is built in android library "FlashlightLib"
	/// </summary>
	/// 
	void Awake () {
		Debug ();
	}

	public void ActiveFlashlight(){
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		currentActivity.Call ("ActiveFlashlight", "Flashlight ON");

		debugMessage.text = currentActivity.Call<string> ("debugMessage");

	}
	public void DeactiveFlashlight () {
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		currentActivity.Call ("deactiveFlashlight", "Flashlight OFF");
		debugMessage.text = currentActivity.Call<string> ("debugMessage");
	}

	public void ManageFlashlight () {
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		flashActive = currentActivity.Call <bool> ("isActiveFlashlight");
		if (flashActive)
			DeactiveFlashlight ();
		else
			ActiveFlashlight ();
	}

	public void ShareText(){
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		currentActivity.Call ("shareText", 
			"Access native android functionality with a library (plugin) in Unity 3d", 
			"codigo em: https://github.com/Badaueba/share-plugin-for-Unity3d");
		Debug ();
	}

	public void Debug(){
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		debugMessage.text = currentActivity.Call<string> ("debugMessage");
	}

}

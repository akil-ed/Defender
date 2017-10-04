using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook;
using Facebook.Unity;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class LoginManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (FBSignIn());
	}

	IEnumerator FBSignIn(){
		FB.Init ();

		while (!FB.IsInitialized)
			yield return null;

		if(!FB.IsLoggedIn)
			FB.LogInWithPublishPermissions ();
		while (!FB.IsLoggedIn)
			yield return null;
		FB.API ("me?fields=id,name,picture,email", HttpMethod.GET, GotMyInformationCallback);
	}

	MyFacebookInfo profile;
	void GotMyInformationCallback(IGraphResult result)
	{
		print (result.RawResult);
		if(result.Error!=null)
		{
			print (result.Error);
		}
		else
		{
			profile = JsonUtility.FromJson<MyFacebookInfo>(result.RawResult);
			SigninWithFB (AccessToken.CurrentAccessToken.TokenString);
		}
	}


	void SigninWithFB(string accessToken){

		if (FB.IsLoggedIn) {
			new FacebookConnectRequest ().SetAccessToken (accessToken).Send ((responses) => {
				if(responses.HasErrors)
					print("Error"+responses.Errors.JSON);
				else{
					print (responses.JSONString);
					TestSave();
				}
			});
		}
	}

	void TestSave(){
		new GameSparks.Api.Requests.LogEventRequest().SetEventKey("TEST_SAVE")
			.SetEventAttribute("Score", 0)
			.SetEventAttribute("Gems", 10)
			.Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Player Saved To GameSparks..."+response.JSONString);

				} else {
					Debug.Log("Error Saving Player Data..."+response.JSONString);
				}
			});
	}

	// Update is called once per frame
	void Update () {
		
	}
}

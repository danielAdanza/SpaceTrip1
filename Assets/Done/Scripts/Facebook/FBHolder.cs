using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;

public class FBHolder : MonoBehaviour 
{
	public GameObject loggedIn;			//the object that contains all the elements that will show when the user loggs in
	public GameObject notLoggedIn;		//the object that contains all the elements that will show when the user is not logged in
	//public GameObject userImage;		//the object that shows the image of the user
	//public GameObject userName;			// the object that shows the name of the user

	private List<object> scoresList = null;
	private Dictionary <string, string> profile = null;
	public GameObject scoreEntryPanel;
	public GameObject scoreScrollList;
	public RawImage background;
	public GameObject settings;
	public GameObject languajes;
	public GameObject credits;
	public GameObject playerData;

	void Awake ()
	{
		FB.Init (SetInit, OnHideUnity);
	}

	private void SetInit ()
	{
		Debug.Log ("Facebook init done!");

		if (FB.IsLoggedIn) 
		{
			Debug.Log ("The user is logged in");
		}
		else 
		{

		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) 
		{
			Time.timeScale = 0;
		} else 
		{
			Time.timeScale = 1;
		}
	}

	public void FBLoggin ()
	{
		FB.Login ("email,publish_actions", AuthCallback);
	}

	void AuthCallback (FBResult result)
	{
		if (FB.IsLoggedIn) {
			Debug.Log ("the login worked");
			DealWithFBMenus(true);
		} else {
			Debug.Log ("the login did not work");
			DealWithFBMenus(false);
		}
	}

	void DealWithFBMenus (bool isloggedIn)
	{
		if (isloggedIn) 
		{
			loggedIn.SetActive (true);
			notLoggedIn.SetActive (false);

			//get profile profile picture and user name
			FB.API(Util.GetPictureURL("me",128,128), Facebook.HttpMethod.GET, DealWithProfilePicture );

			FB.API( "/me?fields=id,first_name", Facebook.HttpMethod.GET, DealWithUserName );


		} else 
		{
			loggedIn.SetActive (false);
			notLoggedIn.SetActive (true);
		}
	}

	void DealWithProfilePicture (FBResult result)
	{
		if (result.Error != null) 
		{
			Debug.Log("we found problems getting the profile picture");

			FB.API(Util.GetPictureURL("me",128,128), Facebook.HttpMethod.GET, DealWithProfilePicture );
		}

		//Image userAvatar = userImage.GetComponent<Image> ();
		//userAvatar.sprite = Sprite.Create (result.Texture, new Rect(0,0,128,128), new Vector2(0,0) );
	}

	void DealWithUserName (FBResult result)
	{
		if (result.Error != null) 
		{
			Debug.Log("we found problems getting the profile picture");
			
			FB.API( "/me?fields=id,first_name", Facebook.HttpMethod.GET, DealWithUserName );
		}

		profile = Util.DeserializeJSONProfile (result.Text);

		//Text message = userName.GetComponent<Text> ();
		//message.text = "Hello, " +  profile["first_name"];
	}

	public void ShareWithFriends ()
	{
		FB.Feed (
			//the message that will appear in the facebook post
			linkCaption: "I am Playing SPACE TRIP!! come and join",
			//the link of the picture that has to be in the server
			picture: "https://lh3.ggpht.com/YAfaxtW4BK5lPFZpdfHurELsswhdQBJseThxCijAS3-gwsBal9PcBpFzTrjFRk1BoI4=h310-rw",
			//the text that they will see
			linkName: "Check it out",
			//that should be the link to google play
			link: "http://apps.facebook.com/" + FB.AppId + "/challenge_brag=" + (FB.IsLoggedIn ? FB.UserId : "guest")

		);
	}

	public void InviteFriends ()
	{
		FB.AppRequest (
			message: "this game is awesome, do yoou wanna check it out?",
			title: "Invite your friends to join you"
		);
	}

	
	public void Invite3Friends ()
	{
		FB.AppRequest (
			message: "this game is awesome, do yoou wanna check it out?",
		//	title: "Invite your friends to join you",
			callback: InviteCallback
			);
	}

	private void InviteCallback(FBResult response)
	{
		if (response != null) {
			var responseObject = Json.Deserialize(response.Text) as Dictionary<string, object>;
			IEnumerable<object> objectArray = (IEnumerable<object>)responseObject["to"];

			Debug.Log(responseObject.Keys);
			if (responseObject.Count >= 3)
			{
				Debug.Log("it enters");
				PlayerData.playerData.currentworld = PlayerData.playerData.currentworld + 1;
				PlayerData.playerData.Save ();
			}
			else
			{
				Debug.Log("it does not");
			}
		}
	}

	public void QueryScores ()
	{
		FB.API ("/app/scores?fields=score,user.limit(30)", Facebook.HttpMethod.GET, ScoresCallBack);
	}

	private void ScoresCallBack (FBResult result)
	{
		background.gameObject.SetActive (true);

		scoresList = Util.DeserializeScores (result.Text);

		foreach (Transform child in scoreScrollList.transform) 
		{
			GameObject.Destroy (child.gameObject);
		}
		foreach (object score in scoresList)
		{
			var entry = (Dictionary<string,object>) score;
			var user = (Dictionary<string,object>) entry["user"];

			//scoresdebug.text = scoresdebug.text + "UN: "+ user["name"] + " - "+ entry["score"]+ " , ";

			GameObject scorePanel;
			scorePanel = Instantiate (scoreEntryPanel) as GameObject;
			scorePanel.transform.parent = scoreScrollList.transform;

			Transform ThisScoreName = scorePanel.transform.Find ("FriendName");
			Transform ThisScoreScore = scorePanel.transform.Find("FriendScore");
			Text ScoreName = ThisScoreName.GetComponent<Text>();
			Text ScoreScore = ThisScoreScore.GetComponent<Text>();

			ScoreName.text = user["name"].ToString();
			ScoreScore.text = entry["score"].ToString();

			Transform TheUserAvatar = scorePanel.transform.Find("FriendAvatar");
			Image userAvatar = TheUserAvatar.GetComponent<Image>();

			FB.API(Util.GetPictureURL(user["id"].ToString(),128,128), Facebook.HttpMethod.GET,delegate(FBResult PictureResult) {
			if (PictureResult.Error != null)
			{
				Debug.Log(PictureResult.Error);
			}
			else
			{
				userAvatar.sprite = Sprite.Create (PictureResult.Texture, new Rect(0,0,128,128),new Vector2(0,0));
			}
		} );
		}
	}

	public void SetScores ()
	{
		var scoreData = new Dictionary <string,string> ();
		scoreData ["score"] = Random.Range (10, 200).ToString(); 

		PlayerPrefs.SetInt ("mode",1);
		FB.API ("/me/scores", Facebook.HttpMethod.POST, delegate(FBResult result) {
			Debug.Log("score submit result: "+ result.Text);
	}, scoreData);
	}

	public void DisapearScore ()
	{
		background.gameObject.SetActive (false);

			foreach (Transform child in scoreScrollList.transform) 
			{	GameObject.Destroy (child.gameObject);}

		if ( PlayerPrefs.GetInt ("mode") == 2 ) 
		{
			settings.gameObject.SetActive(false);
		}
		else if ( PlayerPrefs.GetInt ("mode") == 3 ) 
		{
			languajes.gameObject.SetActive(false);
		}
		else if ( PlayerPrefs.GetInt ("mode") == 4 ) 
		{
			credits.gameObject.SetActive(false);
		}
		else if ( PlayerPrefs.GetInt ("mode") == 5 ) 
		{
			playerData.gameObject.SetActive(false);
		}
	}
}

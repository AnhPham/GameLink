using UnityEngine;
using System.Collections;

public class GameLinkGlobal
{
	public const int GAME_NUMBER = 4;
	public const string APPLE_JSON_URL = "http://s3-ap-northeast-1.amazonaws.com/gamelink/index_ios.json";
	public const string APPLE_ICON_URL = "http://s3-ap-northeast-1.amazonaws.com/gamelink/icon_ios/{0}.png";
	public const string APPLE_STORE_URL = "http://itunes.apple.com/app/id{0}?mt=8";

	public const string ANDROID_JSON_URL = "http://s3-ap-northeast-1.amazonaws.com/gamelink/index_android.json";
	public const string ANDROID_ICON_URL = "http://s3-ap-northeast-1.amazonaws.com/gamelink/icon_android/{0}.png";
	public const string ANDROID_STORE_URL = "https://play.google.com/store/apps/details?id={0}";
}

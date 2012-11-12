using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLinkController : MonoBehaviour
{
	public UIDraggablePanel dragPanel;
	public UIGrid uiGrid;
	public GameObject gameItemPrefab;
	public bool isShowAllGame;
	public int gameNumber = GameLinkGlobal.GAME_NUMBER;
	public bool isCanDrag;
	
	private GameLinkItem[] gameItems;

	private void Start () {
		StartCoroutine(DownLoadList());
	}
	
	private IEnumerator DownLoadList()
	{
		// DOWN LOAD JSON FILE	
		#if UNITY_ANDROID	
		WWW www = new WWW(GameLinkGlobal.ANDROID_JSON_URL);
		#elif UNITY_EDITOR || UNITY_IPHONE
		WWW www = new WWW(GameLinkGlobal.APPLE_JSON_URL);
		#endif
		yield return www;
		
		// JSON MAPPER
		List<GameItemModel> gameItemList =  LitJson.JsonMapper.ToObject<List<GameItemModel>> (www.text);
		
		// IF SHOW ALL GAME
		if (isShowAllGame) {
			gameNumber = gameItemList.Count;
		}
		
		// IF CAN DRAG
		dragPanel.disableDragIfFits = !isCanDrag;
		
		// CREATE GAME ITEMS
		gameItems = new GameLinkItem[gameNumber];
		for (int i = 0; i < gameNumber; i++) {
			GameObject gameItem = Instantiate(gameItemPrefab) as GameObject;
			gameItem.name = "GameItem";
			gameItem.transform.parent = uiGrid.transform;
			gameItem.transform.localScale = Vector3.one;
			gameItem.transform.localPosition = Vector3.zero;
			SetObjectLayer(gameItem, uiGrid.transform.gameObject.layer);
			gameItems[i] = gameItem.GetComponent<GameLinkItem>();
		}	
		uiGrid.Reposition();
		
		// MAKE COUNT LIST FOR RANDOM SELECTION
		List<int> countList = new List<int>();
		for (int i = 0; i < gameItemList.Count; i++) {
			countList.Add(i);
		}
		
		// RANDOM SELECT AND SET DATE FOR GAME ITEM
		for (int i = 0; i < gameNumber; i++) {
			int index = Random.Range(0, countList.Count);
			int val = countList[index];
			
			// REMOVE SELECTED NUMBER FOR AVOID DUPLICATE
			countList.RemoveAt(index);
			
			// SET DATA FOR ITEM
			gameItems[i].Data = gameItemList[val];
		}
	}
	
	private void SetObjectLayer(GameObject go, int layer)
	{
		go.layer = layer;
		Transform[] childs = go.transform.GetComponentsInChildren<Transform>();
		foreach (Transform child in childs) {
			child.gameObject.layer = layer;
		}
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameLinkItem : MonoBehaviour {
	
	public GameObject image;
	public SysFontText labelName;
	
	protected string iconUrl;
	protected string storeUrl;
	protected GameItemModel data;
	
	#region Public
	public GameItemModel Data
	{
		get 
		{ 
			return data; 
		}
		set 
		{ 
			data = value; 		
			SetData();
		}
	}	
	#endregion
	
	#region Protected
	protected virtual void OnClick()
	{
		if (!string.IsNullOrEmpty(storeUrl)) {
			Application.OpenURL(storeUrl);
		}
	}
	
	protected virtual void SetData()
	{
		SetUrlByPlatform();
		SetNameByLanguage();
		SetImage();
	}
	
	protected virtual void SetNameByLanguage()
	{
		switch (Application.systemLanguage)
		{
			case SystemLanguage.Japanese:
				labelName.Text = data.name.ja;
				break;
			case SystemLanguage.English:
				labelName.Text = data.name.en;
				break;
			default:
				labelName.Text = data.name.en;
				break;				
		}
	}
	#endregion

	#region Private
	private void Awake()
	{
		MakeNewMesh();
	}
	
	private void MakeNewMesh() 
	{		
		// NEW MESH FILTER
		image.AddComponent<MeshFilter>();		
        Mesh mesh = image.GetComponent<MeshFilter>().mesh;
        mesh.Clear();
		
		// NEW VERTICLES 2D
		Vector2[] vertices2D;
		vertices2D = new Vector2[] {new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(1, 0)};
		
		// NEW TRIANGLES
        int[] triangles = new int[6] {0,1,2,0,2,3};
 
		// NEW VERTICLES 3D FROM 2D
        Vector3[] vertices3D = new Vector3[vertices2D.Length];
        for (int i=0; i<vertices3D.Length; i++) {
            vertices3D[i] = new Vector3(vertices2D[i].x, vertices2D[i].y, 0);
        }
		
		// SET ALL TO MESH
		mesh.vertices = vertices3D;
        mesh.uv = vertices2D;
        mesh.triangles = triangles;
    }
	
	private void SetUrlByPlatform()
	{
		#if UNITY_ANDROID
			iconUrl = string.Format(GameLinkGlobal.ANDROID_ICON_URL, data.id);
			storeUrl = string.Format(GameLinkGlobal.ANDROID_STORE_URL, data.id);
		#elif UNITY_EDITOR || UNITY_IPHONE
			iconUrl = string.Format(GameLinkGlobal.APPLE_ICON_URL, data.id);
			storeUrl = string.Format(GameLinkGlobal.APPLE_STORE_URL, data.id);
		#endif
	}
	
	private void SetImage()
	{
		StartCoroutine(DownLoadImage());
	}
	
	private IEnumerator DownLoadImage()
	{
		WWW www = new WWW(iconUrl);
		yield return www;
		
		image.renderer.material.mainTexture = www.texture as Texture;
	}	
	#endregion
}
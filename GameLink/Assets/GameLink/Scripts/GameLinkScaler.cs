using UnityEngine;
using System.Collections;
 
public class GameLinkScaler : MonoBehaviour
{
	public const float INVISIBLE_AREA_X = 2000;
    public float baseWidth = 640f;
	public float baseHeight = 960f;
    public bool aspectFit = false;
	
	private Vector3 firstPos;
	
	private void Awake()
	{
		firstPos = transform.localPosition;
		
		// BRING THE TRANSFORM TO INVISIBLE AREA
		transform.localPosition = new Vector3(INVISIBLE_AREA_X, 0, 0);
	}
     
    private void Update()
	{
		// CALCULATE RATION
        Vector3 ratio = new Vector3(
            Screen.width / baseWidth,
            Screen.height / baseHeight,
            1.0f
        );
         
		// SCALE BY THE SMALLER SIZE
        if(aspectFit){
            if(ratio.x > ratio.y){ ratio.x = ratio.y; }
            else if(ratio.y > ratio.x){ ratio.y = ratio.x; }
        }
         
        transform.localScale = ratio;
		
		// BRING THE TRANSFORM BACK TO FIRST POSITION
		transform.localPosition = firstPos;
		
		// ENABLED FALSE BECAUSE ONLY NEED SCALE AT THE FIRST FRAME
		enabled = false;
    }
}
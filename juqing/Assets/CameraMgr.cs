using UnityEngine;
using System.Collections;

public class CameraMgr : MonoBehaviour {
	public Camera uiCamera;
	public Camera mainCamera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AjastCameraScreenSize();
	}

	void AjastCameraScreenSize(){
		float ManualWidth = 960;
		float ManualHeight = 640;

		float defaultAspect=ManualWidth/ManualHeight;
		float screenAspect = Screen.width / (float)Screen.height;
		if (screenAspect > defaultAspect) {//屏幕太宽,保持屏幕高度不变，屏幕宽度留白
			float widthPercent =defaultAspect/screenAspect;
			float leftOffset = (1 - widthPercent) / 2f;
			if (mainCamera != null)
				mainCamera.rect = new Rect (leftOffset, 0, widthPercent, 1);
			if(uiCamera!=null)
				uiCamera.rect= new Rect (leftOffset, 0, widthPercent, 1);
		} else {//屏幕太窄,保持屏幕宽度不变，屏幕高度留白
			float heightPercent = screenAspect / defaultAspect;
			float topOffset = (1 - heightPercent) / 2f;
			if (mainCamera != null)
				mainCamera.rect = new Rect (0, topOffset, 1, heightPercent);
			if(uiCamera!=null)
				uiCamera.rect= new Rect (0, topOffset, 1, heightPercent);
		}


	}
}

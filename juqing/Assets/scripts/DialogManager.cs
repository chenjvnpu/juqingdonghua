using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogEntry{
	public string userName;
	public string content;
	public string imageName;
	public bool isShowLeft;
}
public class DialogData{
	string[] story1=new string[]{};
}
public class DialogManager : MonoBehaviour {
	Text userNameText;
	Text contentText;
	Image userImage;
	bool isFinishText;
	GameObject top;
	GameObject leftDialog;
	GameObject rightDialog;
	bool isShow=false;
	Dictionary<string,Object> modelDic = new Dictionary<string, Object> ();

	public static DialogManager Instance;

	void Awake(){
		Instance = this;
		top = transform.FindChild ("bg_top").gameObject;
		leftDialog = transform.FindChild ("dialog_left").gameObject;
		rightDialog = transform.FindChild ("dialog_right").gameObject;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}



	public void OnSkipBtnClick(){
		
	}

	public void UpdateDialog(DialogEntry data){
		leftDialog.SetActive (data.isShowLeft);
		rightDialog.SetActive (!data.isShowLeft);
		if (data.isShowLeft) {
			leftDialog.GetComponent<DialogWindow> ().updateContent (data);
		} else {
			rightDialog.GetComponent<DialogWindow> ().updateContent (data);
		}
	}

	public void ShowDialog(){
		this.gameObject.SetActive (true);
		top.SetActive (true);
		isShow = true;
	}

	public void CloseDialog(){
		isShow = false;
		top.SetActive (false);
		leftDialog.SetActive (false);
		rightDialog.SetActive (false);
	}
	public Object GetModelByName(string modelName){
		if (modelDic.ContainsKey (modelName))
			return modelDic [modelName];
		else {
			Object obj= Resources.Load ("" + modelName);
			modelDic.Add (modelName, obj);
			return obj;
		}
		return null;
	}
}

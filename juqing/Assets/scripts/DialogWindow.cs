using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogWindow : MonoBehaviour {

	Text userNameText;
	TypewriterEffect contentText;
	Image userImage;
	Transform modeParent;


	bool isFinishText;
	public static DialogWindow Instance;

	void Awake(){
		Instance = this;
		userNameText = transform.FindChild ("bg_botom/user").GetComponent<Text> ();
		contentText = transform.FindChild ("bg_botom/content").GetComponent<TypewriterEffect> ();
		userImage = transform.FindChild ("bg_botom/userImage").GetComponent<Image> ();
		modeParent = transform.FindChild ("hero");
		modeParent.gameObject.SetActive (true);
		userImage.gameObject.SetActive (false);

	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(gameObject.activeSelf && Input.GetMouseButtonDown(0)){
			if (contentText.isFinishTypewrite()) {
				CommandManager.instance.Next ();
			} else
				contentText.FinishAnimation ();

		}

	}

	public void updateContent(DialogEntry data){
		userNameText.text = data.userName;
		contentText.SetText (data.content);
		string modelName = data.imageName;
		int count = modeParent.childCount;
		bool flag = false;//标记当前名称的model是否已经实例化过
		for (int i = 0; i < count; i++) {
			if (modeParent.GetChild (i).name.Equals (modelName)) {
				modeParent.GetChild (i).gameObject.SetActive (true);
				flag = true;
			} else {
				modeParent.GetChild (i).gameObject.SetActive (false);
			}
		}

		if(!flag){
			Object model = DialogManager.Instance.GetModelByName (modelName);
			if(model){
				GameObject gob = Instantiate (model, modeParent) as GameObject;
				ChangeGameObjectLayer (gob, 5);//将模型所有子对象的层级设置为UI层
				gob.transform.localScale = Vector3.one;
				gob.transform.localPosition = Vector3.zero;
				gob.transform.localEulerAngles = Vector3.zero;
				gob.name = modelName;
			}
		}


	}

	void ChangeGameObjectLayer(GameObject gob,int targetLayer){
		Transform[] trans = gob.GetComponentsInChildren<Transform> ();
		for (int i = 0; i < trans.Length; i++) {
			trans [i].gameObject.layer = targetLayer;
		}
	}

	public void OnSkipBtnClick(){

	}
}

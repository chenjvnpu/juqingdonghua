using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StoryMgr.Instance.Init ();
		StoryMgr.StoryEntry st=StoryMgr.Instance.GetDataById<StoryMgr.StoryEntry> (3);
		Debug.Log (st.id+"--"+st.content);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

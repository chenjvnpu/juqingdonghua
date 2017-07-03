using UnityEngine;
using System.Collections;
/// <summary>
/// 显示对话模式UI
/// </summary>
public class CommandDialogueModeEnter : Command {

//	public CommandDialogueModeEnter(){
//		
//	}

	/// <summary>
	/// Execute this instance.
	/// </summary>
	public override void Execute ()
	{
		base.Execute ();
		GameObject gob = GameObject.FindGameObjectWithTag ("dialog");
		if(gob==null){
			Object temp= Resources.Load ("dialog") ;
			Transform parent = GameObject.Find ("Canvas").transform;
			gob=GameObject.Instantiate (temp)as GameObject;
			gob.transform.SetParent (parent,false);
//			gob.GetComponent<RectTransform> ().anchoredPosition = Vector2.zero;

		}

		DialogManager.Instance.ShowDialog ();

		CommandManager.instance.Next ();
	}
}

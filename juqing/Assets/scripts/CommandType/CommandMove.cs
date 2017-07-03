using UnityEngine;
using System.Collections;
/// <summary>
/// Command move.
/// </summary>
public class CommandMove : Command {
	string targetName;
	Vector3 destinationPos;
	float durationTime;
	GameObject targetGob;
	bool needUpdata=false;
	public CommandMove (string targetName,Vector3 desPos,float durationTime=0f){
		this.targetName = targetName;
		this.destinationPos = desPos;
		this.durationTime = durationTime;
	}

	/// <summary>
	/// Execute this instance.
	/// </summary>
	public override void Execute ()
	{
		base.Execute ();
		targetGob = GameObject.Find (targetName);

		if (durationTime == 0) {
			targetGob.transform.position = destinationPos;
			Next ();
		} else
			needUpdata = true;
		
	}

	public override void Update ()
	{
		base.Update ();
		if (needUpdata) {
			Debug.Log ("commandMove---update");
			if (targetGob.transform.position != destinationPos) {
				targetGob.transform.position = Vector3.Lerp (targetGob.transform.position, destinationPos, durationTime);
			} else {
				Debug.Log ("commandMove---end");
				Next ();
				needUpdata = false;
			}

		}
	}
}

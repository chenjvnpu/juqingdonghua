using UnityEngine;
using System.Collections;
/// <summary>
/// Command rotate.
/// </summary>
public class CommandRotate : Command {

	string targetName;
	Vector3 destinationRotate;
	float durationTime;
	GameObject targetGob;
	bool needUpdata=false;
	public CommandRotate(string targetName,Vector3 destinationRotate,float durationTime=0){
		this.targetName = targetName;
		this.destinationRotate = destinationRotate;
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
			targetGob.transform.localEulerAngles = destinationRotate;
			Next ();
		} else {
			needUpdata = true;
		}

	}

	public override void Update ()
	{
		base.Update ();
		if (needUpdata) {
			Debug.Log ("commandRotate---update");
			if(targetGob.transform.localEulerAngles != destinationRotate){
				targetGob.transform.rotation = Quaternion.Slerp (targetGob.transform.rotation, Quaternion.Euler(destinationRotate), durationTime);
			}else{
				Next ();
				needUpdata = false;
			}

		}
	}
}

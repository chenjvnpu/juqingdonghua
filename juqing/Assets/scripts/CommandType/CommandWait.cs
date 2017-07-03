using UnityEngine;
using System.Collections;
/// <summary>
/// Command wait.
/// </summary>
public class CommandWait : Command {
	float waitTime;
	public CommandWait(float waitTime){
		this.waitTime = waitTime;
	}
	/// <summary>
	/// Execute this instance.
	/// </summary>
	public override void Execute ()
	{
		base.Execute ();

	}
}

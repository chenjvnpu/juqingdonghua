using UnityEngine;
using System.Collections;
/// <summary>
/// Command play animation.
/// </summary>
public class CommandPlayAnim : Command {
	string targetName;

	public CommandPlayAnim(string targetName){
		this.targetName=targetName;
	}
	/// <summary>
	/// Execute this instance.
	/// </summary>
	public override void Execute ()
	{
		base.Execute ();
	}
}

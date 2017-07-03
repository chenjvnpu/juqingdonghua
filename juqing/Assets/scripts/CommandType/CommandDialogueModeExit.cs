using UnityEngine;
using System.Collections;
/// <summary>
/// Command dialogue mode exit.
/// </summary>
public class CommandDialogueModeExit : Command {

//	public CommandDialogueModeExit(){
//	
//	}
	/// <summary>
	/// Execute this instance.
	/// </summary>
	public override void Execute ()
	{
		base.Execute ();
		DialogManager.Instance.CloseDialog ();
	}
}

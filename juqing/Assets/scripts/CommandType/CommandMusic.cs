using UnityEngine;
using System.Collections;
/// <summary>
/// Command music.
/// </summary>
public class CommandMusic : Command {
	string musicName;
	public CommandMusic(string musicName){
		this.musicName = musicName;
	}

	/// <summary>
	/// Execute this instance.
	/// </summary>
	public override void Execute ()
	{
		base.Execute ();
	}
}

using UnityEngine;
using System.Collections;
/// <summary>
/// Command dialogue.
/// </summary>
public class CommandDialogue : Command {
	
	string story;
	int startIndex;
	int endIndex;
	int nextExcuteCount;

	public CommandDialogue(string story,int startIndex,int endIndex,int nextExcuteCount){
		this.story = story;
		this.startIndex = startIndex;
		this.endIndex = endIndex;
		this.nextExcuteCount = nextExcuteCount;
	}

	/// <summary>
	/// Execute this instance.
	/// </summary>
	public override void Execute ()
	{
		base.Execute ();
//		bool isLeftDia = startIndex % 2 == 0 ? false : true;
//		if(isLeftDia){
			DialogEntry data = new DialogEntry();
			StoryMgr.StoryEntry story=StoryMgr.Instance.GetDataById<StoryMgr.StoryEntry> (startIndex);
			data.imageName = story.hero;
			data.content = story.content;
			data.isShowLeft = story.type=="1"?true:false;
			data.userName = story.heroName;
			DialogManager.Instance.UpdateDialog (data);
			
//		}
	}

	void getStory(){
	
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class CommandManager : MonoBehaviour {
	 
	public static CommandManager instance;
	 
	private List<Command> commands = new List<Command>();
	private int nowIndex = 0;
	public bool isDialogueMode = false;
	bool isExcuteCommond=false;
	 
	//缓存Transform
	[SerializeField]
	public List<string> startObj = new List<string>();//一开始就存在的物体
	public Dictionary<string,Transform> allObj = new Dictionary<string,Transform>();
	 
	void Awake()
	{
		instance = this;
		StoryMgr.Instance.Init ();
	}
	 
	void Start()
	{
		for (int i = 0; i < startObj.Capacity;i++ )
			allObj.Add(startObj[i], GameObject.Find(startObj[i]).transform);


//		commands.Add(new CommandMove("Main Camera", new Vector3(-6f, 7f, -8f), 0f));
//
//		commands.Add(new CommandRotate("Main Camera", new Vector3(45f, 0f, -0f), 0f));



		 
//		commands.Add(new CommandMusic("Taylor Swift - Red"));
//		 
		//场景一 对话驱动画面
		commands.Add(new CommandDialogueModeEnter());
//		 

 
		commands.Add(new CommandDialogue("Story1", 1, 1, 2));
		commands.Add(new CommandMove("Main Camera", new Vector3(99f, 12f, 34f), 0f));
		commands.Add(new CommandRotate("Main Camera",new Vector3(17f, -169f, 0f), 0f) );

		commands.Add(new CommandDialogue("Story1", 2, 2, 3));
		commands.Add(new CommandMove("Main Camera",new Vector3(97f, 12f, 29.85f), 0f) );
		commands.Add(new CommandRotate("Main Camera", new Vector3(18.209f, -10.156f, 0f), 0f));

		commands.Add(new CommandDialogue("Story1", 3, 3, 4));
		commands.Add(new CommandMove("Main Camera", new Vector3(106.1376f, 16.25043f, 32.37301f), 0f));
		commands.Add(new CommandRotate("Main Camera",new Vector3(27.687f, -89.36501f, 0f), 0f) );
		commands.Add(new CommandDialogue("Story1", 4, 4, 5));
		commands.Add(new CommandDialogue("Story1", 5, 5, 6));
//		commands.Add(new CommandRotate("Main Camera", new Vector3(10f, 180f, 0f), 0f));
//		commands.Add(new CommandMove("Main Camera", new Vector3(-2.5f, 3.4f, -1f), 0f));
//		commands.Add(new CommandMove("Main Camera", new Vector3(-4.6f, 3.4f, -1f), 5f));
//		 
//		commands.Add(new CommandDialogueModeExit());
//		 
//		//场景二 自动
//		commands.Add(new CommandMove("Main Camera", new Vector3(-20.5f, 5.8f, -7.9f), 0f));
//		commands.Add(new CommandRotate("Main Camera", new Vector3(12f, 180f, 0f), 0f));
//		 
//		commands.Add(new CommandWait(2f));
//		commands.Add(new CommandPlayAnim("skeleton_warrior1", AnimatorManager.instance.run));
//		commands.Add(new CommandPlayAnim("skeleton_warrior2", AnimatorManager.instance.run));
//		commands.Add(new CommandPlayAnim("skeleton_warrior3", AnimatorManager.instance.run));
//		commands.Add(new CommandPlayAnim("skeleton_warrior4", AnimatorManager.instance.run));
//		commands.Add(new CommandPlayAnim("skeleton_warrior5", AnimatorManager.instance.run));
//		 
//		commands.Add(new CommandWait(2f));
//		commands.Add(new CommandPlayAnim("magic", AnimatorManager.instance.attack1));
//		 
//		commands.Add(new CommandWait(1f));
//		commands.Add(new CommandPlayAnim("skeleton_warrior1", AnimatorManager.instance.dead));
//		commands.Add(new CommandPlayAnim("skeleton_warrior2", AnimatorManager.instance.dead));
//		commands.Add(new CommandPlayAnim("skeleton_warrior3", AnimatorManager.instance.dead));
//		commands.Add(new CommandPlayAnim("skeleton_warrior4", AnimatorManager.instance.dead));
//		commands.Add(new CommandPlayAnim("skeleton_warrior5", AnimatorManager.instance.dead));
//		 
//		commands.Add(new CommandPlayAnim("magic", AnimatorManager.instance.stand));
//		 
//		commands.Add(new CommandDialogue("Story1", 3, 5, 0));
//		 
//		commands.Add(new CommandWait(1f));
	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Q)) {
			isExcuteCommond = true;
			commands[nowIndex].Execute();
		}

		if(isExcuteCommond){
			if(commands[nowIndex]!=null){
				commands [nowIndex].Update ();
			}
		}
			
	}
	 
	//对话模式下直接进入下一状态
	public void Next()
	{
		nowIndex++;
		if (nowIndex < commands.Count)
			commands [nowIndex].Execute ();
		else {
			OnCommandsFinish ();
		}
		
	}
	 
	//自动模式下直接进入下一状态
	public void Next2()
	{
		if (isDialogueMode)
			return;
		else
			Next();
	}

	public void OnCommandsFinish(){
		isExcuteCommond = false;
		commands.Clear ();
	}
}
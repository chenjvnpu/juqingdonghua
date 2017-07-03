using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;


public class StoryMgr:ModelMgrBase  {

	public 	class StoryEntry:ModelBase{
		
		public string chapter;
		public string index;
		public string content;
		public string hero;
		public string heroName;
		public string type;

		public void show(){
			string str = "";
			//取得当前方法命名空间
			str += "命名空间名:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "\n";
			//取得当前方法类全名
			str += "类名:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "\n";
			Debug.Log (str);
		}
	}
	private static StoryMgr instance;

	public static StoryMgr Instance{
		get
		{ 
			if (instance == null)
				instance = new StoryMgr ();
			return instance;
		
		}
	}

 
	public override void Init ()
	{
		base.Init ();
		Load ();
	}

	 

	void Load(){
		string path=Application.streamingAssetsPath+"/xml/story.xml";
		string[] keys = new string[]{ "id","chapter","index","content","hero","heroName","type"};
		LoadFromXml (path,keys,"StoryMgr+StoryEntry");
	}



}

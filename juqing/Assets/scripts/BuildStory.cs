using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
public class BuildStory : MonoBehaviour {
	public string fileName;
	class StroyEntry{
		public int id;
		public int chapter;
		public string content;
		public string hero;
		public bool type;
	}
	// Use this for initialization
	void Start () {
		loadFile ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void loadFile(){
		string path = Application.dataPath + "/file/"+fileName;
		FileStream fs = new FileStream (path,FileMode.Open);
	
		using(StreamReader sr=new StreamReader(fs)){
			string str = sr.ReadLine ();
			while (str!=null) {
				string[] arr = str.Split (',');
				if (arr.Length == 6) {
					addToXml (arr);
				} else
					Debug.LogError ("data error"+str);
				str = sr.ReadLine ();
			}
		}
		fs.Close ();
	}

	/// <summary>
	/// Adds to xml.
	/// </summary>
	/// <param name="arr">Arr.</param>
	void addToXml(string[] arr){
		string xmlPath = Application.streamingAssetsPath + "/" + "story.xml";
		if(!File.Exists(xmlPath)){
			CreatXmlFile (xmlPath);
		}
		XmlDocument xmldoc = new XmlDocument ();
		xmldoc.Load (xmlPath);
		XmlNode root= xmldoc.SelectSingleNode ("root");

		XmlElement record = xmldoc.CreateElement ("Record");

		record.SetAttribute ("id",arr[0]);
		record.SetAttribute ("chapter",arr[1]);
		record.SetAttribute ("index",arr[2]);
		record.SetAttribute ("content",arr[3]);
		record.SetAttribute ("hero",arr[4]);
		record.SetAttribute ("type",arr[5]);

		root.AppendChild (record);
		xmldoc.Save (xmlPath);

	}

	void CreatXmlFile(string path){
		XmlDocument doc = new XmlDocument ();
		XmlDeclaration dec= doc.CreateXmlDeclaration("1.0", "utf-8", null);
		doc.AppendChild (dec);
		XmlNode root= doc.CreateElement ("root");
		doc.AppendChild (root);
		doc.Save (path);
		Debug.Log ("save path=" + path);
	}
}

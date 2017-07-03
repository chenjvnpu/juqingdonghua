using UnityEngine;
using System.Xml;
using System.IO;
using UnityEditor;
//using System;

/// <summary>
/// 把给定列数的csv文件转换为xml文件.该类文件放在file／csv文件夹下
/// csv文件的格式：第一行为属性的名称，后面若干行为属性的值
/// 生成的xml文件，放在StreamingAssets／xml目录下
/// </summary>
public class CsvToXmlTools : Editor {


	[MenuItem("Assets/CsvToXml/Story")]
	static void CsvToXml_Story(){
		 string path=AssetDatabase.GetAssetPath (Selection.activeObject);
		if(path.EndsWith(".csv"))
			loadFile (path);
	}

	/// <summary>
	/// 加载csv文件，并按行读取数据.
	/// </summary>
	/// <param name="filePath">文件路径.</param>
	/// <param name="columCount">列数.</param>
	static  void loadFile(string filePath){
		string path = filePath;
		string saveName = Path.GetFileNameWithoutExtension(path);

		string xmlPath = Application.streamingAssetsPath + "/xml/" +saveName+ ".xml";
		CreatXmlFile (xmlPath);//创建或者覆盖之前的xml文件
		

		//读取csv文件
		FileStream fs = new FileStream (path,FileMode.Open);
		using(StreamReader sr=new StreamReader(fs)){
			string str = sr.ReadLine ();
			string[] keys = str.Split (',');//保存属性名称
			str = sr.ReadLine ();
			addToXml (new string[]{"dataType"},new string[]{str},xmlPath);//保存数据格式
			int columCount = keys.Length ;
			while ((str=sr.ReadLine ())!=null) {
				string[] arr = str.Split (',');
				if (keys.Length ==  arr.Length) {
					addToXml (keys,arr,xmlPath);//保存读取的数据到xml文件中
				} else
					Debug.LogError ("data error"+str);
				
			}
		}
		fs.Close ();
		Debug.Log ("转换文件结束");
	}



	/// <summary>
	/// 为xml文件添加新的节点.
	/// </summary>
	/// <param name="keys">需要添加的数据的健.</param>
	/// <param name="arr">需要添加的数据值.</param>
	/// <param name="xmlPath">xml文件的位置.</param>
	static  void addToXml(string[] keys,string[] values,string xmlPath){
		XmlDocument xmldoc = new XmlDocument ();
		xmldoc.Load (xmlPath);
		XmlNode root= xmldoc.SelectSingleNode ("root");

		XmlElement record = xmldoc.CreateElement ("Record");
		for (int i = 0; i < keys.Length; i++) {
//			Debug.Log(keys[i]+"-------"+values[i]);
			record.SetAttribute (keys [i], values [i]);
		}

		root.AppendChild (record);
		xmldoc.Save (xmlPath);

	}

	/// <summary>
	/// 创建一个新的xml文件.
	/// </summary>
	/// <param name="path">xml文件的保存路径.</param>
	static  void CreatXmlFile(string path){
		XmlDocument doc = new XmlDocument ();
		XmlDeclaration dec= doc.CreateXmlDeclaration("1.0", "utf-8", null);
		doc.AppendChild (dec);
		XmlNode root= doc.CreateElement ("root");
		doc.AppendChild (root);
		doc.Save (path);
		Debug.Log ("save path=" + path);
	}
}

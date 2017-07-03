using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Reflection;

public class ModelMgrBase {

	public Dictionary<int,ModelBase> dataDic = new Dictionary<int, ModelBase>();

	public virtual void Init(){
		
	}
		
	/// <summary>
	/// 从 xml 中加载数据并保存到字典里面.
	/// </summary>
	/// <param name="path">Path.</param>
	/// <param name="keys">Keys.</param>
	/// <param name="className">Class name.</param>
	protected void LoadFromXml(string path,string[] keys,string className){
		XmlDocument xml = new XmlDocument ();
		xml.Load (path);
		XmlNode root= xml.SelectSingleNode ("root");
		XmlNodeList nodes = root.ChildNodes;

		string[] dataTypes=GetDataType ((XmlElement)nodes [0]);

		for (int i = 1; i < nodes.Count; i++) {
			XmlElement item = nodes[i] as XmlElement;

			Assembly assembly = Assembly.GetExecutingAssembly();
			ModelBase model= (ModelBase)assembly.CreateInstance (className);
			if (model == null)
				continue;
			System.Type type= model.GetType ();

			for (int j = 0; j < keys.Length; j++) {

				FieldInfo fi= type.GetField (keys [j]);
				object dataValue=null;
				switch (dataTypes[j]) {
				case "int":
					dataValue = int.Parse (item.GetAttribute (keys [j]));
					break;
				case "float":
					dataValue = float.Parse (item.GetAttribute (keys [j]));
					break;
				case "bool":
					dataValue = bool.Parse (item.GetAttribute (keys [j]));
					break;
				case "string":
					dataValue =item.GetAttribute (keys [j]);
					break;
				default:
					break;
				}

				if(fi!=null){
					fi.SetValue(model,dataValue);

				}
			}

			dataDic.Add (model.id,model);

		}
	}

	string[] GetDataType(XmlElement element){
//		Debug.Log (bool.Parse("true"));
//		Debug.Log (float.Parse("1.23"));
		string dt = element.GetAttribute ("dataType");
		return dt.Split(',');
	}

	/// <summary>
	/// 通过ID从集合中查找数据.
	/// </summary>
	/// <param name="id">Identifier.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public T GetDataById<T>(int id) where T:ModelBase{
		T model;
		ModelBase mb;
		dataDic.TryGetValue (id, out mb);
		if(dataDic.ContainsKey(id)){
			
			return (T)dataDic[id];
		}else return default(T);
	}

	/// <summary>
	/// 通过className创建实例对象.
	/// </summary>
	/// <returns>The instance by class name.</returns>
	/// <param name="className">Class name.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	private T CreateInstanceByClassName<T>(string className){
		Assembly assembly = Assembly.GetExecutingAssembly();
		object obj= assembly.CreateInstance (className);
		//		obj.GetType().GetField("chapter").SetValue(obj,21); //获取指定名称的字段
		//		System.Reflection.PropertyInfo propertyInfo = type.GetProperty("chapter"); //获取指定名称的属性
		//		propertyInfo.SetValue(obj,21,null);
		return (T)obj;
	}


}

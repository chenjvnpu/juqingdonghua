using UnityEngine;
using System.Collections;
 
public class Command {
	 
	public virtual void Execute() { }
	public virtual void  Next()
	{
		CommandManager.instance.Next2();

	}
	public virtual void Update(){
		
	}
}
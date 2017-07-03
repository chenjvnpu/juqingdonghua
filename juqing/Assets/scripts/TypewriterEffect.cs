using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/// <summary>
/// 打字机效果显示文字.
/// </summary>
public class TypewriterEffect : MonoBehaviour {

	private float charsPerSecond = 0.1f;//打字时间间隔
	private string words;//保存需要显示的文字

	private bool isActive = false;
	private float timer;//计时器
	private Text myText;
	private int currentPos=0;//当前打字位置

	void Awake(){
		myText = GetComponent<Text> ();
	}
	// Use this for initialization
	void Start () {
		InitTyper ();

	}

	void InitTyper(){
		myText.text = "";//获取Text的文本信息，保存到words中，然后动态更新文本显示内容，实现打字机的效果
		timer = 0;
		currentPos=0;
	}


	void Update () {
		OnStartWriter ();
		//Debug.Log (isActive);
	}



	/// <summary>
	/// 执行打字任务
	/// </summary>
	void OnStartWriter(){

		if(isActive){
			timer += Time.deltaTime;
			if(timer>=charsPerSecond){//判断计时器时间是否到达
				timer = 0;
				currentPos++;
				if(currentPos>=words.Length) {
					OnFinish();
					return;
				}
				myText.text = words.Substring (0,currentPos);//刷新文本显示内容


			}

		}
	}
	/// <summary>
	/// 结束打字，初始化数据
	/// </summary>
	void OnFinish(){
		isActive = false;
		myText.text = words;
	}

	/// <summary>
	/// 设置文本内容.
	/// </summary>
	/// <param name="textContent">Text content.</param>
	public void SetText(string textContent){
		words = textContent;
		InitTyper ();
		isActive = true;
	}

	/// <summary>
	/// 打印动画是否结束.
	/// </summary>
	/// <returns><c>true</c>, true：结束，false：还在播放动画 <c>false</c> otherwise.</returns>
	public bool isFinishTypewrite(){
		return !isActive;
	}

	/// <summary>
	/// 停止打字播放动画.
	/// </summary>
	public void FinishAnimation(){
		OnFinish ();
	}


}

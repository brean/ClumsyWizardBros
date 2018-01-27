using UnityEngine;
using System.Collections;

public class QuitOnClick : MonoBehaviour {

	// Use this for initialization
	public void Quit () {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying =false;
		#else 
		Application.Quit();
		#endif
	}

}

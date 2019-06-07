using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

	// Use this for initialization
	public void LoadScene (int level) {
		SceneManager.LoadScene (level);
	}

}

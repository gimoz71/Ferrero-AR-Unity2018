using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {
	
	public int level;    //Level to open after splash

	public void GoToLevel() {
		SceneManager.LoadScene (level);
		Debug.Log("sdfsdf");
	}
}
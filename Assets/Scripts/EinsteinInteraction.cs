using UnityEngine;
using System.Collections;


//---------------------------------------------------
// Script interazione Einstein
//---------------------------------------------------

public class EinsteinInteraction : MonoBehaviour {

	// dichiarazioni variabili ed oggetti

	private AudioSource audiosource;
	private Animator animator;
	public Transform targetCody;

	public Transform targetSerena;
	private bool audiotrigger;

	//inizializzo interazioni audio
	public AudioClip EinsteinIdle;
	public AudioClip EinsteinToCody;
	public AudioClip EinsteinToCodyTwo;
	public AudioClip EinsteinToCodyThree;
	public AudioClip EinsteinToSerena;
	public AudioClip EinsteinToSerenaTwo;


	// Nuova gestione clip audio

	public void stopAudio () {
		audiosource.Stop();
	}

	public void startEinsteinIdle () {
		audiosource.PlayOneShot(EinsteinIdle);
	}

	public void startEinsteinToCody () {
		audiosource.PlayOneShot(EinsteinToCody);
	}

	public void startEinsteinToCodyTwo () {
		audiosource.PlayOneShot(EinsteinToCodyTwo);
	}
	public void startEinsteinToCodyThree () {
		audiosource.PlayOneShot(EinsteinToCodyThree);
	}

	public void startEinsteinToSerena () {
		audiosource.PlayOneShot(EinsteinToSerena);
	}

	public void startEinsteinToSerenaTwo () {
		audiosource.PlayOneShot(EinsteinToSerenaTwo);
	}

	//---------------------------------------------------
	// settaggi all'avvio
	//---------------------------------------------------

	void Start(){

		// mi assicuro che tutte le variabil di interazione siano a zero (idle state in )
		audiosource = GetComponent<AudioSource> ();
		animator = GetComponent <Animator> ();
		animator.SetBool ("lookCody", false);
		animator.SetBool ("lookSerena", false);

		audiotrigger=true;

	}


	//---------------------------------------------------
	// inizio interazione audio (play one time)
	//---------------------------------------------------
	void OnTriggerEnter (Collider other) {

		// blocco qualsiasi audio attivo nell'oggetto corrente
		audiosource.Stop();

		if (other.gameObject.name == "cody") {

			// attivo animazione per Einstein verso Cody
			animator.SetBool ("lookCody", true);
		}
		if (other.gameObject.name == "serena") {

			// attivo animazione per Einstein verso Serena
			animator.SetBool ("lookSerena", true);
		}
	}


	//---------------------------------------------------
	// inizio interazione
	//---------------------------------------------------
	void OnTriggerStay (Collider other) {

		// blocco qualsiasi audio attivo nell'oggetto corrente

		if (audiotrigger) {

			Debug.Log ("************************  EINSTEIN testBool: ON     ******************");
			audiosource.Stop ();
			audiotrigger = false;
		}

		//-------------------------------
		// interazione Einstein <-> Cody
		//-------------------------------

		if (other.gameObject.name == "cody") {

			// gurda Cody
			transform.LookAt(targetCody); 

			// script di fix assi di rotazione 
			var rot = transform.localRotation.eulerAngles;
			rot.z = 0f;
			rot.x = 0f;
			transform.localRotation = Quaternion.Euler(rot);
		}


		//-------------------------------
		// interazione Einstein <-> Serena 
		//-------------------------------

		if (other.gameObject.name == "serena") {

			// gurda Serena
			transform.LookAt(targetSerena); 

			// script di fix assi di rotazione 
			var rot = transform.localRotation.eulerAngles;
			rot.z = 0f;
			rot.x = 0f;
			transform.localRotation = Quaternion.Euler(rot);
		}
	}


	//---------------------------------------------------
	// fine interazione
	//---------------------------------------------------

	void OnTriggerExit (Collider other) {

		audiotrigger = true;
		audiosource.Stop();

		// resetto tutte le trasformazioni
		transform.localRotation = Quaternion.identity;
		transform.localPosition = Vector3.zero;
		transform.localScale = Vector3.one;

		// setto tutte le variabili di inerazione a zero
		animator.SetBool ("lookCody", false);
		animator.SetBool ("lookSerena", false);

	}
}
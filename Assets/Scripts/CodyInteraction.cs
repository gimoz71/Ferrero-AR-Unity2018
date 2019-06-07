using UnityEngine;
using System.Collections;


//---------------------------------------------------
// Script interazione Cody Simpson
//---------------------------------------------------

public class CodyInteraction : MonoBehaviour {

	// dichiarazioni variabili ed oggetti

	private AudioSource audiosource;
	private Animator animator;
	private bool audiotrigger;

	public Transform targetEinstein;
	public Transform targetSerena;

	//inizializzo interazioni audio
	public AudioClip CodyIdle;
	public AudioClip CodyToEinsteinOne;
	public AudioClip CodyToEinsteinTwo;
	public AudioClip CodyToSerenaDiscoLoop;
	public AudioClip CodyToSerena;

	// Nuova gestione clip audio

	public void stopAudio () {
		audiosource.Stop();
	}

	public void startCodyIdle () {
		audiosource.PlayOneShot(CodyIdle);
	}

	public void startCodyToSerena () {
		audiosource.PlayOneShot(CodyToSerena);
	}
	public void startCodyToSerenaDiscoLoop () {
		audiosource.PlayOneShot(CodyToSerenaDiscoLoop);
	}

	public void startCodyToEinsteinOne () {
		audiosource.PlayOneShot(CodyToEinsteinOne);
	}

	public void startCodyToEinsteinTwo () {
		audiosource.PlayOneShot(CodyToEinsteinTwo);
	}

	//---------------------------------------------------
	// settaggi all'avvio
	//---------------------------------------------------

	void Start(){

		// mi assicuro che tutte le variabil di interazione siano a zero (idle state in )
		audiosource = GetComponent<AudioSource> ();
		animator = GetComponent <Animator> ();
		animator.SetBool ("lookEinstein", false);
		animator.SetBool ("lookSerena", false);

		audiotrigger=true;

	}


	//---------------------------------------------------
	// inizio interazione audio (play one time)
	//---------------------------------------------------
	void OnTriggerEnter (Collider other) {

		// blocco qualsiasi audio attivo nell'oggetto corrente
		audiosource.Stop();

		if (other.gameObject.name == "einstein") {
			
			// attivo animazione per Cody verso Einstein
			animator.SetBool ("lookEinstein", true);
		}
		if (other.gameObject.name == "serena") {
			
			// attivo animazione per Cody verso Serena
			animator.SetBool ("lookSerena", true);
		}
	}


	//---------------------------------------------------
	// inizio interazione
	//---------------------------------------------------
	void OnTriggerStay (Collider other) {
		
		// blocco qualsiasi audio attivo nell'oggetto corrente (solo una volta)

		if (audiotrigger) {

			Debug.Log ("************************  CODY testBool: ON     ******************");
			audiosource.Stop ();
			audiotrigger = false;
		}

		//-------------------------------
		// interazione Cody <-> Einstein
		//-------------------------------

		if (other.gameObject.name == "einstein") {

			// guarda Einstein
			transform.LookAt(targetEinstein); 

			// script di fix assi di rotazione 
			var rot = transform.localRotation.eulerAngles;
			rot.z = 0f;
			rot.x = 0f;
			transform.localRotation = Quaternion.Euler(rot);
		}


		//-------------------------------
		// interazione Cody <-> Serena 
		//-------------------------------

		if (other.gameObject.name == "serena") {

			// guarda Serena
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
		animator.SetBool ("lookEinstein", false);
		animator.SetBool ("lookSerena", false);

	}
}
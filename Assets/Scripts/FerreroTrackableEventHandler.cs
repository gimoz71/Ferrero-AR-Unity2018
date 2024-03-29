/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class FerreroTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 		
        private TrackableBehaviour mTrackableBehaviour;
    
        #endregion // PRIVATE_MEMBER_VARIABLES


		#region PUBLIC_MEMBER_VARIABLES

		public GameObject charObject;

		#endregion

        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS

		

        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				//GetComponent<AudioSource> ().PlayOneShot (audioIdle);
                OnTrackingFound();
            }
            else
            {
				//GetComponent<AudioSource> ().Stop();
				charObject.GetComponent<AudioSource> ().Stop ();
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			Animator[] animatorComponents = GetComponentsInChildren<Animator> (); 

			foreach (Animator anim in animatorComponents) {
				anim.SetBool("Start", true);
				//Debug.Log ("***START anim component: " + anim.name);
			}
            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
			

            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			Animator[] animatorComponents = GetComponentsInChildren<Animator> (); 

			foreach(GameObject fooObj in GameObject.FindGameObjectsWithTag("Player")) {

				if (fooObj.gameObject.name == "cody" && (fooObj.GetComponent <Animator> ().GetBool ("lookEinstein") || fooObj.GetComponent <Animator> ().GetBool ("lookSerena") ) ) {
					fooObj.GetComponent <Animator> ().SetBool ("lookEinstein", false);
					fooObj.GetComponent <Animator> ().SetBool ("lookSerena", false);
					fooObj.GetComponent<AudioSource>().Stop();

					// resetto tutte le trasformazioni
					fooObj.transform.localRotation = Quaternion.identity;
					fooObj.transform.localPosition = Vector3.zero;
					fooObj.transform.localScale = Vector3.one;
				}
				if (fooObj.gameObject.name == "einstein" && (fooObj.GetComponent <Animator> ().GetBool ("lookCody") || fooObj.GetComponent <Animator> ().GetBool ("lookSerena") ) ) {
					fooObj.GetComponent <Animator> ().SetBool ("lookCody", false);
					fooObj.GetComponent <Animator> ().SetBool ("lookSerena", false);
					fooObj.GetComponent<AudioSource>().Stop();

					// resetto tutte le trasformazioni
					fooObj.transform.localRotation = Quaternion.identity;
					fooObj.transform.localPosition = Vector3.zero;
					fooObj.transform.localScale = Vector3.one;
				}
				if (fooObj.gameObject.name == "serena" && (fooObj.GetComponent <Animator> ().GetBool ("lookCody") || fooObj.GetComponent <Animator> ().GetBool ("lookEinstein") ) ) {
					fooObj.GetComponent <Animator> ().SetBool ("lookCody", false);
					fooObj.GetComponent <Animator> ().SetBool ("lookEinstein", false);
					fooObj.GetComponent<AudioSource>().Stop();

					// resetto tutte le trasformazioni
					fooObj.transform.localRotation = Quaternion.identity;
					fooObj.transform.localPosition = Vector3.zero;
					fooObj.transform.localScale = Vector3.one;
				}
			
			}

			foreach (Animator anim in animatorComponents) {
				
				anim.SetBool("Start", false);
				//Debug.Log ("***STOP anim component: " + anim.name);
			}
            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS
    }
}

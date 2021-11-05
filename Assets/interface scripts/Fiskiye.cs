using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fiskiye : MonoBehaviour, IRepairable {

    private GameObject puffFX;
    private GameObject myParticle;

    private void Awake() {
        puffFX = GameObject.Find("puffFX");//PuffFX'in ad puffFX olmal.
        if (puffFX == null) {
            Debug.Log("null");
        }
        myParticle = gameObject;
    }


    public void Repair() {
        if (myParticle.activeSelf) {
            myParticle.SetActive(false);

            puffFX.transform.position = transform.position + new Vector3(0, 1, 0);
            puffFX.GetComponent<ParticleSystem>().Play();
        }
    }
}

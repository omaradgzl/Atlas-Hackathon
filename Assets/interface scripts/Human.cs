using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour, IRepairable {

    [SerializeField] private GameObject myHelmet;
    private GameObject puffFX;

    private void Awake() {
        puffFX = GameObject.Find("puffFX");//PuffFX'in ad puffFX olmal.
        if (puffFX == null) {
            Debug.Log("null");
        }
        //myHelmet = transform.GetChild(0).gameObject;//Baret ilk child olmal.
    }


    public void Repair() {
        if (!myHelmet.activeSelf) {
            myHelmet.SetActive(true);
            puffFX.transform.position = transform.position + new Vector3(0, 1, 0);
            puffFX.GetComponent<ParticleSystem>().Play();
        }
    }


}

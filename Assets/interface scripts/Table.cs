using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour, IRepairable {

    private GameObject puffFX;
    private List<GameObject> myToolsOnGround;
    private List<GameObject> myToolsOnTable;

    private void Awake() {
        puffFX = GameObject.Find("puffFX");//PuffFX'in ad puffFX olmal.

        myToolsOnGround = new List<GameObject>();
        myToolsOnTable = new List<GameObject>();

        myToolsOnGround.Add(transform.GetChild(0).gameObject);
        myToolsOnGround.Add(transform.GetChild(1).gameObject);
        myToolsOnGround.Add(transform.GetChild(2).gameObject);

        myToolsOnTable.Add(transform.GetChild(3).gameObject);
        myToolsOnTable.Add(transform.GetChild(4).gameObject);
        myToolsOnTable.Add(transform.GetChild(5).gameObject);

    }


    public void Repair() {
        if (!myToolsOnTable[0].activeSelf) {
            for (int i = 0; i < 3; i++) {
                myToolsOnGround[i].SetActive(false);
                myToolsOnTable[i].SetActive(true);
            }


            puffFX.transform.position = transform.position + new Vector3(0, 1, 0);
            puffFX.GetComponent<ParticleSystem>().Play();
        }
    }
}

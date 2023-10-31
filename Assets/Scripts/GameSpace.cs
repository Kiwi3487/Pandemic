using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpace : MonoBehaviour
{
    public GameObject[] diseases;

    public void TreatDisease()
    {
        // treat disease since they are both medic and I dont want to add more they just get rid of all the active cubes
        if (diseases != null && diseases.Length > 0)
        {
            diseases[0].SetActive(false);
            diseases[1].SetActive(false);
            diseases[2].SetActive(false);
        }
    }
}

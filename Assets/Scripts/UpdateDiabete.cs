using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateDiabete : MonoBehaviour
{
    public Sprite sp1, sp2, sp3, sp4, sp5, sp6, sp0;
    public GameObject playerObject;

    // Update is called once per frame
    void Update()
    {
        // V�rifiez si le GameObject du joueur est assign�
        if (playerObject != null)
        {
            // Acc�dez au script du joueur � partir du GameObject du joueur
            PlayerMovement playerScript = playerObject.GetComponent<PlayerMovement>();

            // V�rifiez si le script du joueur est trouv� sur le GameObject du joueur
            if (playerScript != null)
            {
                // R�cup�rez la variable currentHealth du script du joueur
                int currentDiabete = playerScript.currentDiabete;

                if (currentDiabete == 6)
                {
                    GetComponent<SpriteRenderer>().sprite = sp6;
                }
                if (currentDiabete == 5)
                {
                    GetComponent<SpriteRenderer>().sprite = sp5;
                }
                if (currentDiabete == 4)
                {
                    GetComponent<SpriteRenderer>().sprite = sp4;
                }
                if (currentDiabete == 3)
                {
                    GetComponent<SpriteRenderer>().sprite = sp3;
                }
                if (currentDiabete == 2)
                {
                    GetComponent<SpriteRenderer>().sprite = sp2;
                }
                if (currentDiabete == 1)
                {
                    GetComponent<SpriteRenderer>().sprite = sp1;
                }
                if (currentDiabete ==0)
                {
                    GetComponent<SpriteRenderer>().sprite = sp0;
                }
            }
        }
    }
}
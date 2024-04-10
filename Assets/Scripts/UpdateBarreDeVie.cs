using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBarreDeVie : MonoBehaviour
{
    public Sprite sp1, sp2, sp3, sp4, sp5, sp6;
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
                int currentHealth = playerScript.currentHealth;
                
                if (currentHealth==6)
                {
                    GetComponent<SpriteRenderer>().sprite = sp6;
                }
                if (currentHealth == 5)
                {
                    GetComponent<SpriteRenderer>().sprite = sp5;
                }
                if (currentHealth == 4)
                {
                    GetComponent<SpriteRenderer>().sprite = sp4;
                }
                if (currentHealth == 3)
                {
                    GetComponent<SpriteRenderer>().sprite = sp3;
                }
                if (currentHealth == 2)
                {
                    GetComponent<SpriteRenderer>().sprite = sp2;
                }
                if (currentHealth == 1)
                {
                    GetComponent<SpriteRenderer>().sprite = sp1;
                }
            }
        }
    }
}
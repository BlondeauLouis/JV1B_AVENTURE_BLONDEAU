using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI; // R�f�rence vers l'interface utilisateur de l'inventaire
    public KeyCode inventoryKey = KeyCode.I; // Touche pour ouvrir et fermer l'inventaire

    private bool isInventoryOpen = false;

    void Start()
    {
        inventoryUI.SetActive(false); // D�sactivez l'inventaire au d�marrage du jeu
    }

    void Update()
    {
        // V�rifiez si la touche de l'inventaire est press�e
        if (Input.GetKeyDown(inventoryKey))
        {
            // Inversez l'�tat de l'inventaire
            isInventoryOpen = !isInventoryOpen;

            // Activez ou d�sactivez l'interface utilisateur de l'inventaire en fonction de l'�tat de l'inventaire
            inventoryUI.SetActive(isInventoryOpen);
        }
    }
}
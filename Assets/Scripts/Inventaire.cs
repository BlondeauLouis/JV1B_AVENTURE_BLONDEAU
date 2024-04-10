using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI; // Référence vers l'interface utilisateur de l'inventaire
    public KeyCode inventoryKey = KeyCode.I; // Touche pour ouvrir et fermer l'inventaire

    private bool isInventoryOpen = false;

    void Start()
    {
        inventoryUI.SetActive(false); // Désactivez l'inventaire au démarrage du jeu
    }

    void Update()
    {
        // Vérifiez si la touche de l'inventaire est pressée
        if (Input.GetKeyDown(inventoryKey))
        {
            // Inversez l'état de l'inventaire
            isInventoryOpen = !isInventoryOpen;

            // Activez ou désactivez l'interface utilisateur de l'inventaire en fonction de l'état de l'inventaire
            inventoryUI.SetActive(isInventoryOpen);
        }
    }
}
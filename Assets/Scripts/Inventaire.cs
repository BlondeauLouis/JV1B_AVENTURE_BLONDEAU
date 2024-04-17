using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI; // Référence vers l'interface utilisateur de l'inventaire
    public KeyCode inventoryKey = KeyCode.I; // Touche pour ouvrir et fermer l'inventaire

    private void Start()
    {
        inventoryUI.SetActive(false);
    }


    void Update()
    {
        // Vérifie si la touche de l'inventaire est pressée
        if (Input.GetKeyDown(inventoryKey))
        {
            // Inversez l'état de l'inventaire
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}

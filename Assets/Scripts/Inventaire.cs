using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryUI; // R�f�rence vers l'interface utilisateur de l'inventaire
    public KeyCode inventoryKey = KeyCode.I; // Touche pour ouvrir et fermer l'inventaire

    private void Start()
    {
        inventoryUI.SetActive(false);
    }


    void Update()
    {
        // V�rifie si la touche de l'inventaire est press�e
        if (Input.GetKeyDown(inventoryKey))
        {
            // Inversez l'�tat de l'inventaire
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}

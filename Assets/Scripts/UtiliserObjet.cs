using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UseCakeButton : MonoBehaviour
{
    public GameObject cakePrefab; // R�f�rence au prefab du cake dans l'inventaire
    public int healthToAdd = 1; // Nombre de points de vie � ajouter

    public TextMeshProUGUI cakeCountText;

    private void Awake()
    {
        // R�cup�rer le composant TextMeshProUGUI pour afficher le nombre de cakes
        cakeCountText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UseCake()
    {
        // V�rifier si le joueur a des cakes dans son inventaire
        if (PlayerPrefs.GetInt(cakePrefab.GetComponent<Object>().ID) > 0)
        {
            // D�cr�menter le nombre de cakes dans l'inventaire
            int currentCakeCount = PlayerPrefs.GetInt(cakePrefab.GetComponent<Object>().ID);
            currentCakeCount--;
            PlayerPrefs.SetInt(cakePrefab.GetComponent<Object>().ID, currentCakeCount);
            cakeCountText.text = currentCakeCount.ToString(); // Mettre � jour l'affichage du nombre de cakes

            // Ajouter des points de vie au joueur
            // Ajoutez ici votre logique pour ajouter des points de vie au joueur
            // Par exemple, vous pouvez acc�der au script de sant� du joueur et appeler une m�thode pour ajouter des points de vie
        }
    }
}

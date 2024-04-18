using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UseCakeButton : MonoBehaviour
{
    public GameObject cakePrefab; // Référence au prefab du cake dans l'inventaire
    public int healthToAdd = 1; // Nombre de points de vie à ajouter

    public TextMeshProUGUI cakeCountText;

    private void Awake()
    {
        // Récupérer le composant TextMeshProUGUI pour afficher le nombre de cakes
        cakeCountText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UseCake()
    {
        // Vérifier si le joueur a des cakes dans son inventaire
        if (PlayerPrefs.GetInt(cakePrefab.GetComponent<Object>().ID) > 0)
        {
            // Décrémenter le nombre de cakes dans l'inventaire
            int currentCakeCount = PlayerPrefs.GetInt(cakePrefab.GetComponent<Object>().ID);
            currentCakeCount--;
            PlayerPrefs.SetInt(cakePrefab.GetComponent<Object>().ID, currentCakeCount);
            cakeCountText.text = currentCakeCount.ToString(); // Mettre à jour l'affichage du nombre de cakes

            // Ajouter des points de vie au joueur
            // Ajoutez ici votre logique pour ajouter des points de vie au joueur
            // Par exemple, vous pouvez accéder au script de santé du joueur et appeler une méthode pour ajouter des points de vie
        }
    }
}

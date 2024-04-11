using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si la collision est avec un ennemi
        if (other.CompareTag("Enemy"))
        {
            // Vérifie si la barre d'espace est enfoncée
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("quoicoubeh");
                // Détruit l'ennemi
                Destroy(other.gameObject);
            }
        }
    }
}
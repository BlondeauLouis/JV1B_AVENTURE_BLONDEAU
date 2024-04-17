using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si la collision est avec un ennemi
        if (other.CompareTag("Bec"))
        {
            Destroy(gameObject);
        }
    }
}
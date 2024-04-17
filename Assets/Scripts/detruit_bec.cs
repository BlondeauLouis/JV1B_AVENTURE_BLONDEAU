using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // V�rifie si la collision est avec un ennemi
        if (other.CompareTag("Bec"))
        {
            Destroy(gameObject);
        }
    }
}
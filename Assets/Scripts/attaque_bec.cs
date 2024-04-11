using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // V�rifie si la collision est avec un ennemi
        if (other.CompareTag("Enemy"))
        {
            // V�rifie si la barre d'espace est enfonc�e
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("quoicoubeh");
                // D�truit l'ennemi
                Destroy(other.gameObject);
            }
        }
    }
}
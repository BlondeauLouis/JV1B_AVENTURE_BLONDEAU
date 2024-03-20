using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string Titre;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // V�rifie si le joueur entre en collision
        {
            SceneManager.LoadScene(Titre); // Charge la nouvelle sc�ne
        }
    }
}
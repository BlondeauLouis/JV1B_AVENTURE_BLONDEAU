using UnityEngine;

public class Controles : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement du joueur

    private Rigidbody2D rb;

    void Start()
    {
        DontDestroyOnLoad(this);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculer le vecteur de mouvement
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Normaliser le vecteur pour �viter le mouvement diagonal plus rapide
        movement.Normalize();

        // D�placer le joueur
        rb.velocity = movement * moveSpeed;
    }
}

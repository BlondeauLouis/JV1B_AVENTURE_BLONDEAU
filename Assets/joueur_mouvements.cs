using UnityEngine;

public class Controles : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement du joueur
    public float maxSpeed = 5f; // Vitesse maximale du joueur

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

        // Normaliser le vecteur pour éviter le mouvement diagonal plus rapide
        movement.Normalize();

        // Appliquer une force de déplacement
        rb.AddForce(movement * moveSpeed);

        // Limiter la vitesse maximale
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Si aucune entrée de mouvement n'est détectée, arrêtez le mouvement
        if (moveHorizontal == 0f && moveVertical == 0f)
        {
            rb.velocity = Vector2.zero;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controles : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement du joueur

    public string horizontalAxis = "Horizontal"; // Axe de d�placement horizontal
    public string verticalAxis = "Vertical"; // Axe de d�placement vertical

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis(horizontalAxis);
        float moveVertical = Input.GetAxis(verticalAxis);

        // Si aucun mouvement n'est d�tect� via la manette, utilisez les touches du clavier
        if (moveHorizontal == 0f)
            moveHorizontal = Input.GetAxis("HorizontalKeyboard");
        if (moveVertical == 0f)
            moveVertical = Input.GetAxis("VerticalKeyboard");

        // Calculer le vecteur de mouvement
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Normaliser le vecteur pour �viter le mouvement diagonal plus rapide
        movement.Normalize();

        // D�placer le joueur
        rb.velocity = movement * moveSpeed;
    }
}
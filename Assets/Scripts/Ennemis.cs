using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement de l'ennemi

    private Transform player; // R�f�rence au joueur

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Trouver le joueur
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculer la direction du mouvement vers le joueur
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // Appliquer le mouvement
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int maxHealth = 6;
    public int currentHealth;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public Transform respawnPoint;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(this);
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
        }

        if (change != Vector3.zero)
        {
            MoveCharacter();
        }
        Debug.Log(change); //pour debug

        if (currentHealth<=0)
        {
            Respawn();
        }
    }
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed
        );
    }

    public void PerdPv()
    {
        currentHealth--;
    }

    public void Respawn()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Scene0");
        transform.position = respawnPoint.position;
    }
}

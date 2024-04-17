using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Sprite sp1, sp2, backsprite, frontsprite;
    public int maxHealth = 6;
    public int currentHealth;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public Transform respawnPoint;
    private SpriteRenderer spriteRenderer;
    private bool isInvincible = false;
    public float invincibilityTime = 2f;

    public Transform beakTransform;

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
            GetComponent<SpriteRenderer>().sprite = sp1;
            spriteRenderer.flipX = true;
            if (beakTransform != null)
            {
                // Exemple d'ajustement de position (à adapter selon les besoins)
                beakTransform.localPosition = new Vector3(-0.5f, 0.2f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
            spriteRenderer.flipX = false;
            if (beakTransform != null)
            {
                // Exemple d'ajustement de position (à adapter selon les besoins)
                beakTransform.localPosition = new Vector3(2f, 0.5f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
            spriteRenderer.flipX = true;
            if (beakTransform != null)
            {
                // Exemple d'ajustement de position (à adapter selon les besoins)
                beakTransform.localPosition = new Vector3(-0.5f, 0.2f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
            spriteRenderer.flipX = false;
            if (beakTransform != null)
            {
                // Exemple d'ajustement de position (à adapter selon les besoins)
                beakTransform.localPosition = new Vector3(0.5f, 0.2f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<SpriteRenderer>().sprite = backsprite;
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<SpriteRenderer>().sprite = frontsprite;
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<SpriteRenderer>().sprite = backsprite;
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GetComponent<SpriteRenderer>().sprite = frontsprite;
            spriteRenderer.flipX = false;
        }

        if (change != Vector3.zero)
        {
            MoveCharacter();
        }

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
        if (!isInvincible)
        {
            currentHealth--;
            StartCoroutine(InvincibilityRoutine());
        }
    }

    IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;

        GetComponent<SpriteRenderer>().sprite = sp2;

        yield return new WaitForSeconds(invincibilityTime);

        isInvincible = false;

        GetComponent<SpriteRenderer>().sprite = sp1;
    }

    public void Respawn()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Scene0");
        transform.position = respawnPoint.position;
    }
}
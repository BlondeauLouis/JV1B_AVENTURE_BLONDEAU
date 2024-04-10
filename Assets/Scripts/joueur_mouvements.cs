using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Sprite sp1, sp2;
    public int maxHealth = 6;
    public int currentHealth;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public Transform respawnPoint;
    private SpriteRenderer spriteRenderer;
    private bool isInvincible = false;
    public float invincibilityTime = 2f;

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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
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
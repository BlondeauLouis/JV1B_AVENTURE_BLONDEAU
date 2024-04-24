using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerMovement : MonoBehaviour
{
    public Sprite sp1, sp2, backsprite, frontsprite;
    public int maxHealth = 6;
    public int currentHealth;
    public int maxDiabete = 6;
    public int currentDiabete = 0;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public Transform respawnPoint;
    private SpriteRenderer spriteRenderer;
    private bool isInvincible = false;
    public float invincibilityTime = 2f;

    public Transform beakTransform;
    public GameObject beak;

    public GameObject inventoryUI;
    public KeyCode inventoryKey = KeyCode.I;

    public PostProcessVolume postProcessVolume;
    public float maxBlurIntensity = 5f;
    private DepthOfField depthOfFieldEffect;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(this);
        currentHealth = maxHealth;
        currentDiabete = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventoryUI.SetActive(false);
        postProcessVolume.profile.TryGetSettings(out depthOfFieldEffect);
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
                beakTransform.localPosition = new Vector3(-2.5f, 1f, 0f);
                beakTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
            spriteRenderer.flipX = false;
            if (beakTransform != null)
            {
                beakTransform.localPosition = new Vector3(2.5f, 1f, 0f);
                beakTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
            spriteRenderer.flipX = true;
            if (beakTransform != null)
            {
                beakTransform.localPosition = new Vector3(-2.5f, 1f, 0f);
                beakTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
            spriteRenderer.flipX = false;
            if (beakTransform != null)
            {
                beakTransform.localPosition = new Vector3(2.5f, 1f, 0f);
                beakTransform.localRotation = Quaternion.Euler(0f, 0f,  0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<SpriteRenderer>().sprite = backsprite;
            spriteRenderer.flipX = false;
            if (beakTransform != null)
            {
                beakTransform.localPosition = new Vector3(-2f, 2.5f, 0f);
                beakTransform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<SpriteRenderer>().sprite = frontsprite;
            spriteRenderer.flipX = false;
            if (beakTransform != null)
            {
                beakTransform.localPosition = new Vector3(-2f, -1.25f, 0f);
                beakTransform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            }
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

        if (Input.GetKeyDown(inventoryKey))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        float blurIntensity = Mathf.Clamp(currentDiabete / maxDiabete, 0f, 1f) * maxBlurIntensity;  //VOIR PLUS TARD POUR TROUBLER LA VISION
        depthOfFieldEffect.focusDistance.value = blurIntensity;
    }
    void MoveCharacter()
    {
        if (currentDiabete > 0)
        {
            myRigidbody.MovePosition(
              transform.position + change * speed / currentDiabete
          );
        }
        if (currentDiabete ==0)
        {
            myRigidbody.MovePosition(
              transform.position + change * speed
          );
        }
    }

    public void PerdPv()
    {
        if (!isInvincible)
        {
            currentHealth--;
            beak.SetActive(!beak.activeSelf);
            StartCoroutine(InvincibilityRoutine());
        }
    }

    public void PerdDiabete()
    {
        if (currentDiabete > 0)
        {
            currentDiabete--;
        }
    }

    public void GagnePv()
    {
        if (currentHealth < 6)
        {
            currentHealth++;
        }
    }

    public void GagneDiabete()
    {
        if (currentDiabete < 6)
        {
            currentDiabete++;
        }
    }

    IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;

        GetComponent<SpriteRenderer>().sprite = sp2;

        yield return new WaitForSeconds(invincibilityTime);

        isInvincible = false;

        beak.SetActive(!beak.activeSelf);

        GetComponent<SpriteRenderer>().sprite = sp1;
    }

    public void Respawn()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Scene0");
        transform.position = respawnPoint.position;
    }
}
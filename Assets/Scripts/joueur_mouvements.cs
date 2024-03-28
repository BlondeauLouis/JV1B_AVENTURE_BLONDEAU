using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public Transform respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(this);
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
        if (change != Vector3.zero)
        {
            MoveCharacter();
        }
        Debug.Log(change); //pour debug
    }
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed
        );
    }

    public void Respawn()
    {
        transform.position = respawnPoint.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruction : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D bc2d;

    [SerializeField]
    private KeyCode attackkey = KeyCode.Space;

    public bool aportee = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (aportee)
        {
            if (Input.GetKey(attackkey))
            {
                Destroy(bc2d.gameObject);
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("hitboxattack"))
        {

            aportee = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("hitboxattack"))
        {

            aportee = false;
        }
    }
}
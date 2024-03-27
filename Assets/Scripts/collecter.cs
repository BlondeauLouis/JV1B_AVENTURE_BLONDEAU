using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collecter : MonoBehaviour
{
    private Object thisObject;

    private void Awake()
    {
        thisObject = GetComponent<Object>();
        PlayerPrefs.DeleteKey(thisObject.ID);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(thisObject.ID, PlayerPrefs.GetInt(thisObject.ID) + 1);
            Destroy(gameObject);
        }
    }
}

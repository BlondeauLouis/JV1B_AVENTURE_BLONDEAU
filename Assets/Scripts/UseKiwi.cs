using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UseKiwiButton : MonoBehaviour
{
    public GameObject kiwiPrefab;

    public TextMeshProUGUI kiwiCountText;

    public PlayerMovement playerMovement;

    private void Awake()
    {
        kiwiCountText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UseKiwi()
    {
        if (PlayerPrefs.GetInt(kiwiPrefab.GetComponent<Object>().ID) > 0)
        {
            int currentKiwiCount = PlayerPrefs.GetInt(kiwiPrefab.GetComponent<Object>().ID);
            currentKiwiCount--;
            PlayerPrefs.SetInt(kiwiPrefab.GetComponent<Object>().ID, currentKiwiCount);
            kiwiCountText.text = currentKiwiCount.ToString();

            playerMovement.PerdDiabete();
        }
    }
}
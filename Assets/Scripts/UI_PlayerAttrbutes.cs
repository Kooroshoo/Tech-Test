using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerAttrbutes : MonoBehaviour
{
    [SerializeField] Text healthText;
    [SerializeField] Text speedText;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        // assign the player variable by finding a object of type Player in the scene
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthText && speedText)
        {
            // get the players health and speed and show it on the UI
            healthText.text = player.GetPlayerHealth().ToString();
            speedText.text = player.GetPlayerSpeed().ToString();
        }
        else
        {
            // To make sure the healthText and speedText values are not null
            Debug.LogError("Please attach the health text and speed text from the UI to this scripts");
        }
    }
}

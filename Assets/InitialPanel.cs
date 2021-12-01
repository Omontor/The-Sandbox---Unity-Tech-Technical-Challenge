using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPanel : MonoBehaviour
{
    bool gamestarted;
   public GameObject menu, hud;
    private void Start()
    {
        menu.SetActive(true);
        hud.SetActive(false);
    }
    public void startGame()
    {
        menu.SetActive(false);
        hud.SetActive(true);
    }

    private void Update()
    {
        if (!gamestarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                startGame();
                gamestarted = true;
            }
        }
 
    }
}

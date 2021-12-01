using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPanel : MonoBehaviour
{
    bool gamestarted;
    public void startGame()
    {
        gameObject.SetActive(false);
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

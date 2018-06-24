using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestarter : MonoBehaviour
{

    public void OnGameOver()
    {
        GetComponent<Animator>().SetTrigger("deathTrigger");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("FirstRoom");
    }
	
}

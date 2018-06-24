using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void OnButtonPressed()
    {
        GetComponentInParent<Animator>().SetTrigger("fadeTrigger");
        Invoke("LoadIt", 0.5f);
    }

    public void LoadIt()
    {
        SceneManager.LoadScene("FirstRoom");
    }

}

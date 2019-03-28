using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDeath : MonoBehaviour
{
    public GameObject dead;
    //public GameObject levelAudio;
    public GameObject fadeOut;

    void OnTriggerEnter()
    {
        StartCoroutine(YouDied());
    }

    IEnumerator YouDied()
    {
        dead.SetActive(true);
        //levelAudio.SetActive(false);
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}

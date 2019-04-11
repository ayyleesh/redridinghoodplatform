using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    //public GameObject levelMusic;
    public GameObject levelTimer;
    public AudioSource levelComplete;
    public GameObject completeText;
    public GameObject fadeOut;
    public GameObject timeLeft;
    public GameObject collectScore;
    public GameObject totalScore;
    public int timeCalc;
    public int scoreCalc;
    public int totalScored;

    void OnTriggerEnter()
    {
        timeCalc = GlobalTimer.extendScore * 100;
        timeLeft.GetComponent<Text>().text = "Time left : " + GlobalTimer.extendScore + " x 100";
        scoreCalc = GlobalScore.currentScore * 1000;
        collectScore.GetComponent<Text>().text = "Score : " + scoreCalc;
        totalScored = scoreCalc + timeCalc;
        totalScore.GetComponent<Text>().text = "Total Score : " + totalScored;
        //levelMusic.SetActive(false);
        levelTimer.SetActive(false);
        levelComplete.Play();
        StartCoroutine(LevelComplete());
    }

    IEnumerator LevelComplete()
    {
        fadeOut.SetActive(true);
        completeText.SetActive(true);
        yield return new WaitForSeconds(1);
        timeLeft.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        collectScore.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        totalScore.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(RedirectToLevel.nextLevel);
            
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    public GameObject timerDisplay;
    public bool countingDown;
    public int seconds = 150;
    public static int extendScore;
    

    // Update is called once per frame
    void Update()
    {
        extendScore = seconds;
        if (countingDown == false)
        {
            StartCoroutine(SubstractSecond());
        }
    }

    IEnumerator SubstractSecond()
    {
        countingDown = true;
        seconds -= 1;
        timerDisplay.GetComponent<Text>().text = "" + seconds;
        yield return new WaitForSeconds(1);
        countingDown = false;
    }
}

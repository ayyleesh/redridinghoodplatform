﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level004 : MonoBehaviour
{
    public GameObject fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        RedirectToLevel.redirectToLevel = 5;
        //RedirectToLevel.nextLevel = 6;
        StartCoroutine(FadeInOFf());
    }

    IEnumerator FadeInOFf()
    {
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }
}

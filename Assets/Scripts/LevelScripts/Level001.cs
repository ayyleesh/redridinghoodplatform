using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level001 : MonoBehaviour
{
    public GameObject fadeIn;
    // Start is called before the first frame update
    void Start()
    {
        RedirectToLevel.redirectToLevel = 2;
        RedirectToLevel.nextLevel = 3;
        StartCoroutine(FadeInOFf());
    }

    IEnumerator FadeInOFf()
    {
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }
}

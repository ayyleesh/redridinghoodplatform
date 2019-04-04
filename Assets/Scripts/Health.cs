using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //Start is called before the first frame update
    private int health;
    public static int extraHeart;
    public GameObject dead;
    public GameObject fadeOut;

    public RawImage[] hearts;
    public static int extraHealth;
    public static int initialLive;
    public int maxLives;

    void Start()
    {
        initialLive = 5;
    }

    // Update is called once per frame
    void Update()
    {
        health = initialLive + extraHealth;

        if (health <= maxLives)
        {

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].enabled = true;
                }
                else
                {
                    hearts[i].enabled = false;
                }
            }
        }
        if (health == 0)
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
            health = initialLive;
            SceneManager.LoadScene(0);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //Start is called before the first frame update
    PlayerScript playerScript;
    Animator playerAC;

    private int health;
    public static int playerHealth;
    public GameObject dead;
    public GameObject fadeOut;

    public RawImage[] hearts;
    public static int extraHealth;
    public static int damage;
    public int initialLive;
    public int maxLives;

    void Awake()
    {
        playerScript = GetComponent<PlayerScript>();
        playerAC = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        health = initialLive + extraHealth + damage;
        playerHealth = health;

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
        if (health <= 0)
        {
            StartCoroutine(YouDied());
        }

        IEnumerator YouDied()
        {
            //playerScript.enabled = false;
            dead.SetActive(true);
            //levelAudio.SetActive(false);
            yield return new WaitForSeconds(2);
            fadeOut.SetActive(true);
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(0);
        }

    }
}

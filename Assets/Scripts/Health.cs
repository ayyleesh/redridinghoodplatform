using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int health;
    private bool isRespawning;
    private Vector3 respawnPoint;

    public AudioSource damagedSound;
    public static int playerHealth;
    public RawImage[] hearts;
    public int initialLive;
    public int maxLives;

    public PlayerScript player;
    public GameObject dead;
    public GameObject fadeOut;

    void Start()
    {
        health = initialLive;
        player = FindObjectOfType<PlayerScript>();
        respawnPoint = player.transform.position;
    }

    void Update()
    {

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

    public void HurtPlayer(int damage, Vector3 direction)
    {
        health -= damage;
        damagedSound.Play();
    }

    public void HealPlayer(int heal)
    {
        health += heal;

        if (health > maxLives)
        {
            health = maxLives;
        }
    }

    public void Respawn()
    {
        if (health > 0 && !isRespawning)
        {
            StartCoroutine(RespawnCoRoutine());
        }
    }

    IEnumerator RespawnCoRoutine()
    {
        isRespawning = true;
        yield return new WaitForSeconds(0.5f);
        isRespawning = false;
        player.transform.position = respawnPoint;
    }
}

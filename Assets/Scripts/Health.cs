using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int health;
    private bool isRespawning;
    public Vector3 respawnPoint;
    public GameObject[] enemy;

    public AudioSource damagedSound;
    public static int playerHealth;
    public RawImage[] hearts;
    public int initialLive;
    public int maxLives;
    public float respawnDelay;

    public PlayerScript player;
    public GameObject dead;
    public GameObject fadeOut;

    void Start()
    {
        health = initialLive;
        player = FindObjectOfType<PlayerScript>();
        respawnPoint = player.transform.position;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
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
            SceneManager.LoadScene(1);
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

    public void ChangeCheckPoint(Vector3 newCheckPoint)
    {
        respawnPoint = newCheckPoint;
    }

    IEnumerator RespawnCoRoutine()
    {
        isRespawning = true;
        yield return new WaitForSeconds(respawnDelay);
        isRespawning = false;
        player.transform.position = respawnPoint;
    }
}

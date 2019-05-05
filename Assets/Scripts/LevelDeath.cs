using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDeath : MonoBehaviour
{
    public int damage_amt = 1;
    public GameObject dead;
    //public GameObject levelAudio;
    public GameObject fadeOut;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<Health>().HurtPlayer(damage_amt, hitDirection);
            FindObjectOfType<Health>().Respawn();
        }
    }

    IEnumerator YouDied()
    {
        dead.SetActive(true);
        //levelAudio.SetActive(false);
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}

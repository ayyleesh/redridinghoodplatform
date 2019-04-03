using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //Start is called before the first frame update
    private int health;
    public static int extraHeart;

    public RawImage[] hearts;
    public static int extraHealth;
    public int initialLive;
    public int maxLives;

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

    }
}

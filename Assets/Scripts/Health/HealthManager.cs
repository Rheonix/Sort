using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    // The current health of the player
    public int health = 3;

    // The max health of the player
    int maxHealth = 3;

    // Bool variables to keep track of how many hearts the player has
    bool displayHeart1 = true;
    bool displayHeart2 = true;
    bool displayHeart3 = true;
    bool damaged;

    Image heart1;
    Image heart2;
    Image heart3;

    public Image damageImage;

    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f); //means completely red, and the last number is how opaque it is
    //0.1f is 10% opacity for the alpha value above


    // Use this for initialization
    void Start ()
    {
        heart1 = GameObject.FindGameObjectWithTag("heartOne").GetComponent<Image>();
        heart2 = GameObject.FindGameObjectWithTag("heartTwo").GetComponent<Image>();
        heart3 = GameObject.FindGameObjectWithTag("heartThree").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime); //lerp is moving from something to another
        }
        damaged = false;
    }

    // Functions to display the health
    void Heart1display()
    {
        heart1.color = new Color(255, 255, 255, 255);
    }

    void Heart2display()
    {
        heart2.color = new Color(255, 255, 255, 255);
    }

    void Heart3display()
    {
        heart3.color = new Color(255, 255, 255, 255);
    }

    // Functions to hide the health
    void Heart1hide()
    {
        heart1.color = new Color(255, 255, 255, 0);
    }

    void Heart2hide()
    {
        heart2.color = new Color(255, 255, 255, 0);
    }

    void Heart3hide()
    {
        heart3.color = new Color(255, 255, 255, 0);
    }

    // Function to lose a point of health

    public void GainHealth()
    {
        if (health < 3)
        {
            health++;
        }
        else
        {
            return;
        }

        if(health == 2)
        {
            Heart2display();
        }

        if (health == 3)
        {
            Heart3display();
        }
    }

    public void LoseHealth()
    {
        if (health >= 1)
        {
            health--;
            damaged = true;
        }
        else
        {
            return; // make this a game that ends statement
        }

        if (health == 2)
        {
            Heart3hide();
        }

        if (health == 1)
        {
            Heart2hide();
        }

        if (health == 0)
        {
            Heart1hide();
        }
    }

    public void LoseHealthNoFlash()
    {
        if (health >= 1)
        {
            health--;
        }
        else
        {
            return; // make this a game that ends statement
        }

        if (health == 2)
        {
            Heart3hide();
        }

        if (health == 1)
        {
            Heart2hide();
        }

        if (health == 0)
        {
            Heart1hide();
        }
    }



}

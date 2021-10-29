using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public bool isInsideTheZone = false;
    public int currentHealth;
    public int domage;
    public int maxHealth;
    // Start is called before the first frame update

    public healtBar healtbar;
    public GameOver gameOver;
    void Start()
    {
        healtbar.SetHealth(currentHealth);
        StartCoroutine("Domage");
    }

    // Update is called once per frame
    void Update()
    {


        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player") //taguer player
        {
            isInsideTheZone = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player") //taguer player
        {
            isInsideTheZone = false;
        }

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healtbar.SetHealth(currentHealth);
    }

    IEnumerator Domage()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);

            if (isInsideTheZone == true)
            {
                TakeDamage((-domage));
            } else
            {
                TakeDamage(domage);
            }

            if (currentHealth == 0)
            {
                gameOver.EndGame();
            }

        }
    }
}

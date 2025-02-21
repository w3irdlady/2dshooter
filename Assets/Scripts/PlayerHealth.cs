using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public static PlayerHealth instance;

    public HealthBar healthBar;

    public float immortalTime;
    private float immortalCounter;

    private SpriteRenderer sr;

    private Vector2 checkPoint;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        checkPoint = transform.position;

        currentHealth = maxHealth;

        healthBar.SetMaxHealth(currentHealth);

        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (immortalCounter > 0)
        {
            immortalCounter -= Time.deltaTime;

            if (immortalCounter <= 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
        }
    }

    public void DealDamage()
    {
        if (immortalCounter <= 0)
        {
            currentHealth--;

            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                //gameObject.SetActive(false);
                Die();
            }
            else
            {
                immortalCounter = immortalTime;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.6f);
            }
        }
    }

    public void UpdatedCheckpoint(Vector2 pos)
    {
        checkPoint = pos;
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {

        currentHealth = maxHealth;

        healthBar.SetHealth(currentHealth);

        transform.position = checkPoint;
    }
}

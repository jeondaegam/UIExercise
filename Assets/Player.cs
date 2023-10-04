using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bar Bar;

    public int MaxHealth;
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        Bar.ResetSlider();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(10);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Heal(10);
        }
    }

    public void Respawn()
    {
        Bar.ResetSlider();
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        Bar.UpdateHealth(Health, MaxHealth);
    }

    public void Heal(int heal)
    {
        Health += heal;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        Bar.UpdateHealth(Health, MaxHealth);
    }
}

using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 따라다니는 카메라 
    public Camera Camera;
    public float CameraShakeDuration = 0.5f;
    public float CameraShakeStrengt = 1f;
    public float CamaraRotShakeDuration = 0.5f;
    public float CameraRotShakeStrength = 3f;


    public Bar Bar;
    public WorldText WorldTextPf;
    public Vector3 OffSet;

    public int MaxHealth;
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        // 메인 카메라를 찾아 들고있는다. 비효율적이므로 사용시 주의 
        Camera = Camera.main; 
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

        var text = Instantiate(WorldTextPf, transform.position, Quaternion.identity);
        text.Setup(damage.ToString());

        // 원위치로 리셋
        Camera.DOComplete();  
        Camera.DOShakeRotation(CameraShakeDuration, CameraShakeStrength);
        Camera.DOShakeRotation(CamaraRotShakeDuration, CameraRotShakeStrength);
    }

    public void Heal(int heal)
    {
        Health += heal;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        Bar.UpdateHealth(Health, MaxHealth);
    }
}

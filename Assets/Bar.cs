using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public enum EBarUpdate { None, Update,  Coroutine, Tween }
    public EBarUpdate BarUpdate;

    public float Speed;

    public Slider Sld;
    public Slider RedSld;
    //public Slider FlashSld;
    [Range(0f, 1f)]
    public float TargetValue;
    public float Duration;

    private Coroutine _updateRoutine;
    private Tween _tweening;

    private void Awake()
    {
        //Sld = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BarUpdate != EBarUpdate.Coroutine)
        {
            if (_updateRoutine != null)
            {
                StopCoroutine(_updateRoutine);
                _updateRoutine = null;
            }
        }

        if (BarUpdate == EBarUpdate.Update)
        {
            if (TargetValue != Sld.value)
            {
                if (TargetValue < Sld.value)
                {
                    Sld.value -= Speed * Time.deltaTime;
                    if (Sld.value < TargetValue)
                    {
                        Sld.value = TargetValue;
                    }
                }
                else
                {
                    Sld.value += Speed * Time.deltaTime;
                    if (Sld.value > TargetValue)
                    {
                        Sld.value = TargetValue;
                    }
                }
            }
        }
        else if (BarUpdate == EBarUpdate.Coroutine)
        {
            if (_updateRoutine == null)
            {
                _updateRoutine = StartCoroutine(UpdateRoutine());
            }
        }
        else if (BarUpdate == EBarUpdate.Tween)
        {
            if (_tweening == null && TargetValue != Sld.value)
            {
                _tweening = Sld.DOValue(TargetValue, Duration)
                    .OnComplete(OnDoValueCompleted);
            }
        }
    }


    public void ResetSlider()
    {
        TargetValue = 1f;
        Sld.value = 1f;
        RedSld.value = 1f;
    }

    public void UpdateHealth(int health, int maxHealth)
    {
        float pct = (float)health / maxHealth;
        RedSld.value = pct;
        TargetValue = pct;
    }


    private void OnDoValueCompleted()
    {
        Debug.Log("OnDoValueCompleted :: ");
        _tweening = null;
    }

    private IEnumerator UpdateRoutine()
    {
        while (true)
        {
            Debug.Log("UpdateRoutine :: ");
            if (TargetValue != Sld.value)
            {
                if (TargetValue < Sld.value)
                {
                    Sld.value -= Speed * Time.deltaTime;
                    if (Sld.value < TargetValue)
                    {
                        Sld.value = TargetValue;
                    }
                }
                else
                {
                    Sld.value += Speed * Time.deltaTime;
                    if (Sld.value > TargetValue)
                    {
                        Sld.value = TargetValue;
                    }
                }
            }

            yield return null;
        }
    }
}

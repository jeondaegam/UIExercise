using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public int TargetNumber;
    public float CurrentNumber;
    public float Speed = 10;
    public float Duration; // 2초만에 업데이트 되도록 

    private void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Text.text = "1";
    }

    // Update is called once per frame
    void Update()
    {
        SlidingNumber();
        
    }

    private void SlidingNumber()
    {
        if (CurrentNumber != TargetNumber)
        {
            if (CurrentNumber < TargetNumber)
            {
                CurrentNumber += Time.deltaTime * Speed;
                if (CurrentNumber > TargetNumber)
                {
                    CurrentNumber = TargetNumber;
                }
            }
            else
            {   // TargetNumber가 더 큰경우
                CurrentNumber -= Time.deltaTime * Speed;
                if (CurrentNumber < TargetNumber)
                {
                    CurrentNumber = TargetNumber;
                }
            }
        }
        Text.text = ((int)CurrentNumber).ToString();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public int TargetNumber;
    public float CurrentNumber;
    public float Speed = 10;
    public float Duration = 5; // 2초만에 업데이트 되도록

    public float LastTargetNumber;

    public float StartNumber;
    public float EndNumber;
    public float ElapsedTime;

    public bool DoLerp;


    private void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
        TargetNumber = 10000;
        CurrentNumber = 0;
        LastTargetNumber = -1;
        Text.text = "0";
    }

    // Start is called before the first frame update
    void Start()
    {
        Text.text = "1";
    }

    // Update is called once per frame
    void Update()
    {
        Lerp();
        //UpdateSpeed();
        //SlidingNumber();
    }

    private void UpdateSpeed()
    {
        if(LastTargetNumber != TargetNumber)
        {
            // 속도 = (변화량:목표값과 현재값 사이의 차이) / 시간
            // 남은 변화량이 시간내에 소진되도록 속도를 수정한다
            //Speed = (TargetNumber - CurrentNumber) / Duration;
        }
    }

    //Lerp를 시작하는 함수
    public void StartLerp()
    {
        // 유저가 코인을 획득한다면 ?! 이 함수를 호출
        DoLerp = true;
        int.TryParse(Text.text, out int textValue);
        StartNumber = (float)textValue;
        ElapsedTime = 0;
    }

    public void FinishLerp()
    {
        DoLerp = false;
        Text.text = TargetNumber.ToString();
    }



    private void Lerp()
    {
        if (DoLerp)
        {
            // 경과시간
            ElapsedTime += Time.deltaTime;
            float value = Mathf.Lerp(StartNumber, EndNumber, ElapsedTime / Duration);
            Text.text = ((int)value).ToString();

            if (ElapsedTime > Duration)
            {
                FinishLerp();
                DoLerp = true;
                int.TryParse(Text.text, out int textValue);
                StartNumber = (float)textValue;
                ElapsedTime = 0;
            }

        }
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

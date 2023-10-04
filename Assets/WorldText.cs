using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class WorldText : MonoBehaviour
{
    /**
     * 
     * 텍스트 이동시키기 
     * - 데미지 팝업
     */

    public TextMeshPro Text;
    // 목적지 
    public Vector3 Destination;
    // 목적지까지 몇초동안 이동할 것인가
    public float Duration;

    public Vector3 Scale;

    private float positionXRange;


    private void Awake()
    {
        Text = GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    void Start()
    {
        var color = Text.color;
        // alpha값(투명도) 
        color.a = 0; 

        Text.DOColor(color, Duration);
        //Destination = ?? 팝업 랜덤으로 뜨게하기

        Destination = new Vector3(Random.Range(1, 10), transform.position.y, transform.position.z); ;
        // 목적지까지 이동시간동안 이동한다
        Text.transform.DOMove(Destination, Duration);
        Text.transform.DOScale(Scale, Duration)
            .OnComplete(OnCompleted);

    }

    public void Setup(string damageTxt)
    {
        Text.text = damageTxt;
    }

    private void OnCompleted()
    {
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashComponent : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Color ParentColor;
    private Color FlashColor;
    private bool IsFlash;
    private float _existTime;
    public bool StartFlash;
    public float RedComponent;
    public float GreenComponent;
    public float BlueComponent;
    public bool IsContinueFlash;
    public float StartTime;
    public float FlashInterval;
    public float FlashDuration;
    public float WaitTime;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ParentColor = sprite.material.color;
        _existTime = 0.0f;
        FlashColor.r = RedComponent;
        FlashColor.g = GreenComponent;
        FlashColor.b = BlueComponent;
        FlashColor.a = ParentColor.a;
        IsFlash = false;
    }
    
    private void FixedUpdate()
    {
        if (StartFlash)
        {
            if (!IsFlash) StartCoroutine(Flashing());
        }
        _existTime += Time.deltaTime;
    }

    private IEnumerator Flashing()
    {
        float FlashingCondition = Mathf.Abs(_existTime % (FlashDuration + WaitTime)-StartTime);
        float timeMark = _existTime;
        if (FlashingCondition < Time.deltaTime)
        {
            IsFlash = true;
            while (_existTime < timeMark+FlashDuration)
            {
                ChangeColor();
                yield return new WaitForSeconds(FlashInterval);
            }
        }
        sprite.material.color = ParentColor;
        if (IsContinueFlash) IsFlash = false;
    }

    private void ChangeColor()
    {
        if (sprite.material.color == FlashColor)
        {
            sprite.material.color = ParentColor;
        }
        else
        {
            sprite.material.color = FlashColor;
        }
    }

    public void SetFlashColor(float red, float green, float blue)
    {
        RedComponent = red;
        GreenComponent = green;
        BlueComponent = blue;
    }

    public void SetFlashContinueFlag(bool IsContinue)
    {
        IsContinueFlash = IsContinue;
    }

    public void SetFlashInterval(float Interval)
    {
        FlashInterval = Interval;
    }
    public void SetFlashDuration(float Duration)
    {
        FlashDuration = Duration;
    }
    public void SetWaitTime(float waitTime)
    {
        WaitTime = waitTime;
    }
}

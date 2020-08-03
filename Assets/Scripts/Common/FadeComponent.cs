using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeComponent : MonoBehaviour
{
    SpriteRenderer sprite;
    private Color color;
    private float _existTime;
    public bool StartFade;
    public float FadeInTime;
    public float FadeOutTime;
    public float WaitTime;
    public bool DestroyOnFinish;
    private bool Invisible;
    public bool IsInvisibleOnStart;
    
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.material.color;
        _existTime = 0.0f;
        Invisible = false;
        if (IsInvisibleOnStart) color.a = 0.0f;
        sprite.material.color = color;
    }
    
    private void FixedUpdate()
    {
        if (StartFade)
        {
            if (IsInvisibleOnStart)
                StartCoroutine(StartFadeOut());
            else StartCoroutine(StartFadeIn);
            if (!DestroyOnFinish)
                StartCoroutine(StartFadeIn());
        }
        _existTime += Time.deltaTime;
    }

    private IEnumerator StartFadeIn()
    {
        float FadeInStartCondition = Mathf.Abs(_existTime % (FadeOutTime + FadeInTime + WaitTime * 2 - (FadeOutTime + WaitTime)));
        float timestart = 0.0f;
        if (FadeInStartCondition <= Time.deltaTime && Invisible)
        {
            while (timestart < FadeInTime)
            {
                color.a = timestart / FadeInTime;
                sprite.material.color = color;
                timestart += Time.deltaTime; 
                yield return null;
            } 
            color.a = 1.0f;
            Invisible = false;
        }
        else yield break;
    }

    private IEnumerator StartFadeOut()
    {
        float FadeOutStartCondition = Mathf.Abs(_existTime % (FadeOutTime + FadeInTime + WaitTime * 2));
        float timestart = FadeOutTime;
        {
            if (FadeOutStartCondition <= Time.deltaTime && !Invisible) 
            {
                while (timestart > 0.0f)
                {
                    color.a = timestart / FadeOutTime;
                    sprite.material.color = color;
                    timestart -= Time.deltaTime;
                    yield return null;
                } 
                color.a = 0.0f;
                Invisible = true;
            }
            else yield break;
        }
    }

    public void SetFadeStarter(bool IsFadeStart)
    {
        StartFade = IsFadeStart;
    }
    
    public void SetDestroyer(bool IsDestroy)
    {
        DestroyOnFinish = IsDestroy;
    }

    public void SetFadeInTime(float FadeInDuration)
    {
        FadeInTime = FadeInDuration;
    }

    public void SetFadeOutTime(float FadeOutDuration)
    {
        FadeOutTime = FadeOutDuration;
    }

    public void SetWaitTime(float WaitDuration)
    {
        WaitTime = WaitDuration;
    }
}
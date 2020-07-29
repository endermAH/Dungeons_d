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
    
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = sprite.material.color;
        _existTime = 0.0f;
    }
    
    private void Update()
    {
        float FadeOutStartCondition = Mathf.Abs(_existTime % (FadeOutTime + FadeInTime + WaitTime * 2));
        float FadeInStartCondition = Mathf.Abs(FadeOutStartCondition - (FadeOutTime + WaitTime));
        if (StartFade)
        {
            if (FadeOutStartCondition <= 0.05f)
            {
                StartCoroutine(StartFadeOut());
            }
            if (!DestroyOnFinish)
            {
                if (FadeInStartCondition <= 0.05f)
                {
                    StartCoroutine(StartFadeIn());
                }
            }
            //else destroy object
        }
        _existTime += Time.deltaTime;
    }

    private IEnumerator StartFadeIn()
    {
        float timestart = 0.0f;
        while (timestart < FadeInTime)
        {
            color.a = timestart / FadeInTime;
			sprite.material.color = color;
            timestart += Time.deltaTime;
            yield return null;
        }
        color.a = 1.0f;
    }

    private IEnumerator StartFadeOut()
    {
        float timestart = FadeOutTime;
        while (timestart > 0.0f)
        {
            color.a = timestart / FadeOutTime;
            sprite.material.color = color;
            timestart -= Time.deltaTime;
            yield return null;
        }
        color.a = 0.0f;
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
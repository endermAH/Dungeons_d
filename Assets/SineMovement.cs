using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour
{
    public float deltaY;
    public float amplitude;
    public bool activeOnStart;
    private bool _isMoving;

    private Vector3 _startPosition;

    private void Start()
    {
        if (activeOnStart) StartMovement();
    }

    public void StartMovement()
    {
        _isMoving = true;
        _startPosition = transform.position;
        var end = new Vector3(_startPosition.x, _startPosition.y+deltaY, _startPosition.z);
        StartCoroutine(MoveFromTo(_startPosition, end, amplitude));
    }

    public void StopMovement()
    {
        _isMoving = false;
    }
    private IEnumerator MoveFromTo(Vector3 startPoint, Vector3 endPoint, float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            if (_isMoving) transform.position = Vector3.Lerp(startPoint, endPoint, timeElapsed / duration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        if (_isMoving)
        {
            transform.position = endPoint;
            deltaY *= -1;
            var end = new Vector3(_startPosition.x, _startPosition.y + deltaY, _startPosition.z);
            StartCoroutine(MoveFromTo(endPoint, end, amplitude));
        }
    }
}

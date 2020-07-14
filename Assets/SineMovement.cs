using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour
{
    public float deltaY;
    public float amplitude;

    private Vector3 _startPosition;
    private void Start()
    {
        _startPosition = transform.position;
        StartMovement();
    }

    private void StartMovement()
    {
        var end = new Vector3(_startPosition.x, _startPosition.y+deltaY, _startPosition.z);
        StartCoroutine(MoveFromTo(_startPosition, end, amplitude));
    }
    private IEnumerator MoveFromTo(Vector3 startPoint, Vector3 endPoint, float duration)
    {
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPoint, endPoint, timeElapsed / duration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = endPoint;
        
        deltaY *= -1;
        var end = new Vector3(_startPosition.x, _startPosition.y+deltaY, _startPosition.z);
        StartCoroutine(MoveFromTo(endPoint, end, amplitude));
    }
}

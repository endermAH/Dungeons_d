using System.Collections;
using UnityEngine;

namespace Common
{
    public class MoveTo : MonoBehaviour
    {
        public void MoveToPoint(Vector3 target, float duration)
        {
            var currentPosition = transform.position;
            StartCoroutine(MoveFromTo(currentPosition, target, duration));
        }

        public void MoveToGameObject(GameObject target, float duration)
        {
            var currentPosition = transform.position;
            var targetPosition = target.transform.position;
            StartCoroutine(MoveFromTo(currentPosition, targetPosition, duration));
        }

        private IEnumerator MoveFromTo(Vector3 from, Vector3 to, float duration)
        {
            float timeElapsed = 0;

            while (timeElapsed < duration)
            {
                transform.position = Vector3.Lerp(from, to, timeElapsed / duration);
                timeElapsed += Time.deltaTime;

                yield return null;
            }

            transform.position = to;
        }
    }
}

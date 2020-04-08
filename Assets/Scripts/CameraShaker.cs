using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public IEnumerator Shake(float duration, float range)
    {
        Vector3 original_position = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-range, range);
            float y = Random.Range(-range, range);

            transform.localPosition = new Vector3(x, y, original_position.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = original_position;
    }
}

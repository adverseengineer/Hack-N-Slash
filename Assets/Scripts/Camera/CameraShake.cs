using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera/Camera Shake")]
public class CameraShake : MonoBehaviour
{
    [HideInInspector] public float duration;
    [HideInInspector] public float magnitude;

    private Vector3 originalPosition;

    private bool shaking = false;

    void Update()
    {
        if(!shaking)
        {
            originalPosition = transform.localPosition;
        }
    }

    public IEnumerator Shake(float duration = 2f)
    {
        float timer = 0f;
        shaking = true;
        while(timer < duration)
        {
            transform.position = Random.insideUnitSphere;
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = originalPosition;
        shaking = false;
    }
}
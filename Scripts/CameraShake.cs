using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField] float shakeDuration = 0.5f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPos;

     void Start()
    {
       initialPos = transform.position;
    }

   public void play()
    {
        StartCoroutine(ShakeCamera());
    }

    IEnumerator ShakeCamera()
    {
        float timeElapsed = 0;
      
        while (timeElapsed < shakeDuration)
        {
            transform.position = initialPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = initialPos;
    }


}

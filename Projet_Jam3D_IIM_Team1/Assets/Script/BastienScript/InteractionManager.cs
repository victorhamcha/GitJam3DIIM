using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum effect
{
    TIMESCALE
}

[RequireComponent(typeof(BoxCollider))]
public class InteractionManager : MonoBehaviour
{
    [SerializeField] private string tagForTrigger = "Player";
    [SerializeField] private effect effectType = effect.TIMESCALE;
    [Range(0.1f, 2)] [SerializeField] private float timescaleValue = 1;
    [Range (1,5)] [SerializeField] private float effectDuration = 1;
    [SerializeField] private float timeBeforeEffect = 0f;
    [SerializeField] private int numberOfEffect = 1;

    //https://answers.unity.com/questions/1284988/custom-inspector-2.html

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagForTrigger)
            if (numberOfEffect > 0)
            {
                numberOfEffect--;
                StartCoroutine(TimeScaleEffect(timescaleValue, effectDuration, timeBeforeEffect));
            }
    }

    private IEnumerator TimeScaleEffect(float tsv, float timer, float countdown)
    {
        yield return new WaitForSecondsRealtime(countdown);
        if (effectType == effect.TIMESCALE)
        {
            Time.timeScale = tsv;
            yield return new WaitForSecondsRealtime(timer);
            Time.timeScale = 1f;
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.GetComponent<BoxCollider>().size);
    }
}

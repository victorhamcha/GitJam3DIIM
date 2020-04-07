using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum effect
{
    SLOWMO,
    FASTMO
}

[RequireComponent(typeof(BoxCollider))]
public class InteractionManager : MonoBehaviour
{
    [SerializeField] private effect effectType = effect.SLOWMO;
    [Range (1,5)] [SerializeField] private float effectDuration = 1;
    [SerializeField] private float timeBeforeEffect = 0f;

    //https://answers.unity.com/questions/1284988/custom-inspector-2.html

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            StartCoroutine(TimeScaleEffect(effectDuration, timeBeforeEffect));
    }

    private IEnumerator TimeScaleEffect(float timer, float countdown)
    {
        yield return new WaitForSeconds(countdown);
        if (effectType == effect.SLOWMO)
        {
            Time.timeScale = 0.5f;
        }
        if(effectType == effect.FASTMO)
        {
            Time.timeScale = 1.5f;
        }
        yield return new WaitForSeconds(timer);
        Time.timeScale = 1f;
    }

    void OnDrawGizmos()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.GetComponent<BoxCollider>().size);
    }
}

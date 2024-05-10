using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalZone : MonoBehaviour
{
    [SerializeField] private float radius;
    private Transform mainCamera;

    [SerializeField] private UnityEvent onInside, onOutside;
    
    private void Start()
    {
        mainCamera = Camera.main.transform;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        if(Vector3.Distance(mainCamera.position, transform.position) < radius)
        {
            onInside.Invoke();
        }
        else
        {
            onOutside.Invoke();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

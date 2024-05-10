using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PortalPlacer : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject placementObject;

    private bool isPlaced = false;

    public static event Action onPortalPlaced;

    private void Update()
    {
        if (isPlaced) return;

        if (Input.touchCount > 0 && Input.touchCount < 2 &&
            Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);

            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = touch.position;

            List<RaycastResult> results = new List<RaycastResult>();

            EventSystem.current.RaycastAll(pointerData, results);

            if (results.Count > 0)
            {
                // We hit a UI element
                Debug.Log("We hit an UI Element");
                return;
            }

            Debug.Log("Touch detected, fingerId: " + touch.fingerId);  


            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                Debug.Log("Is Pointer Over GOJ, No placement ");
                return;
            }

            TouchToRay(touch.position);
        }
    }

    private void TouchToRay(Vector3 touch)
    {
        Ray ray = mainCam.ScreenPointToRay(touch);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(placementObject, hit.point, Quaternion.FromToRotation(transform.up, hit.normal));
            isPlaced = true;
            onPortalPlaced?.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshControllerAR : MonoBehaviour
{
    private void OnEnable()
    {
        PortalPlacer.onPortalPlaced += HideMeshing;
    }

    private void OnDisable()
    {
        PortalPlacer.onPortalPlaced -= HideMeshing;
    }

    private void HideMeshing()
    {
        this.gameObject.SetActive(false);
    }
}

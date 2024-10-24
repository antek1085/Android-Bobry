using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateOpener : MonoBehaviour
{ 
    private Touch touch;
    Vector3 touchPosition;
    private Vector3 rayStartPosition;
    private Camera cam;
    
    [SerializeField] private LayerMask layerMask;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                RaycastHit hit;
                rayStartPosition = cam.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, Camera.main.transform.position.z));
                if (Physics.Raycast(rayStartPosition, Camera.main.transform.forward, out hit, Mathf.Infinity, layerMask.value))
                {
                    hit.transform.GetComponent<Crate>().CreateOpen();
                }
            }
        }
    }
}

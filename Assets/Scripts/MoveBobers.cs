using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveBobers : MonoBehaviour
{
    RaycastHit hit;
    private Touch touch;
    Vector3 touchPosition;
    public GameObject objectToMove;
    private Vector3 rayStartPosition;
    private Camera cam;

    [SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.touchCount);
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                
                if (objectToMove == null)
                {
                    rayStartPosition = cam.ScreenToWorldPoint(new Vector3
                    (touchPosition.x, touchPosition.y, Camera.main.transform.position.z));
                    if (Physics.Raycast(rayStartPosition ,Camera.main.transform.forward ,out hit, Mathf.Infinity,layerMask.value))
                    {
                        objectToMove = hit.transform.gameObject;
                        objectToMove.GetComponent<MergeBober>().isHolded = true;
                    }   
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (objectToMove != null)
                { 
                    rayStartPosition = cam.ScreenToWorldPoint(new Vector3
                        (touchPosition.x, touchPosition.y, Camera.main.transform.position.z));
                    
                    Debug.Log("Moved"); 
                    objectToMove.transform.position = new Vector3(rayStartPosition.x, rayStartPosition.y,0);  
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                if (objectToMove == null)
                {
                    objectToMove = null;
                }
                else if (objectToMove != null)
                {
                    objectToMove.GetComponent<MergeBober>().isHolded = false;
                    objectToMove = null;
                }
            }
        }
    }
    
    

    void MouseMove()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            
            hit.transform.GetComponent<MergeBober>().isHolded = true;
        }
    }
    
}

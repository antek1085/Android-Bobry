using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBobers : MonoBehaviour
{
    RaycastHit hit;
    private Touch touch;
    Vector3 touchPosition;
    GameObject objectToMove;

    [SerializeField] int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            switch (touch.phase)
            {
                
                case TouchPhase.Began:
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                    {
                        objectToMove = hit.transform.gameObject;
                        objectToMove.GetComponent<MergeBober>().isHolded = true;
                    }
                    break;
                case TouchPhase.Moved:
                    if (objectToMove != null)
                    {
                        objectToMove.transform.position = touchPosition;
                    }
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    objectToMove.GetComponent<MergeBober>().isHolded = false;
                    objectToMove = null;
                    break;
                case TouchPhase.Canceled:
                    objectToMove = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        
        /*MouseMove();
        if(Input.touchCount > 0)
        {
            MouseMove();
            
            touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity,layerMask))
                    {
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            
                        hit.transform.GetComponent<MergeBober>().isHolded = true;
                    }
                    break;
                case TouchPhase.Moved:
                    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    mousePosition.z = 0;
                    transform.position = mousePosition;
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    hit.transform.GetComponent<MergeBober>().isHolded = false;
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }*/
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

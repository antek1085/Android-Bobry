using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurnONOFFObject : MonoBehaviour
{
    [SerializeField] GameObject gameObject;

    public void SetActiveWindow()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }

}

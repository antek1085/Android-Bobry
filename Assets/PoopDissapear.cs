using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PoopDissapear : MonoBehaviour
{
   void Start()
   {
      this.gameObject.GetComponent<SpriteRenderer>().DOFade(0, 5);
      
   }

   IEnumerator DestroyObject()
   {
      yield return new WaitForSeconds(5.5f);
      Destroy(this.gameObject);
   }
}

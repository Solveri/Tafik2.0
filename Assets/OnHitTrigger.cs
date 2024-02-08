using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitTrigger : MonoBehaviour
{
    public bool hasBeenHit { get; private set; }
    [SerializeField] float hitBoxCD;
    private void Start()
    {
        hasBeenHit = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         * if the player got hit we need to tell the healthsystem he got hit and then lower the HP By the damage Amount
         * 
        */
        if (collision.tag == "Enemy")
        {
            hasBeenHit = true;
            StartCoroutine(RestHitBox());

        }
    }
    private IEnumerator RestHitBox()
    {
        yield return new WaitForSeconds(hitBoxCD);
        hasBeenHit = false;
    }

    
}

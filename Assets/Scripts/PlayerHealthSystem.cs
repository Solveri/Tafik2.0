using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public int MaxHP { get; private set; }
    public int CurrentHP { get; private set; }
    [SerializeField] OnHitTrigger HitBox;

    void Start()
    {
        MaxHP = 100;
        CurrentHP = MaxHP;

    }

    // Update is called once per frame
    void Update()
    {
        if (HitBox != null)
        {
            if (HitBox.hasBeenHit)
            {
                ApplyDamage(30);
            }
        }
    }
    private void ApplyDamage(int damage)
    {
        CurrentHP-=damage;
    }
   

}

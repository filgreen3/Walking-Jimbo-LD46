using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Сudgel : GenericItem
{
    bool isHitEnd = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isHitEnd && other.tag == "Player")
        {
            isHitEnd = false;
            other.GetComponent<Player>().GetDamage(0.1f);
            other.GetComponent<SoundPlayer>().PlaySound();

            Invoke("EndHit", 1f);
        }
    }


    void EndHit()
    {
        isHitEnd = true;
    }

}

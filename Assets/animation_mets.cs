using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_mets : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Animator>().SetFloat("ASpeed", Random.Range(0.7f, 1.3f));
    }
    public void Rotate()
    {
        gameObject.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

}

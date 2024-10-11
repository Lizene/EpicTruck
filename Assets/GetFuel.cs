using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFuel : MonoBehaviour
{
    bool collected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected) return;
        collected = true;
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gm is null) return;
        gm.FillTank();
        Destroy(gameObject);
    }
}

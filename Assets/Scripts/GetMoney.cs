using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMoney : MonoBehaviour
{
    bool collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected) return;
        collected = true;
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gm is null) return;
        gm.AddMoney(1);
        Destroy(gameObject);
    }
}

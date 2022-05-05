using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    public GameObject Coin;

    private void Start()
    {
        Instantiate(Coin, transform.position, Quaternion.identity);
    }
}

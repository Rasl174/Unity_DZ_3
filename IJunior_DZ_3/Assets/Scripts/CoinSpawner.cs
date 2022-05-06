using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private void Start()
    {
        Instantiate(_coin, transform.position, Quaternion.identity);
    }
}

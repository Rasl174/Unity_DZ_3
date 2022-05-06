using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;

    private void Start()
    {
        Instantiate(_coin, transform.position, Quaternion.identity);
    }
}

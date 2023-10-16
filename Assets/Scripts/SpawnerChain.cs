using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerChain : MonoBehaviour
{
    [SerializeField] GameObject Chain;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_Spawner());
    }

    private IEnumerator _Spawner()
    {
        yield return new WaitForSeconds(time);
        Instantiate(Chain, transform.position, Quaternion.identity);
        StartCoroutine(_Spawner());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] GameObject _coinPrefab;
    [SerializeField] AudioSource _coinSound;

    List<GameObject> _coins = new List<GameObject>();

    public void Spawn()
    {
        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            GameObject coin = Instantiate(_coinPrefab, transform.position, _coinPrefab.transform.rotation, transform);
            _coins.Add(coin); 
        }

        for (int i = 0; i < _coins.Count; i++)
            StartCoroutine(LerpAround(_coins[i], 0.3f));

        for (int i = 0; i < _coins.Count; i++)
            StartCoroutine(LerpTowardsPlayer(_coins[i], GameObject.FindGameObjectWithTag("Player").transform.position, 1));

        _coinSound.Play();
    }

    IEnumerator LerpAround(GameObject coin, float duration)
    {
        float time = 0;
        Vector3 startPosition = coin.transform.position;
        Vector3 targetPosition = new Vector3(Random.Range(transform.position.x - 3, transform.position.x + 3),
                                            _coinPrefab.transform.position.y,
                                            Random.Range(transform.position.z - 3, transform.position.z + 3));

        while (time < duration)
        {
            coin.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        coin.transform.position = targetPosition;
    }

    IEnumerator LerpTowardsPlayer(GameObject c, Vector3 targetPosition, float duration)
    {
        yield return new WaitForSeconds(0.3f);

        float time = 0;
        Vector3 startPosition = c.transform.position;

        while (time < duration)
        {
            c.transform.position = Vector3.Lerp(startPosition, GameObject.FindGameObjectWithTag("Player").transform.position + new Vector3(0, 1, 0), time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        c.transform.position = targetPosition;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] GameObject _lid;

    bool _isOpened = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _lid.transform.Rotate(new Vector3(-90, 0, 0));

            if (!_isOpened)
            {
                GetComponent<CoinSpawn>().Spawn();
                _isOpened = true;
            }             
        }       
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            _lid.transform.Rotate(new Vector3(90, 0, 0));
    }

    //IEnumerator OpenLid()
    //{
    //    float time = 0;
    //    Vector3 direction = new Vector3(-90, transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y);
    //    Quaternion targetRotation = Quaternion.Euler(direction);

    //    while (time < 1)
    //    {
    //        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, time / 1);
    //        time += Time.deltaTime;
    //        yield return null;
    //    }
    //    this.transform.rotation = targetRotation;
    //}

    //IEnumerator CloseLid()
    //{
    //    float time = 0;
    //    Vector3 direction = new Vector3(0, 0, 0);
    //    Quaternion targetRotation = Quaternion.Euler(direction);

    //    while (time < 1)
    //    {
    //        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, time / 1);
    //        time += Time.deltaTime;
    //        yield return null;
    //    }
    //    this.transform.rotation = targetRotation;
    //}
}

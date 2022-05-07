using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoCtrl : MonoBehaviour
{
    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, Speed * Time.deltaTime, 0);
        if (transform.position.y > 5 || transform.position.y < -5) Destroy(this.gameObject);
    }

    public static explicit operator TorpedoCtrl(GameObject v)
    {
        throw new NotImplementedException();
    }
}

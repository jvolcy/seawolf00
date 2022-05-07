using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCtrl : MonoBehaviour
{
    public float RandomStartRange = 16f;
    public float MinSpeed = 1f;
    public float MaxSpeed = 4f;
    float Speed;
    public float Value = 0f;     //how many points we get for hitting this ship
    public GameObject TorpedoPrefab;
    public float TorpedoSpeed = 5f;
    public float MinTorpedoPeriod = 1f;
    public float MaxTorpedoPeriod = 5f;
    float XScale;

    float FireTime;

    float XPos;
    bool TravelDir;

    // Start is called before the first frame update
    void Start()
    {
        XScale = transform.localScale.x;
        Speed = Random.Range(MinSpeed, MaxSpeed);
        ResetPosition();
        FireTime = Time.time + Random.Range(0f, MaxTorpedoPeriod);
    }

    // Update is called once per frame
    void Update()
    {
        XPos += Speed * Time.deltaTime;
        SetPosition();
        if (XPos > 8) ResetPosition();

        if (Time.time > FireTime) FireTorpedo();
    }

    void ResetPosition()
    {
        XPos = -8 - Random.Range(0, RandomStartRange);

        if (Random.Range(0, 2) == 1)   //reverse the travel direction (R->L)
        {
            TravelDir = true;
            transform.localScale = new Vector3(-XScale, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            TravelDir = false;
            transform.localScale = new Vector3(XScale, transform.localScale.y, transform.localScale.z);
        }

        SetPosition();
    }

    void SetPosition()
    {
        transform.position = new Vector2(TravelDir ? -XPos : XPos, transform.position.y);
    }

    void FireTorpedo()
    {
        GameObject x = Instantiate(TorpedoPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0f, 0f, 180f));
        x.GetComponent<TorpedoCtrl>().Speed = TorpedoSpeed;

        FireTime = Time.time + Random.Range(MinTorpedoPeriod, MaxTorpedoPeriod);
    }
}

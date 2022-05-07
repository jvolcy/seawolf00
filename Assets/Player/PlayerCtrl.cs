using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCtrl : MonoBehaviour
{
    public GameObject TorpedoPrefab;
    public float TorpedoSpeed = 3f;
    public float PlayerSpeed = 1f;
    public TMP_Text tMP_Text;
    public TMP_Text tMP_Text2;
    float PlayerPosition = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerPosition += PlayerSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerPosition -= PlayerSpeed * Time.deltaTime;
        }
        else
        {
            PlayerPosition += PlayerSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }

        PlayerPosition = Mathf.Clamp(PlayerPosition, -8f, 8f);
        transform.position = new Vector2(PlayerPosition, transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject x = Instantiate(TorpedoPrefab, new Vector3(PlayerPosition, -5f, 0), Quaternion.Euler(0f, 0f, 0f));
            x.GetComponent<TorpedoCtrl>().Speed = TorpedoSpeed;

        }

        tMP_Text.text = Input.GetAxis("Fire1").ToString("0.00");
        //tMP_Text2.text = Input.GetButton("").ToString(); //GetAxis("Fire1").ToString("0.00");
    }
}

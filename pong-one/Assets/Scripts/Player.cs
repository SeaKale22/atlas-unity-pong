using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        if (Input.GetKey(upKey))
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            if (transform.localPosition.y >= 459)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, 455);
            }
        }
        if (Input.GetKey(downKey))
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
            if (transform.localPosition.y <= -459)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, -455);
            }
        }
    }
}

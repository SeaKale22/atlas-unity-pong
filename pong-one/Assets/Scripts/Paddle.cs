using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MoveUp()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        if (transform.localPosition.y >= 459)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, 455);
        }
    }

    public void MoveDown()
    {
        transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        if (transform.localPosition.y <= -459)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, -455);
        }
    }
}

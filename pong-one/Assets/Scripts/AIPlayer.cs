using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    private Paddle parentPaddle;
    // Start is called before the first frame update
    void Start()
    {
        parentPaddle = GetComponentInParent<Paddle>();
        if (GetComponentInParent<Player>())
        {
            Player playerScript = GetComponentInParent<Player>();
            playerScript.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

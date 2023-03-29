using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float Speed = 2.0f;
    public float MaxMovement = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float input=0;
        bool gameOver = ManagerWorks.Instance.GameOver;
        #if UNITY_ANDROID
        if (!gameOver){
        input = Input.GetAxis("Mouse X");
        }
        #endif
        #if UNITY_STANDALONE_WIN
        if (!gameOver){
        input = Input.GetAxis("Horizontal");
        }
        #endif

        Vector3 pos = transform.position;
        pos.x += input * Speed * Time.deltaTime;

        if (pos.x > MaxMovement)
            pos.x = MaxMovement;
        else if (pos.x < -MaxMovement)
            pos.x = -MaxMovement;

        transform.position = pos;
    }
}

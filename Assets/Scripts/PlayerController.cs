using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 4f;
    float boostSpeed = 20f;
    float normalSpeed = 8f;
    bool moveEnable = true;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2d = FindObjectOfType<SurfaceEffector2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveEnable){
            RotatePlayer();
            SpeedUpPlayer();
        }

    }

    public void disableMove(){
        moveEnable = false;
    }

    void SpeedUpPlayer(){
        if(Input.GetKey(KeyCode.UpArrow)){
            surfaceEffector2d.speed = boostSpeed;
        }
        else {
            surfaceEffector2d.speed = normalSpeed;
        }
    }

    void RotatePlayer(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb2d.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            rb2d.AddTorque(-torqueAmount);
        }
    }
}

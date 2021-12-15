using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Touch touch;

    void Start()
    {
        
    }

   
    void Update()
    {
        TouchController();
    }



    private void TouchController()
    {
        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
               
            }

            if (touch.phase == TouchPhase.Moved)
            {

            }

            if (touch.phase == TouchPhase.Ended)
            {

            }
        }
    }
}

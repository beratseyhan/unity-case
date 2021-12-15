using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    
 

    public void SetLineToGame(GameObject newLine)
    {
        //  yukardaki objeye Parachute dedim ve buranın tek child ı olabilcek sekilde kodladım eger child varsa yenisi gelirse yok edilip yenisi yerine gelcek

        if (transform.childCount > 0)
        {
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
            newLine.transform.parent = this.transform;
            newLine.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}

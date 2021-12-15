

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public GameObject linePrefabs;
    public LayerMask cantDrawOwerLayer;
    int cantDrawOverLayerIndex;

    public float linePointsMinDistance;
    public float lineWidth;
    public Gradient lineColor;

    bool startPointControl = false;

    Line currentLine;


    private Touch touch;

    Parachute parachute;

    public void Awake()
    {
        // layer sayesinde cizgi cizemicegimiz alan kontrol ediliyor
        cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");
        
        parachute = FindObjectOfType<Parachute>();
    }




    private void Update()
    {
      // touch islemleri kontrol ediliyor

        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                BeginDraw();
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Draw();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                EndDraw();
            }
        }
    }

    private void BeginDraw()
    {
        // cizime baslanan nokta 
       

        Vector2 finger = Camera.main.ScreenToWorldPoint(touch.position);
        RaycastHit2D hit = Physics2D.CircleCast(finger, lineWidth / 3f, Vector2.zero, 1f, cantDrawOwerLayer);

        if (hit ==false)
        {
            startPointControl = true;
            currentLine = Instantiate(linePrefabs, this.transform).GetComponent<Line>();

            currentLine.SetLineColor(lineColor);
            currentLine.SetLineWidt(lineWidth);
            currentLine.SetPointMinDistance(linePointsMinDistance);
        }
        else
        {
         
            startPointControl = false;
        }
    }

    private void Draw()
    {
        // suruklenirken cizim islemi
        Vector2 finger = Camera.main.ScreenToWorldPoint(touch.position);
        RaycastHit2D hit = Physics2D.CircleCast(finger, lineWidth / 3f, Vector2.zero, 1f, cantDrawOwerLayer);


        // istenmiyen yere gelirse  cizim  bitiyor
        if (hit)
        {
            EndDraw();
        }
        else
        {
            //iki alan bıtısık oldugu ıcın cızılmeyen yerden cızmeye baslandı mı diye kontrol ediyorum.
            if (startPointControl == true)
            {
                currentLine.AddPoint(finger);
            }
           
        }
       
    }

    private void EndDraw()
    {
        if (currentLine != null)
        {
            if (currentLine.pointsCount < 2)
            {
                Destroy(currentLine.gameObject);
            }
            else
            {
                currentLine.gameObject.layer = cantDrawOverLayerIndex;
                //  yukarı kısma gitmesi için yaptıgım islem
                parachute.SetLineToGame(currentLine.gameObject);
                currentLine = null;
            }
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] EdgeCollider2D edgeCollider2D;
   

    [HideInInspector] public List<Vector2> points = new List<Vector2>();
    [HideInInspector] public int pointsCount = 0;


    private float pointsMinDistance = 0.1f;
    private float CircleColliderRadius;



    public Vector2 GetLastPoint()
    {
       
        return (Vector2)line.GetPosition(pointsCount - 1);
    }


   
    public void SetLineColor(Gradient LineColor)
    {
        //renk islemleri
        line.colorGradient = LineColor;
    }

    public void SetLineWidt(float widt)
    {
        //kalınlık verme  islemleri
        line.startWidth = widt;
        line.endWidth = widt;



        edgeCollider2D.edgeRadius = widt / 2f;
        CircleColliderRadius = widt / 2f;
    }


    public void AddPoint(Vector2 newPoint)
    {
         //noktaları ekliyoruz 
        if(pointsCount>= 1&& Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
        {
            return;
        }
        points.Add(newPoint);
        pointsCount++;

        CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
        circleCollider.offset = newPoint;
        circleCollider.radius = CircleColliderRadius;


        line.positionCount = pointsCount;
        line.SetPosition(pointsCount - 1, newPoint);

        if (pointsCount > 1)
        {
            edgeCollider2D.points = points.ToArray();
        }

    }

    public void SetPointMinDistance(float distance)
    {
        //ip olustrulması ıcın  gerekli min
        pointsMinDistance = distance;
    }


}

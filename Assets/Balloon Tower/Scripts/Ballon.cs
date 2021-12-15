using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ballon : MonoBehaviour
{
    //balonlar icin material unity içersinden verilir
    [SerializeField] Material[] ballonMaterial = new Material[5];
    //balonlar icin referans alınması gereken nokta
    [SerializeField] GameObject centerObject;
    //balonlara uygulanacak guc
    [SerializeField] Vector3 addForce = new Vector3(0, 3f, 0);
    //balonları sısırmek ıcın uygulanacak güc
    [SerializeField] Vector3 ınflateBalonSpeed = new Vector3(0.005f, 0.005f, 0.005f);


    Rigidbody rb;
    Renderer  render;
    SpringJoint springJoint;
    LineRenderer lineRenderer;

   


    //balonlar ucmaya hazır mı diye kontrol ediyoruz
    bool isBallonCanFly = false;
   
   
    
 

    
    void Awake()
    {


        StartSettings();



    }



    private void FixedUpdate()
    {

        if (isBallonCanFly != true)
        {
            InflateBallon();
        }

        else
        {

            rb.AddForce(addForce, ForceMode.Force);

            /*
            if (transform.position.y < springJoint.maxDistance)
            {
                
            }
            */
            
        }
        //ip cizilmesi  icin
        CreateRope();
      
    }
    

    private void StartSettings()
    {
        //oyun baslarken olusturulması gerekenleri duzenli olması icin tek fonksiyonda topladım
        SetMaterial();
        rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        springJoint = GetComponent<SpringJoint>();

        //spring joint noktosı veriyorum x ve z sıfır cunku merkezden uzaklastıgımız zaman yukselirken açı ile yukseliyor
        springJoint.connectedAnchor = centerObject.transform.position + new Vector3(0, 2f, 0);
        

        
    }
    

    private void SetMaterial()
    {
        System.Random random = new System.Random();

        render = GetComponent<Renderer>();

        GetComponent<Renderer>().material = ballonMaterial[random.Next(0, ballonMaterial.Length)];
    }

    private  void InflateBallon()
    {
        //balonu sisirmek icin bu yöntemi kullandım fakat animasyon kısmından da bunu yapabilirdik.
        if (transform.localScale.y <= 1)
        {
           
            transform.localScale += ınflateBalonSpeed;
        }
        else
        {
            isBallonCanFly = true;
        } 
         

    }


    private void CreateRope()
    {
        //balon ve merkez arasındaki kısma ip ciziyoruz
        lineRenderer.startWidth = 0.015f;
        lineRenderer.endWidth = 0.03f;
        lineRenderer.SetPosition(0, centerObject.transform.position);
        lineRenderer.SetPosition(1, transform.position);

        
    }

}

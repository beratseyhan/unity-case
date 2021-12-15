using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject ballon;

    [SerializeField] GameObject createArea;

    bool canCreateBallon = true;
    GameObject currentBallon;

    [SerializeField] List<GameObject> ballonArray = new List<GameObject>();

    void Awake()
    {
        CreateBallon();
    }

    


    void Update()
    {
        //balon olusturabilmemiz basta true fakat olustrulduktan  false dönuyoruz 4 sn sonra IEnumerator fonksiyonu sayesinde tekrar true oluyor
        if (canCreateBallon == true)
        {
            StartCoroutine(CreateBallon());
        }

    }

    IEnumerator CreateBallon()
    {
            canCreateBallon = false;

        //balon olusturabilma  kısmında center icerisinde hafif bir randomluk katıldı


       
        // oyunun ilerelyen  kısmında balon sayımız ihtiyac olabilceginden array icine sakladım

        currentBallon = Instantiate(ballon, new Vector3( (createArea.transform.position.x+ Random.Range(-0.01f, 0.01f)),
                2f,
                (createArea.transform.position.z + Random.Range(-0.01f, 0.01f))),

                Quaternion.identity);

        ballonArray.Add(currentBallon);
       
        yield return new WaitForSeconds(4f);
        canCreateBallon = true;
       
    }
}
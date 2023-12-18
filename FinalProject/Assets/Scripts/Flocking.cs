using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    // Start is called before the first frame update

    public FlockingManager myManager;
    public float speed;
    public Vector3 direction;
    public int probabilitySkip = 10;
    private float et, maxt;

    void Start()
    {
        speed = UnityEngine.Random.Range(myManager.minSpeed, myManager.maxSpeed);
        Flock();
        maxt = Random.Range(0.3f, 0.5f);
        et = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        et += Time.deltaTime;
        if (et > maxt)
        {
            Flock();
            et -= maxt;
            maxt = Random.Range(0.3f, 0.5f);
        };
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);

        int randomNumber = UnityEngine.Random.Range(0, probabilitySkip);

        //if (randomNumber == 0)
        //{
        //    Flock();
        //}
    }

    void Flock()
    {
        Vector3 cohesion = Vector3.zero;
        int num = 0;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    cohesion += go.transform.position;
                    num++;
                }
            }
        }
        float number = 0.001f;
        Vector3 randomVector = new Vector3(UnityEngine.Random.Range(-number, number), UnityEngine.Random.Range(-number, number), UnityEngine.Random.Range(-number, number));
        //cohesion = cohesion + randomVector;
        if (num > 0)
            cohesion = (cohesion / num - transform.position).normalized * speed;
        
        //
        
        Vector3 align = Vector3.zero;
        /*int*/ num = 0;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    align += go.GetComponent<Flocking>().direction;
                    num++;
                }
            }
        }
        if (num > 0)
        {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
        }
        //align = align + randomVector;
        
        
        
        Vector3 separation = Vector3.zero;
        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                    separation -= (transform.position - go.transform.position) /
                                  (distance * distance);
            }
        }
        
        direction = (cohesion + align + separation).normalized * speed;
        //Debug.Log(cohesion);
        //Debug.Log(myManager.allFish.Length);
        //direction = direction + randomVector;



        //Vector3 cohesion = Vector3.zero;
        //int num = 0;
        //Vector3 align = Vector3.zero;
        //Vector3 separation = Vector3.zero;
        //
        //foreach (GameObject go in myManager.allFish)
        //{
        //    if (go != this.gameObject)
        //    {
        //        float distance = Vector3.Distance(go.transform.position,
        //                                          transform.position);
        //        if (distance <= myManager.neighbourDistance)
        //        {
        //            cohesion += go.transform.position;
        //            num++;
        //        }
        //    }
        //
        //    if (num > 0)
        //        cohesion = (cohesion / num - transform.position).normalized * speed;
        //
        //    if (go != this.gameObject)
        //    {
        //        float distance = Vector3.Distance(go.transform.position,
        //                                          transform.position);
        //        if (distance <= myManager.neighbourDistance)
        //        {
        //            align += go.GetComponent<Flocking>().direction;
        //            num++;
        //        }
        //    }
        //
        //    if (num > 0)
        //    {
        //        align /= num;
        //        speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
        //    }
        //
        //    if (go != this.gameObject)
        //    {
        //        float distance = Vector3.Distance(go.transform.position,
        //                                          transform.position);
        //        if (distance <= myManager.neighbourDistance)
        //            separation -= (transform.position - go.transform.position) /
        //                          (distance * distance);
        //    }
        //
        //    direction = (cohesion + align + separation).normalized * speed;
        //}

    }
}

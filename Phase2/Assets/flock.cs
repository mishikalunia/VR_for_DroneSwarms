using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flock : MonoBehaviour
{
    public float speed = 60f;
    float rotSpeed = 2f;
    //Vector3 avgHeading;
    //Vector3 avgPosition;
    public List<GameObject> drones;

    float neighbourDistance = 10f;

    bool turning = false;
    void Start()
    {
        speed = Random.Range(0.1f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) >= globalFLock.neighbourhoodSize)
        {
            turning = true;
        }
        else
            turning = false;

        if(turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

            speed = Random.Range(0.1f, 0.5f);
        }
        else
        {
            if (Random.Range(0, 5) < 1)
                ApplyRules();
        }
        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = globalFLock.allDrone;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.1f;

        Vector3 goalPos = globalFLock.goalPos;

        float dist;

        int groupSize = 0;
        foreach(GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if(dist <= neighbourDistance)
                {
                    vcenter += go.transform.position;
                    groupSize++;

                    if(dist < 0.5f)
                    {
                        vavoid = vavoid +  (this.transform.position - go.transform.position);
                    }

                    flock anotherFlock = go.GetComponent<flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        /*for (int i = 0; i < this.drones.Count; i++)
        {
            if (drones[i] == null) continue;

            if (drones[i] != this.gameObject)
            {
                dist = Vector3.Distance(transform.position, drones[i].transform.position);
                if (dist <= neighbourDistance)
                {
                    vcenter += drones[i].transform.position;
                    groupSize++;

                    if (dist > 0 && dist < 1f)
                    {
                        // calculate vector headed away from myself
                        vavoid += transform.position - drones[i].transform.position;
                    }

                    flock anotherFlock = drones[i].GetComponent<flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }*/


        if (groupSize > 0)
        {
            vcenter = vcenter / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcenter + vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

        }
    }
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, neighbourDistance);
    }
}

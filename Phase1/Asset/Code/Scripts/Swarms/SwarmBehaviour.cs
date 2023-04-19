using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwarmBehaviour : MonoBehaviour
{
    public Transform Goal;
    GameObject[] AI;
    Vector3 h;

    public float neighborRadius = 2f;
    public float desiredSeparation = 1f;
    //public float desiredSeparation = 2f;

    // velocity influences
    private void Start()
    {
        AI = GameObject.FindGameObjectsWithTag("AI");
    }

    void FixedUpdate()
    {
        #region Cohesion

        if (Vector3.Distance(Goal.position, transform.position) >= neighborRadius)
        {
            Vector3 direction = Goal.position - transform.position;
            transform.Translate(direction * Time.deltaTime);
        }

        #endregion

        #region Separation

        foreach (GameObject go in AI)
        {
            if (go != gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, this.transform.position);
                if (distance > 0 && distance < neighborRadius)
                {
                    Vector3 direction = transform.position - go.transform.position;
                    transform.Translate(direction * Time.deltaTime);
                }
            }
        }

        if (Vector3.Distance(Goal.position, transform.position) < neighborRadius)
        {
            Vector3 direction = transform.position - Goal.position;
            transform.Translate(direction * Time.deltaTime);
        }
        #endregion

        #region Alignment

       //different script
        #endregion

    }
}



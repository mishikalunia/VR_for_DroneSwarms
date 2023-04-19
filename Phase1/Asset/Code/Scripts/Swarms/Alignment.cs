using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignment : MonoBehaviour
{
    public Transform leader;
    GameObject[] AI;

    IEnumerator Start()
    {
        AI = GameObject.FindGameObjectsWithTag("AI");

        Quaternion lastOrientation;
        //Quaternion lastFollowerRot;
        //Quaternion total = Quaternion.identity;

        while (true)
        {
            // Cache the leader's transformation.
            lastOrientation = leader.rotation;

            // Wait till next frame.
            yield return null;

            // Compute leader's local transformation change since last frame.

            Quaternion undoOrientation = Quaternion.Inverse(lastOrientation);
            Quaternion localRotationChange = undoOrientation * leader.rotation;

            //transform.localRotation = Quaternion.Lerp(transform.localRotation, localRotationChange, Time.deltaTime);

            /*foreach (GameObject go in AI)
            {
                if (go != gameObject)
                {
                    lastFollowerRot = go.transform.rotation;

                    // Wait till next frame.
                    yield return null;

                    // Compute leader's local transformation change since last frame.

                    Quaternion undoFOrientation = Quaternion.Inverse(lastFollowerRot);
                    Quaternion followerRotationChange = undoFOrientation * go.transform.rotation;

                    total = Quaternion.Euler((total.eulerAngles.x +  followerRotationChange.eulerAngles.x), (total.eulerAngles.y + followerRotationChange.eulerAngles.y), (total.eulerAngles.z + followerRotationChange.eulerAngles.z));
                }
            }*/
            //total = Quaternion.Euler((total.eulerAngles.x/4 + 5*localRotationChange.eulerAngles.x)/6 , (total.eulerAngles.y/4 +  5*localRotationChange.eulerAngles.y)/6, (total.eulerAngles.z/4 + 5*localRotationChange.eulerAngles.z)/6);
            
            transform.rotation = transform.rotation * localRotationChange;

            //total = Quaternion.identity;
        }
    }
}


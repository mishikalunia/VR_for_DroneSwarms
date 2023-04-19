using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;

    int randomTarget;
    Quaternion newRot;
    Vector3 relPos;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            GetNewTarget();
        }
        else
        {
            relPos = target.position - transform.position;
            newRot = Quaternion.LookRotation(relPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRot, Time.deltaTime * speed);
        }
    }

    void GetNewTarget()
    {
        GameObject[] possibleTargets;
        possibleTargets = GameObject.FindGameObjectsWithTag("AI");
        if (possibleTargets.Length > 0)
        {
            randomTarget = Random.Range(0, possibleTargets.Length);
            target = possibleTargets[randomTarget].transform;
        }
    }

    /*#region Variables

    private Vector3 _offset;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;

    #endregion

    #region Unity callbacks

    private void Awake()
    {
        _offset = transform.position - target.position;
        //playerAngle = AngleOnXZPlane(target);
        //cameraAngle = AngleOnXZPlane(transform);
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        //newRot = Quaternion.LookRotation(targetPosition);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, newRot, Time.deltaTime *smoothTime);*/

        /*float rotationDiff = Mathf.DeltaAngle(cameraAngle, playerAngle);

        // rotate around target by time-sensitive difference between these angles
        transform.RotateAround(target.position, Vector3.up, rotationDiff * Time.deltaTime);
    }

     // Find the angle made when projecting the rotation onto the xz plane.
    private float AngleOnXZPlane(Transform item)
    {

        // get rotation as vector (relative to parent)
        Vector3 direction = item.rotation * item.parent.forward;

        // return angle in degrees when projected onto xz plane
        return Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    }

        #endregion*/
}
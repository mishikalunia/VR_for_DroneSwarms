using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BS_thesis
{
    [RequireComponent(typeof(BoxCollider))]

    public class Drone_Engine : MonoBehaviour
    {
        #region Variables
        [Header("Engine Properties")]
        [SerializeField] private float maxPower = 10f;
        private float throttle;

        [Header("Propeller Properties")]
        [SerializeField] private Transform propeller;
        [SerializeField] private float propRotSpeed = 200f;
        #endregion

        #region Interface Methods
        
        public void UpdateEngine(Rigidbody rb, Drone_Inputs input)
        {
            //Debug.Log("Running Engine:" + gameObject.name);
            Vector3 upVec = transform.up;
            upVec.x = 0f;
            upVec.z = 0f;
            float diff = 1 - upVec.magnitude;
            float finalDiff = Physics.gravity.magnitude * diff;

            Vector3 engineForce = Vector3.zero;

            float throttle = ((rb.mass * Physics.gravity.magnitude) + finalDiff + input.Throttle * maxPower) / 4f;
            engineForce = transform.up * throttle;

            Debug.Log(throttle + " is upspeed");

            rb.AddForce(engineForce, ForceMode.Force);

            HandlePropellers();           
        }

        void HandlePropellers()
        {
            if(!propeller)
            {
                return;
            }

                propeller.Rotate(Vector3.up, propRotSpeed);
        }
        #endregion

    }
}

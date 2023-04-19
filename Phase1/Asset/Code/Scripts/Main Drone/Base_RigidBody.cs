using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BS_thesis
{
    [RequireComponent(typeof(Rigidbody))]
    public class Base_RigidBody : MonoBehaviour
    {
        #region Variables
        [Header("Rigidbody Properties")]
        [SerializeField] private float weightInKgs = 0.454f;

        protected Rigidbody rb;
        protected float startDrag;
        protected float startAngularDrag;
        #endregion

        #region Main Methods 
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if (rb)
            {
                rb.mass = weightInKgs;
                startDrag = rb.drag;
                startAngularDrag = rb.angularDrag;
            }
        }

        void FixedUpdate()
        {
            if (!rb)
            {
                return;
            }
            HandlePhysics();
        }

        #endregion

        #region  Custom Method
        protected virtual void HandlePhysics() { }
        #endregion
    }
}
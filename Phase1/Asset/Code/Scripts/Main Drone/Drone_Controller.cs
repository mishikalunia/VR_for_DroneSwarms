using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace BS_thesis
{
    [RequireComponent(typeof(Drone_Inputs))]
    public class Drone_Controller : Base_RigidBody
    {
        #region Variable
        [Header("Control Properties")]
        [SerializeField] private float minMaxPitch = 10f;
        [SerializeField] private float minMaxRoll = 10f;
        [SerializeField] private float yawPower = 4f;
        private float lerpSpeed = 1f;

        private Drone_Inputs input;
        private List<Drone_Engine> engines = new List<Drone_Engine>();

        private float finalPitch;
        private float finalRoll;
        private float yaw;
        private float finalYaw;
        #endregion

        #region Main Methods
        void Start()
        {
            input = GetComponent<Drone_Inputs>();
            engines = GetComponentsInChildren<Drone_Engine>().ToList<Drone_Engine>();
        }
        #endregion

        #region Custom Methods
        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleControls();
            
        }

        protected virtual void HandleControls()
        {
            //rb.AddForce(Vector3.up * (rb.mass * Physics.gravity.magnitude));

            foreach(Drone_Engine engine in engines)
            {
                engine.UpdateEngine(rb, input);
            }
        }

        protected virtual void HandleEngines()
        {
            float pitch = input.Cyclic.y * minMaxPitch;
            float roll = input.Cyclic.x * minMaxRoll;
            yaw += input.Pedals * yawPower;

            finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
            finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
            finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);

            Quaternion rot = Quaternion.Euler(finalPitch, finalYaw, finalRoll);
            rb.MoveRotation(rot);
        }
       
        #endregion

    }
}

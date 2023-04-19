using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class globalFLock : MonoBehaviour
{
    public GameObject dronePrefab;
    public GameObject goalPrefab;
    [SerializeField]public static float neighbourhoodSize = 20f;

    [SerializeField]static int numDrone = 25;
    public static GameObject[] allDrone = new GameObject[numDrone];
    //public static List<GameObject> drones = new List<GameObject>(numDrone);
    //public static GameObject[] allDrone = drones.ToArray();

    public float spawnRadius = 35f;
    public Vector3 swarmBounds = new Vector3(2 * neighbourhoodSize, 2 * neighbourhoodSize, 2 * neighbourhoodSize);
    public static Vector3 goalPos;

    // Start is called before the first frame update
    void Start()
    {

        if (dronePrefab == null)
        {
            // end early
            Debug.Log("Please assign a drone prefab.");
            return;
        }

        // instantiate the drones

        //GameObject droneTemp;
        //drones = new List<GameObject>();

        for (int i = 0; i < numDrone; i++)
        {

            {
                /*droneTemp = (GameObject)GameObject.Instantiate(dronePrefab);
                flock db = droneTemp.GetComponent<flock>();
                globalFLock globalFLock = this;
                db.drones = globalFLock.drones;

                // spawn inside circle
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z) + Random.insideUnitSphere * spawnRadius;
                droneTemp.transform.position = new Vector3(pos.x, pos.y, pos.z);
                droneTemp.transform.parent = transform;

                drones.Add(droneTemp);*/

                // spawn inside circle
                //Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z) + Random.insideUnitSphere * spawnRadius;

                 Vector3 pos = new Vector3(Random.Range(-neighbourhoodSize, neighbourhoodSize),
                                           Random.Range(-neighbourhoodSize, neighbourhoodSize),
                                           Random.Range(-neighbourhoodSize, neighbourhoodSize));

                allDrone[i] = (GameObject)Instantiate(dronePrefab, pos, Quaternion.identity);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        goalPos = goalPrefab.transform.position;
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, swarmBounds);
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}

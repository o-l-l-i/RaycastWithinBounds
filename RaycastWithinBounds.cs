using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWithinBounds : MonoBehaviour
{
    public GameObject target;
    Bounds groundsBounds;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        groundsBounds = target.gameObject.GetComponent<Collider>().bounds;
    }

    // Update is called once per frame
    void Update()
    {
        // Get bounds min max on XZ-ground plane
        float minX = groundsBounds.min.x;
        float maxX = groundsBounds.max.x;
        float minZ = groundsBounds.min.z;
        float maxZ = groundsBounds.max.z;

        // Randomize X and Z values within bounds
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        // This will hold our ray origin
        float y = 10f; // How high we start from
        Vector3 testPosition = new Vector3(randomX, y, randomZ);
        Debug.Log("testPosition: " + testPosition);

        // Perform a raycast
        RaycastHit hit;
        if (Physics.Raycast(testPosition, Vector3.down, out hit, Mathf.Infinity))
        {
            // If we hit object tagged as "Ground"
            if (hit.transform.gameObject.tag == "Ground")
            {
                Debug.DrawRay(testPosition, Vector3.down * hit.distance, Color.green, 1f);
                Debug.Log("Hit Ground");
                spawnPosition = hit.point;
            }
            // If not hit something else withing bounds
            else
            {
                Debug.DrawRay(testPosition, Vector3.down * hit.distance, Color.red, 1f);
                Debug.Log("Hit something else");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI_ClimbExample : MonoBehaviour
{
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Walls_1"))
        {
            // Check if the NavMeshAgent component exists
            if (agent != null)
            {
                // Set the rotation to zero along the X-axis
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }
            else
            {
                Debug.LogWarning("NavMeshAgent component not found on the GameObject.");
            }
        }
    }
}

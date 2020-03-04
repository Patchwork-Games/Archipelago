using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIK : MonoBehaviour
{
    [SerializeField] private float islandDistance = 100.0f;
    private Animator anim = null;

    [System.Serializable]
    public class IKObjects
    {
        public GameObject island = null;
        public GameObject[] objToLookAt = new GameObject[1];

    };
    [SerializeField] IKObjects[] objects = new IKObjects[1];

    //target to look at
    private Transform target = null;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        //check each island
        for (int i = 0; i < objects.Length; i++)
        {
            //if close to an island
            if (Vector3.Distance(objects[i].island.transform.position, transform.position) < islandDistance)
            {
                //check each ik object on the island
                for (int j = 0; j < objects[i].objToLookAt.Length; j++)
                {
                    //if close to an object, look at it
                    if (Vector3.Distance(objects[i].objToLookAt[j].transform.position, transform.position) < islandDistance)
                    {
                        target = objects[i].objToLookAt[j].transform;
                    }
                }
            }
        }
    }


    private void OnAnimatorIK(int layerIndex)
    {
        var heading = target.position - transform.position;
        var dot = Vector3.Dot(heading, transform.forward);
        if (dot > 0.4 && ((target.position - transform.position).sqrMagnitude < 100) && (PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.MOVING || PlayerStateMachine.Instance.state == PlayerStateMachine.PlayerState.TALKING))
        {
            anim.SetLookAtWeight(1);
            anim.SetLookAtPosition(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }



}

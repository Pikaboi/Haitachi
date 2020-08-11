using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderCheck : MonoBehaviour
{
    GameObject Leader;

    public void SetLeader(GameObject obj)
    {
        Leader = obj;
    }

    public GameObject GetLeader()
    {
        return Leader;
    }
}

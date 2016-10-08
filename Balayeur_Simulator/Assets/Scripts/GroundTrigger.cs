using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GroundTrigger : MonoBehaviour
{



    private GroundBody father;
    private List<Leaf> leaves = new List<Leaf>();



    void Start ()
    {
        father = this.transform.parent.gameObject.GetComponent<GroundBody>();
    }


    void OnTriggerEnter2D (Collider2D c)
    {
        if (c.gameObject.GetComponent<Leaf>() != null)
        {
            leaves.Add(c.gameObject.GetComponent<Leaf>());
        }
    }
    


	void Update ()
    {
        foreach (Leaf leaf in leaves)
        {
            List<Leaf> closeLeaves = new List<Leaf>();
            foreach (Leaf otherLeaf in leaves)
            {
                if (!otherLeaf.isDead && Math.Abs(leaf.gameObject.transform.position.x - otherLeaf.gameObject.transform.position.x) < father.maxDistanceBetweenLeaves)
                {
                    closeLeaves.Add(otherLeaf);
                }
            }

            if (closeLeaves.Count > father.numberOfLeavesForStack)
            {
                StackBody.CreateStack(leaf.gameObject.transform.position);

                foreach (Leaf deadleaf in closeLeaves)
                {
                    deadleaf.isDead = true;
                }
                leaf.isDead = true;
            }
        }

        for (int i = 0; i < leaves.Count; i++)
        {
            if (leaves[i].isDead)
            {
                Destroy(leaves[i].gameObject);
                leaves.RemoveAt(i);
            }
        }
    }
}

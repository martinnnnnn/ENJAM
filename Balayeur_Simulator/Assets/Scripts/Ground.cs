using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Ground : MonoBehaviour
{


    public float maxDistanceBetweenLeaves = 3;
    public int numberOfLeavesForStack = 2;

    private List<Flower> leaves = new List<Flower>();


    void OnCollisionEnter2D (Collision2D c)
    {
        if (c.gameObject.GetComponent<Flower>() != null)
        {
            leaves.Add(c.gameObject.GetComponent<Flower>());
        }
    }

    void Update()
    {
        foreach (Flower leaf in leaves)
        {
            List<Flower> closeLeaves = new List<Flower>();
            foreach (Flower otherLeaf in leaves)
            {
                if (otherLeaf != null && leaf != null)
                {
                    if (!otherLeaf.isDead && Math.Abs(leaf.gameObject.transform.position.x - otherLeaf.gameObject.transform.position.x) < maxDistanceBetweenLeaves)
                    {
                        closeLeaves.Add(otherLeaf);
                    }
                }
            }

            if (closeLeaves.Count > numberOfLeavesForStack)
            {
                Stack.CreateStack(leaf.gameObject.transform.position, closeLeaves.Count);

                foreach (Flower deadleaf in closeLeaves)
                {
                    deadleaf.isDead = true;
                }
                leaf.isDead = true;
            }
        }

        for (int i = 0; i < leaves.Count; i++)
        {
            if (leaves[i] == null)
            {
                leaves.RemoveAt(i);
            }
            else if (leaves[i].isDead)
            {
                Destroy(leaves[i].gameObject);
                leaves.RemoveAt(i);
            }
        }
    }
}

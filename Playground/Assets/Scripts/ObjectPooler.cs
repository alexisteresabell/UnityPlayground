using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler Pool { get; private set; }

    public GameObject prefab;
    List<GameObject> pooledObjects = new List<GameObject>();
    public int objectsInPool = 5;
    public bool canGrow = true;

    void Awake()
    {
        if (Pool == null)
        {
            Pool = this;
        }
        else if (this != Pool)
        {
            Destroy(this.gameObject);
        }
        CreatePool();
    }

    private void CreatePool()
    {

        for (int i = 0; i < objectsInPool; i++)
        {
            GameObject newObject = Instantiate<GameObject>(prefab);
            newObject.gameObject.SetActive(false);
            newObject.transform.SetParent(transform);
            newObject.transform.position = this.transform.position;
            pooledObjects.Add(newObject);
        }
    }

    public GameObject GetObject()
    {
        GameObject newObject = null;
        foreach (GameObject g in pooledObjects)
        {
            if (!g.gameObject.activeSelf)
            {
                newObject = g;
                newObject.gameObject.SetActive(true);
                break;
            }
        }

        if (newObject == null && canGrow)
        {
            //we need to make a new guest
            newObject = Instantiate<GameObject>(prefab);
            newObject.transform.SetParent(transform);
            pooledObjects.Add(newObject);
        }

        if (newObject == null)
        {
            Debug.Log("All objects are active, pool can't grow");
        }

        return newObject;
    }

    public void ReturnToPool(GameObject go)
    {
        go.transform.position = this.transform.position;
        go.gameObject.SetActive(false);
    }

    public void RemoveFromPool(GameObject go)
    {
        pooledObjects.Remove(go);
    }
}


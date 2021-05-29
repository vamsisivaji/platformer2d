using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class GalaxyPool
    {
        public string Name;
        public GameObject Obj;
        public int Size;
    }
    public Dictionary<string, Queue<GameObject>> galaxyPool;
    public List<GalaxyPool> GP;
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        galaxyPool = new Dictionary<string, Queue<GameObject>>();
        foreach(GalaxyPool Pool in GP)
        {
            Queue<GameObject> pooledobjs = new Queue<GameObject>();
            for(int i=0;i<Pool.Size;i++)
            {
                GameObject Obj = Instantiate(Pool.Obj);
                Obj.SetActive(false);
                pooledobjs.Enqueue(Obj);
            }
            galaxyPool.Add(Pool.Name, pooledobjs);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 posistion,Quaternion rotation)
    {
        if(!galaxyPool.ContainsKey(tag))
        {
            Debug.LogError("pool tag Not Found");
            return null;
        }
        GameObject objToSpawn = galaxyPool[tag].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = posistion;
        objToSpawn.transform.rotation = rotation;
        galaxyPool[tag].Enqueue(objToSpawn);
        return objToSpawn;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    [System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    
    public static PoolManager Instance;

    private void Awake() {
        Instance = this;
    }

    public List<Pool> pools;

    public Dictionary<string, Queue<GameObject>> poolDictionary;
   
    void Start() {
       
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
       
        foreach (Pool pool in pools) {
            
            Queue<GameObject> objectPool = new Queue<GameObject>();
            
            if(pool.prefab != null){
                
                for(int i = 0; i < pool.size; i++) {
                    GameObject obj = Instantiate(pool.prefab, transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }
                
                poolDictionary.Add(pool.tag, objectPool);
            }

        }
        

    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation) {
        if(!poolDictionary.ContainsKey(tag)){
            return null;
        }

        GameObject obj = poolDictionary[tag].Dequeue();
        
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        IPooledObject pooledObject = obj.GetComponent<IPooledObject>();
        if(pooledObject != null) {
            pooledObject.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(obj);

        return obj;

    }
}

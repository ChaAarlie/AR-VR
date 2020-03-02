using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Spawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab; 
    [SerializeField] private GameObject player;
    private bool spawned;
    private float timer = 180f;
    public List<GameObject> fantoms;
    
    // Start is called before the first frame update
    void Start()
    {
        fantoms = new List<GameObject>();
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if (timer <= Time.deltaTime){
            fantoms.Clear();
        }
        if ((Vector3.Distance(transform.position, player.transform.position) <= 6 ) && (spawned == false)) {
            spawned = true;
            GameObject instantiatedEnemy = Instantiate(prefab,
                                                        Random.insideUnitSphere + transform.position,  // area of spawn 
                                                        transform.rotation)
                as GameObject;
            fantoms.Add(instantiatedEnemy);
        }
    }
}

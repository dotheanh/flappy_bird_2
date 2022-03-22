using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float queueTime = 1.5f;
    private float time = 0f;
    public GameObject obstacle;
    public bool started = false;

    public float height;

    private void Start()
    {
	    time = queueTime;
    }
    public void StartSpawn()
    {
        started = true;
    }
    public void StopSpawn()
    {
        started = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started) return;

        if(time > queueTime)
        {
            GameObject go = Instantiate(obstacle);
            go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

            time = 0;

            Destroy(go, 10);
        }

        time += Time.deltaTime;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBreadCo : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject[] thingsToHit;
    List<GameObject> realStuff = new List<GameObject>();

    float timeSinceSpawn = 0f;
    float nextSpawnTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = 3f + Random.Range(0f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            var vel = rb.velocity;
            vel.y = Mathf.Max(0, vel.x);
            vel.y += 3f;
            rb.velocity = vel;
        }

        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn > nextSpawnTime)
        {
            nextSpawnTime = 3f + Random.Range(0f, 3f);
            timeSinceSpawn = 0f;
            realStuff.Add(Instantiate(thingsToHit[Random.Range(0, thingsToHit.Length)]));
        }
        foreach(GameObject x in realStuff)
        {
            var pos = x.transform.position;
            pos.x -= 0.01f;
            x.transform.position = pos;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlappyBreadCo : MonoBehaviour
{
    public GameObject bread;
    public GameObject[] thingsToHit;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI gameOverText;
    List<GameObject> realStuff = new List<GameObject>();
    List<GameObject> givePoints = new List<GameObject>();
    int points = 0;
    int life = 100;
    bool gameOver = false;
    
    float timeSinceSpawn = 0f;
    float nextSpawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
            return;

        if (Input.GetButtonDown("Jump"))
        {
            var rb = bread.GetComponent<Rigidbody>();
            var vel = rb.velocity;
            vel.y = Mathf.Max(0, vel.x);
            vel.y += 3f;
            rb.velocity = vel;
        }

        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn > nextSpawnTime)
        {
            nextSpawnTime = 2f + Random.Range(0f, 1f);
            timeSinceSpawn = 0f;
            var newObj = Instantiate(thingsToHit[Random.Range(0, thingsToHit.Length)]);
            realStuff.Add(newObj);
            givePoints.Add(newObj);
        }
        foreach(GameObject x in realStuff)
        {
            var pos = x.transform.position;
            pos.x -= 0.01f;
            x.transform.position = pos;
        }
        List<GameObject> removes = new List<GameObject>();
        foreach(var x in givePoints)
        {
            if(x.transform.position.x < -1f)
            {
                points += 1;
                removes.Add(x);
            }
        }
        foreach(var x in removes)
        {
            givePoints.Remove(x);
        }
        var pokes = bread.GetComponent<damageCounter>();
        life -= pokes.pokes * 15;
        pokes.pokes = 0;
        if (life < 0)
            life = 0;

        pointsText.SetText("BreadCo Points: " + points.ToString());
        lifeText.SetText("Loaf life: " + life.ToString());

        if (life < 1)
        {
            gameOver = true;
            gameOverText.gameObject.SetActive(true);
        }
    }
}

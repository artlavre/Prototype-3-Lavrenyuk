using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private Vector3 position = new Vector3(25, 0, 0);

    private PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>(); 
        InvokeRepeating("SpawnObstacle", 2f, Random.Range(2,4));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (!playerScript.gameOver)
        {
            int randObst = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[randObst], position, obstacles[randObst].transform.rotation);
        }
    }
}

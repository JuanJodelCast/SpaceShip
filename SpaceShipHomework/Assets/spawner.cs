using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject star;
    public GameObject tie;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("spawnMeteor");
        StartCoroutine("spawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnMeteor()
    {
        yield return new WaitForSeconds(3.0f);
        float randomPos = Random.Range(-4.0f, 4.0f);
        star.transform.position = new Vector3(this.transform.position.x, randomPos, this.transform.position.z);
        Instantiate(star);
        StartCoroutine("spawnMeteor");
    }

    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(5.0f);
        float randomPos = Random.Range(-4.0f, 4.0f);
        tie.transform.position = new Vector3(this.transform.position.x, randomPos, this.transform.position.z);
        Instantiate(tie);
        StartCoroutine("spawnEnemy");
    }
}
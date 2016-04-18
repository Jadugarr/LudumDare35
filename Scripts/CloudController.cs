using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CloudController : MonoBehaviour {

    public List<Sprite> backClouds;
    public List<Sprite> frontClouds;
    public GameObject prefabCloud;

    //
    public float spawnTimeMin, spawnTimeMax;
    public float cloudSpeedFrontMin, cloudSpeedFrontMax, cloudSpeedBackMin, cloudSpeedBackMax;
    public float spawnPoint;

    //
    private float spawnAcc = 0f;
    private float spawnTime;

    // Use this for initialization
    void Start () {
        spawnTime = CreateSpawnTime();
	}
	
	// Update is called once per frame
	void Update () {
        spawnAcc += Time.deltaTime;
        if(spawnAcc > spawnTime)
        {
            if (Random.Range(0, 2) > 0)
            {
                Vector2 spawnPos = new Vector2(this.transform.position.x, GetRandomYPos());
                GameObject cloud = (GameObject)Instantiate(prefabCloud, spawnPos, prefabCloud.transform.rotation);
                SpriteRenderer spriteRen = cloud.GetComponent < SpriteRenderer >();
                spriteRen.sprite = SetRandomSprite(frontClouds);
                CloudMoving cloudMovScript = cloud.GetComponent<CloudMoving>();
                cloudMovScript.velocity = Random.Range(cloudSpeedFrontMin, cloudSpeedFrontMax);
            } else
            {
                Vector2 spawnPos = new Vector2(this.transform.position.x, GetRandomYPos());
                GameObject cloud = (GameObject)Instantiate(prefabCloud, spawnPos, prefabCloud.transform.rotation);
                SpriteRenderer spriteRen = cloud.GetComponent<SpriteRenderer>();
                spriteRen.sprite = SetRandomSprite(backClouds);
                CloudMoving cloudMovScript = cloud.GetComponent<CloudMoving>();
                cloudMovScript.velocity = Random.Range(cloudSpeedBackMin, cloudSpeedBackMax);
            }
            spawnTime = CreateSpawnTime();
            spawnAcc = 0f;
        }
	}

    private float CreateSpawnTime()
    {
        return Random.Range(spawnTimeMin, spawnTimeMax);
    }

    private float GetRandomYPos()
    {
        return Random.Range(this.transform.position.y, this.transform.position.y + spawnPoint);
    }

    private Sprite SetRandomSprite(List<Sprite> spriteList)
    {
        return spriteList[Random.Range(0, spriteList.Count)];
    }

}

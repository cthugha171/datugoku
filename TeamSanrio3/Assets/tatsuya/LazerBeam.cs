﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBeam : MonoBehaviour
{
    [SerializeField] private GameObject burrel;
    [SerializeField] private GameObject senser;
    [SerializeField] private LineRenderer line;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Transform[] spawnpoint;
    [SerializeField] private int interval=240;
    [SerializeField] private int  appear=100;

    Vector3 hitPos;
    Vector3 tmpPos;

    float lazerDist=10.0f;
    float lazerStartDist=0.15f;
    float lineWidth=0.1f;

    int count = 0;
    int numberOfSpawns = 0;

    bool isHit = false;

    void Reset()
    {
        line.startWidth = lineWidth;
    }

    // Start is called before the first frame update
    void Start()
    {
        line.startWidth = lineWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        OnRay();
        SpawnEnemy();
    }

    void OnRay()
    {
        Vector3 direction = senser.transform.position - burrel.transform.position;
        RaycastHit hit;
        //発射位置から終点まで
        Ray ray = new Ray(burrel.transform.position, direction);
        line.SetPosition(0, burrel.transform.position);

        if (Physics.Raycast(ray, out hit, lazerDist))
        {
            hitPos = hit.point;
            line.SetPosition(1, hitPos);
            //Debug.Log(hitPos);
            //Debug.Log(isHit);
            if (hit.collider.tag=="Player")
            {
                isHit = true;
               //Debug.Log(isHit);
            }
        }
        else
        {
            line.SetPosition(1, senser.transform.position);
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.black, 5);
    }

    void SpawnEnemy()
    {
        count++;

        if (isHit == true)
        {
            if (count % interval == 0)
            {
                for (int i = 0; i < spawnpoint.Length; i++)
                {
                    Instantiate(Enemy, new Vector3(spawnpoint[i].position.x, spawnpoint[i].position.y, spawnpoint[i].position.z), Quaternion.identity);
                    numberOfSpawns++;
                }
            }
            Debug.Log(count % 60);
            if (numberOfSpawns == appear)
            {
                isHit = false;
               //Debug.Log(count / 60 == second);
            }
        }
        
    }
}

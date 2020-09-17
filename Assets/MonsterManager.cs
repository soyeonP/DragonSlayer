using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public List<Transform> spawnPos = new List<Transform>();

    public GameObject[] monsterPrefabs;
    public int monsterCount;

    public GameObject monsterPrefab;

    public float createTime = 5000;

    public int maxMonster = 10;
    private int DeadMonsterCount = 0;
    public bool isGameOver = false;

    void Start()
    {
        MakeSpawnPos();
    }

    void MakeSpawnPos()
    {
        foreach(Transform pos in transform)
        {
            if(pos.tag == "Respawn")
            {
                spawnPos.Add(pos);
            }
        }
        if(maxMonster > spawnPos.Count)
        {
            maxMonster = spawnPos.Count;
        }

        monsterPrefabs = new GameObject[maxMonster];
        MakeMonsters();
    }

    void MakeMonsters()
    {
        for(int i=0; i < maxMonster; i++)
        {
            GameObject monster = Instantiate(monsterPrefab, spawnPos[i].position, Quaternion.identity) as GameObject;

            monster.GetComponent<MonsterStat>().setRespawnObj(gameObject, i, spawnPos[i].position);

            monster.SetActive(false);

            monsterPrefabs[i] = monster;

        }
        monsterCount = monsterPrefabs.Length;
        Debug.Log(monsterCount);
    }

    void SpawnMonster()
    {
        for(int i=0; i < monsterPrefabs.Length; i++)
        {
            monsterPrefabs[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            SpawnMonster();
        }
    }

    
    public void RemoveMonster(int spawnID)
    {
        DeadMonsterCount++;
        monsterPrefabs[spawnID].SetActive(false);

        print(spawnID + "is dead");
        if(DeadMonsterCount > 1 )
        {
            print("생성!");
            StartCoroutine(InitMonsters());
            DeadMonsterCount = 0;
        }

    }

    IEnumerator InitMonsters()
    {
        yield return new WaitForSeconds(createTime);

        SpawnMonster();
        GetComponent<SphereCollider>().enabled = true;
    }


}

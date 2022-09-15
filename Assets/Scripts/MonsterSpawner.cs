using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject[] monsterReferences;

    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, monsterReferences.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReferences[randomIndex]);

            if (randomSide == 0) {
                // left side
                spawnedMonster.transform.position = leftPos.position;

                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
            } else {
                // right side
                spawnedMonster.transform.position = rightPos.position;

                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);

                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}

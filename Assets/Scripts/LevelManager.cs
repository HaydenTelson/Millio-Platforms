using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LevelManager : MonoBehaviour
{
    public CinemachineVirtualCamera cam;

    public static LevelManager instance;
    public Transform respawnPoint;

    public GameObject playerPrefab;

    public GameObject enemyPrefab;

    public GameObject berryPrefab;

    public GameObject[] enemyRespawnPoints;

    public GameObject[] aliveEnemies;
    public GameObject[] berryRespawnPoints;

    public GameObject[] aliveBerries;
    
    public GameObject alivePlayer;

    private void Awake()
    {
        instance = this;
        // GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        // cam.Follow = player.transform;

        // if(enemyRespawnPoints == null)
        // {
        //     enemyRespawnPoints = GameObject.FindGameObjectsWithTag("EnemyRespawnPoint");
        // }

        // foreach(GameObject sp in enemyRespawnPoints)
        // {
        //     Instantiate(enemyPrefab, sp.transform.position, Quaternion.identity);
        // }

        resetPlayer();
        resetEnemies();
        resetBerries();
    }

    public void Respawn()
    {
        resetPlayer();
        resetEnemies();
        resetBerries();
    }

    private void resetPlayer()
    {
        alivePlayer = GameObject.FindGameObjectWithTag("Player");
        Destroy(alivePlayer);

        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
    }

    private void resetEnemies()
    {

        aliveEnemies = GameObject.FindGameObjectsWithTag("FrogEnemy");

        foreach(GameObject enemy in aliveEnemies)
        {
            Destroy(enemy);
        }

        if(enemyRespawnPoints == null)
        {
            enemyRespawnPoints = GameObject.FindGameObjectsWithTag("EnemyRespawnPoint");
        }

        foreach(GameObject sp in enemyRespawnPoints)
        {
            Instantiate(enemyPrefab, sp.transform.position, Quaternion.identity);
        }
    }

    private void resetBerries()
    {
        aliveBerries = GameObject.FindGameObjectsWithTag("Berry");


        foreach(GameObject berry in aliveBerries)
        {
            Destroy(berry);
        }

        if(berryRespawnPoints == null)
        {
            berryRespawnPoints = GameObject.FindGameObjectsWithTag("BerryRespawnPoint");
        }

        foreach(GameObject sp in berryRespawnPoints)
        {
            Instantiate(berryPrefab, sp.transform.position, Quaternion.identity);
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float startHealth = 5;
    [SerializeField] int scorePerAsteroid = 100;
    SphereCollider coll;
    public int Score { get; set; }
    void Start()
    {
        Score = 0;
        coll = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Transform GetPlayerPosition() {
        return player.transform;
    }
    public float GetPlayerHealth() {
        return player.GetComponent<PlayerMovement>().Health;
    }

    public static IEnumerator timerDelete(float time, GameObject objectToDelete)
    {
        yield return new WaitForSeconds(time);
        Destroy(objectToDelete);
    }
    public void IncreaseScore(int scoreToAdd)
    {
        Score += scoreToAdd;
    }
    public int GetScorePerAsteroid()
    {
        return scorePerAsteroid;
    }
    public float GetStartHealth()
    {
        return startHealth;
    }
}

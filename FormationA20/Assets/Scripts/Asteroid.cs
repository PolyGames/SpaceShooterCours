using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Transform Attributes")]
    [SerializeField] float MIN_SCALE = 4f;
    [SerializeField] float MAX_SCALE = 4.5f;
    [SerializeField] int ROTATION_ANGLE = 45;
    [SerializeField] float MOVEMENT_RANGE = 0.4f;
    [Header("Trigger Transform Modifications")]
    [SerializeField] bool enableRotation = true;
    [SerializeField] bool enableTranslation = true;

    Vector3 rotation;
    Vector3 translation;

    Rigidbody asteroidRigidbody;

    [SerializeField] GameObject explosionEffect;

    public bool IsHit { get; set; }
    GameRules rules;
    void Start()
    {
        rules = GameObject.FindGameObjectWithTag("Rules").GetComponent<GameRules>();
        asteroidRigidbody = gameObject.GetComponent<Rigidbody>();
        transform.localScale = new Vector3(Random.Range(MIN_SCALE, MAX_SCALE), 
                                           Random.Range(MIN_SCALE, MAX_SCALE), 
                                           Random.Range(MIN_SCALE, MAX_SCALE));
        if (enableRotation)
            rotation = new Vector3(Random.Range(-ROTATION_ANGLE, ROTATION_ANGLE),
                                   Random.Range(-ROTATION_ANGLE, ROTATION_ANGLE),
                                   Random.Range(-ROTATION_ANGLE, ROTATION_ANGLE));
        if (enableTranslation)
        {
            translation = new Vector3(Random.Range(-MOVEMENT_RANGE, MOVEMENT_RANGE),
                          Random.Range(-MOVEMENT_RANGE, MOVEMENT_RANGE),
                          Random.Range(-MOVEMENT_RANGE, MOVEMENT_RANGE));
            asteroidRigidbody.velocity = translation;
        }
    }
    
    void Update()
    {
        if (enableRotation)
            transform.Rotate(rotation * Time.deltaTime);
    }

    public void Explode()
    {
        StartCoroutine(timedExplosion(0.7f, gameObject));
    }
    IEnumerator timedExplosion(float time, GameObject objectToDelete)
    {
        yield return new WaitForSeconds(time);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(objectToDelete);
    }
    //void OnTriggerEnter()
    //{
    //    Destroy(gameObject); 
    //}
}

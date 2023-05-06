using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform location;
    private NavMeshAgent agent;
    private float maxHealth = 100;
    private float health;
    public Slider slider;
    public GameObject slidergameObject;
    private Rigidbody rb;
    public static float randomx, randomz;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        print(health + "olu�t");
        agent = GetComponent<NavMeshAgent>();
        location = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = location.position;

        if(health < maxHealth)
        {
            slidergameObject.SetActive(true);
        }
        else if(health > maxHealth)
        {
            health = maxHealth;
        }
        float slidervalue = health / maxHealth;
        slider.value = slidervalue;
    }
    private void OnTriggerEnter(Collider other)
    {
        agent.isStopped = true;
    }
    private void OnTriggerExit(Collider other)
    {
        agent.isStopped = false;
    }
    public void EnemyDamage(Collider other)
    {
        print("hasar");
        if(other.tag == "Enemy")
        {
            health = health - 50;
            if (health == 0)
            {
                RandomTransform();
                health = 100;
                print(health);
            }
        }
    }
    public void RandomTransform()
    {
        Vector3 vector3 = GameObject.FindGameObjectWithTag("Player").transform.position;
        RandomHesap();
        float distance = Vector3.Distance(transform.position + new Vector3(randomx, 0, randomz), vector3);
        while (distance <= 4.5f)
        {
            RandomHesap();
            distance = Vector3.Distance(transform.position + new Vector3(randomx, 0, randomz), vector3);
        }
        print(new Vector3(randomx, 0, randomz));
        transform.position = new Vector3(randomx, 0, randomz); 
    }
    private void RandomHesap()
    {
        randomx = Random.Range(-4, 4);
        randomz = Random.Range(-4, 4);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIDriver : MonoBehaviour
{
    [SerializeField] float updateTime;

    float _time;
    NavMeshAgent _agent;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");

        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if(_time > updateTime) 
        {
            _agent.destination = player.transform.position;
            _time = 0;
        }
    }
}

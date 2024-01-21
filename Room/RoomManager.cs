using InteractionSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] int enemyNumber;
    [SerializeField] InteractableItem itemCallback;

    private void Awake()
    {
        EventsManager.OnEnemyDeath += TakeOutAnEnemy;
    }

    public void IncreaseEnemyNumber(int value)
    {
        enemyNumber += value;
    }

    void TakeOutAnEnemy()
    {
        enemyNumber--;
        if(enemyNumber == 0)
        {
            enemyNumber = 0;
            EventsManager.OnRoomCleared?.Invoke();
            Debug.Log("Finishhhhhhhhhhh");
        }
    }
}

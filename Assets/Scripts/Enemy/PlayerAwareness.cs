using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{

    public Vector2 directionToPlayer { get; private set;}
    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerControl>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayer = _player.position - transform.position;
        directionToPlayer = enemyToPlayer.normalized;
    }
}

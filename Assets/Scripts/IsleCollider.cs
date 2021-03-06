﻿using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class IsleCollider : MonoBehaviour
{

    private string _text;
    public int Gold;

    private Rigidbody2D _rigidbody2D;
    //private bool showText = false, someRandomCondition = true;
    public float Goldcd = 3f;
    private PlayerController _playerController;


    // Use this for initialization
    void Start()
    {
        Gold = 10;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        InvokeRepeating("RegenGold", Goldcd, Goldcd);        
    }

    void RegenGold()
    {
        if (Gold >= 10)
        {
            return;
        }
        Gold += 2;
    }

    void ResetGold()
    {
        Gold = 0;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _playerController.AddGold(Gold);
            ResetGold();
        }
        if (col.gameObject.tag == "Cannonball")
        {
            if (col.gameObject.GetComponent<BallController>().Parent == _playerController)
            {
                _playerController.AddGold(Gold);
                ResetGold();
            }
        }
    }
}

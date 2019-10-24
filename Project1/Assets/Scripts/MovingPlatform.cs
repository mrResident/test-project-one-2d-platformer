﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Alexandrov Alexander Alexandrovich
Date: 25/10/2019

Script that implement moving platform
*/
public class MovingPlatform : MonoBehaviour {

    public Vector3 finishPos = Vector3.zero;
    public float speed = 0.5f;

    private Vector3 _startPos;
    private float _trackPercent = 0;
    private int _direction = 1;

    // Start is called before the first frame update
    void Start() {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        _trackPercent += _direction * speed * Time.deltaTime;
        float x = (finishPos.x - _startPos.x) * _trackPercent + _startPos.x;
        float y = (finishPos.y - _startPos.y) * _trackPercent + _startPos.y;
        transform.position = new Vector3(x, y, _startPos.z);

        if ((_direction == 1 && _trackPercent > 1f) || (_direction == -1 && _trackPercent < 0f)) {
            _direction *= -1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFinger : MonoBehaviour {

    private Vector3 pos;

    private void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 5));

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}

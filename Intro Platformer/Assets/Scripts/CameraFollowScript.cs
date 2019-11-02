using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollowScript : MonoBehaviour {
    public GameObject yellow_square;
 
    public float speed = 2.0f;
    
    void FixedUpdate()
	{
        float interpolation = speed * Time.deltaTime;
        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, yellow_square.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, yellow_square.transform.position.x, interpolation);
        
        this.transform.position = position;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Offset;
    private float Position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Position > -1) {
            Position = Position - 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Position < 1)
        {
            Position = Position + 1;
        }
        //transform.position = new Vector3(Position*Offset, 0, 0);
        transform.position = Vector3.MoveTowards(transform.position,  new Vector3(Position * Offset, 0, 0), Time.deltaTime*10);
    }
}

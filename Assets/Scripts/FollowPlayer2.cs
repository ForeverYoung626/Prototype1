using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer2 : MonoBehaviour
{
    //    public GameObject player;
    //    private Vector3 offset = new Vector3(0, 4, 1.5f);
    //
    // Start is called before the first frame update
    //    void Start()
    //  {

    //}

    // Update is called once per frame
    //void LateUpdate()
    //{
    //        transform.position = player.transform.position + offset;
    //        transform.rotation = Quaternion.Euler(new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y, player.transform.eulerAngles.z));
    //    }

    public Transform target;


    public float distanceUp = 15f;
    public float distanceAway = 10f;
    public float smooth = 2f;//
    public float camDepthSmooth = 5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 
        if ((Input.mouseScrollDelta.y < 0 && Camera.main.fieldOfView >= 3) || Input.mouseScrollDelta.y > 0 && Camera.main.fieldOfView <= 80)
        {
            Camera.main.fieldOfView += Input.mouseScrollDelta.y * camDepthSmooth * Time.deltaTime;
        }

    }

    void LateUpdate()
    {
        //
        Vector3 disPos = target.position + Vector3.up * distanceUp - target.forward * distanceAway;
        transform.position = Vector3.Lerp(transform.position, disPos, Time.deltaTime * smooth);
        //
        transform.LookAt(target.position);
    }

}

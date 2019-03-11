using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothTimeX, smoothTimeY;
    public Vector2 velocity;
    public GameObject player;

    public Vector2 minpos, maxpos;
    public bool bound;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posX = player.transform.position.x;
        //float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);

        if (bound)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minpos.x, maxpos.x),
                Mathf.Clamp(transform.position.y, minpos.y, maxpos.y),
                Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z));
        }
    }
}

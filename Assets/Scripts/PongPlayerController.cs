using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public KeyCode key_up = KeyCode.W;
    public KeyCode key_down = KeyCode.S;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key_up))
        {
            if (this.transform.position.y < 4)
                this.transform.Translate(
                    Vector3.up * speed * Time.deltaTime);
            else
                this.transform.position.Set(
                    this.transform.position.x,
                    4f,
                    this.transform.position.z);
        }
        else if (Input.GetKey(key_down))
        {
            if (this.transform.position.y > -4)
                this.transform.Translate(
                    Vector3.down * speed * Time.deltaTime);
            else
                this.transform.position.Set(
                    this.transform.position.x,
                    -4f,
                    this.transform.position.z);
        }
    }
}

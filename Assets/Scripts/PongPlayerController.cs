using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public KeyCode key_up = KeyCode.W;
    public KeyCode key_down = KeyCode.S;
    public int player_number = 1;
    public GameObject follow_as_cpu;
    public Options options;

    bool is_cpu_controlled = false;

    // Start is called before the first frame update
    void Start()
    {
        is_cpu_controlled = options.GetSelectedMode() == Mode.PVCPU;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_cpu_controlled && player_number == 2)
        {
            if (follow_as_cpu.transform.position.y < transform.position.y - 1)
            {
                transform.Translate(
                    Vector3.down * (speed * 2) * Time.deltaTime);
            }
            else if (follow_as_cpu.transform.position.y > transform.position.y + 1)
            {
                transform.Translate(
                    Vector3.up * (speed * 2) * Time.deltaTime);
            }

            return;
        }

        if (Input.GetKey(key_up))
        {
            if (transform.position.y < 4)
                transform.Translate(
                    Vector3.up * speed * Time.deltaTime);
            else
                transform.position.Set(
                    transform.position.x,
                    4f,
                    transform.position.z);
        }
        else if (Input.GetKey(key_down))
        {
            if (transform.position.y > -4)
                transform.Translate(
                    Vector3.down * speed * Time.deltaTime);
            else
                transform.position.Set(
                    transform.position.x,
                    -4f,
                    transform.position.z);
        }
    }
}

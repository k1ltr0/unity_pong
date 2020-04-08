using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public PointCounter counter;
    public CameraShaker shaker;
    public Rigidbody body;
    public float speed = 5f;
    public SphereSoundController sphere_sound_controller;

    private Vector3 direction = Vector3.zero;
    private TrailRenderer trail;

    // Start is called before the first frame update
    void Start()
    {
        this.body = GetComponent<Rigidbody>();
        this.trail = GetComponent<TrailRenderer>();
        this.sphere_sound_controller = GetComponent<SphereSoundController>();
        this.Trigger();
    }

    private void Trigger()
    {
        // reset trail renderer
        this.trail.emitting = false;
        this.trail.emitting = true;

        // set on zero
        transform.position = Vector3.zero;

        // add force
        float random_number = Random.Range(0, 10);

        if (random_number <= 5)
            this.direction = Vector3.right;
        else
            this.direction = Vector3.left;

        StartCoroutine(shaker.Shake(.5f, .1f));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        float new_y = (
            collision.gameObject.transform.position.y
                - this.transform.position.y
            ) / collision.gameObject.transform.localScale.y;
        normal.Set(normal.x, -new_y, normal.z);

        this.direction = Vector3.Reflect(
            this.direction, normal);
        this.direction.Set(
            this.direction.x < 0 ? -1 : 1, this.direction.y, this.direction.z);

        this.sphere_sound_controller.PlayBounceSound();
        StartCoroutine(shaker.Shake(.2f, .04f));
    }

    private void FixedUpdate()
    {
        // check points
        if (transform.position.x < -9.0f)
        {
            this.sphere_sound_controller.PlayPointSound();
            this.Trigger();
            this.counter.AddPoint(NumPlayer.PLAYER_TWO);
        }

        if (transform.position.x > 9.0f)
        {
            this.sphere_sound_controller.PlayPointSound();
            this.Trigger();
            this.counter.AddPoint(NumPlayer.PLAYER_ONE);
        }

        // move
        this.transform.position += this.direction
            * this.speed
            * Time.fixedDeltaTime;

        // wall bounce
        if (this.transform.position.y < -5.0f && this.direction.y < 0.0f)
        {
            this.direction = Vector3.Reflect(this.direction, Vector3.up);
            this.sphere_sound_controller.PlayBounceSound();
            StartCoroutine(shaker.Shake(.2f, .04f));
        }

        if (this.transform.position.y > 5.0f && this.direction.y > 0.0f)
        {
            this.direction = Vector3.Reflect(this.direction, Vector3.down);
            this.sphere_sound_controller.PlayBounceSound();
            StartCoroutine(shaker.Shake(.2f, .04f));
        }
    }
}

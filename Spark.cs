using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    public float speed;
    public Vector2 centralTarget;
    // Start is called before the first frame update
    void Start()
    {
        Bounce();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.CompareTag("Bounds"))
            Bounce();
    }

    void Bounce()
    {
        Vector3 direction = new Vector3(Random.Range(-centralTarget.x, centralTarget.x), transform.position.y, Random.Range(-centralTarget.y, centralTarget.y));
        transform.LookAt(direction, Vector3.up);
    }
}

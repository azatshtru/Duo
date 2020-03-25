using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform target;
    public Vector2 rangeMinMax;
    public float enemySpeed;

    EnemyShooting enemyShooting;
    Rigidbody rb;
    Animator anim;

    float range;

    // Start is called before the first frame update
    void Start()
    {
        enemyShooting = GetComponent<EnemyShooting>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        enemyShooting.UpdateTarget(target);

        range = Random.Range(rangeMinMax.x, rangeMinMax.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) > range)
        {
            rb.MovePosition(rb.position + (transform.right * enemySpeed * Time.deltaTime));
            enemyShooting.DeactivateAim();
            Animate(true);
        }
        else
        {
            enemyShooting.ActivateAim();
            Animate(false);
        }
    }

    void Animate(bool isRunning)
    {
        anim.SetBool("IsRunning", isRunning);
    }
}

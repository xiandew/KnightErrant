using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileController : MonoBehaviour {

    Rigidbody projectileBody;
    public float fireRange;
    public int damageAmount = 50;
    public string tagToDamage;
    private bool onHit = false;

    private Vector3 startPos;

    private float lifeTimer = 60f;
    private float timer;

    void Start() {
        projectileBody = GetComponent<Rigidbody>();
        this.transform.rotation = Quaternion.LookRotation(projectileBody.velocity);
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer >= lifeTimer) {
            Destroy(gameObject);
        }

        if (!onHit) {
            this.transform.rotation = Quaternion.LookRotation(projectileBody.velocity);
        }

        if (Vector3.Distance(this.transform.position, startPos) > fireRange) {
            Destroy(gameObject);
        }

	}

    // Handle collisions
    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == tagToDamage)
        {
            // Damage object with relevant tag
            HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
            healthManager.ApplyDamage(damageAmount);
        }

        // Destroy self
        Destroy(this.gameObject);
    }
}

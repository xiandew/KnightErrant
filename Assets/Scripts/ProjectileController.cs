using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileController : MonoBehaviour {

    Rigidbody projectileBody;
    public float fireRange;
    public int damageAmount = 50;
    public string tagToDamage;

    void Start() {
        projectileBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        this.transform.rotation = Quaternion.LookRotation(projectileBody.velocity);
	}

    // Handle collisions
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagToDamage)
        {
            // Damage object with relevant tag
            HealthManager healthManager = col.gameObject.GetComponent<HealthManager>();
            healthManager.ApplyDamage(damageAmount);

            // Destroy self
            Destroy(this.gameObject);
        }
    }
}

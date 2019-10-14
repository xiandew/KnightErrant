using System;
using UnityEngine;

public class NPCWeaponController : MonoBehaviour {
    public ProjectileController projectilePrefab;
    public float shootForce;

    public void Shoot(GameObject player) {
        gameObject.transform.LookAt(player.transform);
        ProjectileController projectile = Instantiate<ProjectileController>(
            projectilePrefab,
            gameObject.transform.position + new Vector3(0, (float)Math.Ceiling(gameObject.GetComponent<BoxCollider>().size.y), 0),
            Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = (player.transform.position - projectile.transform.position).normalized * shootForce;
    }
}

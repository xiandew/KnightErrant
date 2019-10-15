using System;
using UnityEngine;

public class NPCWeaponController : MonoBehaviour {
    public ProjectileController projectilePrefab;
    public float shootForce;

    public void Shoot(GameObject player) {
        transform.LookAt(player.transform);
        ProjectileController projectile = Instantiate<ProjectileController>(
            projectilePrefab,
            transform.Find("SwordSpawn").transform.position,
            Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        Vector3 direction = (player.transform.position - projectile.transform.position).normalized;
        rb.velocity = direction * shootForce;
    }
}

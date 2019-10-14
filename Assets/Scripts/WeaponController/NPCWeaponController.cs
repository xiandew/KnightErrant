using System.Collections;
using UnityEngine;

public class NPCWeaponController : MonoBehaviour {
    public ProjectileController projectilePrefab;
    public float shootForce;

    public void Shoot(GameObject player) {
        gameObject.transform.LookAt(player.transform);
        ProjectileController projectile = Instantiate<ProjectileController>(projectilePrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * shootForce;
    }
}

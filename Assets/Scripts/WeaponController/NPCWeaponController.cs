using UnityEngine;

public class NPCWeaponController : MonoBehaviour {

    public ProjectileController projectilePrefab;
    public float shootForce;

    public void Shoot(Vector3 dest) {

        ProjectileController projectile = Instantiate<ProjectileController>(projectilePrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 20;
    }
}

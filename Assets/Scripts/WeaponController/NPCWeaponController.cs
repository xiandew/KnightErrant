using UnityEngine;

public class NPCWeaponController : MonoBehaviour {

    public ProjectileController projectilePrefab;
    public GameObject npc;
    public Transform arrowSpwan;
    public float shootForce;
    private float timer = 0;

    void Update() {
        timer += Time.deltaTime;
        if (timer < 0.25) {
            Shoot();
        }
    }

    void Shoot() {
        ProjectileController projectile = Instantiate<ProjectileController>(projectilePrefab, npc.transform.position, projectilePrefab.transform.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        // rb.velocity = npc.transform.forward * Random.Range(10, shootForce);
    }
}
using UnityEngine;

public class RangedWeaponController : MonoBehaviour {

    public ProjectileController projectilePrefab;
    public Camera playerCam;
    public Transform arrowSpawn;
    public float shootForce;

    private Animator animator;

    void Start() {
        // animator = GetComponent<Animator>();
    }

    void Update() {
        // Fire the projectile when the left of the mouse is clicked
        if (Input.GetButtonDown("Fire1")) {
            
            Shoot();

        }
        print(arrowSpawn.position);
    }

    void Shoot() {
        // animator.SetTrigger("fire");
        ProjectileController projectile = Instantiate(projectilePrefab, arrowSpawn.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = playerCam.transform.forward * shootForce;
    }

}
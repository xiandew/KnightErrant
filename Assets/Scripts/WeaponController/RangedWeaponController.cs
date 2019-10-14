using UnityEngine;

public class RangedWeaponController : MonoBehaviour {

    public ProjectileController projectilePrefab;
    public Camera playerCam;
    public Transform arrowSpwan;
    public float shootForce;

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        // Fire the projectile when the left of the mouse is clicked
        if (Input.GetButtonDown("Fire1")) {
            
            Shoot();

        }
    }

    void Shoot() {
        // animator.SetTrigger("fire");
        ProjectileController projectile = Instantiate(projectilePrefab, arrowSpwan.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = playerCam.transform.forward * shootForce;

    }

}
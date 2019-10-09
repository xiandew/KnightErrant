using UnityEngine;
using System.Collections;

public class RangedWeaponController : MonoBehaviour {

    public ProjectileController projectilePrefab;

    void Start() {

    }

    void Update() {
        // Fire the projectile when the left of the mouse is clicked
        if (Input.GetMouseButtonDown(0)) {

            // Get the mouse position on screen
            Vector2 mouseScreenPos = Input.mousePosition;

            // Create the projectile
            ProjectileController projectile = Instantiate<ProjectileController>(projectilePrefab);
            projectile.transform.position = this.transform.position;

        }
    }

}
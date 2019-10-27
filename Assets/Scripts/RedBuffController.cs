using UnityEngine;
using System.Collections;

public class RedBuffController : MonoBehaviour {
    
    public float spinSpeed;
        	
	// Update is called once per frame
	void Update () {
        this.transform.localRotation *= Quaternion.AngleAxis(Time.deltaTime * spinSpeed, Vector3.up);
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			HealthManager hm = col.gameObject.GetComponent<HealthManager>();
			hm.SetCurrHealth(hm.GetCurrHealth() + 20);

			Destroy(gameObject);
		}
	}
}

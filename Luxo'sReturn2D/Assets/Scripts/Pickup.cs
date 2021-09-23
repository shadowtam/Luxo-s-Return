using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuxosReturn;

public class Pickup : MonoBehaviour {

    public LuxosReturn.PickupType pickupType;
    PickupHandler pickupHandler;
    private void Start() {
        pickupHandler = PickupHandler.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            pickupHandler.AddPickup(pickupType);
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusIncrease : Projectile {
    
    [SerializeField] internal CircleCollider2D col;
    [SerializeField] float incRate;
    [SerializeField] internal int lBounces, lBounceMax;
    [SerializeField] LineRenderer lr;

    // Start is called before the first frame update
    void Start() {
        // col = GetComponent<CircleCollider2D>();
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        col.radius += incRate;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy" && !(other.gameObject.GetComponent<Hit>() != null)){
            other.gameObject.AddComponent<Hit>();
            if(lBounces <= lBounceMax) {
                col.radius = 0;
                lr.enabled =true;
                lr.SetPositions(new Vector3[]{transform.position, other.transform.position});

                transform.position = other.transform.position;
                lBounces++;
                if(lBounces > lBounceMax) {
                    this.gameObject.SetActive(false);
                }
                Damage(other);
            } else {
                col.radius = 0;
                this.gameObject.SetActive(false);
            }
            
        }
    }



}

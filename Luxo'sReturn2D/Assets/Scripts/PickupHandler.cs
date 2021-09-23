using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuxosReturn;
using UnityEngine.UI;
using TMPro;

public class PickupHandler : MonoBehaviour {

    [SerializeField] Button[] pickupBtn;
    [SerializeField] TMP_Text[] pickupTxt;
    [SerializeField] int lCount, aCount, cCount = 0;
    [SerializeField] bool gravity, foresight, kobold = false;
    [SerializeField] Attacks playerAttacks;


    public static PickupHandler Instance;
    private void Awake() {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start() {
        foreach(Button btn in pickupBtn) {
            btn.interactable = false;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
    

    internal void AddPickup(PickupType pickUp) {
        if(pickUp == PickupType.LIGHTNING) {
            lCount++;
            pickupBtn[0].interactable = true;
            pickupTxt[0].text = "" + lCount;
        } else if(pickUp == PickupType.ACID) {
            aCount++;
            pickupBtn[1].interactable = true;
            pickupTxt[1].text = "" + aCount;
        } else if(pickUp == PickupType.COLD) {
            cCount++;
            pickupBtn[2].interactable = true;
            pickupTxt[2].text = "" + cCount;
        } else if(pickUp == PickupType.GRAVITY) {
            gravity = true;
            pickupBtn[3].interactable = true;
        } else if(pickUp == PickupType.FORESIGHT) {
            foresight = true;
            pickupBtn[4].interactable = true;
        } else if(pickUp == PickupType.KOBOLD) {
            kobold = true;
            pickupBtn[5].interactable = true;
        }
    }

    public void UsePickup(string typeName) {
        switch(typeName) {
            case "LIGHTNING":
                lCount--;
                if(lCount <=0) {
                    lCount = 0;
                    pickupBtn[0].interactable = false;
                }
                pickupTxt[0].text = "" + lCount;
                playerAttacks.activateSA(PickupType.LIGHTNING);
            return;

            case "ACID":
                aCount--;
                if(aCount <=0) {
                    aCount = 0;
                    pickupBtn[1].interactable = false;
                }
                pickupTxt[1].text = "" + aCount;
                playerAttacks.activateSA(PickupType.COLD);
            return;

            case "COLD":
                cCount--;
                if(cCount <=0) {
                    cCount = 0;
                    pickupBtn[2].interactable = false;
                }
                pickupTxt[2].text = "" + cCount;
                playerAttacks.activateSA(PickupType.COLD);
            return;

            default:
            return;
        }
    }
}

namespace LuxosReturn {
    public enum PickupType {
        LIGHTNING, ACID, COLD, GRAVITY, FORESIGHT, KOBOLD
    }
    internal class LookAt {
        internal static void look(Rigidbody2D rb, Vector2 target) {
            Vector2 lookDir = target - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon {

    private Animator animator;
    public List<BaseStat> Stats { get; set; }

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void PerformAttack() {
        animator.SetTrigger("BaseAttack");
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Enemy") {
            collider.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
        }
    }
}

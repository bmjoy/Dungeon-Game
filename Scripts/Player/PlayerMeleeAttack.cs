using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] AudioSource _swordSound;
    [SerializeField] ParticleSystem _swordSlashFX;

    bool _isAttacking = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && _isAttacking)
        {
            gameObject.GetComponentInParent<Transform>().LookAt(other.transform);
            GetComponentInParent<Animator>().SetTrigger("UseSword");
            _swordSound.Play();
            Invoke("PlaySwordFX", 0.3f);
        }          
    }

    public void StopAttack() => _isAttacking = false;

    void PlaySwordFX() => _swordSlashFX.Play();
}

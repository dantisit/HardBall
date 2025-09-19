using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public float damage;
    public float DamageDeley = 0.5f;
    public PlayerHealth health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health.Damage(damage);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<DestroyableObjects>().Hits();
            StartCoroutine(TimelyInvulnerability(other.GetComponent<DestroyableObjects>()) );
            Debug.Log(other.GetComponent<DestroyableObjects>().IsIndestructible);
        }
    }

    private IEnumerator TimelyInvulnerability(DestroyableObjects invulnerability)
    {
        invulnerability.IsIndestructible = true;
        yield return new WaitForSeconds(DamageDeley);
        invulnerability.IsIndestructible = false;
    }
}

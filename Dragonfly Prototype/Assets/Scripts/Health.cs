using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ITakeDamage {

    [Header("Health")]
    [SerializeField] int currentHealth = 10;
    [SerializeField] int maxHealth = 10;
    [SerializeField] AudioClip hitSound;
    [SerializeField] GameObject audioInstance;



    public void TakeDamage(int damage) {
        currentHealth -= damage;

        DropAudio();

        StartCoroutine(FlashRed());

        CheckForDeath();
        CheckForHealthOverflow();
    }
    private void CheckForDeath() {
        if(currentHealth <= 0) {
            currentHealth = 0;

            Debug.Log(gameObject.name + " has died! Get Good.");
            Destroy(gameObject);
        }
    }
    private void CheckForHealthOverflow() {
        if(currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }

    private IEnumerator FlashRed() {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void DropAudio() { 
        var audioObject = Instantiate(audioInstance, transform.position, transform.rotation);
        audioObject.GetComponent<AudioSource>().clip = hitSound;
        audioObject.GetComponent<AudioSource>().Play();
        Destroy(audioObject, 2f);
    }
}

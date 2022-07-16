using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform spawnPosition;
    public Slider cooldownSlider;
    //public Vector3 direction;
    [Header("Speed")]
    public float speed = 1f;
    public float angularSpeed = 1f;
    public float cooldownTime = 2f;

    private bool isReady = true;
    private float shotTime;
 
    void Start()
    {
        
    }


    void Update()
    {
        bool fireTrigger = Input.GetKeyDown(KeyCode.Space);

        if (fireTrigger && isReady)
        {
            // spawns the projectile
            GameObject firedBullet = Instantiate(bulletObject, spawnPosition.position, gameObject.transform.rotation);
            Rigidbody bulletRigidBody = firedBullet.GetComponent<Rigidbody>();
            bulletRigidBody.velocity = gameObject.transform.right * speed;
            bulletRigidBody.angularVelocity = gameObject.transform.right * angularSpeed;

            // starts cooldown
            isReady = false;
            StartCoroutine(ShotCooldown());
            shotTime = Time.time;
        }

        if (!isReady)
        {
            cooldownSlider.value = (cooldownTime - (Time.time - shotTime)) / cooldownTime;
        }
    }

    // Waits for cooldown before next shot
    IEnumerator ShotCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isReady = true;
    }

    
}

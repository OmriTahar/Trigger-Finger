using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float lifeTime;
    public void Activate(Vector3 position, Vector3 velocity)
    {
        transform.position = position;
        rigidbody.velocity = velocity;
        gameObject.SetActive(true);

        StartCoroutine("Decay");
    }

    private IEnumerator Decay()
    {
        yield return new WaitForSeconds(lifeTime);
        Deactivate();
    }

    public void Deactivate()
    {
        BulletPool.Instance.AddToPool(this);
        StopAllCoroutines();
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("Trigger Activated!");
            Deactivate();
        }
    }
}

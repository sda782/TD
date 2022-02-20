using UnityEngine;
using UnityEngine.Timeline;

public class Turret : MonoBehaviour
{
    private int lives = 10;
    private ParticleSystem ps;
    private GameObject target;
    void Start()
    {
        target = null;
        ps = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy" && target == null)
        {
            target = col.gameObject;
            InvokeRepeating("Attack", 0, 0.5f);
        }
    }
    private void OnTriggerLeave(Collider col)
    {
        if (col.gameObject == target)
        {
            target = null;
            CancelInvoke();
        }
    }

    private void Attack()
    {
        if (target.gameObject == null) return;
        ps.Play();
        EnemyData ed = target.gameObject.GetComponent<EnemyData>();
        lives -= ed.Attack();
        ed.TakeDamage(5);
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}

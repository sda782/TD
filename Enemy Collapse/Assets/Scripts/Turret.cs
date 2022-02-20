using UnityEngine;

public class Turret : MonoBehaviour
{
    private int lives = 10;
    private ParticleSystem ps;
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            ps.Play();
            EnemyData ed = col.gameObject.GetComponent<EnemyData>();
            lives -= ed.Attak();
            ed.TakeDamage(5);
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

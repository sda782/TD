using UnityEngine;

public class Turret : MonoBehaviour
{
    private int lives = 10;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            EnemyData ed = col.gameObject.GetComponent<EnemyData>();
            lives -= ed.Attak();
            ed.TakeDamage(1);
            if (lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

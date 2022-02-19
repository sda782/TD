using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    private int step;
    [SerializeField]
    private float moveSpeed;
    private Vector3 from;
    private bool canTurn;
    void Start()
    {
        StartPos();
    }

    void StartPos()
    {
        step = 0;
        transform.position = new Vector3(Level.levelData.StartPoint.x, transform.position.y, Level.levelData.StartPoint.z);
        from = Level.levelData.StartPoint;
        faceDirection(ConvertV(Level.levelData.Path[step]));
    }

    void Update()
    {
        Vector2 dir = Level.levelData.Path[step];
        transform.position = Vector3.MoveTowards(transform.position, from + ConvertV(dir), Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, (from + ConvertV(dir))) <= 0f)
        {
            from += ConvertV(dir);
            step++;
            faceDirection(ConvertV(Level.levelData.Path[step == Level.levelData.Path.Count ? Level.levelData.Path.Count - 1 : step]));
        }
        if (step == Level.levelData.Path.Count)
        {
            StartPos();
        }
    }

    private Vector3 ConvertV(Vector2 dir)
    {
        return new Vector3(dir.x, 0, dir.y);
    }
    private void faceDirection(Vector3 dir)
    {
        if (dir == Vector3.zero) return;
        Quaternion q = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = q;
    }
}

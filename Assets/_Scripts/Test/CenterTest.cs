using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterTest : MonoBehaviour
{
    [SerializeField] private Collider2D col_top;
    [SerializeField] private Collider2D col_bottom;
    [SerializeField] private Transform test_1;
    [SerializeField] private Transform test_2;
    [SerializeField] private Transform middle_point;

    private void Awake()
    {
        col_top = GetComponent<Collider2D>();
    }

    void OnDrawGizmos()
    {
        test_1.position = new Vector2(col_top.transform.position.x, col_top.bounds.min.y);
        test_2.position = new Vector2(col_bottom.transform.position.x, col_bottom.bounds.max.y);
        Vector2 center = (test_1.position + test_2.position) / 2f;

        float distance = Vector2.Distance(test_1.position, test_2.position);

        Vector2 boxSize = new Vector2(col_top.bounds.size.x, distance);

        Gizmos.DrawWireCube(center, boxSize);

        Gizmos.DrawLine(test_1.position, test_2.position);
    }
}

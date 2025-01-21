using Unity.VisualScripting;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private BoxCollider2D deadZoneCollider;
    private float ballContactDuration;
    private const float GAME_OVER_DURATION = 3f; // ���� ���� ���� (��)
    private int ballLayer; // DeadZone ���̾��� �ε����� ������ ����

    private void Start()
    {
        deadZoneCollider = GetComponent<BoxCollider2D>();
        deadZoneCollider.isTrigger = true;
        deadZoneCollider.enabled = true;
        ballContactDuration = 0f;
        ballLayer = LayerMask.NameToLayer("BALL"); // ���̾� �̸����� �ε��� ��������
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //}
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == ballLayer)
        {
            ballContactDuration += Time.deltaTime;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        ballContactDuration = 0f;
    }
    private void FixedUpdate()
    {
        Gameover();
    }
    private void Gameover()
    {
        if (ballContactDuration >= GAME_OVER_DURATION)
        {
            GameManager.instance.isGameOver = true;
            //ballContactDuration = 0f;
            Debug.Log("���� ����");
        }
    }
}
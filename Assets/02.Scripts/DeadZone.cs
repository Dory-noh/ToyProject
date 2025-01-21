using Unity.VisualScripting;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private BoxCollider2D deadZoneCollider;
    private float ballContactDuration;
    private const float GAME_OVER_DURATION = 3f; // 게임 오버 조건 (초)
    private int ballLayer; // DeadZone 레이어의 인덱스를 저장할 변수

    private void Start()
    {
        deadZoneCollider = GetComponent<BoxCollider2D>();
        deadZoneCollider.isTrigger = true;
        deadZoneCollider.enabled = true;
        ballContactDuration = 0f;
        ballLayer = LayerMask.NameToLayer("BALL"); // 레이어 이름으로 인덱스 가져오기
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
            Debug.Log("게임 종료");
        }
    }
}
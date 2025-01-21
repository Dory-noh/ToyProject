using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] ballPrefabs;
    [SerializeField] Transform tr;
    [SerializeField] Image nextBallImage;
    [SerializeField] DeadZone deadZone;
    int idx = 0;
    void Start()
    {
        tr = transform;
        ballPrefabs = Resources.LoadAll<GameObject>("Balls");
        
        idx = Random.Range(0, 3);
        nextBallImage.color = ballPrefabs[idx].GetComponent<SpriteRenderer>().color;
        deadZone = GameObject.Find("DeadZone").GetComponent<DeadZone>();
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if(GameManager.instance.isGameOver && GameManager.instance!=null) return;
        if (Input.GetMouseButtonDown(0))
        {
            RespawnBall();
        }
    }
    void RespawnBall()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 ballPos = new Vector3(mouseWorldPosition.x, tr.position.y, tr.position.z);
        
        GameObject ball = Instantiate(ballPrefabs[idx], ballPos, tr.rotation);
        ball.name = ballPrefabs[idx].name;
        StartCoroutine(ChooseNextBall());
        
    }
    IEnumerator ChooseNextBall(){
        yield return new WaitForSeconds(0.2f);
        idx = Random.Range(0, 3);
        nextBallImage.color = ballPrefabs[idx].GetComponent<SpriteRenderer>().color;
    }
}

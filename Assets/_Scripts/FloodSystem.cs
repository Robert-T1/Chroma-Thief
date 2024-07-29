using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodSystem : MonoBehaviour, IChase
{
    [SerializeField] private Transform resetPoint;
    [SerializeField] private CameraController camController;
    [SerializeField] private StressReceiver stressReceiver;
    [SerializeField] private float floodSpeedSpeed = 3.5f;
    [SerializeField] private GameObject floodObject;
    [SerializeField] private Vector2 stopPoint;
    private bool isChasing;

    private void Update()
    {
        if (!isChasing)
        {
            return;
        }
       
        if (Vector2.Distance(transform.position, stopPoint) < 2f)
        {
            camController.enabled = false;
        }
        else
        {
            camController.enabled = true;
        }
    }

    public void StartChase()
    {
        isChasing = true;
        StartCoroutine(ChaseSequence());
    }

    private IEnumerator ChaseSequence()
    {
        stressReceiver.InduceStress(2f);
        yield return new WaitForSeconds(3);

        StartCoroutine(StartFlood());
    }

    public void ResetChase()
    {
        isChasing = false;
        camController.transform.position = new Vector3(resetPoint.position.x, resetPoint.position.y, -10);
        LevelManager.Instance.player.transform.position = resetPoint.position;

        StartCoroutine(ChaseSequence());
    }

    private IEnumerator StartFlood()
    {
        Vector3 orginPos = floodObject.transform.position;
        while (isChasing) 
        {
            float newY = Mathf.Lerp(floodObject.transform.position.y, 100, floodSpeedSpeed * Time.deltaTime);
            floodObject.transform.position = new Vector2(floodObject.transform.position.x, newY);
            yield return null;
        }

        floodObject.transform.position = orginPos;
    }
}

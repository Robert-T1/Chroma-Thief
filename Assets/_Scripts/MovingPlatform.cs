using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private MoveType movingMode;
    [SerializeField] private Transform[] track;
    [SerializeField] private float speed;

    private bool isBacktracking = false;
    private int currentTrackIndex = 0;

    private void Start()
    {
        transform.position = track[currentTrackIndex].position;
        StartCoroutine(PlatformMoveLoop());
    }

    private IEnumerator PlatformMoveLoop()
    {
        Transform nextPoint = GetNextTrackPoint(movingMode);
        while(true)
        {
            transform.position = Vector2.MoveTowards(transform.position, nextPoint.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, nextPoint.position) <= 0.01f)
            {
                nextPoint = GetNextTrackPoint(movingMode);
            }

            yield return null;
        }
    }
    private Transform GetNextTrackPoint(MoveType type)
    {
        int next = currentTrackIndex;

        if(currentTrackIndex == 0 && isBacktracking) { 
            isBacktracking = false;
        }

        if (isBacktracking)
        {
            next = currentTrackIndex - 1;
        }
        else
        {
            next = currentTrackIndex + 1;
        }

        if (next >= track.Length)
        {
            if(movingMode == MoveType.BackAndForth)
            {
                isBacktracking = !isBacktracking;

                if (isBacktracking)
                {
                    currentTrackIndex = currentTrackIndex - 1;
                    return track[currentTrackIndex];
                }
                else
                {
                    currentTrackIndex = currentTrackIndex + 1;
                    return track[currentTrackIndex];
                }
            }
            else if (movingMode == MoveType.Loop)
            {
                currentTrackIndex = 0;
                return track[0];
            }
        }
        else
        {
            currentTrackIndex = next;
            return track[next];
        }

        return track[currentTrackIndex];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Entity>(out Entity entity))
        {
            entity.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Entity>(out Entity entity))
        {
            entity.transform.SetParent(null);
        }
    }


    private enum MoveType
    {
        None,
        BackAndForth, 
        Loop,
    }
}


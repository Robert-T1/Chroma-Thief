using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 locationOffset;
    [SerializeField] private RawImage fade;
    private float scrollSpeed;
    private bool freezeCamera;

    private CameraMode mode;
    private bool scrollUp, scrollLeft;

    private void Start()
    {
        fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, 1);
        StartCoroutine(FadeCamera(false, 0.8f));
        FollowTarget(LevelManager.Instance.player.transform);
    } 

    public IEnumerator FadeCamera(bool state, float fadeSpeed = 2.5f)
    {
        float fadeToo = state ? 1 : 0;
        while (Mathf.Abs(fade.color.a - fadeToo) > 0.01f)
        {
            float alpha = Mathf.Lerp(fade.color.a, fadeToo, fadeSpeed * Time.deltaTime);
            fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, alpha);
            yield return null;
        }
        fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, fadeToo);
    }

    void FixedUpdate()
    {
        if (freezeCamera)
        {
            return;
        }

        if(mode == CameraMode.Target)
        {
            Vector3 desiredPosition = target.position + target.rotation * locationOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else if (mode == CameraMode.AutoScroll && scrollLeft)
        {
            float y = target.position.y;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 5, y, transform.position.z), scrollSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }

    public void CameraState(bool state)
    {
        freezeCamera = state;
    }

    public void FollowTarget(Transform target)
    {
        this.target = target;
        mode = CameraMode.Target;
    }
    public void AutoScrollUp(float speed)
    {
        scrollSpeed = speed;
        scrollLeft = false;
        scrollUp = true;
    }
    public void AutoScrollLeft(float speed)
    {
        scrollSpeed = speed;
        scrollUp = false;
        scrollLeft = true;
        mode = CameraMode.AutoScroll;
    }
    public void SetLocationOffset(Vector3 offset)
    {
        locationOffset = offset;
    }

    private enum CameraMode
    {
        AutoScroll,
        Target,
    }
}



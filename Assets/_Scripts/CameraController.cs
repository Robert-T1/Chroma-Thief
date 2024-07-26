using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 locationOffset;
    private float scrollSpeed;
    private bool freezeCamera;

    private CameraMode mode;
    private bool scrollUp, scrollLeft;

    private void Start()
    {
        FollowTarget(GameManager.Instance.player.transform);
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



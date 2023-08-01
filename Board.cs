
using UnityEngine;
public enum eCam{ start, mid}
public class Board : MonoBehaviour
{
    [NamedArray(typeof(ePos))]public Spot[] spots;// will handle specific spots
    [NamedArray(typeof(eCam))] public Transform[] camPt;
    [NamedArray(typeof(eCam))] public float[] fov = { 44f, 20f };

    bool isTargetted;
    Transform target;
    private void Start()
    {
        MoveCamera(eCam.start, null);
    }
    public void MoveCamera(eCam _cam, Transform _target)
    {
        target = _target;
        isTargetted = (target != null);
        Camera.main.transform.position = camPt[(int)_cam].position;
        Camera.main.transform.rotation = camPt[(int)_cam].rotation;
        Camera.main.fieldOfView =fov [(int)_cam];
    }


    private void LateUpdate()
    {
        if (isTargetted)
        {
            Camera.main.transform.LookAt(target);
        }
    }
    //GameManager.gm.board.MoveCamera(eCam.)
}

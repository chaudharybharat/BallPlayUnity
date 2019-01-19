using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform LookAt;

    private Vector3 _desiredPosition;
    private Vector3 _offset;

    private float _smoothSpeed = 7.5f;
    private float _distance = 5.0f;
    private float _yOffSet = 3.5f;


	void Start () {
        _offset = new Vector3(0, _yOffSet, -1f * _distance);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            SlideCamera(true);

        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            SlideCamera(false);

        }
    }

    private void FixedUpdate() {
        _desiredPosition = LookAt.position + _offset;
        transform.position = Vector3.Lerp(transform.position, _desiredPosition, _smoothSpeed * Time.deltaTime);
        transform.LookAt(LookAt.position + Vector3.up);
    }

    public void SlideCamera(bool left) {
        if (left) {
            _offset = Quaternion.Euler(0, 90f, 0) * _offset;
        } else {
            _offset = Quaternion.Euler(0, -90f, 0) * _offset;
        }
    }

}
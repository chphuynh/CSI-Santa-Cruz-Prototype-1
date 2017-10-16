using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRig : MonoBehaviour 
{

	public Transform y_axis;
	public Transform x_axis;
	public float moveTime;
	public float dragSpeed = 0.75f;
	public float leftBound = -0.8f;
	public float rightBound = 2.8f;
	public float topBound = 3.7f;
	public float botBound = 0.6f;

	private Vector3 dragOrigin;

	public void AlignTo(Transform target)
	{
		Sequence seq = DOTween.Sequence();
		seq.Append(y_axis.DOMove(target.position, moveTime));
		seq.Join(y_axis.DORotate(new Vector3 (0f, target.rotation.eulerAngles.y, 0f), moveTime));
		seq.Join(x_axis.DOLocalRotate(new Vector3 (target.rotation.eulerAngles.x, 0f, 0f), moveTime));

	}

	public void DragCheck()
	{

		if (Input.GetMouseButtonDown(0))
		{
			dragOrigin = Input.mousePosition;
			return;
		}

		if (!Input.GetMouseButton(0)) return;

		Vector3 cam_pos = this.gameObject.transform.position;

		Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);

		if ( cam_pos.x <= rightBound && cam_pos.x >= leftBound && cam_pos.y <= topBound && cam_pos.y >= botBound) 
		{
			Vector3 move = new Vector3 (pos.x * dragSpeed, pos.y * dragSpeed, 0f);
			transform.Translate (move, Space.World);  
		}

		RestrictCamera ();
	}

	void RestrictCamera()
	{
		Vector3 cam_pos = this.gameObject.transform.position;

		if (cam_pos.x > rightBound)
			this.gameObject.transform.position = new Vector3(rightBound, cam_pos.y, cam_pos.z);
		if (cam_pos.x < leftBound)
			this.gameObject.transform.position = new Vector3(leftBound, cam_pos.y, cam_pos.z);
		if (cam_pos.y > topBound)
			this.gameObject.transform.position = new Vector3(cam_pos.x, topBound, cam_pos.z);
		if (cam_pos.y < botBound)
			this.gameObject.transform.position = new Vector3(cam_pos.x, botBound, cam_pos.z);
	}
}

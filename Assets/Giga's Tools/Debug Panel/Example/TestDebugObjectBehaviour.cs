using UnityEngine;

public class TestDebugObjectBehaviour : MonoBehaviour
{
	[Debug]
	public bool debug_DisableOnPlay = false;

	[Debug]
	public Color debug_GizmoColor = Color.green;
	[Debug]
	public bool debug_ShowGizmo = false;
	[Debug]
	public float debug_GizmoRadius = 0.5f;

	public float normalFloat = 1.337f;

	void OnDrawGizmos()
	{
		if (debug_ShowGizmo)
		{
			Gizmos.color = debug_GizmoColor;
			Gizmos.DrawSphere(transform.position, debug_GizmoRadius);
		}
	}
}

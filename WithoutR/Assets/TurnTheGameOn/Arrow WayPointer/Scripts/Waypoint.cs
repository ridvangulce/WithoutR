namespace TurnTheGameOn.ArrowWaypointer
{
	using UnityEngine;		
	public class Waypoint : MonoBehaviour
	{

		public int radius;
		[HideInInspector] public WaypointController waypointController;
		[HideInInspector] public int waypointNumber;

		void Update(){
			if (waypointController.player) {
				if(Vector3.Distance(transform.position, waypointController.player.position) < radius){
					waypointController.ChangeTarget ();
				}
			}
		}

		

		#if UNITY_EDITOR
		void OnDrawGizmosSelected(){
			if (waypointController != null) waypointController.OnDrawGizmosSelected (radius);
		}
		#endif
	}
}
using TMPro;

namespace TurnTheGameOn.ArrowWaypointer
{
    using UnityEngine;
    using UnityEngine.Events;

    [ExecuteInEditMode]
    public class WaypointController : MonoBehaviour
    {
        public enum Switch
        {
            Off,
            On
        }

        [System.Serializable]
        public class WaypointComponents
        {
            public string waypointName = "Waypoint Name";
            public Waypoint waypoint;
            public UnityEvent waypointEvent;
        }

        private float _distance;
        public Transform player;
        public Switch configureMode;

        [Range(0.0001f, 20)]
        public float arrowTargetSmooth; // controls how fast the arrow should smoothly target the next waypoint

        [Range(1, 100)] public int TotalWaypoints; // controls how many Waypoints should be used
        public WaypointComponents[] waypointList;
        private GameObject newWaypoint;
        private string newWaypointName;
        private int nextWP;

        private Transform waypointArrow; //Transform used to reference the Waypoint Arrow
        [HideInInspector] public Transform currentWaypoint; //Transforms used to identify the Waypoint Arrow's target
        [HideInInspector] public Transform arrowTarget;
        public GameObject enemy;
        public static WaypointController Current;

        void Start()
        {
            Current = this;

            // if (Application.isPlaying)
            // {
            //     GameObject newObject = new GameObject();
            //     newObject.name = "Arrow Target";
            //     newObject.transform.parent = gameObject.transform;
            //     arrowTarget = newObject.transform;
            //     newObject = null;
            // }

            nextWP = 0;
            ChangeTarget();
        }

        [ContextMenu("Reset")]
        public void Reset()
        {
            nextWP = 0;
            ChangeTarget();
        }

        void Update()
        {
            if (configureMode == Switch.Off)
            {
                TotalWaypoints = waypointList.Length;
            }
            //Check if the script is being executed in the Unity Editor
#if UNITY_EDITOR
            if (configureMode == Switch.On)
            {
                CalculateWaypoints();
            }
#endif
            //Keep the Waypoint Arrow pointed at the Current Waypoint
            if (arrowTarget != null)
            {
                arrowTarget.localPosition = Vector3.Lerp(arrowTarget.localPosition, currentWaypoint.localPosition,
                    arrowTargetSmooth * Time.deltaTime);
                arrowTarget.localRotation = Quaternion.Lerp(arrowTarget.localRotation, currentWaypoint.localRotation,
                    arrowTargetSmooth * Time.deltaTime);
            }
            else
            {
                arrowTarget = currentWaypoint;
            }

            if (waypointArrow == null)
                FindArrow();
            waypointArrow.LookAt(arrowTarget);
        }

        public void WaypointEvent(int waypointEvent)
        {
            waypointList[waypointEvent - 1].waypointEvent.Invoke();
        }

        public void ChangeTarget()
        {
            int check = nextWP;
            if (check < TotalWaypoints)
            {
                if (currentWaypoint == null)
                    currentWaypoint = enemy.transform;
            }
        }

        // public void CreateArrow()
        // {
        //     GameObject instance = Instantiate(Resources.Load("Waypoint Arrow", typeof(GameObject))) as GameObject;
        //     instance.name = "Waypoint Arrow";
        //     instance = null;
        // }

        public void FindArrow()
        {
            GameObject arrow = GameObject.Find("Waypoint Arrow");
            if (arrow == null)
            {
                // CreateArrow();
                waypointArrow = GameObject.Find("Waypoint Arrow").transform;
            }
            else
            {
                waypointArrow = arrow.transform;
            }
        }

        public void CalculateWaypoints()
        {
            if (configureMode == Switch.On)
            {
                System.Array.Resize(ref waypointList, TotalWaypoints);
                if (waypointArrow == null) FindArrow();
                CleanUpWaypoints();
            }
        }

        public void CleanUpWaypoints()
        {
            if (configureMode == Switch.On)
            {
                if (Application.isPlaying)
                {
                    Debug.LogWarning("ARROW WAYPOINTER: Turn Off 'Configure Mode' on the Waypoint Controller");
                }

                if (transform.childCount > waypointList.Length)
                {
                    foreach (Transform oldChild in transform)
                    {
                        if (oldChild.GetComponent<Waypoint>().waypointNumber > waypointList.Length)
                        {
                            DestroyImmediate(oldChild.gameObject);
                        }
                    }
                }
            }
        }

#if UNITY_EDITOR
        //Draws a Gizmo in the scene view window to show the Waypoints
        public void OnDrawGizmosSelected(int radius)
        {
            for (var i = 0; i < waypointList.Length; i++)
            {
                if (waypointList[i] != null)
                {
                    if (waypointList[i].waypoint != null)
                    {
                        Gizmos.DrawWireCube(waypointList[i].waypoint.transform.position, new Vector3(1, 1, 1));
                    }
                }
            }
        }
#endif
    }
}
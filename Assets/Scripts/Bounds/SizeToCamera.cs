using UnityEngine;

public class SizeToCamera : MonoBehaviour
{
    [SerializeField] private GameObject top;
    [SerializeField] private GameObject bottom;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        ResizeBounds();
    }

    private Vector2 CalculateScreenSizeInWorldCoords() {
        var p1 = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        var p2 = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane));
        var p3 = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        var width = (p2 - p1).magnitude;
        var height = (p3 - p2).magnitude;
 
         var dimensions = new Vector2(width, height);
 
         return dimensions;
    }

    private void ResizeBounds()
    {
        var size = CalculateScreenSizeInWorldCoords();
        transform.localScale = new Vector3(size.x / 10, transform.localScale.y, size.y / 10);

        top.transform.position = new Vector3(0, 0.5f, size.y / 2);
        top.transform.localScale = new Vector3(size.x, 1, 0.1f);

        bottom.transform.position = new Vector3(0, 0.5f, -size.y / 2);
        bottom.transform.localScale = new Vector3(size.x, 1, 0.1f);

        left.transform.position = new Vector3(-size.x / 2, 0.5f, 0);
        left.transform.localScale = new Vector3(0.1f, 1, size.y);

        right.transform.position = new Vector3(size.x / 2, 0.5f, 0);
        right.transform.localScale = new Vector3(0.1f, 1, size.y);
    }
}

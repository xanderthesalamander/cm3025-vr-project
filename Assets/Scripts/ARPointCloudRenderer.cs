using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPointCloudRenderer : MonoBehaviour
{
    public ARPointCloudManager pointCloudManager;
    public Material renderingMaterial;

    void OnEnable()
    {
        pointCloudManager.pointCloudsChanged += OnPointCloudsChanged;
    }

    void OnDisable()
    {
        pointCloudManager.pointCloudsChanged -= OnPointCloudsChanged;
    }

    void OnPointCloudsChanged(ARPointCloudChangedEventArgs eventArgs)
    {
        foreach (var pointCloud in eventArgs.updated)
        {
            VisualizePointCloud(pointCloud);
        }
    }

    void VisualizePointCloud(ARPointCloud pointCloud)
    {
        GameObject pointCloudObject = new GameObject("PointCloudObject");
        pointCloudObject.transform.position = pointCloud.transform.position;
        pointCloudObject.transform.rotation = pointCloud.transform.rotation;

        MeshRenderer meshRenderer = pointCloudObject.AddComponent<MeshRenderer>();
        meshRenderer.material = renderingMaterial;

        MeshFilter meshFilter = pointCloudObject.AddComponent<MeshFilter>();
        meshFilter.mesh = new Mesh();

        // Convert NativeSlice<Vector3> to List<Vector3>
        List<Vector3> pointCloudList = new List<Vector3>(pointCloud.positions);
        meshFilter.mesh.SetVertices(pointCloudList);
    }
}

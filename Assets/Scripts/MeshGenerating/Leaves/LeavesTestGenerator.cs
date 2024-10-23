using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class LeavesTestGenerator : MonoBehaviour
{
    [SerializeField] private AnimationCurve leaveMeshTrajectory;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private Mesh leafMesh;
    [SerializeField] private float distanceScale;
    [SerializeField] private float leafHeight;
    [SerializeField] private float leafWidth;
    private void Start()
    {
        leafMesh = new Mesh();
        meshFilter.mesh = leafMesh;
        
        //GenerateMesh();
    }

    private void OnValidate()
    {
        //GenerateMesh();
    }

    private void Update()
    {
        GenerateMesh();
        foreach (var vertex in leafMesh.vertices)
        {
            print(vertex);
        }
    }

    private void GenerateMesh()
    {
        var edgeCount = 2 + leaveMeshTrajectory.length;
        var minEdgeDistance = leaveMeshTrajectory[leaveMeshTrajectory.length - 1].value / edgeCount;

        List<Vector3> mainLeafCurve = new List<Vector3>();
        List<int> triangles = new List<int>();

        for (int i = 0; i < edgeCount; i++)
        {
            var x = 0 + minEdgeDistance * (i + 1);
            var y = 0 + leaveMeshTrajectory.Evaluate(x);
            mainLeafCurve.Add(new Vector3(x * distanceScale, y * distanceScale, 0));
        }

        var downLeafCurve = new List<Vector3>(mainLeafCurve);

        for (int i = 0; i < downLeafCurve.Count; i++)
        {
            var vert = downLeafCurve[i];
            vert.z -= leafWidth / 2;
            vert.y -= leafHeight - 1;
            downLeafCurve[i] = vert;
            //print(downLeafCurve[i]);
        }
        
        var leftLeafCurve = new List<Vector3>(mainLeafCurve);
        
        for (int i = 0; i < leftLeafCurve.Count; i++)
        {
            var vert = leftLeafCurve[i];
            vert.z -= leafWidth;
            leftLeafCurve[i] = vert;
            //print(leftLeafCurve[i]);
        }
        
        mainLeafCurve.AddRange(leftLeafCurve);
        mainLeafCurve.AddRange(downLeafCurve);

        leafMesh.vertices = mainLeafCurve.ToArray();
        
        for (int i = 0; i < mainLeafCurve.Count - 1; i++)
        {
            var triangleVertices = new List<Vector3>();
            triangleVertices.AddRange(mainLeafCurve.FindAll(t => Math.Abs(t.x - mainLeafCurve[i].x) < 0.1f && Math.Abs(t.y - mainLeafCurve[i].y) < leafHeight));
            triangleVertices.AddRange(mainLeafCurve.FindAll(t => Math.Abs(t.x - mainLeafCurve[i + 1].x) < 0.1f && Math.Abs(t.y - mainLeafCurve[i + 1].y) < leafHeight));
            
            
        }
        
        //leafMesh.triangles = triangle.ToArray();
    }

    private int[] GenerateTriangles(List<Vector3> vertexes)
    {
        var vertexIndexes = new List<int>();
        var allVertex = new List<Vector3>();

        var closestVertex = vertexes[0];
        
        for (int i = 0; i < vertexes.Count - 2; i++)
        {
            if (Vector3.Distance(closestVertex, vertexes[i + 1]) > Vector3.Distance(closestVertex, vertexes[i + 2]))
            {
                closestVertex = vertexes[i + 2];
            }
            else
            {
                closestVertex = vertexes[i + 1];
            }
            allVertex.Add(closestVertex); 
        }
        
        

        return null;
    }
}

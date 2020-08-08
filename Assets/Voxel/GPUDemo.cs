using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VoxelSystem.Demo {

    [RequireComponent (typeof(MeshFilter))]
	public class GPUDemo : MonoBehaviour {

        enum MeshType {
            Volume, Surface
        };

        [SerializeField] MeshType type = MeshType.Volume;
		[SerializeField] public Mesh mesh;
		[SerializeField] public ComputeShader voxelizer;
		[SerializeField] public int resolution = 32;
        [SerializeField] public bool useUV = false;

		void Start () {
			var data = GPUVoxelizer.Voxelize(voxelizer, mesh, resolution, (type == MeshType.Volume));
			Debug.Log(data.UnitLength);
			GetComponent<MeshFilter>().sharedMesh = VoxelMesh.Build(data.GetData(), data.UnitLength, useUV);
			data.Dispose();
		}

	}

}

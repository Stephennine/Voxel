using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace BVH
{
	public class BVHCreateSphere : MonoBehaviour
	{
		public GameObject mesh;
		void ComputeBoundingSphereRitter(Vector3[] vertices)
		{
			int vertex_num = vertices.Length;
		    int maxX = 0, maxY = 0, maxZ = 0, minX = -1, minY = -1, minZ = -1;

			//Find the max and min along the x-axie, y-axie, z-axie
			for (int i = 0; i < vertex_num; i++)
			{
				if (vertices[i].x > maxX) maxX = i;
				if (vertices[i].x < minX) minX = i;
				if (vertices[i].y > maxY) maxY = i;
				if (vertices[i].y < minY) minY = i;
				if (vertices[i].z > maxZ) maxZ = i;
				if (vertices[i].z < minZ) minZ = i;
			}// end for
             //sub1.x = vertices[maxX].x; sub1.y = vertices[maxX].y; sub1.z = vertices[maxX].z;
             //sub2.x = vertices[minX].x; sub2.y = vertices[minX].y; sub2.z = vertices[minX].z;
             //Vec3Sub(sub1, sub1, sub2);
             //Vec3Dot(x, sub1, sub1);
            Vector3 sub1 = vertices[maxX];
            Vector3 sub2 = vertices[minX];
            sub1 -= sub2;
            float x = Vector3.Dot(sub1, sub1);
            //sub1.x = vertices[maxY].x; sub1.y = vertices[maxY].y; sub1.z = vertices[maxY].z;
            //sub2.x = vertices[minY].x; sub2.y = vertices[minY].y; sub2.z = vertices[minY].z;
            //Vec3Sub(sub1, sub1, sub2);
            //Vec3Dot(y, sub1, sub1);
            sub1 = vertices[maxY];
			sub2 = vertices[minY];
			sub1 -= sub2;
            float y = Vector3.Dot(sub1, sub1);
            //sub1.x = vertices[maxZ].x; sub1.y = vertices[maxZ].y; sub1.z = vertices[maxZ].z;
            //sub2.x = vertices[minZ].x; sub2.y = vertices[minZ].y; sub2.z = vertices[minZ].z;
            //Vec3Sub(sub1, sub1, sub2);
            //Vec3Dot(z, sub1, sub1);
            sub1 = vertices[maxZ];
			sub2 = vertices[minZ];
			sub1 -= sub2;
            float z = Vector3.Dot(sub1, sub1);

            float dia = 0;
			int max = maxX, min = minX;
			if (z > x && z > y)
			{
				max = maxZ;
				min = minZ;
				dia = z;
			}
			else if (y > x && y > z)
			{
				max = maxY;
				min = minY;
				dia = y;
			}

			//Compute the center point
			//center.x = 0.5 * (vertices[max].x + vertices[min].x);
			//center.y = 0.5 * (vertices[max].y + vertices[min].y);
			//center.z = 0.5 * (vertices[max].z + vertices[min].z);
			Vector3 center = 0.5f * (vertices[max] + vertices[min]);

			//Compute the radious
			float radius2 = dia * 0.25f;
			float radius = 0.5f * Mathf.Sqrt(dia);

			//Fix it
			for (int i = 0; i < vertex_num; i++)
			{
				Vector3 d = vertices[i] - center;
				float dist2 = Vector3.Dot(d, d);

				if (dist2 > radius2)
				{
					float dist = Mathf.Sqrt(dist2);
					float newRadious = (dist + radius) * 0.5f;
					float k = (newRadious - radius) / dist;
					radius = newRadious;
					//VECTOR3 temp;
					//Vec3Mul(temp, d, k);
					//Vec3Add(center, center, temp);
					Vector3 temp = d * k;
					center += temp;
				}// end if
			}// end for vertex_num
		}// end for computeBoundingSphereRitter
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneScript : MonoBehaviour
{

    public Mesh mesh;

    void Start()
    {
//        meshFilter = GetComponent<MeshFilter>();
        gameObject.AddComponent<Animation>();
        gameObject.AddComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer rend = GetComponent<SkinnedMeshRenderer>();
        Animation anim = GetComponent<Animation>();


        //        Mesh mesh = meshFilter.mesh;
        rend.material = new Material(Shader.Find("Diffuse"));

        BoneWeight[] weights = new BoneWeight[mesh.vertices.Length];
        // TODO add the weights and stuff


        for (var i = 0; i < weights.Length; i++)
        {
            if (i >= 20 && i <= 76) // mid selection
            {
                if (i >= 58) // Top ring
                {
                    weights[i].boneIndex0 = 2;
                    weights[i].weight0 = 1;
                }
                else if (i <= 57) // middel and bottom ring
                {

                    if (i >= 22 && i <= 29) // bugged section
                    {
                        if (i % 2 == 0)
                        {
                            // middel                        
                            weights[i].boneIndex0 = 1;
                            weights[i].weight0 = 1;
                        }
                        else
                        {
                            // bottom
                            weights[i].boneIndex0 = 0;
                            weights[i].weight0 = 1;
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            // bottom
                            weights[i].boneIndex0 = 0;
                            weights[i].weight0 = 1;
                        }
                        else
                        {
                            // middel
                            weights[i].boneIndex0 = 1;
                            weights[i].weight0 = 1;
                        }
                    }

                    
                }
            }
            else // Top and bottom
            {

                if (i < 47)
                {
                    weights[i].boneIndex0 = 0; // bottom
                }
                else
                {
                    weights[i].boneIndex0 = 2; // top
                }

                weights[i].weight0 = 1;
            }

           
        }

        // A BoneWeights array (weights) was just created and the boneIndex and weight assigned.
        // The weights array will now be assigned to the boneWeights array in the Mesh.
        mesh.boneWeights = weights;

        Transform[] bones = new Transform[3];
        Matrix4x4[] bindPoses = new Matrix4x4[3];

        bones[0] = new GameObject("Lower").transform;
        bones[0].parent = transform;

        // Set the position relative to the parent
        bones[0].localRotation = Quaternion.identity;
        bones[0].localPosition = Vector3.zero;

        // The bind pose is bone's inverse transformation matrix
        // In this case the matrix we also make this matrix relative to the root
        // So that we can move the root game object around freely
        bindPoses[0] = bones[0].worldToLocalMatrix * transform.localToWorldMatrix;

        bones[1] = new GameObject("Middel").transform;
        bones[1].parent = transform;

        // Set the position relative to the parent
        bones[1].localRotation = Quaternion.identity;
        bones[1].localPosition = new Vector3(0, 0, 1);

        // The bind pose is bone's inverse transformation matrix
        // In this case the matrix we also make this matrix relative to the root
        // So that we can move the root game object around freely
        bindPoses[1] = bones[1].worldToLocalMatrix * transform.localToWorldMatrix;

        bones[2] = new GameObject("Upper").transform;
        bones[2].parent = transform;

        // Set the position relative to the parent
        bones[2].localRotation = Quaternion.identity;
        bones[2].localPosition = new Vector3(0, 0, 2);

        // The bind pose is bone's inverse transformation matrix
        // In this case the matrix we also make this matrix relative to the root
        // So that we can move the root game object around freely
        bindPoses[2] = bones[2].worldToLocalMatrix * transform.localToWorldMatrix;

        // assign the bindPoses array to the bindposes array which is part of the mesh.
        mesh.bindposes = bindPoses;

        // Assign bones and bind poses
        rend.bones = bones;
        rend.sharedMesh = mesh;

        // Assign a simple waving animation to the bottom bone
        AnimationCurve curve = new AnimationCurve
        {
            keys = new[] {new Keyframe(0, 0, 0, 0), new Keyframe(1, 3, 0, 0), new Keyframe(2, 0.0F, 0, 0)}
        };

        // Create the clip with the curve
        AnimationClip clip = new AnimationClip();
        clip.SetCurve("Lower", typeof(Transform), "m_LocalPosition.z", curve);
        clip.SetCurve("Middel", typeof(Transform), "m_LocalPosition.y", curve);
        clip.SetCurve("Upper", typeof(Transform), "m_LocalPosition.x", curve);
        clip.legacy = true;

        // Add and play the clip
//        anim.clip = clip;
        anim.AddClip(clip, "test");
        anim.Play("test");
    }
}
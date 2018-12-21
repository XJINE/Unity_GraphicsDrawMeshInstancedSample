using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GraphicsDrawMeshInstancedSample : MonoBehaviour
{
    #region Field

    public Mesh mesh;

    public Material material;

    public int count = 30;

    public ShadowCastingMode shadowCastingMode;

    public bool receiveShadows;

    public bool inSubCamera;

    public Camera subCamera;

    protected List<Matrix4x4> matrix4x4s;

    protected MaterialPropertyBlock materialPropertyBlock;

    #endregion Field

    #region Method

    private void Start()
    {
        this.matrix4x4s = new List<Matrix4x4>();

        for (int i = 0; i < this.count; i++)
        {
            this.matrix4x4s.Add(Matrix4x4.Translate(new Vector3(Random.value - 0.5f,
                                                                Random.value - 0.5f,
                                                                Random.value - 0.5f) * 10f)
                              * Matrix4x4.Rotate(Quaternion.Euler((Random.value - 0.5f) * 90f,
                                                                  (Random.value - 0.5f) * 90f,
                                                                  (Random.value - 0.5f) * 90f)));
        }

        this.materialPropertyBlock = new MaterialPropertyBlock();
        this.materialPropertyBlock.SetColor("_Color", Color.blue);
    }

    void Update ()
    {
        // STEP:1
        // Simplest pattern.
        // count settings is needed when using array instead of the list.

        //Graphics.DrawMeshInstanced(this.mesh, 0, this.material, this.matrix4x4s);
        //Graphics.DrawMeshInstanced(this.mesh, 0, this.material, this.matrix4x4s.ToArray(), 5);

        // STEP:2
        // With additional material settings.

        //Graphics.DrawMeshInstanced(this.mesh, 0, this.material, this.matrix4x4s,
        //                           this.materialPropertyBlock);

        // STEP:3
        // Shadow options.

        //Graphics.DrawMeshInstanced(this.mesh, 0, this.material, this.matrix4x4s,
        //                           this.materialPropertyBlock, this.shadowCastingMode);
        //Graphics.DrawMeshInstanced(this.mesh, 0, this.material, this.matrix4x4s,
        //                           this.materialPropertyBlock, this.shadowCastingMode, this.receiveShadows);

        // STEP:4
        Graphics.DrawMeshInstanced(this.mesh, 0, this.material, this.matrix4x4s,
                                   this.materialPropertyBlock, this.shadowCastingMode, this.receiveShadows,
                                   0, this.inSubCamera ? this.subCamera : null);
    }

    #endregion Method
}
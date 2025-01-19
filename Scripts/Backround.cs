using Unity.VisualScripting;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
   
   private MeshRenderer mesh;

   public float Speed = 1f;

   private void Awake()
   {
        mesh = GetComponent<MeshRenderer>();
   }

    private void Update()
    {
        mesh.material.mainTextureOffset += new Vector2(Speed * Time.deltaTime, 0);
    }

}

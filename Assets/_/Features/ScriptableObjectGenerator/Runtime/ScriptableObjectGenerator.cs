using System.Collections;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjectGenerator.Runtime
{
    
    public class ScriptableObjectGenerator : MonoBehaviour
    {
        #region Publics

        #endregion

        #region Unity API
        private void Awake()
        {
            BoydEntity so_instance = ScriptableObject.CreateInstance<BoydEntity>();
            JsonUtility.FromJsonOverwrite(_myJson.text, so_instance);
            Debug.Log(so_instance.ToString());
            string path = "Assets/_/ConspiratorJson.asset";
            AssetDatabase.CreateAsset(so_instance, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

        }
        #endregion

        #region Main methods

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }


        #endregion

        #region Utils

        #endregion

        #region Privates & Protected

        [SerializeField] private TextAsset _myJson;

        #endregion
    }

}

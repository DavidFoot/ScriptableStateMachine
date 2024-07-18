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
            //so_instance.m_myStructs.Add(new MyStruct("a","b","c"));
            //so_instance.m_myStructs.Add(new MyStruct("d","e","f"));
            //Debug.Log(SaveToString(so_instance));
            so_instance = JsonUtility.FromJson<BoydEntity>(_myJson.text);
            Debug.Log(so_instance.ToString());
            //so_instance.m_myStructs.Add(testStruct);
            string path = "Assets/_/Conspirator.asset";
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

        public string SaveToString(BoydEntity _test)
        {
            return JsonUtility.ToJson(_test, true);
        }

        #endregion

        #region Privates & Protected

        [SerializeField] private TextAsset _myJson;

        #endregion
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptablesObject.Runtime
{
    [System.Serializable]
    public struct BoydLine
    {
        [SerializeField] public string m_sentence;
        [SerializeField] public AudioClip m_sane;
        [SerializeField] public AudioClip m_crazy;
    }

    [System.Serializable]
    public struct BoydTransition
    {
        [SerializeField] public string m_name;
        [SerializeField] public BoydLine m_state;
        [Range(0.0f,1.0f)]
        [SerializeField] public float m_probability;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BoydEntity",menuName ="Psychonauts/Entity")]
[System.Serializable]
public class BoydEntity : ScriptableObject
{
    #region Publics

    #endregion

    #region Unity API

    #endregion

    #region Main methods

    // Start is called before the first frame update


    #endregion

    #region Utils



    #endregion

    #region Privates & Protected

    [SerializeField] public List<MyStruct> m_myStructs = new List<MyStruct>();

    #endregion
}
[System.Serializable]
public struct MyStruct
{
    public MyStruct(string x, string y, string z)
    {
        m_boydLine = x;
        m_saneClip = y;
        m_crazyClip = z;
    }
    public override string ToString()
    {
        return m_boydLine + m_saneClip + m_crazyClip;
    }
    public string m_boydLine;
    public string m_saneClip;
    public string m_crazyClip;

}

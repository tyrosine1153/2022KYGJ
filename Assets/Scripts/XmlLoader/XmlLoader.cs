using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class XmlLoader : MonoBehaviour {
    void Start() {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(Resources.Load<TextAsset>("Text/TalkData").text);
        foreach (XmlElement child in doc["Data"]) {
            int index = XmlConvert.ToInt32(child.GetAttribute("index"));
            TalkData data = new TalkData(child);
            DB.talk.Add(index, data);
        }
    }
    void Update() {
        
    }
}
public struct DB {
    public static Dictionary<int, TalkData> talk = new Dictionary<int, TalkData>();
}
public class TalkData {
    public List<string> names { get; }
    public List<string> talks { get; }

    public TalkData(XmlElement child) {
        this.names = new List<string>();
        this.talks = new List<string>();
        foreach (XmlElement a in child) {
            names.Add(child.GetAttribute("name"));
            talks.Add(child.GetAttribute("value"));
        }
    }
}
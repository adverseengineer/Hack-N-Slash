using UnityEngine;
using System;
using System.IO;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager
{
    public static string LoadDialogue(string path, int index)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("Assets\\Dialogue\\" + path + ".xml");
        XmlNode node = doc.DocumentElement.ChildNodes.Item(index);
        return node.FirstChild.FirstChild.ChildNodes.Item(UnityEngine.Random.Range(0,node.FirstChild.FirstChild.ChildNodes.Count)).InnerText;
    }
}

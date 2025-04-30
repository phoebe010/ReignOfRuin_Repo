using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Notes : MonoBehaviour
{
   [TextArea(10, 5)]
   public List<string> notes = new List<string>(); 
}

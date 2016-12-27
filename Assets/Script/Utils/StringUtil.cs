using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Security.Cryptography;

public class StringUtil {
	public static bool isNull(string str)
	{
	if(str == null || str =="" || str == "null")
	{
		return true;
	}
	return false;
}

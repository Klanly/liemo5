using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ByteData
{
    static int SIZE =32;
    byte[] bytes;
    int read;
    int write;


    public int readInt()
    {
        int size = 4;
        int value = 0;
        for (int j = 0; j < size; j++)
        {
            value += (bytes[read + j] & 0xff) << 8 * (size - 1 - j);
        }
        this.read += size;
        return value;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class ArrayUtility
{
    public static void PrintArray<T>(string name, IEnumerable<T> array)
    {
        string typeName = ConvertTypeName(array.GetType());
        string values = ConvertStringValues(array);
        string message = string.Format("{0} {1} = {{{2}}}", typeName, name, values);
        Debug.Log(message);
    }

    static string ConvertStringValues<T>(IEnumerable<T> array)
    {
        IEnumerable<string> strings = array.Select(x => x != null ? x.ToString() : "null");
        return string.Join(", ", strings.ToArray());
    }

    static string ConvertTypeName(Type type)
    {
        string result;
        if (primitiveTypes.TryGetValue(type, out result))
        {
            return result;
        }
        else
        {
            result = type.Name.Replace('+', '.');
        }

        if (!type.IsGenericType)
        {
            return result;
        }
        else if (type.IsNested && type.DeclaringType.IsGenericType)
        {
            return "<unknown>";
        }

        result = result.Substring(0, result.IndexOf("`"));
        return result + "<" + string.Join(", ", type.GetGenericArguments().Select(ConvertTypeName).ToArray()) + ">";
    }

    static Dictionary<Type, string> primitiveTypes = new Dictionary<Type, string>
    {
        { typeof(bool),      "bool"      },
        { typeof(byte),      "byte"      },
        { typeof(sbyte),     "sbyte"     },
        { typeof(char),      "char"      },
        { typeof(decimal),   "decimal"   },
        { typeof(double),    "double"    },
        { typeof(float),     "float"     },
        { typeof(int),       "int"       },
        { typeof(uint),      "uint"      },
        { typeof(long),      "long"      },
        { typeof(ulong),     "ulong"     },
        { typeof(object),    "object"    },
        { typeof(short),     "short"     },
        { typeof(ushort),    "ushort"    },
        { typeof(string),    "string"    },
        { typeof(bool[]),    "bool[]"    },
        { typeof(byte[]),    "byte[]"    },
        { typeof(sbyte[]),   "sbyte[]"   },
        { typeof(char[]),    "char[]"    },
        { typeof(decimal[]), "decimal[]" },
        { typeof(double[]),  "double[]"  },
        { typeof(float[]),   "float[]"   },
        { typeof(int[]),     "int[]"     },
        { typeof(uint[]),    "uint[]"    },
        { typeof(long[]),    "long[]"    },
        { typeof(ulong[]),   "ulong[]"   },
        { typeof(object[]),  "object[]"  },
        { typeof(short[]),   "short[]"   },
        { typeof(ushort[]),  "ushort[]"  },
        { typeof(string[]),  "string[]"  },
    };
}

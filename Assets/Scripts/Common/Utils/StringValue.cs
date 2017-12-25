using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class StringValue : System.Attribute
{
    private readonly string _value;

    public StringValue(string value)
    {
        _value = value;
    }

    public string Value
    {
        get { return _value; }
    }

    public static string GetStringValue(Enum Flagvalue)
    {
        var type = Flagvalue.GetType();
        var flags = Flagvalue.ToString().Split(',').Select(x => x.Trim()).ToArray();
        var values = new List<string>();

        for (var i = 0; i < flags.Length; i++)
        {
            var fi = type.GetField(flags[i].ToString());

            var attrs = fi.GetCustomAttributes(typeof(StringValue), false) as StringValue[];
            if (attrs.Length > 0)
                values.Add(attrs[0].Value);
        }
        return String.Join(",", values.ToArray());
    }
}
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Reflection;
using System.Resources;

internal static partial class SR
{   
    public static ResourceManager ResourceManager = new System.Resources.ResourceManager("SR", Assembly.GetExecutingAssembly());

    public static object GetObject(string name)
    {
        object resourceObject = null;
        try { resourceObject = ResourceManager.GetObject(name); }
        catch (MissingManifestResourceException) { }
        return resourceObject;
    }

    internal static string GetResourceString (string str) => (string)GetObject(str);
}

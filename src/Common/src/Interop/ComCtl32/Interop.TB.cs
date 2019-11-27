// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

internal static partial class Interop
{
    internal static partial class ComCtl32
    {
        public enum TB : int
        {
            GETBUTTONINFOW = (int)User32.WM_USER + 63,
            SETBUTTONINFOW = (int)User32.WM_USER + 64,
            INSERTBUTTONW = (int)User32.WM_USER + 67,
        }
    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;

internal partial class Interop
{
    internal static partial class Oleaut32
    {
        [DllImport(Libraries.Oleaut32, ExactSpelling = true, PreserveSig = true)]
        public static extern int OleCreateFontIndirect(ref FONTDESC lpFontDesc, ref Guid riid, out Ole32.IFont result);

        public static Ole32.IFont OleCreateFontIndirect(ref FONTDESC lpFontDesc, ref Guid riid)
		{
			Ole32.IFont result;
			Marshal.ThrowExceptionForHR(OleCreateFontIndirect(ref lpFontDesc, ref riid, out result));
			return result;
		}

        [DllImport(Libraries.Oleaut32, ExactSpelling = true, EntryPoint = "OleCreateFontIndirect", PreserveSig = true)]
        public static extern int OleCreateIFontDispIndirect(ref FONTDESC lpFontDesc, ref Guid riid, out Ole32.IFontDisp result);

        public static Ole32.IFontDisp OleCreateIFontDispIndirect(ref FONTDESC lpFontDesc, ref Guid riid)
		{
			Ole32.IFontDisp result;
			Marshal.ThrowExceptionForHR(OleCreateIFontDispIndirect(ref lpFontDesc, ref riid, out result));
			return result;
		}
    }
}

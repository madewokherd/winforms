// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Ole32
    {
        [DllImport(Libraries.Oleaut32)]
        [return: MarshalAs(UnmanagedType.Interface)]
        private unsafe static extern int OleCreatePictureIndirect(PICTDESC* pictdesc, ref Guid refiid, BOOL fOwn, out IntPtr result);

        private unsafe static object OleCreatePictureIndirect(PICTDESC* pictdesc, ref Guid refiid, BOOL fOwn)
		{
			IntPtr result;
			Marshal.ThrowExceptionForHR(OleCreatePictureIndirect(pictdesc,ref refiid,fOwn,out result));
			return Marshal.GetObjectForIUnknown(result);
		}

        /// <param name="fOwn">
        ///  <see cref="BOOL.TRUE"/> if the picture object is to destroy its picture when the object is destroyed.
        ///  (The picture handle in the <paramref name="pictdesc"/>.)
        /// </param>
        public unsafe static object OleCreatePictureIndirect(ref PICTDESC pictdesc, ref Guid refiid, BOOL fOwn)
        {
            pictdesc.cbSizeofstruct = (uint)sizeof(PICTDESC);
            fixed (PICTDESC* p = &pictdesc)
            {
                return OleCreatePictureIndirect(p, ref refiid, fOwn);
            }
        }

        public unsafe static object OleCreatePictureIndirect(ref Guid refiid)
            => OleCreatePictureIndirect(null, ref refiid, BOOL.TRUE);
    }
}

﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;

internal partial class Interop
{
    internal static partial class Oleaut32
    {
        [LibraryImport(Libraries.Oleaut32)]
        public static partial HRESULT VarFormat(
            IntPtr pvarIn,
            IntPtr pstrFormat,
            Ole32.VarFormatFirstDayOfWeek iFirstDay,
            Ole32.VarFormatFirstWeekOfYear iFirstWeek,
            VarFormatOptions dwFlags,
            ref IntPtr pbstrOut);
    }
}
﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

internal partial class Interop
{
    internal partial class ComCtl32
    {
        [DllImport(Libraries.Comctl32)]
        public static extern void InitCommonControls();
    }
}

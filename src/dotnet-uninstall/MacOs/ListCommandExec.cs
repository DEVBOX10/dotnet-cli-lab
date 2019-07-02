﻿using System;
using System.Collections.Generic;
using System.CommandLine.Rendering.Views;
using System.Linq;
using Microsoft.DotNet.Tools.Uninstall.Shared.BundleInfo;

namespace Microsoft.DotNet.Tools.Uninstall.MacOs
{
    internal static class ListCommandExec
    {
        public static GridView GetGridView(IList<Bundle> bundles)
        {
            var gridView = new GridView();

            gridView.SetColumns(Enumerable.Repeat(ColumnDefinition.SizeToContent(), 3).ToArray());
            gridView.SetRows(Enumerable.Repeat(RowDefinition.SizeToContent(), Math.Max(bundles.Count, 1)).ToArray());

            foreach (var (bundle, index) in bundles.Select((bundle, index) => (bundle, index)))
            {
                gridView.SetChild(new ContentView(string.Empty), 0, index);
                gridView.SetChild(new ContentView(bundle.Version.ToString()), 1, index);
                gridView.SetChild(new ContentView($"({bundle.Arch.ToString().ToLower()})"), 2, index);
            }

            return gridView;
        }
    }
}

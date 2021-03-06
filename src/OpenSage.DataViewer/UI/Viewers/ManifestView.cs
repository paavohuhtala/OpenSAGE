﻿using System;
using System.Collections.Generic;
using Eto.Forms;
using OpenSage.Data;
using OpenSage.Data.StreamFS;

namespace OpenSage.DataViewer.UI.Viewers
{
    public sealed class ManifestView : Splitter
    {
        public ManifestView(FileSystemEntry entry, Func<GameInstallation> getInstallation, Func<FileSystem> getFileSystem)
        {
            var gameStream = new GameStream(entry);

            var assetItems = new List<ListItem>();
            foreach (var asset in gameStream.ManifestFile.Assets)
            {
                assetItems.Add(new TreeItem
                {
                    Text = asset.Name,
                    Tag = asset
                });
            }

            var contentView = new ContentView(getInstallation, getFileSystem);

            var listBox = new ListBox
            {
                Width = 300,
                DataStore = gameStream.ManifestFile.Assets,
                ItemTextBinding = Binding.Property((Asset x) => x.Name)
            };
            listBox.SelectedValueChanged += (sender, e) => contentView.SetContent((Asset) listBox.SelectedValue);
            Panel1 = listBox;

            Panel2 = contentView;
        }
    }
}

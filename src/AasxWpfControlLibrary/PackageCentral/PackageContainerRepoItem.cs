﻿/*
Copyright (c) 2018-2019 Festo AG & Co. KG <https://www.festo.com/net/de_de/Forms/web/contact_international>
Author: Michael Hoffmeister

This source code is licensed under the Apache License 2.0 (see LICENSE.txt).

This source code may use other Open Source software components (see LICENSE.txt).
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using AasxIntegrationBase;
using AasxWpfControlLibrary.PackageCentral;
using AdminShellNS;
using Newtonsoft.Json;

namespace AasxWpfControlLibrary.PackageCentral
{
    /// <summary>
    /// This (rather base) container class integrates the former <c>AasxFileRepoItem</c> class, which implemented
    /// back in JAN 2021 the (updated) AASX file repository (a serialized list of file informations, which was 
    /// extended to a set of repo lists clickable by the user).
    /// In this version, this class takes over (on source code level) the members of <c>AasxFileRepoItem</c>
    /// and associated code and makes the legacy code therefore OBSOLETE (and to be removed).
    /// The idea is, to inject the visual properties and the ability of serialization of information to 
    /// JSON files directly into the single container class and therefore unify the capabilities of these
    /// two class systems.
    /// Note: As the would mean, that deriatives from this class will be serialized by JSON, for all
    ///       runtime properties a [JsonIgnore] attribute is required in ALL DERIVED CLASSES.
    /// </summary>
    public class PackageContainerRepoItem : PackageContainerBase, INotifyPropertyChanged
    {
        //
        // Members
        //

        // duty from INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        // Visual state
        public enum VisualStateEnum { Idle, Activated, ReadFrom, WriteTo }

        // static members, to be persisted

        //
        // Note 1: this is the new version of the Repository from 8 JAN 2021.
        //         Target is to switch to maintaining LISTS of assetId, aasId, submodelId
        //
        // Note 2: the single id properties are supported for READing old JSONs.
        //

        /// <summary>
        /// Asset Ids of the respective AASX Package.
        /// Note: to make this easy, only the value-strings of the Ids are maintained. A 2nd check needs
        /// to ensure full AAS KeyList compatibility.
        /// </summary>
        /// 
        [JsonProperty(PropertyName = "AssetIds")]
        private List<string> _assetIds = new List<string>();

        [JsonIgnore]
        public List<string> AssetIds
        {
            get { return _assetIds; }
            set { _assetIds = value; OnPropertyChanged("InfoIds"); }
        }

        // for compatibility before JAN 2021
        [JsonProperty(PropertyName = "assetId")]
        private string _legacyAssetId { set { _assetIds.Add(value); OnPropertyChanged("InfoIds"); } }


        /// <summary>
        /// AAS Ids of the respective AASX Package.
        /// Note: to make this easy, only the value-strings of the Ids are maintained. A 2nd check needs
        /// to ensure full AAS KeyList compatibility.
        /// </summary>
        [JsonProperty(PropertyName = "AasIds")]
        private List<string> _aasIds = new List<string>();

        [JsonIgnore]
        public List<string> AasIds
        {
            get { return _aasIds; }
            set { _aasIds = value; OnPropertyChanged("InfoIds"); }
        }

        // for compatibility before JAN 2021
        [JsonProperty(PropertyName = "aasId")]
        private string _legacyAaasId { set { _aasIds.Add(value); OnPropertyChanged("InfoIds"); } }

        // TODO (MIHO, 2021-01-08): add SubmodelIds

        /// <summary>
        /// Description; help for the human user.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        private string description = "";

        [JsonIgnore]
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("InfoIds"); }
        }

        /// <summary>
        /// 3-5 letters of Tag to be displayed in user interface
        /// </summary>
        [JsonProperty(PropertyName = "tag")]
        private string tag = "";

        [JsonIgnore]
        public string Tag
        {
            get { return tag; }
            set { tag = value; OnPropertyChanged("InfoIds"); }
        }

        /// <summary>
        /// QR or DMC format of the assit id
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string CodeType2D = "";

        /// <summary>
        /// AASX file name to load
        /// </summary>
        [JsonProperty(PropertyName = "fn")]
        private string location = "";

        [JsonIgnore]
        public string Location
        {
            get { return location; }
            set { location = value; OnPropertyChanged("InfoFilename"); }
        }

        //
        // dynamic members, to be not persisted            
        //

        /// <summary>
        /// Visual animation, currently displayed
        /// </summary>
        [JsonIgnore]
        public VisualStateEnum VisualState = VisualStateEnum.Idle;

        /// <summary>
        /// Tine in seconds, how long an animation shall be displayed.
        /// </summary>
        [JsonIgnore]
        private double visualTime = 0.0;

        [JsonIgnore]
        public double VisualTime
        {
            get { return visualTime; }
            set
            {
                this.visualTime = value;
                OnPropertyChanged("VisualLabelText");
                OnPropertyChanged("VisualLabelBackground");
            }
        }

        // Getters used by the binding
        [JsonIgnore]
        public string InfoIds
        {
            get
            {
                var info = "";
                Action<string, List<string>> lambdaAddIdList = (head, ids) =>
                {
                    if (ids != null && ids.Count > 0)
                    {
                        if (info != "")
                            info += Environment.NewLine;
                        info += head;
                        foreach (var id in ids)
                            info += "" + id + ",";
                        info = info.TrimEnd(',');
                    }
                };

                if (Description.HasContent())
                    info += Description;

                lambdaAddIdList("Assets: ", _assetIds);
                lambdaAddIdList("AAS: ", _aasIds);

                return info;
            }
        }

        [JsonIgnore]
        public string InfoLocation
        {
            get { return "" + this.Location; }
        }

        [JsonIgnore]
        public string VisualLabelText
        {
            get
            {
                switch (VisualState)
                {
                    case VisualStateEnum.Activated:
                        return "A";
                    case VisualStateEnum.ReadFrom:
                        return "R";
                    case VisualStateEnum.WriteTo:
                        return "W";
                    default:
                        return "";
                }
            }
        }

        [JsonIgnore]
        public Brush VisualLabelBackground
        {
            get
            {
                if (VisualState == VisualStateEnum.Idle)
                    return Brushes.Transparent;

                var col = Colors.Green;
                if (VisualState == VisualStateEnum.ReadFrom)
                    col = Colors.Blue;
                if (VisualState == VisualStateEnum.WriteTo)
                    col = Colors.Orange;

                if (visualTime > 2.0)
                    col.ScA = 1.0f;
                else if (visualTime > 0.001)
                    col.ScA = (float)(visualTime / 2.0);
                else
                {
                    visualTime = 0.0;
                    col = Colors.Transparent;
                    VisualState = VisualStateEnum.Idle;
                }

                return new SolidColorBrush(col);
            }
        }

        //
        // Constructors
        //

        public PackageContainerRepoItem() { }

        public PackageContainerRepoItem(PackageCentral packageCentral) : base (packageCentral) { }

        public PackageContainerRepoItem(string assetId, string fn, string aasId = null, string description = "",
            string tag = "", string code = "", PackageCentral packageCentral = null)
            : base(packageCentral)
        {
            this.Location = fn;
            if (assetId != null)
                this.AssetIds.Add(assetId);
            if (aasId != null)
                this.AasIds.Add(aasId);
            this.Description = description;
            this.Tag = tag;
            this.CodeType2D = code;
        }

        //
        // enumerations as important interface to the outside
        //

        public IEnumerable<string> EnumerateAssetIds()
        {
            if (_assetIds != null)
                foreach (var id in _assetIds)
                    yield return id;
        }

        public IEnumerable<string> EnumerateAasIds()
        {
            if (_aasIds != null)
                foreach (var id in _aasIds)
                    yield return id;
        }

        public IEnumerable<string> EnumerateAllIds()
        {
            foreach (var id in EnumerateAssetIds())
                yield return id;
            foreach (var id in EnumerateAasIds())
                yield return id;
        }

        //
        // Implementation
        //

    }
}
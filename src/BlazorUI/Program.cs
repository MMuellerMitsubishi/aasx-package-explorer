using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdminShellNS;
using AnyUi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlazorUI
{
    public class Program
    {
        public static event EventHandler NewDataAvailable;
        public class AnyUiPanelEntry
        {
            public AnyUiPanel panel;
            public int iChild;
            public AnyUiPanelEntry() { }
        }

        public class AnyUiPanelEntryStack
        {
            AnyUiPanelEntry[] recursionStack = new AnyUiPanelEntry[10];
            public int iRecursionStack = 0;
            public AnyUiPanelEntryStack() { }
            public int getIndex() { return iRecursionStack; }
            public void Pop(out AnyUiPanel panel, out int iChild)
            {
                panel = null;
                iChild = 0;
                if (iRecursionStack > 0)
                {
                    iRecursionStack--;
                    panel = recursionStack[iRecursionStack].panel;
                    iChild = recursionStack[iRecursionStack].iChild;
                    recursionStack[iRecursionStack] = null;
                }
            }
            public void Push(AnyUiPanel panel, int iChild)
            {
                recursionStack[iRecursionStack] = new Program.AnyUiPanelEntry();
                recursionStack[iRecursionStack].panel = panel;
                recursionStack[iRecursionStack].iChild = iChild + 1;
                iRecursionStack++;
            }
        }

        public static AdminShellPackageEnv env = null;

        public static AnyUiStackPanel stack = new AnyUiStackPanel();
        public static AnyUiStackPanel stack2 = new AnyUiStackPanel();

        public static string LogLine = "Started..";

        public class BlazorDisplayData : AnyUiDisplayDataBase
        {
            public Action<object> MyLambda;

            public BlazorDisplayData() { }

            public BlazorDisplayData(Action<object> lambda)
            {
                MyLambda = lambda;
            }
        }

        public static void Main(string[] args)
        {
            env = new AdminShellPackageEnv("Example_AAS_ServoDCMotor_21.aasx");

            //
            // Test for Blazor
            //

            // stack2 = JsonConvert.DeserializeObject<AnyUiStackPanel>(File.ReadAllText(@"c:\development\file.json"));

            // var d = new JavaScriptSerializer();
            // stack2 = d.Deserialize<AnyUiStackPanel>(File.ReadAllText(@"c:\development\file.json"));
            // var parent = (Dictionary<string, object>)results["Parent"];

            string s = File.ReadAllText(@"c:\development\file.json");
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            stack2 = JsonConvert.DeserializeObject<AnyUiStackPanel>(s, jsonSerializerSettings);

            var editMode = true;
            stack.Orientation = AnyUiOrientation.Vertical;

            if (true)
            {
                var lab1 = new AnyUiLabel();
                lab1.Content = "Hallo1";
                lab1.Foreground = AnyUiBrushes.DarkBlue;
                stack.Children.Add(lab1);

                var stck2 = new AnyUiStackPanel();
                stck2.Orientation = AnyUiOrientation.Horizontal;
                stack.Children.Add(stck2);

                var lab2 = new AnyUiLabel();
                lab2.Content = "Hallo2";
                lab2.Foreground = AnyUiBrushes.DarkBlue;
                stck2.Children.Add(lab2);

                var stck3 = new AnyUiStackPanel();
                stck3.Orientation = AnyUiOrientation.Horizontal;
                stck2.Children.Add(stck3);

                var lab3 = new AnyUiLabel();
                lab3.Content = "Hallo3";
                lab3.Foreground = AnyUiBrushes.DarkBlue;
                stck3.Children.Add(lab3);

                if (editMode)
                {
                    var tb = new AnyUiTextBox();
                    tb.Foreground = AnyUiBrushes.Black;
                    tb.Text = "Initial";
                    stck2.Children.Add(tb);
                    //repo.RegisterControl(tb, (o) =>
                    //{
                    //    Log.Singleton.Info($"Text changed to .. {"" + o}");
                    //    return new AnyUiLambdaActionNone();
                    //});

                    var btn = new AnyUiButton();
                    btn.Content = "Click me!";
                    btn.DisplayData = new BlazorDisplayData(lambda: (o) =>
                    {
                        if (o == btn)
                            Program.LogLine = "Hallo, Match zwischen Button und callback!";
                    });
                    stck3.Children.Add(btn);
                    //repo.RegisterControl(btn, (o) =>
                    //{
                    //    Log.Singleton.Error("Button clicked!");
                    //    return new AnyUiLambdaActionRedrawAllElements(null);
                    //});
                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

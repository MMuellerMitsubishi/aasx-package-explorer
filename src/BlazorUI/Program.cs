using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AasxPackageLogic;
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
        public static AnyUiStackPanel stack17 = new AnyUiStackPanel();

        public static string LogLine = "The text of the clicked button will be shown here..";

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
            var editMode = true;
            var hintMode = true;

#if __test__PackageLogic
#else

            var packages = new PackageCentral();
            packages.Main = env;

            var helper = new DispEditHelperEntities();
            helper.levelColors = DispLevelColors.GetLevelColorsFromOptions(Options.Curr);
            ModifyRepo repo = null;
            if (editMode)
            {
                // some functionality still uses repo != null to detect editMode!!
                repo = new ModifyRepo();
            }
            helper.editMode = editMode;
            helper.hintMode = hintMode;
            helper.repo = repo;
            helper.context = null;
            helper.packages = packages;

            stack17 = new AnyUiStackPanel();
            stack17.Orientation = AnyUiOrientation.Vertical;

            helper.DisplayOrEditAasEntityAas(
                    packages, env.AasEnv, env.AasEnv.AdministrationShells[0], editMode, stack17, hintMode: hintMode);
#endif

            //
            // Test for Blazor
            //

            // stack2 = JsonConvert.DeserializeObject<AnyUiStackPanel>(File.ReadAllText(@"c:\development\file.json"));

            // var d = new JavaScriptSerializer();
            // stack2 = d.Deserialize<AnyUiStackPanel>(File.ReadAllText(@"c:\development\file.json"));
            // var parent = (Dictionary<string, object>)results["Parent"];

            if (false)
            {
                string s = File.ReadAllText(@"c:\development\file.json");
                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                stack2 = JsonConvert.DeserializeObject<AnyUiStackPanel>(s, jsonSerializerSettings);
            }

            if (true)
            {
                stack.Orientation = AnyUiOrientation.Vertical;

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

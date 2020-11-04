﻿## AasxAmlImExport\AmlExport.cs

[Line 880, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxAmlImExport/AmlExport.cs#L880
), 
Michael Hoffmeister,
2020-08-01

    If further data specifications exist (in future), add here

## AasxAmlImExport\AmlImport.cs

[Line 177, column 17](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxAmlImExport/AmlImport.cs#L177
), 
MIHO,
2020-08-01

    The check for role class or requirements is still questionable
    but seems to be correct (see below)
    
    Question MIHO: I dont understand the determinism behind that!
    WIEGAND: me, neither ;-)
    Wiegand:  ich hab mir von Prof.Drath nochmal erklären lassen, wie SupportedRoleClass und
    RoleRequirement verwendet werden:
    In CAEX2.15(aktuelle AML Version und unsere AAS Mapping Version):
      1.Eine SystemUnitClass hat eine oder mehrere SupportedRoleClasses, die ihre „mögliche Rolle
        beschreiben(Drucker / Fax / kopierer)
      2.Wird die SystemUnitClass als InternalElement instanziiert entscheidet man sich für eine
        Hauptrolle, die dann zum RoleRequirement wird und evtl. Nebenklassen die dann
        SupportedRoleClasses sind(ist ein Workaround weil CAEX2.15 in der Norm nur
        ein RoleReuqirement erlaubt)
    InCAEX3.0(nächste AMl Version):
      1.Wie bei CAEX2.15
      2.Wird die SystemUnitClass als Internal Elementinstanziiert werden die verwendeten Rollen
        jeweils als RoleRequirement zugewiesen (in CAEX3 sind mehrere RoleReuqirements nun erlaubt)

[Line 1444, column 45](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxAmlImExport/AmlImport.cs#L1444
), 
Michael Hoffmeister,
2020-08-01

    fill out 
    eds.hasDataSpecification by using outer attributes

## AasxCsharpLibrary.Tests\TestLoadSaveChain.cs

[Line 42, column 5](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary.Tests/TestLoadSaveChain.cs#L42
), 
mristin,
2020-10-05

    The class is unused since all its tests were disabled temporarily and
    will be fixed in the near future.
    
    Once the tests are enabled, please remove this Resharper directive.

[Line 92, column 9](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary.Tests/TestLoadSaveChain.cs#L92
), 
mristin,
2020-10-05

    This test has been temporary disabled so that we can merge in the branch
    MIHO/EnhanceDocumentShelf. The test should be fixed in a future pull request and we will then re-enable it
    again.
    
    Please do not forget to remove the Resharper directive at the top of this class.
    
    [TestCase(".xml")]
    
    dead-csharp ignore this comment

[Line 138, column 9](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary.Tests/TestLoadSaveChain.cs#L138
), 
mristin,
2020-10-05

    This test has been temporary disabled so that we can merge in the branch
    MIHO/EnhanceDocumentShelf. The test should be fixed in a future pull request and we will then re-enable it
    again.
    
    Please do not forget to remove the Resharper directive at the top of this class.
    
    [Test]
    
    dead-csharp ignore this comment

[Line 163, column 25](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary.Tests/TestLoadSaveChain.cs#L163
), 
mristin,
2020-09-17

    Remove autofix once XSD and Aasx library in sync
    
    Package has been loaded, now we need to do an automatic check & fix.
    
    This is necessary as Aasx library is still not conform with the XSD AASX schema and breaks
    certain constraints (*e.g.*, the cardinality of langString = 1..*).

## AasxCsharpLibrary\AasxCompatibilityModels\V10\AdminShellV10.cs

[Line 1849, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AasxCompatibilityModels/V10/AdminShellV10.cs#L1849
), 
Michael Hoffmeister,
1970-01-01

    in V1.0, shall be a list of embeddedDataSpecification

[Line 2567, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AasxCompatibilityModels/V10/AdminShellV10.cs#L2567
), 
Michael Hoffmeister,
1970-01-01

    Qualifiers not working!

[Line 2927, column 29](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AasxCompatibilityModels/V10/AdminShellV10.cs#L2927
), 
Michael Hoffmeister,
1970-01-01

    Operation

[Line 3906, column 25](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AasxCompatibilityModels/V10/AdminShellV10.cs#L3906
), 
Michael Hoffmeister,
1970-01-01

    use aasenv serialzers here!

[Line 3931, column 29](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AasxCompatibilityModels/V10/AdminShellV10.cs#L3931
), 
Michael Hoffmeister,
1970-01-01

    use aasenv serialzers here!

[Line 4038, column 25](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AasxCompatibilityModels/V10/AdminShellV10.cs#L4038
), 
Michael Hoffmeister,
1970-01-01

    use aasenv serialzers here!

[Line 4067, column 29](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AasxCompatibilityModels/V10/AdminShellV10.cs#L4067
), 
Michael Hoffmeister,
1970-01-01

    use aasenv serialzers here!

[Line 4094, column 29](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AasxCompatibilityModels/V10/AdminShellV10.cs#L4094
), 
Michael Hoffmeister,
1970-01-01

    use aasenv serialzers here!

## AasxCsharpLibrary\AdminShell.cs

[Line 1144, column 25](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShell.cs#L1144
), 
MIHO,
2020-08-30

    this does not prevent the corner case, that we could have
    * multiple dataSpecificationIEC61360 in this list, which would be an error

[Line 2815, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShell.cs#L2815
), 
MIHO,
2020-08-27

    According to spec, cardinality is [1..1][1..n]

[Line 2819, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShell.cs#L2819
), 
MIHO,
2020-08-27

    According to spec, cardinality is [0..1][1..n]

[Line 2850, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShell.cs#L2850
), 
MIHO,
2020-08-27

    According to spec, cardinality is [0..1][1..n]

[Line 3129, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShell.cs#L3129
), 
MIHO,
2020-08-30

    align wording of the member ("embeddedDataSpecification") with the 
    * wording of the other entities ("hasDataSpecification")

[Line 3810, column 29](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShell.cs#L3810
), 
MIHO,
2020-08-26

    not very elegant, yet. Avoid temporary collection

[Line 4459, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShell.cs#L4459
), 
Michael Hoffmeister,
2020-08-01

    check, if Json has Qualifiers or not

[Line 5201, column 21](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShell.cs#L5201
), 
MIHO,
2020-07-31

    would be nice to use IEnumerateChildren for this ..

## AasxCsharpLibrary\AdminShellPackageEnv.cs

[Line 234, column 25](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShellPackageEnv.cs#L234
), 
Michael Hoffmeister,
2020-08-01

    use a unified function to create a serializer

[Line 360, column 21](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShellPackageEnv.cs#L360
), 
Michael Hoffmeister,
2020-08-01

    use a unified function to create a serializer

[Line 404, column 25](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShellPackageEnv.cs#L404
), 
Michael Hoffmeister,
2020-08-01

    use a unified function to create a serializer

[Line 439, column 25](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxCsharpLibrary/AdminShellPackageEnv.cs#L439
), 
Michael Hoffmeister,
2020-08-01

    use a unified function to create a serializer

## AasxDictionaryImport.Tests\Cdd\TestImport.cs

[Line 83, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxDictionaryImport.Tests/Cdd/TestImport.cs#L83
), 
Robin,
2020-09-03

    please check

[Line 99, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxDictionaryImport.Tests/Cdd/TestImport.cs#L99
), 
Robin,
2020-09-03

    please check

## AasxDictionaryImport.Tests\Cdd\TestModel.cs

[Line 562, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxDictionaryImport.Tests/Cdd/TestModel.cs#L562
), 
krahlro-sick,
2020-07-31

    make sure that there are no duplicates

## AasxDictionaryImport\Iec61360Utils.cs

[Line 122, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxDictionaryImport/Iec61360Utils.cs#L122
), 
Robin,
2020-09-03

    MIHO is not sure, if the data spec reference is correct; please check

[Line 138, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxDictionaryImport/Iec61360Utils.cs#L138
), 
Robin,
2020-09-03

    MIHO is not sure, if the data spec reference is correct; please check

[Line 154, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxDictionaryImport/Iec61360Utils.cs#L154
), 
Robin,
2020-09-03

    check this code

## AasxPluginUaNetClient\UASampleClient.cs

[Line 1, column 1](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxPluginUaNetClient/UASampleClient.cs#L1
), 
MIHO,
2020-08-06

    lookup SOURCE!

## AasxPluginWebBrowser\Plugin.cs

[Line 144, column 17](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxPluginWebBrowser/Plugin.cs#L144
), 
MIHO,
2020-08-02

    when dragging the divider between elements tree and browser window,

## AasxRestServerLibrary\AasxRestClient.cs

[Line 56, column 17](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxRestServerLibrary/AasxRestClient.cs#L56
), 
Michael Hoffmeister,
2020-08-01

    Andreas, check this. 
    System.Net.WebProxy.GetDefaultProxy was deprecated.

## AasxSignature\AasxSignature.cs

[Line 25, column 9](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxSignature/AasxSignature.cs#L25
), 
Andreas Orzelski,
2020-08-01

    The signature file and [Content_Types].xml can be tampered?

[Line 175, column 21](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxSignature/AasxSignature.cs#L175
), 
Andreas Orzelski,
2020-08-01

    Is package according to the Logical model of the AAS?

[Line 209, column 17](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxSignature/AasxSignature.cs#L209
), 
Andreas Orzelski,
2020-08-01

    is package sealed? => no other signatures can be added?

[Line 212, column 17](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxSignature/AasxSignature.cs#L212
), 
Andreas Orzelski,
2020-08-01

    The information from the analysis
    -> return as an object (list of enums with the issues/warings???)

## AasxUaNetConsoleServer\Program.cs

[Line 1, column 1](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetConsoleServer/Program.cs#L1
), 
MIHO,
2020-08-03

    check SOURCE

## AasxUaNetServer\AasxServer\AasEntityBuilder.cs

[Line 271, column 33](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasEntityBuilder.cs#L271
), 
MIHO,
2020-08-06

    check, which namespace shall be used

## AasxUaNetServer\AasxServer\AasUaEntities.cs

[Line 11, column 1](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L11
), 
MIHO,
2020-08-29

    The UA mapping needs to be overworked in order to comply the joint aligment with I4AAS

[Line 12, column 1](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L12
), 
MIHO,
2020-08-29

    The UA mapping needs to be checked for the "new" HasDataSpecification strcuture of V2.0.1

[Line 676, column 21](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L676
), 
MIHO,
2020-08-06

    check (again) if reference to CDs is done are shall be done

[Line 967, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L967
), 
MIHO,
2020-08-06

    not sure if to add these

[Line 1068, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L1068
), 
MIHO,
2020-08-06

    use the collection element of UA?

[Line 1384, column 29](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L1384
), 
MIHO,
2020-08-06

    decide to from where the name comes

[Line 1387, column 29](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L1387
), 
MIHO,
2020-08-06

    description: get "en" version which is appropriate?

[Line 1390, column 29](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L1390
), 
MIHO,
2020-08-06

    parse UA data type out .. OK?

[Line 1399, column 33](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L1399
), 
MIHO,
2020-08-06

    description: get "en" version is appropriate?

[Line 1408, column 37](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L1408
), 
MIHO,
2020-08-06

    this any better?

[Line 1412, column 37](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L1412
), 
MIHO,
2020-08-06

    description: get "en" version is appropriate?

[Line 1756, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/AasxServer/AasUaEntities.cs#L1756
), 
MIHO,
2020-08-06

    check, if to make super classes for UriDictionaryEntryType?

## AasxUaNetServer\Base\SampleNodeManager.cs

[Line 666, column 9](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/Base/SampleNodeManager.cs#L666
), 
MIHO,
2020-08-06

    check, if this is valid use of the SDK. MIHO added this

## AasxUaNetServer\SampleServer.cs

[Line 173, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUaNetServer/SampleServer.cs#L173
), 
MIHO,
2020-08-04

    To be checked by Andreas. All applications have software certificates

## AasxUANodesetImExport\UANodeSet.cs

[Line 20, column 1](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUANodesetImExport/UANodeSet.cs#L20
), 
Michael Hoffmeister,
2020-08-01

    Fraunhofer IOSB: Check ReSharper to be OK

## AasxUANodesetImExport\UANodeSetExport.cs

[Line 26, column 1](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUANodesetImExport/UANodeSetExport.cs#L26
), 
Michael Hoffmeister,
1970-01-01

    License

[Line 27, column 1](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUANodesetImExport/UANodeSetExport.cs#L27
), 
Michael Hoffmeister,
1970-01-01

    Fraunhofer IOSB: Check ReSharper

## AasxUANodesetImExport\UANodeSetImport.cs

[Line 23, column 1](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxUANodesetImExport/UANodeSetImport.cs#L23
), 
Michael Hoffmeister,
2020-08-01

    Fraunhofer IOSB: Check ReSharper settings to be OK

## AasxWpfControlLibrary\AasxFileRepository.cs

[Line 576, column 9](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxWpfControlLibrary/AasxFileRepository.cs#L576
), 
MIHO,
2020-08-05

    refacture this with DispEditHelper.cs

## AasxWpfControlLibrary\DiplayVisualAasxElements.xaml.cs

[Line 717, column 21](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxWpfControlLibrary/DiplayVisualAasxElements.xaml.cs#L717
), 
MIHO,
2020-07-21

    was because of multi-select

## AasxWpfControlLibrary\DispEditAasxEntity.xaml.cs

[Line 1450, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxWpfControlLibrary/DispEditAasxEntity.xaml.cs#L1450
), 
MIHO,
2020-09-01

    extend the lines below to cover also data spec. for units

[Line 1807, column 33](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxWpfControlLibrary/DispEditAasxEntity.xaml.cs#L1807
), 
Michael Hoffmeister,
2020-08-01

    Operation mssing here?

[Line 1829, column 33](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxWpfControlLibrary/DispEditAasxEntity.xaml.cs#L1829
), 
Michael Hoffmeister,
2020-08-01

    Operation mssing here?

## AasxWpfControlLibrary\DispEditHelperBasics.cs

[Line 1166, column 17](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxWpfControlLibrary/DispEditHelperBasics.cs#L1166
), 
Michael Hoffmeister,
2020-08-01

    possibly [Jump] button??

[Line 1335, column 25](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxWpfControlLibrary/DispEditHelperBasics.cs#L1335
), 
Michael Hoffmeister,
2020-08-01

    Needs to be revisited

## AasxWpfControlLibrary\VisualAasxElements.cs

[Line 153, column 17](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/AasxWpfControlLibrary/VisualAasxElements.cs#L153
), 
MIHO,
2020-07-31

    check if commented out because of non-working multi-select?

## WpfMtpControl\MtpAmlHelper.cs

[Line 42, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/WpfMtpControl/MtpAmlHelper.cs#L42
), 
MIHO,
2020-08-03

    see equivalent function in AmlImport.cs; may be re-use

[Line 210, column 41](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/WpfMtpControl/MtpAmlHelper.cs#L210
), 
MIHO,
2020-08-06

    spec/example files seem not to be in a final state

## WpfMtpControl\MtpVisuOpcUaClient.cs

[Line 233, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/WpfMtpControl/MtpVisuOpcUaClient.cs#L233
), 
MIHO,
2020-08-06

    remove this, if not required anymore

## WpfMtpControl\UiElementHelper.cs

[Line 406, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/WpfMtpControl/UiElementHelper.cs#L406
), 
MICHA,
2020-10-04

    check if font is set correctly ..

[Line 407, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/WpfMtpControl/UiElementHelper.cs#L407
), 
MICHA,
2020-10-04

    seems, that for Textblock the alignement DOES NOT WORK!

## WpfMtpVisuViewer\MainWindow.xaml.cs

[Line 70, column 13](
https://github.com/admin-shell-io/aasx-package-explorer/blob/master/src/WpfMtpVisuViewer/MainWindow.xaml.cs#L70
), 
MIHO,
2020-09-18

    remove this test code



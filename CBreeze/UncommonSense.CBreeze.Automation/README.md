# UncommonSense.CBreeze.Automation

PowerShell interface for UncommonSense.CBreeze.Automation.dll

## Design Decisions

### Boolean parameters cannot be implemented as PowerShell SwitchParameters
Because of the following:

```powershell
function Test-Switch
{
    [CmdletBinding()]
    Param
    (
        [Switch]$Yep
    )

    Process
    {
        "ToString returns $($Yep.ToString())"
        "ToBool returns $($Yep.ToBool())"
        "IsPresent returns $($Yep.IsPresent)"
    }
}

PS C:\Users\jhoek\Desktop> Test-Switch 
ToString returns False
ToBool returns False
IsPresent returns False

PS C:\Users\jhoek\Desktop> Test-Switch -Yep
ToString returns True
ToBool returns True
IsPresent returns True

PS C:\Users\jhoek\Desktop> Test-Switch -Yep:$false
ToString returns False
ToBool returns False
IsPresent returns False
```

In other words - there is no difference between the absence of the switch and an explicit `$false` value. Boolean properties in C/SIDE are tri-states, whereas Switch parameters in PowerShell are really booleans. That's why in the following example, not all possible values for PasteIsValid can be expressed:

```powershell
Add-CBreezeObject -Type Table -Range $Range -Name Demo -PasteIsValid
```

## Index

| Command | Synopsis |
| ------- | -------- |
| [Set-CBreezeAccessByPermission](#Set-CBreezeAccessByPermission) | Set-CBreezeAccessByPermission [-ObjectType] <AccessByPermissionObjectType> [-ObjectID] <int> -InputObject <psobject> [-Read] [-Insert] [-Modify] [-Delete] [-Execute] [<CommonParameters>] |
| [Compile-CBreezeApplication](#Compile-CBreezeApplication) | Compile-CBreezeApplication [-Application] <Application> -Database <string> [-DevClientPath <string>] [-ServerName <string>] [<CommonParameters>] |
| [Export-CBreezeApplication](#Export-CBreezeApplication) | Export-CBreezeApplication [-InputObject] <psobject[]> [[-TextWriter] <TextWriter>] [<CommonParameters>]  Export-CBreezeApplication [-InputObject] <psobject[]> [-Path] <string> [<CommonParameters>]  Export-CBreezeApplication [-InputObject] <psobject[]> [-Stream] <Stream> [<CommonParameters>]  Export-CBreezeApplication [-InputObject] <psobject[]> -Database <string> [-DevClientPath <string>] [-ServerName <string>] [-ImportAction <string>] [-AutoCompile] [<CommonParameters>] |
| [Import-CBreezeApplication](#Import-CBreezeApplication) | Import-CBreezeApplication [-Path] <string[]> [<CommonParameters>]  Import-CBreezeApplication -Database <string> [-DevClientPath <string>] [-ServerName <string>] [-Filter <string>] [<CommonParameters>] |
| [New-CBreezeApplication](#New-CBreezeApplication) | New-CBreezeApplication [[-Objects] <scriptblock>] [<CommonParameters>] |
| [New-CBreezeCalcFormula](#New-CBreezeCalcFormula) | New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Sum [-ReverseSign] [<CommonParameters>]  New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Average [-ReverseSign] [<CommonParameters>]  New-CBreezeCalcFormula [-TableName] <string> -Exist [-ReverseSign] [<CommonParameters>]  New-CBreezeCalcFormula [-TableName] <string> -Count [<CommonParameters>]  New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Min [<CommonParameters>]  New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Max [<CommonParameters>]  New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Lookup [<CommonParameters>] |
| [Add-CBreezeCodeLine](#Add-CBreezeCodeLine) | Add-CBreezeCodeLine [[-Line] <string>] [[-ArgumentList] <Object[]>] -InputObject <psobject> [<CommonParameters>] |
| [Add-CBreezeCodeunit](#Add-CBreezeCodeunit) | Add-CBreezeCodeunit [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  Add-CBreezeCodeunit [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [New-CBreezeCodeunit](#New-CBreezeCodeunit) | New-CBreezeCodeunit [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  New-CBreezeCodeunit [-Name] <string> [[-SubObjects] <scriptblock>] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [Add-CBreezeColumnReportElement](#Add-CBreezeColumnReportElement) | Add-CBreezeColumnReportElement -ID <int> -Name <string> -Report <Report> -SourceExpr <string> [-AutoCalcField <bool>] [-AutoFormatExpr <string>] [-AutoFormatType <AutoFormatType>] [-AutoOptionCaption] [-DecimalPlacesAtLeast <int>] [-DecimalPlacesAtMost <int>] [-Description <string>] [-IncludeCaption <bool>] [-OptionString <string>] [-ParentElement <ReportElement>] [-PassThru] [<CommonParameters>] |
| [Add-CBreezeCondition](#Add-CBreezeCondition) | Add-CBreezeCondition [-FieldName] <string> -Const [-Value] <string> -InputObject <TableRelationLine> [-PassThru] [<CommonParameters>]  Add-CBreezeCondition [-FieldName] <string> -Filter [-Value] <string> -InputObject <TableRelationLine> [-PassThru] [<CommonParameters>] |
| [Add-CBreezeDataItemReportElement](#Add-CBreezeDataItemReportElement) | Add-CBreezeDataItemReportElement -ID <int> -Report <Report> -DataItemTable <int> [-ParentElement <ReportElement>] [-PassThru] [-CalcFields <string[]>] [-DataItemLinkReference <string>] [-DataItemTableViewKey <string>] [-DataItemTableViewOrder <Order>] [-MaxIteration <int>] [-PrintOnlyIfDetail <bool>] [-ReqFilterFields <string[]>] [-ReqFilterHeading <string>] [-Temporary <bool>] [<CommonParameters>] |
| [Add-CBreezeEvent](#Add-CBreezeEvent) | Add-CBreezeEvent [-SourceID] <int> [-SourceName] <string> [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> [-PassThru] [<CommonParameters>] |
| [New-CBreezeEvent](#New-CBreezeEvent) | New-CBreezeEvent [-SourceID] <int> [-SourceName] <string> [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [<CommonParameters>] |
| [Add-CBreezeFilter](#Add-CBreezeFilter) | Add-CBreezeFilter [-FieldName] <string> -Const [-Value] <string> -InputObject <psobject> [-OnlyMaxLimit] [-ValueIsFilter] [-PassThru] [<CommonParameters>]  Add-CBreezeFilter [-FieldName] <string> -Filter [-Value] <string> -InputObject <psobject> [-OnlyMaxLimit] [-ValueIsFilter] [-PassThru] [<CommonParameters>]  Add-CBreezeFilter [-FieldName] <string> -Field [-Value] <string> -InputObject <psobject> [-OnlyMaxLimit] [-ValueIsFilter] [-PassThru] [<CommonParameters>] |
| [Add-CBreezeFunction](#Add-CBreezeFunction) | Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-TestFunctionType <TestFunctionType>] [-HandlerFunctions <string>] [-TransactionModel <TransactionModel>] [-TryFunction <bool>] [<CommonParameters>]  Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-UpgradeFunctionType <UpgradeFunctionType>] [-TryFunction <bool>] [<CommonParameters>]  Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> -EventSubscriber -EventPublisherObjectType <ObjectType> -EventPublisherObjectID <int> -EventFunction <string> [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-EventPublisherElement <string>] [-OnMissingLicense <MissingAction>] [-OnMissingPermission <MissingAction>] [-TryFunction <bool>] [<CommonParameters>]  Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> -BusinessEvent [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-TryFunction <bool>] [<CommonParameters>]  Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> -IntegrationEvent [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-GlobalVarAccess <bool>] [-TryFunction <bool>] [<CommonParameters>] |
| [New-CBreezeFunction](#New-CBreezeFunction) | New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-TestFunctionType <TestFunctionType>] [-HandlerFunctions <string>] [-TransactionModel <TransactionModel>] [-TryFunction <bool>] [<CommonParameters>]  New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-UpgradeFunctionType <UpgradeFunctionType>] [-TryFunction <bool>] [<CommonParameters>]  New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -EventSubscriber -EventPublisherObjectType <ObjectType> -EventPublisherObjectID <int> -EventFunction <string> [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-EventPublisherElement <string>] [-OnMissingLicense <MissingAction>] [-OnMissingPermission <MissingAction>] [-TryFunction <bool>] [<CommonParameters>]  New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -BusinessEvent [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-TryFunction <bool>] [<CommonParameters>]  New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -IntegrationEvent [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-GlobalVarAccess <bool>] [-TryFunction <bool>] [<CommonParameters>] |
| [Add-CBreezeLink](#Add-CBreezeLink) | Add-CBreezeLink [-FieldName] <string> -Const [-Value] <string> -InputObject <psobject> [-ReferenceDataItem <string>] [-OnlyMaxLimit] [-ValueIsFilter] [<CommonParameters>]  Add-CBreezeLink [-FieldName] <string> -Filter [-Value] <string> -InputObject <psobject> [-ReferenceDataItem <string>] [-OnlyMaxLimit] [-ValueIsFilter] [<CommonParameters>]  Add-CBreezeLink [-FieldName] <string> -Field [-Value] <string> -InputObject <psobject> [-ReferenceDataItem <string>] [-OnlyMaxLimit] [-ValueIsFilter] [<CommonParameters>] |
| [Add-CBreezeMenuSuite](#Add-CBreezeMenuSuite) | Add-CBreezeMenuSuite [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  Add-CBreezeMenuSuite [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [New-CBreezeMenuSuite](#New-CBreezeMenuSuite) | New-CBreezeMenuSuite [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  New-CBreezeMenuSuite [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [Add-CBreezeMenuSuiteNode](#Add-CBreezeMenuSuiteNode) | Add-CBreezeMenuSuiteNode [[-NextNodeID] <guid>] [<CommonParameters>] |
| [New-CBreezeMenuSuiteNode](#New-CBreezeMenuSuiteNode) | New-CBreezeMenuSuiteNode [[-NextNodeID] <guid>] [<CommonParameters>] |
| [Set-CBreezeMLValue](#Set-CBreezeMLValue) | Set-CBreezeMLValue [[-Property] <string>] [-LanguageName] <string> [-Value] <string> -InputObject <psobject> [-PassThru] [<CommonParameters>] |
| [Invoke-CBreezeObject](#Invoke-CBreezeObject) | Invoke-CBreezeObject [-Object] <Object> [-RoleTailoredClientPath <string>] [-ServerName <string>] [-ServerPort <int>] [-ServerInstance <string>] [-CompanyName <string>] [-PageMode <PageMode>] [-HideNavigationPane] [-FullScreen] [<CommonParameters>] |
| [Add-CBreezeOrderBy](#Add-CBreezeOrderBy) | Add-CBreezeOrderBy [-Column] <string> [[-Direction] <QueryOrderByDirection>] -InputObject <Query> [<CommonParameters>] |
| [New-CBreezeOrderBy](#New-CBreezeOrderBy) | New-CBreezeOrderBy [-Column] <string> [[-Direction] <QueryOrderByDirection>] [<CommonParameters>] |
| [Add-CBreezePage](#Add-CBreezePage) | Add-CBreezePage [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  Add-CBreezePage [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [New-CBreezePage](#New-CBreezePage) | New-CBreezePage [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  New-CBreezePage [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [Add-CBreezePageAction](#Add-CBreezePageAction) | Add-CBreezePageAction [-ID] <int> [[-Caption] <string>] [[-Image] <string>] -InputObject <psobject> [-PassThru] [-Position <Position>] [-Description <string>] [-Ellipsis <bool>] [-Enabled <string>] [-InFooterBar <bool>] [-Name <string>] [-Promoted <bool>] [-PromotedCategory <PromotedCategory>] [-PromotedIsBig <bool>] [-RunObjectType <RunObjectType>] [-RunObjectID <int>] [-RunPageMode <RunPageMode>] [-RunPageOnRec <bool>] [-RunPageViewKey <string>] [-RunPageViewOrder <Order>] [-Scope <PageActionScope>] [-ShortcutKey <string>] [-Visible <string>] [<CommonParameters>] |
| [New-CBreezePageAction](#New-CBreezePageAction) | New-CBreezePageAction [-ID] <int> [[-Caption] <string>] [[-Image] <string>] [-Description <string>] [-Ellipsis <bool>] [-Enabled <string>] [-InFooterBar <bool>] [-Name <string>] [-Promoted <bool>] [-PromotedCategory <PromotedCategory>] [-PromotedIsBig <bool>] [-RunObjectType <RunObjectType>] [-RunObjectID <int>] [-RunPageMode <RunPageMode>] [-RunPageOnRec <bool>] [-RunPageViewKey <string>] [-RunPageViewOrder <Order>] [-Scope <PageActionScope>] [-ShortcutKey <string>] [-Visible <string>] [<CommonParameters>] |
| [Add-CBreezePageActionContainer](#Add-CBreezePageActionContainer) | Add-CBreezePageActionContainer [-ID] <int> [-ContainerType] <ActionContainerType> [[-ChildActions] <scriptblock>] -InputObject <psobject> [-PassThru] [-Position <Position>] [-Description <string>] [-Name <string>] [<CommonParameters>] |
| [Get-CBreezePageActionContainer](#Get-CBreezePageActionContainer) | Get-CBreezePageActionContainer -Page <Page> -Type <ActionContainerType> [<CommonParameters>] |
| [New-CBreezePageActionContainer](#New-CBreezePageActionContainer) | New-CBreezePageActionContainer [-ID] <int> [-ContainerType] <ActionContainerType> [[-ChildActions] <scriptblock>] [-Description <string>] [-Name <string>] [<CommonParameters>] |
| [Add-CBreezePageActionGroup](#Add-CBreezePageActionGroup) | Add-CBreezePageActionGroup [-ID] <int> [[-Caption] <string>] [[-ChildActions] <scriptblock>] -InputObject <psobject> [-PassThru] [-Position <Position>] [-Description <string>] [-Enabled <string>] [-Image <string>] [-Name <string>] [-Visible <string>] [<CommonParameters>] |
| [Get-CBreezePageActionGroup](#Get-CBreezePageActionGroup) | Get-CBreezePageActionGroup -Caption <string> -ContainerType <ActionContainerType> -Page <Page> [-Position <Position>] [<CommonParameters>] |
| [New-CBreezePageActionGroup](#New-CBreezePageActionGroup) | New-CBreezePageActionGroup [-ID] <int> [[-Caption] <string>] [[-ChildActions] <scriptblock>] [-Description <string>] [-Enabled <string>] [-Image <string>] [-Name <string>] [-Visible <string>] [<CommonParameters>] |
| [Add-CBreezePageActionSeparator](#Add-CBreezePageActionSeparator) | Add-CBreezePageActionSeparator [-ID] <int> -InputObject <psobject> [-PassThru] [-Position <Position>] [-Caption <string>] [-IsHeader <bool>] [<CommonParameters>] |
| [New-CBreezePageActionSeparator](#New-CBreezePageActionSeparator) | New-CBreezePageActionSeparator [-ID] <int> [-Caption <string>] [-IsHeader <bool>] [<CommonParameters>] |
| [Add-CBreezePageControl](#Add-CBreezePageControl) | Add-CBreezePageControl [[-Width] <int>] [-ID] <int> [[-ChildControls] <scriptblock>] -InputObject <psobject> [-PassThru] [-Description <string>] [-Name <string>] [-AutoCaption] [<CommonParameters>] |
| [New-CBreezePageControl](#New-CBreezePageControl) | New-CBreezePageControl [[-Width] <int>] [-ID] <int> [[-ChildControls] <scriptblock>] [-Description <string>] [-Name <string>] [-AutoCaption] [<CommonParameters>] |
| [Get-CBreezePageControlContainer](#Get-CBreezePageControlContainer) | Get-CBreezePageControlContainer -Page <Page> -Type <ContainerType> [<CommonParameters>] |
| [Get-CBreezePageControlGroup](#Get-CBreezePageControlGroup) | Get-CBreezePageControlGroup -GroupCaption <string> -Page <Page> [-Position <Position>] [<CommonParameters>]  Get-CBreezePageControlGroup -GroupType <GroupType> -Page <Page> [-Position <Position>] [<CommonParameters>] |
| [Add-CBreezeParameter](#Add-CBreezeParameter) | Add-CBreezeParameter [-ID] <int> [-Name] <string> [-Type] <ParameterType> -InputObject <psobject> [-Var] [-Dimensions <string>] [-PassThru] [<CommonParameters>] |
| [New-CBreezeParameter](#New-CBreezeParameter) | New-CBreezeParameter [-ID] <int> [-Name] <string> [-Type] <ParameterType> [-Var] [-Dimensions <string>] [-PassThru] [<CommonParameters>] |
| [Set-CBreezePermission](#Set-CBreezePermission) | Set-CBreezePermission -InputObject <IHasProperties[]> -TableID <int> [-Read] [-Insert] [-Modify] [-Delete] [-PassThru] [<CommonParameters>] |
| [Add-CBreezeQuery](#Add-CBreezeQuery) | Add-CBreezeQuery [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  Add-CBreezeQuery [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [New-CBreezeQuery](#New-CBreezeQuery) | New-CBreezeQuery [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  New-CBreezeQuery [-Name] <string> [[-SubObjects] <scriptblock>] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [Add-CBreezeQueryElement](#Add-CBreezeQueryElement) | Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Column [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [-ReverseSign <bool>] [<CommonParameters>]  Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Column -DateMethod <DateMethod> [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [-ReverseSign <bool>] [<CommonParameters>]  Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Column -TotalsMethod <TotalsMethod> [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [-ReverseSign <bool>] [<CommonParameters>]  Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -DataItem -DataItemTable <int> [-DataItemLinkType <DataItemLinkType>] [-Description <string>] [-PassThru] [-Position <Position>] [-SqlJoinType <SqlJoinType>] [<CommonParameters>]  Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Filter [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [<CommonParameters>] |
| [Add-CBreezeReport](#Add-CBreezeReport) | Add-CBreezeReport [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  Add-CBreezeReport [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [New-CBreezeReport](#New-CBreezeReport) | New-CBreezeReport [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  New-CBreezeReport [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [Add-CBreezeReportLabel](#Add-CBreezeReportLabel) | Add-CBreezeReportLabel [-ID] <int> [-Name] <string> -Report <Report> [-Caption <string>] [-Description <string>] [<CommonParameters>] |
| [New-CBreezeReportLabel](#New-CBreezeReportLabel) | New-CBreezeReportLabel [-ID] <int> [-Name] <string> [-Caption <string>] [-Description <string>] [<CommonParameters>] |
| [Add-CBreezeTable](#Add-CBreezeTable) | Add-CBreezeTable [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  Add-CBreezeTable [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [New-CBreezeTable](#New-CBreezeTable) | New-CBreezeTable [-Name] <string> [[-SubObjects] <scriptblock>] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  New-CBreezeTable [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [Add-CBreezeTableField](#Add-CBreezeTableField) | Add-CBreezeTableField [[-Enabled] <bool>] [-Name] <string> [-Type] <TableFieldType> -Table <Table> [-PassThru] [-AutoCaption] [-Description <string>] [<CommonParameters>] |
| [New-CBreezeTableField](#New-CBreezeTableField) | New-CBreezeTableField [[-Enabled] <bool>] [-Name] <string> [-Type] <TableFieldType> [-AutoCaption] [-Description <string>] [<CommonParameters>] |
| [Add-CBreezeTableFieldGroup](#Add-CBreezeTableFieldGroup) | Add-CBreezeTableFieldGroup [[-ID] <int>] [[-Name] <string>] [-FieldNames] <string[]> -Table <Table> [-PassThru] [-Caption <string>] [<CommonParameters>] |
| [New-CBreezeTableFieldGroup](#New-CBreezeTableFieldGroup) | New-CBreezeTableFieldGroup [[-ID] <int>] [[-Name] <string>] [-FieldNames] <string[]> [-Caption <string>] [<CommonParameters>] |
| [Add-CBreezeTableKey](#Add-CBreezeTableKey) | Add-CBreezeTableKey [-Fields] <string[]> -Table <Table> [-PassThru] [-Clustered <bool>] [-Enabled <bool>] [-KeyGroups <string>] [-MaintainSIFTIndex <bool>] [-MaintainSQLIndex <bool>] [-SQLIndex <string[]>] [-SumIndexFields <string[]>] [<CommonParameters>] |
| [New-CBreezeTableKey](#New-CBreezeTableKey) | New-CBreezeTableKey [-Fields] <string[]> [-Clustered <bool>] [-Enabled <bool>] [-KeyGroups <string>] [-MaintainSIFTIndex <bool>] [-MaintainSQLIndex <bool>] [-SQLIndex <string[]>] [-SumIndexFields <string[]>] [<CommonParameters>] |
| [Add-CBreezeTableRelation](#Add-CBreezeTableRelation) | Add-CBreezeTableRelation [-TableName] <string> [[-FieldName] <string>] -InputObject <psobject> [-PassThru] [<CommonParameters>] |
| [Add-CBreezeVariable](#Add-CBreezeVariable) | Add-CBreezeVariable [[-Dimensions] <string>] [-Name] <string> [-Type] <VariableType> -InputObject <psobject> [-PassThru] [<CommonParameters>] |
| [New-CBreezeVariable](#New-CBreezeVariable) | New-CBreezeVariable [[-Dimensions] <string>] [-Name] <string> [-Type] <VariableType> [<CommonParameters>] |
| [Add-CBreezeXmlPort](#Add-CBreezeXmlPort) | Add-CBreezeXmlPort [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  Add-CBreezeXmlPort [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [New-CBreezeXmlPort](#New-CBreezeXmlPort) | New-CBreezeXmlPort [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]  New-CBreezeXmlPort [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>] |
| [Add-CBreezeXmlPortLink](#Add-CBreezeXmlPortLink) | Add-CBreezeXmlPortLink [-Field] <int> [-ReferenceField] <int> -InputObject <XmlPortNode> [<CommonParameters>] |
| [Set-CBreezeXmlPortNamespace](#Set-CBreezeXmlPortNamespace) | Set-CBreezeXmlPortNamespace [-Prefix] <string> [-Namespace] <string> -InputObject <XmlPort> [-PassThru] [<CommonParameters>] |
| [Add-CBreezeXmlPortNode](#Add-CBreezeXmlPortNode) | Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Element -Table -SourceTable <int> [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]  Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Element -Field [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Unbound <bool>] [-Width <int>] [<CommonParameters>]  Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Element -Text [-PassThru] [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-TextType <TextType>] [-Unbound <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]  Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Attribute -Table -SourceTable <int> [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-Occurrence <Occurrence>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]  Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Attribute -Field [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-Occurrence <Occurrence>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Width <int>] [<CommonParameters>]  Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Attribute -Text [-PassThru] [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-Occurrence <Occurrence>] [-TextType <TextType>] [-VariableName <string>] [-Width <int>] [<CommonParameters>] |
| [New-CBreezeXmlPortNode](#New-CBreezeXmlPortNode) | New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Element -Table -SourceTable <int> [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]  New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Element -Field [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Unbound <bool>] [-Width <int>] [<CommonParameters>]  New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Element -Text [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-TextType <TextType>] [-Unbound <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]  New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Attribute -Table -SourceTable <int> [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-Occurrence <Occurrence>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]  New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Attribute -Field [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-Occurrence <Occurrence>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Width <int>] [<CommonParameters>]  New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Attribute -Text [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-Occurrence <Occurrence>] [-TextType <TextType>] [-VariableName <string>] [-Width <int>] [<CommonParameters>] |
| [Test-DynamicParams](#Test-DynamicParams) | Test-DynamicParams -InputObject <psobject> [<CommonParameters>] |

<a name="Set-CBreezeAccessByPermission"></a>
## Set-CBreezeAccessByPermission
### Synopsis
Set-CBreezeAccessByPermission [-ObjectType] <AccessByPermissionObjectType> [-ObjectID] <int> -InputObject <psobject> [-Read] [-Insert] [-Modify] [-Delete] [-Execute] [<CommonParameters>]
### Syntax
```powershell
Set-CBreezeAccessByPermission [-ObjectType] <AccessByPermissionObjectType> [-ObjectID] <int> -InputObject <psobject> [-Read] [-Insert] [-Modify] [-Delete] [-Execute] [<CommonParameters>]
```
### Parameters
#### Delete
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Execute
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Insert
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Modify
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ObjectID &lt;int&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ObjectType &lt;AccessByPermissionObjectType&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Read
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Compile-CBreezeApplication"></a>
## Compile-CBreezeApplication
### Synopsis
Compile-CBreezeApplication [-Application] <Application> -Database <string> [-DevClientPath <string>] [-ServerName <string>] [<CommonParameters>]
### Syntax
```powershell
Compile-CBreezeApplication [-Application] <Application> -Database <string> [-DevClientPath <string>] [-ServerName <string>] [<CommonParameters>]
```
### Parameters
#### Application &lt;Application&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Database &lt;string&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DevClientPath &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ServerName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Export-CBreezeApplication"></a>
## Export-CBreezeApplication
### Synopsis
Export-CBreezeApplication [-InputObject] <psobject[]> [[-TextWriter] <TextWriter>] [<CommonParameters>]

Export-CBreezeApplication [-InputObject] <psobject[]> [-Path] <string> [<CommonParameters>]

Export-CBreezeApplication [-InputObject] <psobject[]> [-Stream] <Stream> [<CommonParameters>]

Export-CBreezeApplication [-InputObject] <psobject[]> -Database <string> [-DevClientPath <string>] [-ServerName <string>] [-ImportAction <string>] [-AutoCompile] [<CommonParameters>]
### Syntax
```powershell
Export-CBreezeApplication [-InputObject] <psobject[]> [[-TextWriter] <TextWriter>] [<CommonParameters>]

Export-CBreezeApplication [-InputObject] <psobject[]> [-Path] <string> [<CommonParameters>]

Export-CBreezeApplication [-InputObject] <psobject[]> [-Stream] <Stream> [<CommonParameters>]

Export-CBreezeApplication [-InputObject] <psobject[]> -Database <string> [-DevClientPath <string>] [-ServerName <string>] [-ImportAction <string>] [-AutoCompile] [<CommonParameters>]
```
### Parameters
#### AutoCompile
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ToDatabase
    Aliases                      None
    Dynamic?                     false
#### Database &lt;string&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ToDatabase
    Aliases                      None
    Dynamic?                     false
#### DevClientPath &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ToDatabase
    Aliases                      None
    Dynamic?                     false
#### ImportAction &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ToDatabase
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject[]&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      Application
    Dynamic?                     false
#### Path &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           ToPath
    Aliases                      None
    Dynamic?                     false
#### ServerName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ToDatabase
    Aliases                      None
    Dynamic?                     false
#### Stream &lt;Stream&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           ToStream
    Aliases                      None
    Dynamic?                     false
#### TextWriter &lt;TextWriter&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           ToTextWriter
    Aliases                      None
    Dynamic?                     false
<a name="Import-CBreezeApplication"></a>
## Import-CBreezeApplication
### Synopsis
Import-CBreezeApplication [-Path] <string[]> [<CommonParameters>]

Import-CBreezeApplication -Database <string> [-DevClientPath <string>] [-ServerName <string>] [-Filter <string>] [<CommonParameters>]
### Syntax
```powershell
Import-CBreezeApplication [-Path] <string[]> [<CommonParameters>]

Import-CBreezeApplication -Database <string> [-DevClientPath <string>] [-ServerName <string>] [-Filter <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.Application

### Parameters
#### Database &lt;string&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FromDatabase
    Aliases                      None
    Dynamic?                     false
#### DevClientPath &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FromDatabase
    Aliases                      None
    Dynamic?                     false
#### Filter &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FromDatabase
    Aliases                      None
    Dynamic?                     false
#### Path &lt;string[]&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       true (ByValue, ByPropertyName)
    Parameter set name           FromPath
    Aliases                      None
    Dynamic?                     false
#### ServerName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FromDatabase
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeApplication"></a>
## New-CBreezeApplication
### Synopsis
New-CBreezeApplication [[-Objects] <scriptblock>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeApplication [[-Objects] <scriptblock>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.Application

### Parameters
#### Objects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeCalcFormula"></a>
## New-CBreezeCalcFormula
### Synopsis
New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Sum [-ReverseSign] [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Average [-ReverseSign] [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> -Exist [-ReverseSign] [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> -Count [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Min [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Max [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Lookup [<CommonParameters>]
### Syntax
```powershell
New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Sum [-ReverseSign] [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Average [-ReverseSign] [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> -Exist [-ReverseSign] [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> -Count [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Min [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Max [<CommonParameters>]

New-CBreezeCalcFormula [-TableName] <string> [-FieldName] <string> -Lookup [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.CalcFormula

### Parameters
#### Average
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Average
    Aliases                      None
    Dynamic?                     false
#### Count
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Count
    Aliases                      None
    Dynamic?                     false
#### Exist
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Exist
    Aliases                      None
    Dynamic?                     false
#### FieldName &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           Sum, Average, Min, Max, Lookup
    Aliases                      None
    Dynamic?                     false
#### Lookup
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Lookup
    Aliases                      None
    Dynamic?                     false
#### Max
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Max
    Aliases                      None
    Dynamic?                     false
#### Min
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Min
    Aliases                      None
    Dynamic?                     false
#### ReverseSign
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Sum, Average, Exist
    Aliases                      None
    Dynamic?                     false
#### Sum
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Sum
    Aliases                      None
    Dynamic?                     false
#### TableName &lt;string&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeCodeLine"></a>
## Add-CBreezeCodeLine
### Synopsis
Add-CBreezeCodeLine [[-Line] <string>] [[-ArgumentList] <Object[]>] -InputObject <psobject> [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeCodeLine [[-Line] <string>] [[-ArgumentList] <Object[]>] -InputObject <psobject> [<CommonParameters>]
```
### Parameters
#### ArgumentList &lt;Object[]&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Line &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeCodeunit"></a>
## Add-CBreezeCodeunit
### Synopsis
Add-CBreezeCodeunit [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeCodeunit [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeCodeunit [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeCodeunit [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Parameters
#### Application &lt;Application&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### EventSubscriberInstance &lt;EventSubscriberInstance&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SingleInstance &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### SubType &lt;CodeunitSubType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TableNo &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TestIsolation &lt;TestIsolation&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeCodeunit"></a>
## New-CBreezeCodeunit
### Synopsis
New-CBreezeCodeunit [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeCodeunit [-Name] <string> [[-SubObjects] <scriptblock>] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeCodeunit [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeCodeunit [-Name] <string> [[-SubObjects] <scriptblock>] [-EventSubscriberInstance <EventSubscriberInstance>] [-SingleInstance <bool>] [-SubType <CodeunitSubType>] [-TableNo <int>] [-TestIsolation <TestIsolation>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.Codeunit

### Parameters
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### EventSubscriberInstance &lt;EventSubscriberInstance&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### SingleInstance &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### SubType &lt;CodeunitSubType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TableNo &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TestIsolation &lt;TestIsolation&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeColumnReportElement"></a>
## Add-CBreezeColumnReportElement
### Synopsis
Add-CBreezeColumnReportElement -ID <int> -Name <string> -Report <Report> -SourceExpr <string> [-AutoCalcField <bool>] [-AutoFormatExpr <string>] [-AutoFormatType <AutoFormatType>] [-AutoOptionCaption] [-DecimalPlacesAtLeast <int>] [-DecimalPlacesAtMost <int>] [-Description <string>] [-IncludeCaption <bool>] [-OptionString <string>] [-ParentElement <ReportElement>] [-PassThru] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeColumnReportElement -ID <int> -Name <string> -Report <Report> -SourceExpr <string> [-AutoCalcField <bool>] [-AutoFormatExpr <string>] [-AutoFormatType <AutoFormatType>] [-AutoOptionCaption] [-DecimalPlacesAtLeast <int>] [-DecimalPlacesAtMost <int>] [-Description <string>] [-IncludeCaption <bool>] [-OptionString <string>] [-ParentElement <ReportElement>] [-PassThru] [<CommonParameters>]
```
### Parameters
#### AutoCalcField &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoFormatExpr &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoFormatType &lt;AutoFormatType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoOptionCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DecimalPlacesAtLeast &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DecimalPlacesAtMost &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### IncludeCaption &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### OptionString &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ParentElement &lt;ReportElement&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Report &lt;Report&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SourceExpr &lt;string&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeCondition"></a>
## Add-CBreezeCondition
### Synopsis
Add-CBreezeCondition [-FieldName] <string> -Const [-Value] <string> -InputObject <TableRelationLine> [-PassThru] [<CommonParameters>]

Add-CBreezeCondition [-FieldName] <string> -Filter [-Value] <string> -InputObject <TableRelationLine> [-PassThru] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeCondition [-FieldName] <string> -Const [-Value] <string> -InputObject <TableRelationLine> [-PassThru] [<CommonParameters>]

Add-CBreezeCondition [-FieldName] <string> -Filter [-Value] <string> -InputObject <TableRelationLine> [-PassThru] [<CommonParameters>]
```
### Parameters
#### Const
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           Const
    Aliases                      None
    Dynamic?                     false
#### FieldName &lt;string&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Filter
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           Filter
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;TableRelationLine&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Value &lt;string&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeDataItemReportElement"></a>
## Add-CBreezeDataItemReportElement
### Synopsis
Add-CBreezeDataItemReportElement -ID <int> -Report <Report> -DataItemTable <int> [-ParentElement <ReportElement>] [-PassThru] [-CalcFields <string[]>] [-DataItemLinkReference <string>] [-DataItemTableViewKey <string>] [-DataItemTableViewOrder <Order>] [-MaxIteration <int>] [-PrintOnlyIfDetail <bool>] [-ReqFilterFields <string[]>] [-ReqFilterHeading <string>] [-Temporary <bool>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeDataItemReportElement -ID <int> -Report <Report> -DataItemTable <int> [-ParentElement <ReportElement>] [-PassThru] [-CalcFields <string[]>] [-DataItemLinkReference <string>] [-DataItemTableViewKey <string>] [-DataItemTableViewOrder <Order>] [-MaxIteration <int>] [-PrintOnlyIfDetail <bool>] [-ReqFilterFields <string[]>] [-ReqFilterHeading <string>] [-Temporary <bool>] [<CommonParameters>]
```
### Parameters
#### CalcFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataItemLinkReference &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataItemTable &lt;int&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataItemTableViewKey &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataItemTableViewOrder &lt;Order&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### MaxIteration &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ParentElement &lt;ReportElement&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PrintOnlyIfDetail &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Report &lt;Report&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReqFilterFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReqFilterHeading &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Temporary &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeEvent"></a>
## Add-CBreezeEvent
### Synopsis
Add-CBreezeEvent [-SourceID] <int> [-SourceName] <string> [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> [-PassThru] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeEvent [-SourceID] <int> [-SourceName] <string> [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> [-PassThru] [<CommonParameters>]
```
### Parameters
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    3
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SourceID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SourceName &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    4
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeEvent"></a>
## New-CBreezeEvent
### Synopsis
New-CBreezeEvent [-SourceID] <int> [-SourceName] <string> [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeEvent [-SourceID] <int> [-SourceName] <string> [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.Event

### Parameters
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    3
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SourceID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SourceName &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    4
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeFilter"></a>
## Add-CBreezeFilter
### Synopsis
Add-CBreezeFilter [-FieldName] <string> -Const [-Value] <string> -InputObject <psobject> [-OnlyMaxLimit] [-ValueIsFilter] [-PassThru] [<CommonParameters>]

Add-CBreezeFilter [-FieldName] <string> -Filter [-Value] <string> -InputObject <psobject> [-OnlyMaxLimit] [-ValueIsFilter] [-PassThru] [<CommonParameters>]

Add-CBreezeFilter [-FieldName] <string> -Field [-Value] <string> -InputObject <psobject> [-OnlyMaxLimit] [-ValueIsFilter] [-PassThru] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeFilter [-FieldName] <string> -Const [-Value] <string> -InputObject <psobject> [-OnlyMaxLimit] [-ValueIsFilter] [-PassThru] [<CommonParameters>]

Add-CBreezeFilter [-FieldName] <string> -Filter [-Value] <string> -InputObject <psobject> [-OnlyMaxLimit] [-ValueIsFilter] [-PassThru] [<CommonParameters>]

Add-CBreezeFilter [-FieldName] <string> -Field [-Value] <string> -InputObject <psobject> [-OnlyMaxLimit] [-ValueIsFilter] [-PassThru] [<CommonParameters>]
```
### Parameters
#### Const
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           Const
    Aliases                      None
    Dynamic?                     false
#### Field
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           Field
    Aliases                      None
    Dynamic?                     false
#### FieldName &lt;string&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Filter
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           Filter
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### OnlyMaxLimit
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Value &lt;string&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ValueIsFilter
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeFunction"></a>
## Add-CBreezeFunction
### Synopsis
Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-TestFunctionType <TestFunctionType>] [-HandlerFunctions <string>] [-TransactionModel <TransactionModel>] [-TryFunction <bool>] [<CommonParameters>]

Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-UpgradeFunctionType <UpgradeFunctionType>] [-TryFunction <bool>] [<CommonParameters>]

Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> -EventSubscriber -EventPublisherObjectType <ObjectType> -EventPublisherObjectID <int> -EventFunction <string> [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-EventPublisherElement <string>] [-OnMissingLicense <MissingAction>] [-OnMissingPermission <MissingAction>] [-TryFunction <bool>] [<CommonParameters>]

Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> -BusinessEvent [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-TryFunction <bool>] [<CommonParameters>]

Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> -IntegrationEvent [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-GlobalVarAccess <bool>] [-TryFunction <bool>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-TestFunctionType <TestFunctionType>] [-HandlerFunctions <string>] [-TransactionModel <TransactionModel>] [-TryFunction <bool>] [<CommonParameters>]

Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-UpgradeFunctionType <UpgradeFunctionType>] [-TryFunction <bool>] [<CommonParameters>]

Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> -EventSubscriber -EventPublisherObjectType <ObjectType> -EventPublisherObjectID <int> -EventFunction <string> [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-EventPublisherElement <string>] [-OnMissingLicense <MissingAction>] [-OnMissingPermission <MissingAction>] [-TryFunction <bool>] [<CommonParameters>]

Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> -BusinessEvent [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-TryFunction <bool>] [<CommonParameters>]

Add-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -InputObject <psobject> -IntegrationEvent [-PassThru] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-GlobalVarAccess <bool>] [-TryFunction <bool>] [<CommonParameters>]
```
### Parameters
#### BusinessEvent
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           BusinessEvent
    Aliases                      None
    Dynamic?                     false
#### EventFunction &lt;string&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### EventPublisherElement &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### EventPublisherObjectID &lt;int&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### EventPublisherObjectType &lt;ObjectType&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### EventSubscriber
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### GlobalVarAccess &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           IntegrationEvent
    Aliases                      None
    Dynamic?                     false
#### HandlerFunctions &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Test
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### IncludeSender &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           BusinessEvent, IntegrationEvent
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### IntegrationEvent
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           IntegrationEvent
    Aliases                      None
    Dynamic?                     false
#### Local &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### OnMissingLicense &lt;MissingAction&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### OnMissingPermission &lt;MissingAction&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReturnValueDataLength &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReturnValueDimensions &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReturnValueName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReturnValueType &lt;FunctionReturnValueType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TestFunctionType &lt;TestFunctionType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Test
    Aliases                      None
    Dynamic?                     false
#### TransactionModel &lt;TransactionModel&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Test
    Aliases                      None
    Dynamic?                     false
#### TryFunction &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UpgradeFunctionType &lt;UpgradeFunctionType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Upgrade
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeFunction"></a>
## New-CBreezeFunction
### Synopsis
New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-TestFunctionType <TestFunctionType>] [-HandlerFunctions <string>] [-TransactionModel <TransactionModel>] [-TryFunction <bool>] [<CommonParameters>]

New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-UpgradeFunctionType <UpgradeFunctionType>] [-TryFunction <bool>] [<CommonParameters>]

New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -EventSubscriber -EventPublisherObjectType <ObjectType> -EventPublisherObjectID <int> -EventFunction <string> [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-EventPublisherElement <string>] [-OnMissingLicense <MissingAction>] [-OnMissingPermission <MissingAction>] [-TryFunction <bool>] [<CommonParameters>]

New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -BusinessEvent [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-TryFunction <bool>] [<CommonParameters>]

New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -IntegrationEvent [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-GlobalVarAccess <bool>] [-TryFunction <bool>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-TestFunctionType <TestFunctionType>] [-HandlerFunctions <string>] [-TransactionModel <TransactionModel>] [-TryFunction <bool>] [<CommonParameters>]

New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-UpgradeFunctionType <UpgradeFunctionType>] [-TryFunction <bool>] [<CommonParameters>]

New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -EventSubscriber -EventPublisherObjectType <ObjectType> -EventPublisherObjectID <int> -EventFunction <string> [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-EventPublisherElement <string>] [-OnMissingLicense <MissingAction>] [-OnMissingPermission <MissingAction>] [-TryFunction <bool>] [<CommonParameters>]

New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -BusinessEvent [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-TryFunction <bool>] [<CommonParameters>]

New-CBreezeFunction [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -IntegrationEvent [-Local <bool>] [-ReturnValueName <string>] [-ReturnValueType <FunctionReturnValueType>] [-ReturnValueDataLength <int>] [-ReturnValueDimensions <string>] [-IncludeSender <bool>] [-GlobalVarAccess <bool>] [-TryFunction <bool>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.Function

### Parameters
#### BusinessEvent
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           BusinessEvent
    Aliases                      None
    Dynamic?                     false
#### EventFunction &lt;string&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### EventPublisherElement &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### EventPublisherObjectID &lt;int&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### EventPublisherObjectType &lt;ObjectType&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### EventSubscriber
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### GlobalVarAccess &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           IntegrationEvent
    Aliases                      None
    Dynamic?                     false
#### HandlerFunctions &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Test
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### IncludeSender &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           BusinessEvent, IntegrationEvent
    Aliases                      None
    Dynamic?                     false
#### IntegrationEvent
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           IntegrationEvent
    Aliases                      None
    Dynamic?                     false
#### Local &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### OnMissingLicense &lt;MissingAction&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### OnMissingPermission &lt;MissingAction&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           EventSubscriber
    Aliases                      None
    Dynamic?                     false
#### ReturnValueDataLength &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReturnValueDimensions &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReturnValueName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReturnValueType &lt;FunctionReturnValueType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TestFunctionType &lt;TestFunctionType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Test
    Aliases                      None
    Dynamic?                     false
#### TransactionModel &lt;TransactionModel&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Test
    Aliases                      None
    Dynamic?                     false
#### TryFunction &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UpgradeFunctionType &lt;UpgradeFunctionType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Upgrade
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeLink"></a>
## Add-CBreezeLink
### Synopsis
Add-CBreezeLink [-FieldName] <string> -Const [-Value] <string> -InputObject <psobject> [-ReferenceDataItem <string>] [-OnlyMaxLimit] [-ValueIsFilter] [<CommonParameters>]

Add-CBreezeLink [-FieldName] <string> -Filter [-Value] <string> -InputObject <psobject> [-ReferenceDataItem <string>] [-OnlyMaxLimit] [-ValueIsFilter] [<CommonParameters>]

Add-CBreezeLink [-FieldName] <string> -Field [-Value] <string> -InputObject <psobject> [-ReferenceDataItem <string>] [-OnlyMaxLimit] [-ValueIsFilter] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeLink [-FieldName] <string> -Const [-Value] <string> -InputObject <psobject> [-ReferenceDataItem <string>] [-OnlyMaxLimit] [-ValueIsFilter] [<CommonParameters>]

Add-CBreezeLink [-FieldName] <string> -Filter [-Value] <string> -InputObject <psobject> [-ReferenceDataItem <string>] [-OnlyMaxLimit] [-ValueIsFilter] [<CommonParameters>]

Add-CBreezeLink [-FieldName] <string> -Field [-Value] <string> -InputObject <psobject> [-ReferenceDataItem <string>] [-OnlyMaxLimit] [-ValueIsFilter] [<CommonParameters>]
```
### Parameters
#### Const
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           Const
    Aliases                      None
    Dynamic?                     false
#### Field
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           Field
    Aliases                      None
    Dynamic?                     false
#### FieldName &lt;string&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Filter
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           Filter
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### OnlyMaxLimit
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReferenceDataItem &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Value &lt;string&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ValueIsFilter
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeMenuSuite"></a>
## Add-CBreezeMenuSuite
### Synopsis
Add-CBreezeMenuSuite [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeMenuSuite [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeMenuSuite [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeMenuSuite [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Parameters
#### Application &lt;Application&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeMenuSuite"></a>
## New-CBreezeMenuSuite
### Synopsis
New-CBreezeMenuSuite [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeMenuSuite [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeMenuSuite [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeMenuSuite [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.MenuSuite

### Parameters
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeMenuSuiteNode"></a>
## Add-CBreezeMenuSuiteNode
### Synopsis
Add-CBreezeMenuSuiteNode [[-NextNodeID] <guid>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeMenuSuiteNode [[-NextNodeID] <guid>] [<CommonParameters>]
```
### Parameters
#### Deleted &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### MenuSuite &lt;MenuSuite&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### NextNodeID &lt;guid&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Type &lt;MenuSuiteNodeType&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeMenuSuiteNode"></a>
## New-CBreezeMenuSuiteNode
### Synopsis
New-CBreezeMenuSuiteNode [[-NextNodeID] <guid>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeMenuSuiteNode [[-NextNodeID] <guid>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.MenuSuiteNode

### Parameters
#### Deleted &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### NextNodeID &lt;guid&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Type &lt;MenuSuiteNodeType&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Set-CBreezeMLValue"></a>
## Set-CBreezeMLValue
### Synopsis
Set-CBreezeMLValue [[-Property] <string>] [-LanguageName] <string> [-Value] <string> -InputObject <psobject> [-PassThru] [<CommonParameters>]
### Syntax
```powershell
Set-CBreezeMLValue [[-Property] <string>] [-LanguageName] <string> [-Value] <string> -InputObject <psobject> [-PassThru] [<CommonParameters>]
```
### Parameters
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### LanguageName &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Property &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Value &lt;string&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Invoke-CBreezeObject"></a>
## Invoke-CBreezeObject
### Synopsis
Invoke-CBreezeObject [-Object] <Object> [-RoleTailoredClientPath <string>] [-ServerName <string>] [-ServerPort <int>] [-ServerInstance <string>] [-CompanyName <string>] [-PageMode <PageMode>] [-HideNavigationPane] [-FullScreen] [<CommonParameters>]
### Syntax
```powershell
Invoke-CBreezeObject [-Object] <Object> [-RoleTailoredClientPath <string>] [-ServerName <string>] [-ServerPort <int>] [-ServerInstance <string>] [-CompanyName <string>] [-PageMode <PageMode>] [-HideNavigationPane] [-FullScreen] [<CommonParameters>]
```
### Parameters
#### CompanyName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### FullScreen
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### HideNavigationPane
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Object &lt;Object&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PageMode &lt;PageMode&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RoleTailoredClientPath &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ServerInstance &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ServerName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ServerPort &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeOrderBy"></a>
## Add-CBreezeOrderBy
### Synopsis
Add-CBreezeOrderBy [-Column] <string> [[-Direction] <QueryOrderByDirection>] -InputObject <Query> [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeOrderBy [-Column] <string> [[-Direction] <QueryOrderByDirection>] -InputObject <Query> [<CommonParameters>]
```
### Parameters
#### Column &lt;string&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Direction &lt;QueryOrderByDirection&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;Query&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeOrderBy"></a>
## New-CBreezeOrderBy
### Synopsis
New-CBreezeOrderBy [-Column] <string> [[-Direction] <QueryOrderByDirection>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeOrderBy [-Column] <string> [[-Direction] <QueryOrderByDirection>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.QueryOrderByLine

### Parameters
#### Column &lt;string&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Direction &lt;QueryOrderByDirection&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezePage"></a>
## Add-CBreezePage
### Synopsis
Add-CBreezePage [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezePage [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezePage [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezePage [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Parameters
#### Application &lt;Application&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoSplitKey &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### CardPageID &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataCaptionExpr &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataCaptionFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DelayedInsert &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DeleteAllowed &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Editable &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### InsertAllowed &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### LinksAllowed &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ModifyAllowed &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### MultipleNewLines &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### PageType &lt;PageType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PopulateAllFields &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RefreshOnActivate &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SaveValues &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ShowFilter &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SourceTable &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SourceTableTemporary &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezePage"></a>
## New-CBreezePage
### Synopsis
New-CBreezePage [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezePage [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezePage [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezePage [-Name] <string> [[-SubObjects] <scriptblock>] [-AutoSplitKey <bool>] [-CardPageID <string>] [-DataCaptionExpr <string>] [-DataCaptionFields <string[]>] [-DelayedInsert <bool>] [-DeleteAllowed <bool>] [-Description <string>] [-Editable <bool>] [-InsertAllowed <bool>] [-LinksAllowed <bool>] [-ModifyAllowed <bool>] [-MultipleNewLines <bool>] [-PageType <PageType>] [-PopulateAllFields <bool>] [-RefreshOnActivate <bool>] [-SaveValues <bool>] [-ShowFilter <bool>] [-SourceTable <int>] [-SourceTableTemporary <bool>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.Page

### Parameters
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoSplitKey &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### CardPageID &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataCaptionExpr &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataCaptionFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DelayedInsert &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DeleteAllowed &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Editable &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### InsertAllowed &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### LinksAllowed &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ModifyAllowed &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### MultipleNewLines &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### PageType &lt;PageType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PopulateAllFields &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RefreshOnActivate &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SaveValues &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ShowFilter &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SourceTable &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SourceTableTemporary &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezePageAction"></a>
## Add-CBreezePageAction
### Synopsis
Add-CBreezePageAction [-ID] <int> [[-Caption] <string>] [[-Image] <string>] -InputObject <psobject> [-PassThru] [-Position <Position>] [-Description <string>] [-Ellipsis <bool>] [-Enabled <string>] [-InFooterBar <bool>] [-Name <string>] [-Promoted <bool>] [-PromotedCategory <PromotedCategory>] [-PromotedIsBig <bool>] [-RunObjectType <RunObjectType>] [-RunObjectID <int>] [-RunPageMode <RunPageMode>] [-RunPageOnRec <bool>] [-RunPageViewKey <string>] [-RunPageViewOrder <Order>] [-Scope <PageActionScope>] [-ShortcutKey <string>] [-Visible <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezePageAction [-ID] <int> [[-Caption] <string>] [[-Image] <string>] -InputObject <psobject> [-PassThru] [-Position <Position>] [-Description <string>] [-Ellipsis <bool>] [-Enabled <string>] [-InFooterBar <bool>] [-Name <string>] [-Promoted <bool>] [-PromotedCategory <PromotedCategory>] [-PromotedIsBig <bool>] [-RunObjectType <RunObjectType>] [-RunObjectID <int>] [-RunPageMode <RunPageMode>] [-RunPageOnRec <bool>] [-RunPageViewKey <string>] [-RunPageViewOrder <Order>] [-Scope <PageActionScope>] [-ShortcutKey <string>] [-Visible <string>] [<CommonParameters>]
```
### Parameters
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Ellipsis &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Enabled &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Image &lt;string&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InFooterBar &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Position &lt;Position&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Promoted &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PromotedCategory &lt;PromotedCategory&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PromotedIsBig &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunObjectID &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunObjectType &lt;RunObjectType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunPageMode &lt;RunPageMode&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunPageOnRec &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunPageViewKey &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunPageViewOrder &lt;Order&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Scope &lt;PageActionScope&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ShortcutKey &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Visible &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezePageAction"></a>
## New-CBreezePageAction
### Synopsis
New-CBreezePageAction [-ID] <int> [[-Caption] <string>] [[-Image] <string>] [-Description <string>] [-Ellipsis <bool>] [-Enabled <string>] [-InFooterBar <bool>] [-Name <string>] [-Promoted <bool>] [-PromotedCategory <PromotedCategory>] [-PromotedIsBig <bool>] [-RunObjectType <RunObjectType>] [-RunObjectID <int>] [-RunPageMode <RunPageMode>] [-RunPageOnRec <bool>] [-RunPageViewKey <string>] [-RunPageViewOrder <Order>] [-Scope <PageActionScope>] [-ShortcutKey <string>] [-Visible <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezePageAction [-ID] <int> [[-Caption] <string>] [[-Image] <string>] [-Description <string>] [-Ellipsis <bool>] [-Enabled <string>] [-InFooterBar <bool>] [-Name <string>] [-Promoted <bool>] [-PromotedCategory <PromotedCategory>] [-PromotedIsBig <bool>] [-RunObjectType <RunObjectType>] [-RunObjectID <int>] [-RunPageMode <RunPageMode>] [-RunPageOnRec <bool>] [-RunPageViewKey <string>] [-RunPageViewOrder <Order>] [-Scope <PageActionScope>] [-ShortcutKey <string>] [-Visible <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.PageAction

### Parameters
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Ellipsis &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Enabled &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Image &lt;string&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InFooterBar &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Promoted &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PromotedCategory &lt;PromotedCategory&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PromotedIsBig &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunObjectID &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunObjectType &lt;RunObjectType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunPageMode &lt;RunPageMode&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunPageOnRec &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunPageViewKey &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RunPageViewOrder &lt;Order&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Scope &lt;PageActionScope&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ShortcutKey &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Visible &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezePageActionContainer"></a>
## Add-CBreezePageActionContainer
### Synopsis
Add-CBreezePageActionContainer [-ID] <int> [-ContainerType] <ActionContainerType> [[-ChildActions] <scriptblock>] -InputObject <psobject> [-PassThru] [-Position <Position>] [-Description <string>] [-Name <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezePageActionContainer [-ID] <int> [-ContainerType] <ActionContainerType> [[-ChildActions] <scriptblock>] -InputObject <psobject> [-PassThru] [-Position <Position>] [-Description <string>] [-Name <string>] [<CommonParameters>]
```
### Parameters
#### ChildActions &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ContainerType &lt;ActionContainerType&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Position &lt;Position&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Get-CBreezePageActionContainer"></a>
## Get-CBreezePageActionContainer
### Synopsis
Get-CBreezePageActionContainer -Page <Page> -Type <ActionContainerType> [<CommonParameters>]
### Syntax
```powershell
Get-CBreezePageActionContainer -Page <Page> -Type <ActionContainerType> [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.PageActionContainer

### Parameters
#### Page &lt;Page&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Type &lt;ActionContainerType&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezePageActionContainer"></a>
## New-CBreezePageActionContainer
### Synopsis
New-CBreezePageActionContainer [-ID] <int> [-ContainerType] <ActionContainerType> [[-ChildActions] <scriptblock>] [-Description <string>] [-Name <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezePageActionContainer [-ID] <int> [-ContainerType] <ActionContainerType> [[-ChildActions] <scriptblock>] [-Description <string>] [-Name <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.PageActionContainer

### Parameters
#### ChildActions &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ContainerType &lt;ActionContainerType&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezePageActionGroup"></a>
## Add-CBreezePageActionGroup
### Synopsis
Add-CBreezePageActionGroup [-ID] <int> [[-Caption] <string>] [[-ChildActions] <scriptblock>] -InputObject <psobject> [-PassThru] [-Position <Position>] [-Description <string>] [-Enabled <string>] [-Image <string>] [-Name <string>] [-Visible <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezePageActionGroup [-ID] <int> [[-Caption] <string>] [[-ChildActions] <scriptblock>] -InputObject <psobject> [-PassThru] [-Position <Position>] [-Description <string>] [-Enabled <string>] [-Image <string>] [-Name <string>] [-Visible <string>] [<CommonParameters>]
```
### Parameters
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ChildActions &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Enabled &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Image &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Position &lt;Position&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Visible &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Get-CBreezePageActionGroup"></a>
## Get-CBreezePageActionGroup
### Synopsis
Get-CBreezePageActionGroup -Caption <string> -ContainerType <ActionContainerType> -Page <Page> [-Position <Position>] [<CommonParameters>]
### Syntax
```powershell
Get-CBreezePageActionGroup -Caption <string> -ContainerType <ActionContainerType> -Page <Page> [-Position <Position>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.PageActionGroup

### Parameters
#### Caption &lt;string&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ContainerType &lt;ActionContainerType&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Page &lt;Page&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Position &lt;Position&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezePageActionGroup"></a>
## New-CBreezePageActionGroup
### Synopsis
New-CBreezePageActionGroup [-ID] <int> [[-Caption] <string>] [[-ChildActions] <scriptblock>] [-Description <string>] [-Enabled <string>] [-Image <string>] [-Name <string>] [-Visible <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezePageActionGroup [-ID] <int> [[-Caption] <string>] [[-ChildActions] <scriptblock>] [-Description <string>] [-Enabled <string>] [-Image <string>] [-Name <string>] [-Visible <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.PageActionGroup

### Parameters
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ChildActions &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Enabled &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Image &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Visible &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezePageActionSeparator"></a>
## Add-CBreezePageActionSeparator
### Synopsis
Add-CBreezePageActionSeparator [-ID] <int> -InputObject <psobject> [-PassThru] [-Position <Position>] [-Caption <string>] [-IsHeader <bool>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezePageActionSeparator [-ID] <int> -InputObject <psobject> [-PassThru] [-Position <Position>] [-Caption <string>] [-IsHeader <bool>] [<CommonParameters>]
```
### Parameters
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### IsHeader &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Position &lt;Position&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezePageActionSeparator"></a>
## New-CBreezePageActionSeparator
### Synopsis
New-CBreezePageActionSeparator [-ID] <int> [-Caption <string>] [-IsHeader <bool>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezePageActionSeparator [-ID] <int> [-Caption <string>] [-IsHeader <bool>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.PageActionSeparator

### Parameters
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### IsHeader &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezePageControl"></a>
## Add-CBreezePageControl
### Synopsis
Add-CBreezePageControl [[-Width] <int>] [-ID] <int> [[-ChildControls] <scriptblock>] -InputObject <psobject> [-PassThru] [-Description <string>] [-Name <string>] [-AutoCaption] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezePageControl [[-Width] <int>] [-ID] <int> [[-ChildControls] <scriptblock>] -InputObject <psobject> [-PassThru] [-Description <string>] [-Name <string>] [-AutoCaption] [<CommonParameters>]
```
### Parameters
#### AssistEdit &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoFormatExpr &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### AutoFormatType &lt;AutoFormatType&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### BlankNumbers &lt;BlankNumbers&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### BlankZero &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### CaptionClass &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### CharAllowed &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ChildControls &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ClosingDates &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ColumnSpan &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ControlAddIn &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### DateFormula &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### DecimalPlacesAtLeast &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### DecimalPlacesAtMost &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DrillDown &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### DrillDownPageID &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Editable &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Enabled &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ExtendedDataType &lt;ExtendedDataType&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### HideValue &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Image &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Importance &lt;Importance&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Lookup &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### LookupPageID &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### MaxValue &lt;Object&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### MinValue &lt;Object&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### MultiLine &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Name &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### NotBlank &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Numeric &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Position &lt;Position&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### QuickEntry &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### RowSpan &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ShowCaption &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ShowMandatory &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### SourceExpr &lt;string&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Style &lt;Style&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### StyleExpr &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Title &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Type &lt;PageControlType&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ValuesAllowed &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Visible &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Width &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
<a name="New-CBreezePageControl"></a>
## New-CBreezePageControl
### Synopsis
New-CBreezePageControl [[-Width] <int>] [-ID] <int> [[-ChildControls] <scriptblock>] [-Description <string>] [-Name <string>] [-AutoCaption] [<CommonParameters>]
### Syntax
```powershell
New-CBreezePageControl [[-Width] <int>] [-ID] <int> [[-ChildControls] <scriptblock>] [-Description <string>] [-Name <string>] [-AutoCaption] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.PageControl

### Parameters
#### AssistEdit &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoFormatExpr &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### AutoFormatType &lt;AutoFormatType&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### BlankNumbers &lt;BlankNumbers&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### BlankZero &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### CaptionClass &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### CharAllowed &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ChildControls &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ClosingDates &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ColumnSpan &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ControlAddIn &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### DateFormula &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### DecimalPlacesAtLeast &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### DecimalPlacesAtMost &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DrillDown &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### DrillDownPageID &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Editable &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Enabled &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ExtendedDataType &lt;ExtendedDataType&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### HideValue &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Image &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Importance &lt;Importance&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Lookup &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### LookupPageID &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### MaxValue &lt;Object&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### MinValue &lt;Object&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### MultiLine &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Name &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### NotBlank &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Numeric &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### QuickEntry &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### RowSpan &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ShowCaption &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ShowMandatory &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### SourceExpr &lt;string&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Style &lt;Style&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### StyleExpr &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Title &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Type &lt;PageControlType&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ValuesAllowed &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Visible &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### Width &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
<a name="Get-CBreezePageControlContainer"></a>
## Get-CBreezePageControlContainer
### Synopsis
Get-CBreezePageControlContainer -Page <Page> -Type <ContainerType> [<CommonParameters>]
### Syntax
```powershell
Get-CBreezePageControlContainer -Page <Page> -Type <ContainerType> [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.ContainerPageControl

### Parameters
#### Page &lt;Page&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Type &lt;ContainerType&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Get-CBreezePageControlGroup"></a>
## Get-CBreezePageControlGroup
### Synopsis
Get-CBreezePageControlGroup -GroupCaption <string> -Page <Page> [-Position <Position>] [<CommonParameters>]

Get-CBreezePageControlGroup -GroupType <GroupType> -Page <Page> [-Position <Position>] [<CommonParameters>]
### Syntax
```powershell
Get-CBreezePageControlGroup -GroupCaption <string> -Page <Page> [-Position <Position>] [<CommonParameters>]

Get-CBreezePageControlGroup -GroupType <GroupType> -Page <Page> [-Position <Position>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.GroupPageControl

### Parameters
#### GroupCaption &lt;string&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ByGroupCaption
    Aliases                      None
    Dynamic?                     false
#### GroupType &lt;GroupType&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ByGroupType
    Aliases                      None
    Dynamic?                     false
#### Page &lt;Page&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Position &lt;Position&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeParameter"></a>
## Add-CBreezeParameter
### Synopsis
Add-CBreezeParameter [-ID] <int> [-Name] <string> [-Type] <ParameterType> -InputObject <psobject> [-Var] [-Dimensions <string>] [-PassThru] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeParameter [-ID] <int> [-Name] <string> [-Type] <ParameterType> -InputObject <psobject> [-Var] [-Dimensions <string>] [-PassThru] [<CommonParameters>]
```
### Parameters
#### Dimensions &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Type &lt;ParameterType&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Var
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeParameter"></a>
## New-CBreezeParameter
### Synopsis
New-CBreezeParameter [-ID] <int> [-Name] <string> [-Type] <ParameterType> [-Var] [-Dimensions <string>] [-PassThru] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeParameter [-ID] <int> [-Name] <string> [-Type] <ParameterType> [-Var] [-Dimensions <string>] [-PassThru] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.Parameter

### Parameters
#### Dimensions &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Type &lt;ParameterType&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Var
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Set-CBreezePermission"></a>
## Set-CBreezePermission
### Synopsis
Set-CBreezePermission -InputObject <IHasProperties[]> -TableID <int> [-Read] [-Insert] [-Modify] [-Delete] [-PassThru] [<CommonParameters>]
### Syntax
```powershell
Set-CBreezePermission -InputObject <IHasProperties[]> -TableID <int> [-Read] [-Insert] [-Modify] [-Delete] [-PassThru] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.IHasProperties

### Parameters
#### Delete
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;IHasProperties[]&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Insert
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Modify
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Read
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TableID &lt;int&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeQuery"></a>
## Add-CBreezeQuery
### Synopsis
Add-CBreezeQuery [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeQuery [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeQuery [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeQuery [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Parameters
#### Application &lt;Application&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReadState &lt;ReadState&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### TopNoOfRows &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeQuery"></a>
## New-CBreezeQuery
### Synopsis
New-CBreezeQuery [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeQuery [-Name] <string> [[-SubObjects] <scriptblock>] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeQuery [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeQuery [-Name] <string> [[-SubObjects] <scriptblock>] [-Description <string>] [-ReadState <ReadState>] [-TopNoOfRows <int>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.Query

### Parameters
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### ReadState &lt;ReadState&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### TopNoOfRows &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeQueryElement"></a>
## Add-CBreezeQueryElement
### Synopsis
Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Column [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [-ReverseSign <bool>] [<CommonParameters>]

Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Column -DateMethod <DateMethod> [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [-ReverseSign <bool>] [<CommonParameters>]

Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Column -TotalsMethod <TotalsMethod> [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [-ReverseSign <bool>] [<CommonParameters>]

Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -DataItem -DataItemTable <int> [-DataItemLinkType <DataItemLinkType>] [-Description <string>] [-PassThru] [-Position <Position>] [-SqlJoinType <SqlJoinType>] [<CommonParameters>]

Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Filter [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Column [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [-ReverseSign <bool>] [<CommonParameters>]

Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Column -DateMethod <DateMethod> [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [-ReverseSign <bool>] [<CommonParameters>]

Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Column -TotalsMethod <TotalsMethod> [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [-ReverseSign <bool>] [<CommonParameters>]

Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -DataItem -DataItemTable <int> [-DataItemLinkType <DataItemLinkType>] [-Description <string>] [-PassThru] [-Position <Position>] [-SqlJoinType <SqlJoinType>] [<CommonParameters>]

Add-CBreezeQueryElement [-ID] <int> [[-Name] <string>] -Filter [-DataSource <string>] [-Description <string>] [-PassThru] [-Position <Position>] [<CommonParameters>]
```
### Parameters
#### Column
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ColumnWithNoMethod, ColumnWithDateMethod, ColumnWithTotalsMethod
    Aliases                      None
    Dynamic?                     false
#### DataItem
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           DataItem
    Aliases                      None
    Dynamic?                     false
#### DataItemLinkType &lt;DataItemLinkType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           DataItem
    Aliases                      None
    Dynamic?                     false
#### DataItemTable &lt;int&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           DataItem
    Aliases                      None
    Dynamic?                     false
#### DataSource &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ColumnWithNoMethod, ColumnWithDateMethod, ColumnWithTotalsMethod, Filter
    Aliases                      None
    Dynamic?                     false
#### DateMethod &lt;DateMethod&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ColumnWithDateMethod
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Filter
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           Filter
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Position &lt;Position&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReverseSign &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ColumnWithNoMethod, ColumnWithDateMethod, ColumnWithTotalsMethod
    Aliases                      None
    Dynamic?                     false
#### SqlJoinType &lt;SqlJoinType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           DataItem
    Aliases                      None
    Dynamic?                     false
#### TotalsMethod &lt;TotalsMethod&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           ColumnWithTotalsMethod
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeReport"></a>
## Add-CBreezeReport
### Synopsis
Add-CBreezeReport [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeReport [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeReport [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeReport [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Parameters
#### Application &lt;Application&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DefaultLayout &lt;DefaultLayout&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### EnableExternalAssemblies &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### EnableExternalImages &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### EnableHyperlinks &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### PaperSourceDefaultPage &lt;PaperSource&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PaperSourceFirstPage &lt;PaperSource&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PaperSourceLastPage &lt;PaperSource&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PreviewMode &lt;PreviewMode&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ProcessingOnly &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ShowPrintStatus &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### TransactionType &lt;TransactionType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UseRequestPage &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UseSystemPrinter &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### WordMergeDataItem &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeReport"></a>
## New-CBreezeReport
### Synopsis
New-CBreezeReport [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeReport [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeReport [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeReport [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultLayout <DefaultLayout>] [-Description <string>] [-EnableExternalAssemblies <bool>] [-EnableExternalImages <bool>] [-EnableHyperlinks <bool>] [-PaperSourceDefaultPage <PaperSource>] [-PaperSourceFirstPage <PaperSource>] [-PaperSourceLastPage <PaperSource>] [-PreviewMode <PreviewMode>] [-ProcessingOnly <bool>] [-ShowPrintStatus <bool>] [-TransactionType <TransactionType>] [-UseRequestPage <bool>] [-UseSystemPrinter <bool>] [-WordMergeDataItem <string>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.Report

### Parameters
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DefaultLayout &lt;DefaultLayout&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### EnableExternalAssemblies &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### EnableExternalImages &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### EnableHyperlinks &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### PaperSourceDefaultPage &lt;PaperSource&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PaperSourceFirstPage &lt;PaperSource&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PaperSourceLastPage &lt;PaperSource&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PreviewMode &lt;PreviewMode&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ProcessingOnly &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ShowPrintStatus &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### TransactionType &lt;TransactionType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UseRequestPage &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UseSystemPrinter &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### WordMergeDataItem &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeReportLabel"></a>
## Add-CBreezeReportLabel
### Synopsis
Add-CBreezeReportLabel [-ID] <int> [-Name] <string> -Report <Report> [-Caption <string>] [-Description <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeReportLabel [-ID] <int> [-Name] <string> -Report <Report> [-Caption <string>] [-Description <string>] [<CommonParameters>]
```
### Parameters
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Report &lt;Report&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeReportLabel"></a>
## New-CBreezeReportLabel
### Synopsis
New-CBreezeReportLabel [-ID] <int> [-Name] <string> [-Caption <string>] [-Description <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeReportLabel [-ID] <int> [-Name] <string> [-Caption <string>] [-Description <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.ReportLabel

### Parameters
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeTable"></a>
## Add-CBreezeTable
### Synopsis
Add-CBreezeTable [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeTable [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeTable [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeTable [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Parameters
#### Application &lt;Application&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataCaptionFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataPerCompany &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DrillDownPageID &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ExternalName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ExternalSchema &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### LinkedInTransaction &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### LinkedObject &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### LookupPageID &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PasteIsValid &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### TableType &lt;TableType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeTable"></a>
## New-CBreezeTable
### Synopsis
New-CBreezeTable [-Name] <string> [[-SubObjects] <scriptblock>] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeTable [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeTable [-Name] <string> [[-SubObjects] <scriptblock>] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeTable [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-DataCaptionFields <string[]>] [-DataPerCompany <bool>] [-Description <string>] [-DrillDownPageID <int>] [-ExternalName <string>] [-ExternalSchema <string>] [-LinkedInTransaction <bool>] [-LinkedObject <bool>] [-LookupPageID <int>] [-PasteIsValid <bool>] [-TableType <TableType>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.Table

### Parameters
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataCaptionFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataPerCompany &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DrillDownPageID &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ExternalName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ExternalSchema &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### LinkedInTransaction &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### LinkedObject &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### LookupPageID &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### PasteIsValid &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### TableType &lt;TableType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeTableField"></a>
## Add-CBreezeTableField
### Synopsis
Add-CBreezeTableField [[-Enabled] <bool>] [-Name] <string> [-Type] <TableFieldType> -Table <Table> [-PassThru] [-AutoCaption] [-Description <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeTableField [[-Enabled] <bool>] [-Name] <string> [-Type] <TableFieldType> -Table <Table> [-PassThru] [-AutoCaption] [-Description <string>] [<CommonParameters>]
```
### Parameters
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Enabled &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Table &lt;Table&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Type &lt;TableFieldType&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeTableField"></a>
## New-CBreezeTableField
### Synopsis
New-CBreezeTableField [[-Enabled] <bool>] [-Name] <string> [-Type] <TableFieldType> [-AutoCaption] [-Description <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeTableField [[-Enabled] <bool>] [-Name] <string> [-Type] <TableFieldType> [-AutoCaption] [-Description <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.TableField

### Parameters
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Description &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Enabled &lt;bool&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Type &lt;TableFieldType&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeTableFieldGroup"></a>
## Add-CBreezeTableFieldGroup
### Synopsis
Add-CBreezeTableFieldGroup [[-ID] <int>] [[-Name] <string>] [-FieldNames] <string[]> -Table <Table> [-PassThru] [-Caption <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeTableFieldGroup [[-ID] <int>] [[-Name] <string>] [-FieldNames] <string[]> -Table <Table> [-PassThru] [-Caption <string>] [<CommonParameters>]
```
### Parameters
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### FieldNames &lt;string[]&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Table &lt;Table&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeTableFieldGroup"></a>
## New-CBreezeTableFieldGroup
### Synopsis
New-CBreezeTableFieldGroup [[-ID] <int>] [[-Name] <string>] [-FieldNames] <string[]> [-Caption <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeTableFieldGroup [[-ID] <int>] [[-Name] <string>] [-FieldNames] <string[]> [-Caption <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.TableFieldGroup

### Parameters
#### Caption &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### FieldNames &lt;string[]&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeTableKey"></a>
## Add-CBreezeTableKey
### Synopsis
Add-CBreezeTableKey [-Fields] <string[]> -Table <Table> [-PassThru] [-Clustered <bool>] [-Enabled <bool>] [-KeyGroups <string>] [-MaintainSIFTIndex <bool>] [-MaintainSQLIndex <bool>] [-SQLIndex <string[]>] [-SumIndexFields <string[]>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeTableKey [-Fields] <string[]> -Table <Table> [-PassThru] [-Clustered <bool>] [-Enabled <bool>] [-KeyGroups <string>] [-MaintainSIFTIndex <bool>] [-MaintainSQLIndex <bool>] [-SQLIndex <string[]>] [-SumIndexFields <string[]>] [<CommonParameters>]
```
### Parameters
#### Clustered &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Enabled &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Fields &lt;string[]&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### KeyGroups &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### MaintainSIFTIndex &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### MaintainSQLIndex &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SQLIndex &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SumIndexFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Table &lt;Table&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeTableKey"></a>
## New-CBreezeTableKey
### Synopsis
New-CBreezeTableKey [-Fields] <string[]> [-Clustered <bool>] [-Enabled <bool>] [-KeyGroups <string>] [-MaintainSIFTIndex <bool>] [-MaintainSQLIndex <bool>] [-SQLIndex <string[]>] [-SumIndexFields <string[]>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeTableKey [-Fields] <string[]> [-Clustered <bool>] [-Enabled <bool>] [-KeyGroups <string>] [-MaintainSIFTIndex <bool>] [-MaintainSQLIndex <bool>] [-SQLIndex <string[]>] [-SumIndexFields <string[]>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.TableKey

### Parameters
#### Clustered &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Enabled &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Fields &lt;string[]&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### KeyGroups &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### MaintainSIFTIndex &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### MaintainSQLIndex &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SQLIndex &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SumIndexFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeTableRelation"></a>
## Add-CBreezeTableRelation
### Synopsis
Add-CBreezeTableRelation [-TableName] <string> [[-FieldName] <string>] -InputObject <psobject> [-PassThru] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeTableRelation [-TableName] <string> [[-FieldName] <string>] -InputObject <psobject> [-PassThru] [<CommonParameters>]
```
### Parameters
#### FieldName &lt;string&gt;
    
    Required?                    false
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TableName &lt;string&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeVariable"></a>
## Add-CBreezeVariable
### Synopsis
Add-CBreezeVariable [[-Dimensions] <string>] [-Name] <string> [-Type] <VariableType> -InputObject <psobject> [-PassThru] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeVariable [[-Dimensions] <string>] [-Name] <string> [-Type] <VariableType> -InputObject <psobject> [-PassThru] [<CommonParameters>]
```
### Parameters
#### Dimensions &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Type &lt;VariableType&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeVariable"></a>
## New-CBreezeVariable
### Synopsis
New-CBreezeVariable [[-Dimensions] <string>] [-Name] <string> [-Type] <VariableType> [<CommonParameters>]
### Syntax
```powershell
New-CBreezeVariable [[-Dimensions] <string>] [-Name] <string> [-Type] <VariableType> [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.Variable

### Parameters
#### Dimensions &lt;string&gt;
    
    Required?                    false
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     true
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Type &lt;VariableType&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeXmlPort"></a>
## Add-CBreezeXmlPort
### Synopsis
Add-CBreezeXmlPort [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeXmlPort [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeXmlPort [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

Add-CBreezeXmlPort [-Name] <string> [[-SubObjects] <scriptblock>] -Application <Application> [-PassThru] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Parameters
#### Application &lt;Application&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DefaultFieldsValidation &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DefaultNamespace &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Direction &lt;Direction&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Encoding &lt;XmlPortEncoding&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### FieldDelimiter &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### FieldSeparator &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### FileName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Format &lt;XmlPortFormat&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### FormatEvaluate &lt;FormatEvaluate&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### InlineSchema &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PreserveWhitespace &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RecordSeparator &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### TableSeparator &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TextEncoding &lt;TextEncoding&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TransactionType &lt;TransactionType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UseDefaultNamespace &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UseLax &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UseRequestPage &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### XmlVersionNo &lt;XmlVersionNo&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeXmlPort"></a>
## New-CBreezeXmlPort
### Synopsis
New-CBreezeXmlPort [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeXmlPort [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeXmlPort [-ID] <int> [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]

New-CBreezeXmlPort [-Name] <string> [[-SubObjects] <scriptblock>] [-DefaultFieldsValidation <bool>] [-DefaultNamespace <string>] [-Direction <Direction>] [-Encoding <XmlPortEncoding>] [-FieldDelimiter <string>] [-FieldSeparator <string>] [-FileName <string>] [-Format <XmlPortFormat>] [-FormatEvaluate <FormatEvaluate>] [-InlineSchema <bool>] [-PreserveWhitespace <bool>] [-RecordSeparator <string>] [-TableSeparator <string>] [-TextEncoding <TextEncoding>] [-TransactionType <TransactionType>] [-UseDefaultNamespace <bool>] [-UseLax <bool>] [-UseRequestPage <bool>] [-XmlVersionNo <XmlVersionNo>] [-AutoCaption] [-DateTime <datetime>] [-Modified] [-VersionList <string>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.XmlPort

### Parameters
#### AutoCaption
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DateTime &lt;datetime&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DefaultFieldsValidation &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DefaultNamespace &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Direction &lt;Direction&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Encoding &lt;XmlPortEncoding&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### FieldDelimiter &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### FieldSeparator &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### FileName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Format &lt;XmlPortFormat&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### FormatEvaluate &lt;FormatEvaluate&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ID &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           WithID
    Aliases                      None
    Dynamic?                     false
#### InlineSchema &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Modified
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### PreserveWhitespace &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### RecordSeparator &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### SubObjects &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           WithID, WithoutID
    Aliases                      None
    Dynamic?                     false
#### TableSeparator &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TextEncoding &lt;TextEncoding&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### TransactionType &lt;TransactionType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UseDefaultNamespace &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UseLax &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### UseRequestPage &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### VersionList &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### XmlVersionNo &lt;XmlVersionNo&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeXmlPortLink"></a>
## Add-CBreezeXmlPortLink
### Synopsis
Add-CBreezeXmlPortLink [-Field] <int> [-ReferenceField] <int> -InputObject <XmlPortNode> [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeXmlPortLink [-Field] <int> [-ReferenceField] <int> -InputObject <XmlPortNode> [<CommonParameters>]
```
### Parameters
#### Field &lt;int&gt;
    
    Required?                    true
    Position?                    0
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;XmlPortNode&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReferenceField &lt;int&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Set-CBreezeXmlPortNamespace"></a>
## Set-CBreezeXmlPortNamespace
### Synopsis
Set-CBreezeXmlPortNamespace [-Prefix] <string> [-Namespace] <string> -InputObject <XmlPort> [-PassThru] [<CommonParameters>]
### Syntax
```powershell
Set-CBreezeXmlPortNamespace [-Prefix] <string> [-Namespace] <string> -InputObject <XmlPort> [-PassThru] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.XmlPort

### Parameters
#### InputObject &lt;XmlPort&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Namespace &lt;string&gt;
    
    Required?                    true
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Prefix &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<a name="Add-CBreezeXmlPortNode"></a>
## Add-CBreezeXmlPortNode
### Synopsis
Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Element -Table -SourceTable <int> [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Element -Field [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Unbound <bool>] [-Width <int>] [<CommonParameters>]

Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Element -Text [-PassThru] [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-TextType <TextType>] [-Unbound <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Attribute -Table -SourceTable <int> [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-Occurrence <Occurrence>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Attribute -Field [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-Occurrence <Occurrence>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Width <int>] [<CommonParameters>]

Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Attribute -Text [-PassThru] [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-Occurrence <Occurrence>] [-TextType <TextType>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]
### Syntax
```powershell
Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Element -Table -SourceTable <int> [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Element -Field [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Unbound <bool>] [-Width <int>] [<CommonParameters>]

Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Element -Text [-PassThru] [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-TextType <TextType>] [-Unbound <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Attribute -Table -SourceTable <int> [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-Occurrence <Occurrence>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Attribute -Field [-PassThru] [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-Occurrence <Occurrence>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Width <int>] [<CommonParameters>]

Add-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -InputObject <psobject> -Attribute -Text [-PassThru] [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-Occurrence <Occurrence>] [-TextType <TextType>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.XmlPortNode

### Parameters
#### Attribute
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableAttribute, FieldAttribute, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### AutoCalcField &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute
    Aliases                      None
    Dynamic?                     false
#### AutoReplace &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### AutoSave &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### AutoUpdate &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### CalcFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### ChildNodes &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataType &lt;XmlPortNodeDataType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute, TextElement, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### Element
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, FieldElement, TextElement
    Aliases                      None
    Dynamic?                     false
#### Field
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute
    Aliases                      None
    Dynamic?                     false
#### FieldValidate &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute
    Aliases                      None
    Dynamic?                     false
#### ID &lt;guid&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### LinkTable &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### LinkTableForceInsert &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### MaxOccurs &lt;MaxOccurs&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, FieldElement, TextElement
    Aliases                      None
    Dynamic?                     false
#### MinOccurs &lt;MinOccurs&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, FieldElement, TextElement
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### NamespacePrefix &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, FieldElement, TextElement
    Aliases                      None
    Dynamic?                     false
#### Occurrence &lt;Occurrence&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableAttribute, FieldAttribute, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### PassThru
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### Position &lt;Position&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReqFilterFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### SourceFieldName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute
    Aliases                      None
    Dynamic?                     false
#### SourceFieldTableVariableName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute
    Aliases                      None
    Dynamic?                     false
#### SourceTable &lt;int&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### SourceTableViewKey &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### SourceTableViewOrder &lt;Order&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### Table
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### Temporary &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### Text
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TextElement, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### TextType &lt;TextType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TextElement, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### Unbound &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, TextElement
    Aliases                      None
    Dynamic?                     false
#### VariableName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute, TextElement, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### Width &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute, FieldElement, FieldAttribute, TextElement, TextAttribute
    Aliases                      None
    Dynamic?                     false
<a name="New-CBreezeXmlPortNode"></a>
## New-CBreezeXmlPortNode
### Synopsis
New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Element -Table -SourceTable <int> [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Element -Field [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Unbound <bool>] [-Width <int>] [<CommonParameters>]

New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Element -Text [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-TextType <TextType>] [-Unbound <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Attribute -Table -SourceTable <int> [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-Occurrence <Occurrence>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Attribute -Field [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-Occurrence <Occurrence>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Width <int>] [<CommonParameters>]

New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Attribute -Text [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-Occurrence <Occurrence>] [-TextType <TextType>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]
### Syntax
```powershell
New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Element -Table -SourceTable <int> [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Element -Field [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Unbound <bool>] [-Width <int>] [<CommonParameters>]

New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Element -Text [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-MaxOccurs <MaxOccurs>] [-MinOccurs <MinOccurs>] [-NamespacePrefix <string>] [-TextType <TextType>] [-Unbound <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Attribute -Table -SourceTable <int> [-ID <guid>] [-Position <Position>] [-AutoReplace <bool>] [-AutoSave <bool>] [-AutoUpdate <bool>] [-CalcFields <string[]>] [-LinkTable <string>] [-LinkTableForceInsert <bool>] [-Occurrence <Occurrence>] [-ReqFilterFields <string[]>] [-SourceTableViewKey <string>] [-SourceTableViewOrder <Order>] [-Temporary <bool>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]

New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Attribute -Field [-ID <guid>] [-Position <Position>] [-AutoCalcField <bool>] [-DataType <XmlPortNodeDataType>] [-FieldValidate <bool>] [-Occurrence <Occurrence>] [-SourceFieldName <string>] [-SourceFieldTableVariableName <string>] [-Width <int>] [<CommonParameters>]

New-CBreezeXmlPortNode [-Name] <string> [[-ChildNodes] <scriptblock>] -Attribute -Text [-ID <guid>] [-Position <Position>] [-DataType <XmlPortNodeDataType>] [-Occurrence <Occurrence>] [-TextType <TextType>] [-VariableName <string>] [-Width <int>] [<CommonParameters>]
```
### Output Type(s)

- UncommonSense.CBreeze.Core.XmlPortNode

### Parameters
#### Attribute
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableAttribute, FieldAttribute, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### AutoCalcField &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute
    Aliases                      None
    Dynamic?                     false
#### AutoReplace &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### AutoSave &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### AutoUpdate &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### CalcFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### ChildNodes &lt;scriptblock&gt;
    
    Required?                    false
    Position?                    2
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### DataType &lt;XmlPortNodeDataType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute, TextElement, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### Element
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, FieldElement, TextElement
    Aliases                      None
    Dynamic?                     false
#### Field
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute
    Aliases                      None
    Dynamic?                     false
#### FieldValidate &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute
    Aliases                      None
    Dynamic?                     false
#### ID &lt;guid&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### LinkTable &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### LinkTableForceInsert &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### MaxOccurs &lt;MaxOccurs&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, FieldElement, TextElement
    Aliases                      None
    Dynamic?                     false
#### MinOccurs &lt;MinOccurs&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, FieldElement, TextElement
    Aliases                      None
    Dynamic?                     false
#### Name &lt;string&gt;
    
    Required?                    true
    Position?                    1
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### NamespacePrefix &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, FieldElement, TextElement
    Aliases                      None
    Dynamic?                     false
#### Occurrence &lt;Occurrence&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableAttribute, FieldAttribute, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### Position &lt;Position&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
#### ReqFilterFields &lt;string[]&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### SourceFieldName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute
    Aliases                      None
    Dynamic?                     false
#### SourceFieldTableVariableName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, FieldAttribute
    Aliases                      None
    Dynamic?                     false
#### SourceTable &lt;int&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### SourceTableViewKey &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### SourceTableViewOrder &lt;Order&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### Table
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### Temporary &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute
    Aliases                      None
    Dynamic?                     false
#### Text
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TextElement, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### TextType &lt;TextType&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TextElement, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### Unbound &lt;bool&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           FieldElement, TextElement
    Aliases                      None
    Dynamic?                     false
#### VariableName &lt;string&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute, TextElement, TextAttribute
    Aliases                      None
    Dynamic?                     false
#### Width &lt;int&gt;
    
    Required?                    false
    Position?                    Named
    Accept pipeline input?       false
    Parameter set name           TableElement, TableAttribute, FieldElement, FieldAttribute, TextElement, TextAttribute
    Aliases                      None
    Dynamic?                     false
<a name="Test-DynamicParams"></a>
## Test-DynamicParams
### Synopsis
Test-DynamicParams -InputObject <psobject> [<CommonParameters>]
### Syntax
```powershell
Test-DynamicParams -InputObject <psobject> [<CommonParameters>]
```
### Parameters
#### InputObject &lt;psobject&gt;
    
    Required?                    true
    Position?                    Named
    Accept pipeline input?       true (ByValue)
    Parameter set name           (All)
    Aliases                      None
    Dynamic?                     false
<div style='font-size:small; color: #ccc'>Generated 24-04-2017 11:21</div>

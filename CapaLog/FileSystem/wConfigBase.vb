'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.2407
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On 

Imports System.Xml.Serialization

'
'This source code was auto-generated by xsd, Version=1.1.4322.2407.
'

'<remarks/>
<System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:xmlns:Graphicom:ConfigBaseNS"), _
 System.Xml.Serialization.XmlRootAttribute([Namespace]:="urn:xmlns:Graphicom:ConfigBaseNS", IsNullable:=False)> _
Public Class ConfigBase

    '<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("wConfigBase")> _
    Public wConfigBase() As ConfigBaseType
End Class

'<remarks/>
<System.Xml.Serialization.XmlTypeAttribute([Namespace]:="urn:xmlns:Graphicom:ConfigBaseNS")> _
Public Class ConfigBaseType

    '<remarks/>
    Public CFG_ConnectionString As String

    '<remarks/>
    Public CFG_ConnectionString2 As String

    '<remarks/>
    Public CFG_ConnectionString3 As String

    '<remarks/>
    Public CFG_HttpPostTimeLong As String

    '<remarks/>
    Public CFG_HttpPostTimeNormal As String

    '<remarks/>
    Public CFG_HttpPostTimeShort As String

    '<remarks/>
    Public CFG_HttpPostTimeMin As String

    '<remarks/>
    Public CFG_SmtpServer As String

    '<remarks/>
    Public CFG_SqlExecutionTimeout As String

    '<remarks/>
    Public CFG_LogsPath As String

    '<remarks/>
    Public CFG_AddToTextFile As String

    '<remarks/>
    Public CFG_EncryptionKey As String

    '<remarks/>
    Public CFG_EncryptionKeyAux As String

    '<remarks/>
    Public CFG_EncryptionKeyNum As String

    '<remarks/>
    Public CFG_ExpiresLong As String

    '<remarks/>
    Public CFG_ExpiresShort As String

    '<remarks/>
    Public CFG_DaysReport As String

    '<remarks/>
    Public CFG_BannedAccounts As String

    '<remarks/>
    Public CFG_BannedCountries As String

    '<remarks/>
    Public CFG_Credentials As String

    '<remarks/>
    Public CFG_CheckAccess As String

    '<remarks/>
    Public CFG_IdUser As String

    '<remarks/>
    Public CFG_DeferredDaysBack As String

    '<remarks/>
    Public CFG_PromoCodes As String

    '<remarks/>
    Public CFG_ioVation As String

    '<remarks/>
    Public CFG_PublicProfiles As String

    '<remarks/>
    Public CFG_AutoMenu As String

    '<remarks/>
    Public CFG_PublicKey As String

    '<remarks/>
    Public CFG_PublicUsername As String

    '<remarks/>
    Public CFG_PublicPassword As String

    '<remarks/>
    Public CFG_PubExtOutIp As String

    '<remarks/>
    Public CFG_NetUsr As String

    '<remarks/>
    Public CFG_NetPwd As String
End Class

Imports Intuit.Ipp.Security
Imports Intuit.Ipp.Core
Public Class QBOServiceInitializer

    Public Property accessToken() As String
        Get
            Return m_accessToken
        End Get
        Set
            m_accessToken = Value
        End Set
    End Property
    Private m_accessToken As String
    Public Property refreshToken() As String
        Get
            Return m_refreshToken
        End Get
        Set
            m_refreshToken = Value
        End Set
    End Property
    Private m_refreshToken As String
    Public Property realmId() As String
        Get
            Return m_realmId
        End Get
        Set
            m_realmId = Value
        End Set
    End Property
    Private m_realmId As String

    Public Sub New()
    End Sub

    Public Sub New(accessToken As String, refreshToken As String, realmId As String)
        Me.accessToken = accessToken
        Me.refreshToken = refreshToken
        Me.realmId = realmId
    End Sub

    'private static void Initialize()
    '{


    '}

    Public Function InitializeQBOServiceContextUsingoAuth() As ServiceContext
        'Initialize();
        Dim reqValidator As New OAuth2RequestValidator(Me.accessToken)
        Dim context As New ServiceContext(Me.realmId, IntuitServicesType.QBO, reqValidator)

        'MinorVersion represents the latest features/fields in the xsd supported by the QBO apis.
        'Read more details here- https://developer.intuit.com/docs/0100_quickbooks_online/0200_dev_guides/accounting/querying_data

        context.IppConfiguration.MinorVersion.Qbo = "12"
        Return context
    End Function
End Class

Imports System.Collections.Specialized
Imports System.Web
Imports Intuit.Ipp.Core

Partial Class MainWindow
    Private _connect As New IPPConnect
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Task.Factory.StartNew(Sub() DoNavigate())
    End Sub


    Private Async Sub DoNavigate()
        Await _connect.GetDiscoveryDataAsync()
        Navigate(_connect.GetAuth("OpenId"))
        'If True Then
        'Dim crud As New CrudStart()
        'crud.TestQBO(_connect.AccessToken, _connect.RefreshToken, _connect.RealmId)
        'Else
    End Sub


    ' Navigates to the given URL if it is valid.
    Private Sub Navigate(address As String)
        If String.IsNullOrEmpty(address) Then
            Return
        End If
        If address.Equals("about:blank") Then
            Return
        End If
        If Not address.StartsWith("http://") AndAlso Not address.StartsWith("https://") Then
            address = "http://" + address
        End If
        Try
            'AddHandler wbMain.Navigated, AddressOf NavigateDone
            'wbMain.e = True
            Application.Current.Dispatcher.BeginInvoke(Sub() wbMain.Navigate(New Uri(address)))
        Catch generatedExceptionName As UriFormatException
            Return
        End Try
    End Sub

    Private Sub wbMain_Navigated(sender As Object, e As NavigationEventArgs) Handles wbMain.Navigated
        Dim hostUrl As String = e.Uri.ToString()

        If hostUrl.StartsWith(_connect.RedirectURI) Then
            Task.Factory.StartNew(Sub() DoNavigated(hostUrl))

        End If

    End Sub

    Private Async Sub DoNavigated(hostUrl As String)
        Try

            Dim query As NameValueCollection = HttpUtility.ParseQueryString(hostUrl)
            Await Application.Current.Dispatcher.BeginInvoke(Sub() wbMain.Visibility = Visibility.Hidden)
            'Await Application.Current.Dispatcher.BeginInvoke(Sub() wbMain.Navigate(New Uri("http://QIntegrator.com")))
            Await _connect.GetResponseAsync(query)
            'accessToken = "eyJlbmMiOiJBMTI4Q0JDLUhTMjU2IiwiYWxnIjoiZGlyIn0..dRP8LZ97zhGFVywmI8X2VA.kh03IqWc7UK-POq9OfG2n9f3L-aVX_NSJbKMYGmwBeKJ60fdXlVfuolYaPN6ZoSAKMUtYbmXT7hzdNDdckZVdDN8g5rMmnoBdp2bfSS5IElGRyZXsMXCpvd9flEXpQsYgEpwvu5hr0LWebyPmUgSxPqVnz2eIH9Kp0zD731x7P2gJkhJ_ICJpA4SH70QF5fddLO6lP9GXLli5VyRg_Qd5WZlEc6RIwynaRrka7p2xcEOtnILjI9b8mmxZJ1IGGiaeRLi0-6bgXa5D95VfbV0YuHf5JImvx-e7vNRKLMqbBV_H0PeJ_fZQ-JGQ9lDOjpS9y7MAu2Amf9F0Duz6SGVczOUNiizhpH0DRrZdOxqjbRZiVEMrrYZ_VFFjbpRgdqSCTxgABJeD75l8y74Ge8P_zvLKlCZOT0EJMfvIGs8CPq4ZyzD7UVYgWV3uKDGlMF9Ts1lY_xADt0meBdKeh0OMylB1sAT5pDukC7bGHRnn4EJUfg4td4he4-PnYcLO4BNWnjCponmAQrHWeO79x0S6RxyqwfyHT8ZckAF8bucfN5zx0mH4G0uDT2VPeE-h86hEK5Xrq0Q3Rr80ehKWan-x-G9TkBT_Gb7nuRfXDjsbFUyhYasZYUS600t38ZqHzs0Xvl3gXi5f7jZh3AisuRB01947-HydNvRSn654d1iBBkFFE0-av4OjBml_olfNTXD.TZzWmQo3XO6hO8kWMM-f6Q"
            'refreshToken = "Q011518327222ubPXCLtloF1SHuePgVrkMEVESMzAavKjl18DY"
            'realmId = "123145885531564"
            Dim initialize As New QBOServiceInitializer(_connect.AccessToken, _connect.RefreshToken, _connect.RealmId)
            Dim serviceContext As ServiceContext = initialize.InitializeQBOServiceContextUsingoAuth()
            TestQBOCalls.allqbocalls(serviceContext)
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try


    End Sub


End Class


Imports DevDefined.OAuth.Consumer
Imports DevDefined.OAuth.Framework
Imports System.Collections.Specialized
Imports Intuit.Ipp.OAuth2PlatformClient
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports System.Security.Cryptography
Imports System.Configuration

Class IPPConnect
    Public Property DiscoveryAuthority() As String
        Get
            Return m_DiscoveryAuthority
        End Get
        Set
            m_DiscoveryAuthority = Value
        End Set
    End Property
    Private m_DiscoveryAuthority As String

    Public Property DiscoveryURL() As String
        Get
            Return m_DiscoveryURL
        End Get
        Set
            m_DiscoveryURL = Value
        End Set
    End Property
    Private m_DiscoveryURL As String

    Public Property RedirectURI() As String
        Get
            Return m_RedirectURI
        End Get
        Set
            m_RedirectURI = Value
        End Set
    End Property
    Private m_RedirectURI As String

    Public Property ApplicationToken() As String
        Get
            Return m_ApplicationToken
        End Get
        Set
            m_ApplicationToken = Value
        End Set
    End Property
    Private m_ApplicationToken As String
    Public Property ConsumerKey() As String
        Get
            Return m_ConsumerKey
        End Get
        Set
            m_ConsumerKey = Value
        End Set
    End Property
    Private m_ConsumerKey As String
    Public Property ConsumerSecret() As String
        Get
            Return m_ConsumerSecret
        End Get
        Set
            m_ConsumerSecret = Value
        End Set
    End Property
    Private m_ConsumerSecret As String
    Public Property OauthRequestTokenEndpoint() As String
        Get
            Return m_OauthRequestTokenEndpoint
        End Get
        Set
            m_OauthRequestTokenEndpoint = Value
        End Set
    End Property
    Private m_OauthRequestTokenEndpoint As String
    Public Property OauthAccessTokenEndpoint() As String
        Get
            Return m_OauthAccessTokenEndpoint
        End Get
        Set
            m_OauthAccessTokenEndpoint = Value
        End Set
    End Property
    Private m_OauthAccessTokenEndpoint As String
    Public Property OauthBaseUrl() As String
        Get
            Return m_OauthBaseUrl
        End Get
        Set
            m_OauthBaseUrl = Value
        End Set
    End Property
    Private m_OauthBaseUrl As String
    Public Property OauthUserAuthUrl() As String
        Get
            Return m_OauthUserAuthUrl
        End Get
        Set
            m_OauthUserAuthUrl = Value
        End Set
    End Property
    Private m_OauthUserAuthUrl As String
    Public Property RequestToken() As IToken
        Get
            Return m_RequestToken
        End Get
        Set
            m_RequestToken = Value
        End Set
    End Property
    Private m_RequestToken As IToken

    Public Property OauthVerifier() As String
        Get
            Return m_OauthVerifier
        End Get
        Set
            m_OauthVerifier = Value
        End Set
    End Property
    Private m_OauthVerifier As String

    Public Property RefreshToken() As String
        Get
            Return m_refresh_token
        End Get
        Set
            m_refresh_token = Value
        End Set
    End Property
    Private m_refresh_token As String

    Public Property RealmId() As String
        Get
            Return m_RealmId
        End Get
        Set
            m_RealmId = Value
        End Set
    End Property
    Public m_RealmId As String

    Public m_ReponseCode As String
    Public m_DataSource As String
    Public Property AccessToken() As String
        Get
            Return m_AccessToken
        End Get
        Set
            m_AccessToken = Value
        End Set
    End Property
    Public m_AccessToken As String
    Public m_AccessSecret As String
    Public m_ExpirationDateTime As DateTime

    Shared stateVal As String
    Shared authorizationEndpoint As String
    Shared tokenEndpoint As String
    Shared userinfoEndPoint As String
    Shared revokeEndpoint As String
    Shared issuerUrl As String

    Shared [mod] As String
    Shared expo As String
    Shared incoming_state As String

    Private discoveryClient As DiscoveryClient
    Private doc As DiscoveryResponse
    'AuthorizeRequest request;
    Public Shared keys As IList(Of JsonWebKey)
    Public Shared dictionary As New Dictionary(Of String, String)()

    Public Sub New()
        DiscoveryAuthority = ConfigurationManager.AppSettings("DiscoveryAuthority")
        DiscoveryURL = ConfigurationManager.AppSettings("discoveryUrl")
        RedirectURI = ConfigurationManager.AppSettings("redirectURI")
        ApplicationToken = ConfigurationManager.AppSettings("applicationToken")
        ConsumerKey = ConfigurationManager.AppSettings("consumerKey")
        ConsumerSecret = ConfigurationManager.AppSettings("consumerSecret")
        OauthRequestTokenEndpoint = ConfigurationManager.AppSettings("oauthRequestTokenEndpoint")
        OauthAccessTokenEndpoint = ConfigurationManager.AppSettings("oauthAccessTokenEndpoint")
        OauthBaseUrl = ConfigurationManager.AppSettings("oauthBaseUrl")
        OauthUserAuthUrl = ConfigurationManager.AppSettings("oauthUserAuthUrl")
    End Sub

    Private Function getOauthRequestTokenFromIpp() As IToken
        Dim oauthSession As IOAuthSession = Me.createDevDefinedOAuthSession()
        Return oauthSession.GetRequestToken()
    End Function

    Private Function createDevDefinedOAuthSession() As IOAuthSession

        Dim oauthRequestTokenUrl As String = OauthBaseUrl & OauthRequestTokenEndpoint
        Dim oauthAccessTokenUrl As String = OauthBaseUrl & OauthAccessTokenEndpoint
        Dim oauthUserAuthorizeUrl As String = OauthUserAuthUrl
        Dim consumerContext As New OAuthConsumerContext() With {
                .ConsumerKey = ConsumerKey,
                .ConsumerSecret = ConsumerSecret,
                .SignatureMethod = SignatureMethod.HmacSha1
        }
        Return New OAuthSession(consumerContext, oauthRequestTokenUrl, oauthUserAuthorizeUrl, oauthAccessTokenUrl)
    End Function

    Friend Async Function GetResponseAsync(query As NameValueCollection) As Task

        m_OauthVerifier = query("oauth_verifier")
        m_RealmId = query("realmId")
        m_ReponseCode = query("code")
        m_DataSource = query("dataSource")
        Await performCodeExchange()
        'IToken accessToken = exchangeRequestTokenForAccessToken();
        'm_AccessToken = accessToken.Token;
        'm_AccessSecret = accessToken.TokenSecret;
        m_ExpirationDateTime = DateTime.Now.AddMonths(6)
    End Function
    Public Function exchangeRequestTokenForAccessToken() As IToken
        Dim oauthSession As IOAuthSession = createDevDefinedOAuthSession()
        Return oauthSession.ExchangeRequestTokenForAccessToken(RequestToken, OauthVerifier)
    End Function

    Public Async Function GetDiscoveryDataAsync() As Task
        Try
            'get Discovery Data and JWKS Keys
            'call this once a day or at application_start in your code.
            'await performCodeExchange();
            If Await getDiscoveryData_JWKSkeys() Then
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

    End Function

    Public Function GetAuth(callMadeBy As String) As String
        'was DoAuth
        Dim authorizationRequest As String = ""
        Dim scopeVal As String = ""

        '''/Save the state(CSRF token/Campaign Id/Tracking Id) in dictionary to verify after Oauth2 Callback. This is just for reference. 
        '''/Actual CSRF handling should be done as per security standards in some hidden fields or encrypted permanent store

        stateVal = CryptoRandom.CreateUniqueId()

        If Not dictionary.ContainsKey("CSRF") Then
            dictionary.Add("CSRF", stateVal)
        End If


        If callMadeBy = "OpenId" Then
            'Get App Now scopes
            If Not dictionary.ContainsKey("callMadeBy") Then
                dictionary.Add("callMadeBy", callMadeBy)
            Else
                dictionary("callMadeBy") = callMadeBy
            End If


            'scopeVal = OidcScopes.Accounting.GetStringValue() + " " + OidcScopes.Payment.GetStringValue()
            '    + " " + OidcScopes.OpenId.GetStringValue() + " " + OidcScopes.Address.GetStringValue()
            '    + " " + OidcScopes.Email.GetStringValue() + " " + OidcScopes.Phone.GetStringValue()
            '    + " " + OidcScopes.Profile.GetStringValue();
            scopeVal = OidcScopes.Accounting.GetStringValue()
        End If

        'Create the OAuth 2.0 authorization request.

        If authorizationEndpoint <> "" AndAlso authorizationEndpoint IsNot Nothing Then
            ' clientID,
            authorizationRequest = String.Format("{0}?client_id={1}&response_type=code&scope={2}&redirect_uri={3}&state={4}", authorizationEndpoint, ConsumerKey, scopeVal, Uri.EscapeDataString(RedirectURI), stateVal)





            Return authorizationRequest
        Else
            Debug.Print("Missing authorizationEndpoint url!")
            Return String.Empty
        End If


    End Function


    ''' <summary>
    ''' Get Discovery Data
    ''' </summary>
    ''' <returns></returns>       
    Public Async Function getDiscoveryData_JWKSkeys() As Task(Of Boolean)
        Try
            Dim dpolicy As New DiscoveryPolicy()
            dpolicy.RequireHttps = True
            dpolicy.ValidateIssuerName = True
            'Assign the Sandbox Discovery url for the Apps' Dev clientid and clientsecret that you use
            'Or
            'Assign the Production Discovery url for the Apps' Production clientid and clientsecret that you use

            If DiscoveryURL IsNot Nothing AndAlso ConsumerKey IsNot Nothing AndAlso ConsumerSecret IsNot Nothing Then
                discoveryClient = New DiscoveryClient(DiscoveryURL)
            End If
            'doc = await discoveryClient.GetAsync();
            doc = discoveryClient.GetAsync().Result

            If doc.StatusCode = HttpStatusCode.OK Then
                'Authorization endpoint url
                authorizationEndpoint = doc.AuthorizeEndpoint

                'Token endpoint url
                tokenEndpoint = doc.TokenEndpoint

                'UseInfo endpoint url
                userinfoEndPoint = doc.UserInfoEndpoint

                'Revoke endpoint url
                revokeEndpoint = doc.RevocationEndpoint

                'Issuer endpoint Url 
                issuerUrl = doc.Issuer

                'JWKS Keys
                keys = doc.KeySet.Keys
                Return True
            Else
                Return False

            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
            Return False
        End Try
    End Function



    ''' <summary>
    ''' Start code exchange to get the Access Token and Refresh Token
    ''' </summary>
    ''' <returns></returns>
    Public Async Function performCodeExchange() As Task
        Dim id_token As String = ""
        '            string access_token = "";
        Dim isTokenValid As Boolean = False
        Dim [sub] As String = ""
        Dim email As String = ""
        Dim emailVerified As String = ""
        Dim givenName As String = ""
        Dim familyName As String = ""
        Dim phoneNumber As String = ""
        Dim phoneNumberVerified As String = ""
        Dim streetAddress As String = ""
        Dim locality As String = ""
        Dim region As String = ""
        Dim postalCode As String = ""
        Dim country As String = ""


        'Request Oauth2 tokens
        Dim tokenClient = New TokenClient(tokenEndpoint, ConsumerKey, ConsumerSecret)

        'TokenResponse accesstokenCallResponse = await tokenClient.RequestTokenFromCodeAsync(code, ""); // m_config.RedirectURI);
        Dim accesstokenCallResponse As TokenResponse = tokenClient.RequestTokenFromCodeAsync(m_ReponseCode, RedirectURI).Result
        ' m_config.RedirectURI);
        If accesstokenCallResponse.HttpStatusCode = HttpStatusCode.OK Then


            'save the refresh token in persistent store so that it can be used to refresh short lived access tokens
            m_refresh_token = accesstokenCallResponse.RefreshToken
            If Not dictionary.ContainsKey("refreshToken") Then
                dictionary.Add("refreshToken", m_refresh_token)
            End If

            'access token
            m_AccessToken = accesstokenCallResponse.AccessToken

            If Not dictionary.ContainsKey("accessToken") Then
                dictionary.Add("accessToken", m_AccessToken)
            End If

            'Identity Token (returned only for OpenId scope)
            id_token = accesstokenCallResponse.IdentityToken

            'validate idToken
            isTokenValid = Await isIdTokenValid(id_token)
            'get userinfo
            'This will work only for SIWI and Get App Now(OpenId) flows
            'Since C2QB flow does not has the required scopes, you will get exception.
            'Here we will handle the exception and then finally make QBO api call
            'In your code, based on your workflows/scope, you can choose to not make this call
            Dim userInfoResponse As UserInfoResponse = Await getUserInfo(m_AccessToken, m_refresh_token)

            If userInfoResponse.HttpStatusCode = HttpStatusCode.OK Then
                'Read UserInfo Details
                Dim userData As IEnumerable(Of System.Security.Claims.Claim) = userInfoResponse.Json.ToClaims()

                For Each item As System.Security.Claims.Claim In userData
                    If item.Type = "sub" AndAlso item.Value IsNot Nothing Then
                        [sub] = item.Value
                    End If
                    If item.Type = "email" AndAlso item.Value IsNot Nothing Then
                        email = item.Value
                    End If
                    If item.Type = "emailVerified" AndAlso item.Value IsNot Nothing Then
                        emailVerified = item.Value
                    End If
                    If item.Type = "givenName" AndAlso item.Value IsNot Nothing Then
                        givenName = item.Value
                    End If
                    If item.Type = "familyName" AndAlso item.Value IsNot Nothing Then
                        familyName = item.Value
                    End If
                    If item.Type = "phoneNumber" AndAlso item.Value IsNot Nothing Then
                        phoneNumber = item.Value
                    End If
                    If item.Type = "phoneNumberVerified" AndAlso item.Value IsNot Nothing Then
                        phoneNumberVerified = item.Value
                    End If

                    If item.Type = "address" AndAlso item.Value IsNot Nothing Then

                        Dim jsonObject As Address = JsonConvert.DeserializeObject(Of Address)(item.Value)

                        If jsonObject.StreetAddress IsNot Nothing Then
                            streetAddress = jsonObject.StreetAddress
                        End If
                        If jsonObject.Locality IsNot Nothing Then
                            locality = jsonObject.Locality
                        End If
                        If jsonObject.Region IsNot Nothing Then
                            region = jsonObject.Region
                        End If
                        If jsonObject.PostalCode IsNot Nothing Then
                            postalCode = jsonObject.PostalCode
                        End If
                        If jsonObject.Country IsNot Nothing Then
                            country = jsonObject.Country
                        End If

                    End If

                Next




            End If
        End If
    End Function

    Private Async Function isIdTokenValid(id_token As String) As Task(Of Boolean)

        Dim idToken As String = id_token
        If keys IsNot Nothing Then
            'Get mod and exponent value
            For Each key As JsonWebKey In keys
                If key.N IsNot Nothing Then
                    'Mod
                    [mod] = key.N
                End If
                If key.N IsNot Nothing Then
                    'Exponent
                    expo = key.E

                End If
            Next

            'IdentityToken
            If idToken IsNot Nothing Then
                'Split the identityToken to get Header and Payload
                Dim splitValues As String() = idToken.Split("."c)
                If splitValues(0) IsNot Nothing Then

                    'Decode header 
                    Dim headerJson = Encoding.UTF8.GetString(Base64Url.Decode(splitValues(0).ToString()))

                    'Deserilaize headerData
                    Dim headerData As IdTokenHeader = JsonConvert.DeserializeObject(Of IdTokenHeader)(headerJson)

                    'Verify if the key id of the key used to sign the payload is not null
                    If headerData.Kid Is Nothing Then
                        Return False
                    End If

                    'Verify if the hashing alg used to sign the payload is not null
                    If headerData.Alg Is Nothing Then
                        Return False

                    End If
                End If
                If splitValues(1) IsNot Nothing Then
                    'Decode payload
                    Dim payloadJson = Encoding.UTF8.GetString(Base64Url.Decode(splitValues(1).ToString()))


                    Dim payloadData As IdTokenJWTClaimTypes = JsonConvert.DeserializeObject(Of IdTokenJWTClaimTypes)(payloadJson)

                    'Verify Aud matches ClientId
                    If payloadData.Aud IsNot Nothing Then
                        If payloadData.Aud(0).ToString() <> ConsumerKey Then
                            'same as ClientID
                            Return False
                        End If
                    Else
                        Return False
                    End If


                    'Verify Authtime matches the time the ID token was authorized.                
                    If payloadData.Auth_time Is Nothing Then
                        Return False
                    End If



                    'Verify exp matches the time the ID token expires, represented in Unix time (integer seconds).                
                    If payloadData.Exp IsNot Nothing Then
                        Dim expiration As Long = Convert.ToInt64(payloadData.Exp)


                        Dim currentEpochTime As Long = EpochTimeExtensions.ToEpochTime(DateTime.UtcNow)
                        'Verify the ID expiration time with what expiry time you have calculated and saved in your application
                        'If they are equal then it means IdToken has expired 

                        If (expiration - currentEpochTime) <= 0 Then
                            Return False



                        End If
                    End If

                    'Verify Iat matches the time the ID token was issued, represented in Unix time (integer seconds).            
                    If payloadData.Iat Is Nothing Then
                        Return False
                    End If


                    'verify Iss matches the  issuer identifier for the issuer of the response.     
                    If payloadData.Iss IsNot Nothing Then
                        If payloadData.Iss.ToString() <> issuerUrl Then
                            Return False
                        End If
                    Else
                        Return False
                    End If



                    'Verify sub. Sub is an identifier for the user, unique among all Intuit accounts and never reused. 
                    'An Intuit account can have multiple emails at different points in time, but the sub value is never changed.
                    'Use sub within your application as the unique-identifier key for the user.
                    If payloadData.[Sub] Is Nothing Then
                        Return False



                    End If
                End If

                'Use external lib to decode mod and expo value and generte hashes
                Dim rsa As New RSACryptoServiceProvider()

                'Read values of n and e from discovery document.
                'Read values from discovery document
                rsa.ImportParameters(New RSAParameters() With {
                        .Modulus = Base64Url.Decode([mod]),
                        .Exponent = Base64Url.Decode(expo)
                })

                'Verify Siganture hash matches the signed concatenation of the encoded header and the encoded payload with the specified algorithm
                Dim sha256__1 As SHA256 = SHA256.Create()

                Dim hash As Byte() = sha256__1.ComputeHash(Encoding.UTF8.GetBytes(splitValues(0) + "."c + splitValues(1)))

                Dim rsaDeformatter As New RSAPKCS1SignatureDeformatter(rsa)
                rsaDeformatter.SetHashAlgorithm("SHA256")
                If rsaDeformatter.VerifySignature(hash, Base64Url.Decode(splitValues(2))) Then
                    'identityToken is valid
                    Return True
                Else
                    'identityToken is not valid

                    Return True
                End If
            Else
                'identityToken is not valid
                Return True
            End If
            Return True
        Else
            'Missing mod and expo values
            'return System.Threading.Tasks.Task.FromResult(false);
            Return False
        End If


    End Function


    ''' <summary>
    ''' Get User Info
    ''' </summary>
    ''' <param name="access_token"></param>
    ''' <param name="refresh_token"></param>
    ''' <returns></returns>
    Public Async Function getUserInfo(access_token As String, refresh_token As String) As Task(Of UserInfoResponse)

        'Get UserInfo data when correct scope is set for SIWI and Get App now flows
        Dim userInfoClient = New UserInfoClient(userinfoEndPoint)
        Dim userInfoResponse As UserInfoResponse = Await userInfoClient.GetAsync(access_token)
        Return userInfoResponse


    End Function
End Class


Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq



	Public Class CompanyInfoCRUD
		#Region "Query"

		Public Sub CompanyInfoQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of CompanyInfo)(qboContextoAuth)
        Dim comp As List(Of CompanyInfo) = entityQuery.ExecuteIdsQuery("SELECT * FROM CompanyInfo").ToList() '(Of CompanyInfo)()

    End Sub
		#End Region
	End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

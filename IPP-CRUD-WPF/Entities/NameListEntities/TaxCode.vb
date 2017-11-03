
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class TaxCodeCRUD
		#Region "Sync"

		#Region "Query"

		Public Sub TaxCodeQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of TaxCode)(qboContextoAuth)

        Dim test As List(Of TaxCode) = entityQuery.ExecuteIdsQuery("SELECT * FROM TaxCode").ToList '(Of TaxCode)()
    End Sub

		#End Region

		#End Region

	End Class


'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================

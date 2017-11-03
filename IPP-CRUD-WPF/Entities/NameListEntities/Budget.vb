
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


Public Class BudgetCRUD
		#Region "Sync Methods"



		#Region "Query"

		Public Sub BudgetQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Budget)(qboContextoAuth)
			'Budget existing = Helper.FindOrAdd<Budget>(qboContextoAuth, new Budget());
			Dim entities As List(Of Budget) = entityQuery.ExecuteIdsQuery("select * from Budget").ToList()

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

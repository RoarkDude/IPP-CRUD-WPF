
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class CompanyCurrencyCRUD
		#Region "Sync Methods"


		#Region "Add a currency to the active currency list"


		Public Sub CompanyCurrencyAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the CompanyCurrency for Add
			Dim companyCurrency As CompanyCurrency = QBOHelper.CreateCompanyCurrency(qboContextoAuth)
			'Adding the CompanyCurrency
			Dim added As CompanyCurrency = Helper.Add(Of CompanyCurrency)(qboContextoAuth, companyCurrency)
		End Sub

		#End Region


		#Region "Update Operations"


		Public Sub CompanyCurrencyUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)

			Dim entityQuery As New QueryService(Of CompanyCurrency)(qboContextoAuth)
        Dim foundall As List(Of CompanyCurrency) = entityQuery.ExecuteIdsQuery("SELECT * FROM CompanyCurrency").ToList() '(Of CompanyCurrency)()




        For Each found As CompanyCurrency In foundall
				Dim changed As CompanyCurrency = QBOHelper.UpdateCompanyCurrency(qboContextoAuth, found)
				'Update the returned entity data
					'Verify the updated CompanyCurrency
				Dim updated As CompanyCurrency = Helper.Update(Of CompanyCurrency)(qboContextoAuth, changed)
			Next

		End Sub



		#End Region



		#Region "Query"


		Public Sub CompanyCurrencyQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of CompanyCurrency)(qboContextoAuth)
        Dim exch As List(Of CompanyCurrency) = entityQuery.ExecuteIdsQuery("SELECT * FROM CompanyCurrency where SourceCurrencyCode in ('EUR', 'INR') and AsOfDate='2015-07-07'").ToList() '(Of CompanyCurrency)()

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

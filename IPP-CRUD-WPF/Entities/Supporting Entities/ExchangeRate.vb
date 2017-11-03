
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class ExchangeRateCRUD
		#Region "Sync Methods"





		#Region "Update Operations"


		Public Sub ExchangeRateUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)

			Dim entityQuery As New QueryService(Of ExchangeRate)(qboContextoAuth)
        Dim foundall As List(Of ExchangeRate) = entityQuery.ExecuteIdsQuery("SELECT * FROM ExchangeRate where SourceCurrencyCode in ('INR') and AsOfDate='2015-07-07'").ToList() '(Of ExchangeRate)()




        For Each found As ExchangeRate In foundall
            Dim changed As ExchangeRate = QBOHelper.UpdateExchangeRate(qboContextoAuth, found)
            'Update the returned entity data
            'Verify the updated ExchangeRate
            Dim updated As ExchangeRate = Helper.Update(Of ExchangeRate)(qboContextoAuth, changed)
        Next

    End Sub



#End Region



#Region "Query"


    Public Sub ExchangeRateQueryUsingoAuth(qboContextoAuth As ServiceContext)
        Dim entityQuery As New QueryService(Of ExchangeRate)(qboContextoAuth)
        Dim exch As List(Of ExchangeRate) = entityQuery.ExecuteIdsQuery("SELECT * FROM ExchangeRate where SourceCurrencyCode in ('EUR', 'INR') and AsOfDate='2015-07-07'").ToList() '(Of ExchangeRate)()

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

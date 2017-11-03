
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class TaxAgencyCRUD
		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub TaxAgencyAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Bill for Add
			Dim taxAgency As TaxAgency = QBOHelper.CreateTaxAgency(qboContextoAuth)
			'Adding the TaxAgency
			Dim added As TaxAgency = Helper.Add(Of TaxAgency)(qboContextoAuth, taxAgency)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub TaxAgencyFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			TaxAgencyAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Bill using FindAll
			Dim taxAgencys As List(Of TaxAgency) = Helper.FindAll(Of TaxAgency)(qboContextoAuth, New TaxAgency(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub TaxAgencyFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the TaxAgency for Adding
			Dim taxAgency As TaxAgency = QBOHelper.CreateTaxAgency(qboContextoAuth)
			'Adding the TaxAgency
			Dim added As TaxAgency = Helper.Add(Of TaxAgency)(qboContextoAuth, taxAgency)
			Dim found As TaxAgency = Helper.FindById(Of TaxAgency)(qboContextoAuth, added)

		End Sub

		#End Region



		#Region "Query"

		Public Sub TaxAgencyQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of TaxAgency)(qboContextoAuth)

        Dim test As List(Of TaxAgency) = entityQuery.ExecuteIdsQuery("SELECT * FROM TaxAgency").ToList() '(Of TaxAgency)()
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

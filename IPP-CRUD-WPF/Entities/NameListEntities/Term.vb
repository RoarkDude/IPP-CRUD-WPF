
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class TermCRUD
		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub TermAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Bill for Add
			Dim term As Term = QBOHelper.CreateTerm(qboContextoAuth)
			'Adding the Term
			Dim added As Term = Helper.Add(Of Term)(qboContextoAuth, term)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub TermFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			TermAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Term using FindAll
			Dim terms As List(Of Term) = Helper.FindAll(Of Term)(qboContextoAuth, New Term(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub TermFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Term for Adding
			Dim term As Term = QBOHelper.CreateTerm(qboContextoAuth)
			'Adding the Term
			Dim added As Term = Helper.Add(Of Term)(qboContextoAuth, term)
			Dim found As Term = Helper.FindById(Of Term)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub TermUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Term for Adding
			Dim term As Term = QBOHelper.CreateTerm(qboContextoAuth)
			'Adding the Term
			Dim added As Term = Helper.Add(Of Term)(qboContextoAuth, term)
			'Change the data of added entity
			Dim changed As Term = QBOHelper.UpdateTerm(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Term = Helper.Update(Of Term)(qboContextoAuth, changed)
			'Verify the updated Term
		End Sub


		Public Sub TermSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Term for Adding
			Dim term As Term = QBOHelper.CreateTerm(qboContextoAuth)
			'Adding the Term
			Dim added As Term = Helper.Add(Of Term)(qboContextoAuth, term)
			'Change the data of added entity
			Dim changed As Term = QBOHelper.SparseUpdateTerm(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As Term = Helper.Update(Of Term)(qboContextoAuth, changed)
			'Verify the updated Term
		End Sub

		#End Region



		#Region "CDC Operations"


		Public Sub TermCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			TermAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Term using CDC
			Dim entities As List(Of Term) = Helper.CDC(qboContextoAuth, New Term(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub TermBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Term = Helper.FindOrAdd(qboContextoAuth, New Term())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateTerm(qboContextoAuth))

			'batchEntries.Add(OperationEnum.update, QBOHelper.UpdateTerm(qboContextoAuth, existing));

			batchEntries.Add(OperationEnum.query, "select * from Term")

			'  batchEntries.Add(OperationEnum.delete, existing);

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Term)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub TermQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Term)(qboContextoAuth)
			Dim existing As Term = Helper.FindOrAdd(Of Term)(qboContextoAuth, New Term())
        Dim test As List(Of Term) = entityQuery.ExecuteIdsQuery("SELECT * FROM Term where Id='" + existing.Id + "'").ToList '(Of Term)()

    End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub TermAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Term for Add
			Dim entity As Term = QBOHelper.CreateTerm(qboContextoAuth)

			Dim added As Term = Helper.AddAsync(Of Term)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub TermRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			TermAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Term using FindAll
			Helper.FindAllAsync(Of Term)(qboContextoAuth, New Term())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub TermFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Term for Adding
			Dim entity As Term = QBOHelper.CreateTerm(qboContextoAuth)
			'Adding the Term
			Dim added As Term = Helper.Add(Of Term)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of Term)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub TermUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Term for Adding
			Dim entity As Term = QBOHelper.CreateTerm(qboContextoAuth)
			'Adding the Term
			Dim added As Term = Helper.Add(Of Term)(qboContextoAuth, entity)

			'Update the Term
			Dim updated As Term = QBOHelper.UpdateTerm(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Term = Helper.UpdateAsync(Of Term)(qboContextoAuth, updated)

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

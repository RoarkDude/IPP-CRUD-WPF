
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class CustomerCRUD
		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub CustomerAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Customer for Add
			Dim customer As Customer = QBOHelper.CreateCustomer(qboContextoAuth)

			'Adding the Customer
			Dim added As Customer = Helper.Add(Of Customer)(qboContextoAuth, customer)


		End Sub




		#End Region

		#Region "FindAll Operations"


		Public Sub CustomerFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CustomerAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Customer using FindAll
			Dim customers As List(Of Customer) = Helper.FindAll(Of Customer)(qboContextoAuth, New Customer(), 1, 500)

		End Sub





		Public Sub CustomerRetrieveAsyncTestsNullEntityUsingoAuth(qboContextoAuth As ServiceContext)
			Try

				Helper.FindAll(Of Customer)(qboContextoAuth, Nothing)

			Catch generatedExceptionName As IdsException
			End Try
		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub CustomerFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Customer for Adding
			Dim customer As Customer = QBOHelper.CreateCustomer(qboContextoAuth)
			'Adding the Customer
			Dim added As Customer = Helper.Add(Of Customer)(qboContextoAuth, customer)
			Dim found As Customer = Helper.FindById(Of Customer)(qboContextoAuth, added)

		End Sub



		Public Sub CustomerFindByIdTestsNullEntityUsingoAuth(qboContextoAuth As ServiceContext)
			Try

				Helper.FindById(Of Customer)(qboContextoAuth, Nothing)

			Catch generatedExceptionName As IdsException
			End Try
		End Sub

		#End Region

		#Region "Update Operations"



		Public Sub CustomerUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Customer for Adding
			Dim customer As Customer = QBOHelper.CreateCustomer(qboContextoAuth)
			'Adding the Customer
			Dim added As Customer = Helper.Add(Of Customer)(qboContextoAuth, customer)
			'Change the data of added entity
			Dim updated As Customer = QBOHelper.UpdateCustomer(qboContextoAuth, added)
			'Update the returned entity data
			Dim updatedreturned As Customer = Helper.Update(Of Customer)(qboContextoAuth, updated)

		End Sub



		Public Sub CustomerSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Customer for Adding
			Dim customer As Customer = QBOHelper.CreateCustomer(qboContextoAuth)
			'Adding the Customer
			Dim added As Customer = Helper.Add(Of Customer)(qboContextoAuth, customer)
			'Change the data of added entity
			Dim updated As Customer = QBOHelper.SparseUpdateCustomer(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updatedreturned As Customer = Helper.Update(Of Customer)(qboContextoAuth, updated)

		End Sub


		Public Sub CustomerUpdateTestsNullEntityUsingoAuth(qboContextoAuth As ServiceContext)
			Try

				Dim updatedReturned As Customer = Helper.Update(Of Customer)(qboContextoAuth, Nothing)
			Catch generatedExceptionName As IdsException
			End Try

		End Sub

		#End Region





		#Region "CDC Operations"


		Public Sub CustomerCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CustomerAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Customer using FindAll
			Dim customers As List(Of Customer) = Helper.CDC(qboContextoAuth, New Customer(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub CustomerBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Customer = Helper.FindOrAdd(qboContextoAuth, New Customer())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateCustomer(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateCustomer(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Customer")

			'batchEntries.Add(OperationEnum.delete, existing);

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Customer)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub CustomerQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Customer)(qboContextoAuth)
        Dim test As List(Of Customer) = entityQuery.ExecuteIdsQuery("SELECT * FROM Customer").ToList ' (Of Customer)()

    End Sub


		Public Sub CustomerQueryWithSpecialCharacterUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Customer)(qboContextoAuth)
        Dim test As Customer = entityQuery.ExecuteIdsQuery("SELECT * FROM Customer where DisplayName='Customer\'s Business'").FirstOrDefault '(Of Customer)()
    End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Test Cases for Add Operation"


		Public Sub CustomerAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Customer for Add
			Dim entity As Customer = QBOHelper.CreateCustomer(qboContextoAuth)

			Dim added As Customer = Helper.AddAsync(Of Customer)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "Test Cases for FindAll Operation"


		Public Sub CustomerRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CustomerAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Customer using FindAll
			Helper.FindAllAsync(Of Customer)(qboContextoAuth, New Customer())
		End Sub

		#End Region

		#Region "Test Cases for FindById Operation"


		Public Sub CustomerFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Customer for Adding
			Dim entity As Customer = QBOHelper.CreateCustomer(qboContextoAuth)
			'Adding the Customer
			Dim added As Customer = Helper.Add(Of Customer)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of Customer)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Test Cases for Update Operation"


		Public Sub CustomerUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Customer for Adding
			Dim entity As Customer = QBOHelper.CreateCustomer(qboContextoAuth)
			'Adding the Customer
			Dim added As Customer = Helper.Add(Of Customer)(qboContextoAuth, entity)

			'Update the Customer
			Dim updated As Customer = QBOHelper.UpdateCustomer(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Customer = Helper.UpdateAsync(Of Customer)(qboContextoAuth, updated)

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

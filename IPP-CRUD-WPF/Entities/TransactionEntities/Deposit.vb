
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class DepositCRUD
		#Region "Sync Methods"

		#Region "Add Operations"



		Public Sub DepositAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Deposit for Add
			Dim deposit As Deposit = QBOHelper.CreateDeposit(qboContextoAuth)
			'Adding the Deposit
			Dim added As Deposit = Helper.Add(Of Deposit)(qboContextoAuth, deposit)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub DepositFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)


			'Retrieving the Deposit using FindAll
			Dim deposits As List(Of Deposit) = Helper.FindAll(Of Deposit)(qboContextoAuth, New Deposit(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub DepositFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Deposit for Adding
			Dim deposit As Deposit = QBOHelper.CreateDeposit(qboContextoAuth)
			'Adding the Deposit
			Dim added As Deposit = Helper.Add(Of Deposit)(qboContextoAuth, deposit)
			Dim found As Deposit = Helper.FindById(Of Deposit)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"



		Public Sub DepositUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Deposit for Adding
			Dim deposit As Deposit = QBOHelper.CreateDeposit(qboContextoAuth)
			'Adding the Deposit
			Dim added As Deposit = Helper.Add(Of Deposit)(qboContextoAuth, deposit)
			'Change the data of added entity
			Dim changed As Deposit = QBOHelper.UpdateDeposit(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Deposit = Helper.Update(Of Deposit)(qboContextoAuth, changed)
			'Verify the updated Deposit
		End Sub




		Public Sub DepositSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Deposit for Adding
			Dim deposit As Deposit = QBOHelper.CreateDeposit(qboContextoAuth)
			'Adding the Deposit
			Dim added As Deposit = Helper.Add(Of Deposit)(qboContextoAuth, deposit)
			'Change the data of added entity
			Dim changed As Deposit = QBOHelper.UpdateDepositSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As Deposit = Helper.Update(Of Deposit)(qboContextoAuth, changed)
			'Verify the updated Deposit
		End Sub
		#End Region

		#Region "Delete Operations"



		Public Sub DepositDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Deposit for Adding
			Dim deposit As Deposit = QBOHelper.CreateDeposit(qboContextoAuth)
			'Adding the Deposit
			Dim added As Deposit = Helper.Add(Of Deposit)(qboContextoAuth, deposit)
			'Delete the returned entity
			Try

				Dim deleted As Deposit = Helper.Delete(Of Deposit)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub



		#End Region

		#Region "CDC Operations"



		Public Sub DepositCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			DepositAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Deposit using CDC
			Dim entities As List(Of Deposit) = Helper.CDC(qboContextoAuth, New Deposit(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"



		Public Sub DepositBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Deposit = Helper.FindOrAdd(qboContextoAuth, New Deposit())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateDeposit(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateDeposit(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Deposit")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Deposit)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub DepositQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Deposit)(qboContextoAuth)
			Dim existing As Deposit = Helper.FindOrAdd(Of Deposit)(qboContextoAuth, New Deposit())
			Dim test As List(Of Deposit) = entityQuery.ExecuteIdsQuery("SELECT * FROM Deposit where Id='" + existing.Id + "'").ToList() '(Of Deposit)()

		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"



		Public Sub DepositAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Deposit for Add
			Dim entity As Deposit = QBOHelper.CreateDeposit(qboContextoAuth)

			Dim added As Deposit = Helper.AddAsync(Of Deposit)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub DepositRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			DepositAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Deposit using FindAll
			Helper.FindAllAsync(Of Deposit)(qboContextoAuth, New Deposit())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub DepositFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Deposit for Adding
			Dim entity As Deposit = QBOHelper.CreateDeposit(qboContextoAuth)
			'Adding the Deposit
			Dim added As Deposit = Helper.Add(Of Deposit)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of Deposit)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"



		Public Sub DepositUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Deposit for Adding
			Dim entity As Deposit = QBOHelper.CreateDeposit(qboContextoAuth)
			'Adding the Deposit
			Dim added As Deposit = Helper.Add(Of Deposit)(qboContextoAuth, entity)

			'Update the Deposit
			Dim updated As Deposit = QBOHelper.UpdateDeposit(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Deposit = Helper.UpdateAsync(Of Deposit)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"



		Public Sub DepositDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Deposit for Adding
			Dim entity As Deposit = QBOHelper.CreateDeposit(qboContextoAuth)
			'Adding the Deposit
			Dim added As Deposit = Helper.Add(Of Deposit)(qboContextoAuth, entity)

			Helper.DeleteAsync(Of Deposit)(qboContextoAuth, added)
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

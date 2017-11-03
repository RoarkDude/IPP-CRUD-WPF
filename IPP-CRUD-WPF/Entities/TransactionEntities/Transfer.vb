
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq



	Public Class TransferCRUD
		#Region "Sync Methods"

		#Region "Add Operations"



		Public Sub TransferAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Transfer for Add
			Dim transfer As Transfer = QBOHelper.CreateTransfer(qboContextoAuth)
			'Adding the Transfer
			Dim added As Transfer = Helper.Add(Of Transfer)(qboContextoAuth, transfer)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub TransferFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			TransferAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Transfer using FindAll
			Dim transfers As List(Of Transfer) = Helper.FindAll(Of Transfer)(qboContextoAuth, New Transfer(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub TransferFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Transfer for Adding
			Dim transfer As Transfer = QBOHelper.CreateTransfer(qboContextoAuth)
			'Adding the Transfer
			Dim added As Transfer = Helper.Add(Of Transfer)(qboContextoAuth, transfer)
			Dim found As Transfer = Helper.FindById(Of Transfer)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"



		Public Sub TransferUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Transfer for Adding
			Dim transfer As Transfer = QBOHelper.CreateTransfer(qboContextoAuth)
			'Adding the Transfer
			Dim added As Transfer = Helper.Add(Of Transfer)(qboContextoAuth, transfer)
			'Change the data of added entity
			Dim changed As Transfer = QBOHelper.UpdateTransfer(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Transfer = Helper.Update(Of Transfer)(qboContextoAuth, changed)

		End Sub




		Public Sub TransferSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Transfer for Adding
			Dim transfer As Transfer = QBOHelper.CreateTransfer(qboContextoAuth)
			'Adding the Transfer
			Dim added As Transfer = Helper.Add(Of Transfer)(qboContextoAuth, transfer)
			'Change the data of added entity
			Dim changed As Transfer = QBOHelper.UpdateTransferSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As Transfer = Helper.Update(Of Transfer)(qboContextoAuth, changed)

		End Sub

		#End Region

		#Region "Delete Operations"



		Public Sub TransferDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Transfer for Adding
			Dim transfer As Transfer = QBOHelper.CreateTransfer(qboContextoAuth)
			'Adding the Transfer
			Dim added As Transfer = Helper.Add(Of Transfer)(qboContextoAuth, transfer)
			'Delete the returned entity
			Try

				Dim deleted As Transfer = Helper.Delete(Of Transfer)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub



		#End Region

		#Region "CDC Operations"



		Public Sub TransferCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			TransferAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Transfer using CDC
			Dim entities As List(Of Transfer) = Helper.CDC(qboContextoAuth, New Transfer(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"



		Public Sub TransferBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Transfer = Helper.FindOrAdd(qboContextoAuth, New Transfer())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateTransfer(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateTransfer(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Transfer")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Transfer)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub TransferQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Transfer)(qboContextoAuth)
			Dim existing As Transfer = Helper.FindOrAdd(Of Transfer)(qboContextoAuth, New Transfer())
			Dim tran As List(Of Transfer) = entityQuery.ExecuteIdsQuery("SELECT * FROM Transfer where Id='" + existing.Id + "'").ToList() '(Of Transfer)()

		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"



		Public Sub TransferAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Transfer for Add
			Dim entity As Transfer = QBOHelper.CreateTransfer(qboContextoAuth)

			Dim added As Transfer = Helper.AddAsync(Of Transfer)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub TransferRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			TransferAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Transfer using FindAll
			Helper.FindAllAsync(Of Transfer)(qboContextoAuth, New Transfer())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub TransferFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Transfer for Adding
			Dim entity As Transfer = QBOHelper.CreateTransfer(qboContextoAuth)
			'Adding the Transfer
			Dim added As Transfer = Helper.Add(Of Transfer)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of Transfer)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"



		Public Sub TransferUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Transfer for Adding
			Dim entity As Transfer = QBOHelper.CreateTransfer(qboContextoAuth)
			'Adding the Transfer
			Dim added As Transfer = Helper.Add(Of Transfer)(qboContextoAuth, entity)

			'Update the Transfer
			Dim updated As Transfer = QBOHelper.UpdateTransfer(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Transfer = Helper.UpdateAsync(Of Transfer)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"



		Public Sub TransferDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Transfer for Adding
			Dim entity As Transfer = QBOHelper.CreateTransfer(qboContextoAuth)
			'Adding the Transfer
			Dim added As Transfer = Helper.Add(Of Transfer)(qboContextoAuth, entity)

			Helper.DeleteAsync(Of Transfer)(qboContextoAuth, added)
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

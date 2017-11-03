
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class CreditMemoCRUD



		#Region "Add Operations"


		Public Sub CreditMemoAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the CreditMemo for Add
			Dim creditMemo As CreditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth)
			'Adding the CreditMemo
			Dim added As CreditMemo = Helper.Add(Of CreditMemo)(qboContextoAuth, creditMemo)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub CreditMemoFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CreditMemoAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the CreditMemo using FindAll
			Dim creditMemos As List(Of CreditMemo) = Helper.FindAll(Of CreditMemo)(qboContextoAuth, New CreditMemo(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub CreditMemoFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the CreditMemo for Adding
			Dim creditMemo As CreditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth)
			'Adding the CreditMemo
			Dim added As CreditMemo = Helper.Add(Of CreditMemo)(qboContextoAuth, creditMemo)
			Dim found As CreditMemo = Helper.FindById(Of CreditMemo)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub CreditMemoUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the CreditMemo for Adding
			Dim creditMemo As CreditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth)
			'Adding the CreditMemo
			Dim added As CreditMemo = Helper.Add(Of CreditMemo)(qboContextoAuth, creditMemo)
			'Change the data of added entity
			Dim changed As CreditMemo = QBOHelper.UpdateCreditMemo(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As CreditMemo = Helper.Update(Of CreditMemo)(qboContextoAuth, changed)

		End Sub


		Public Sub CreditMemoSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the CreditMemo for Adding
			Dim creditMemo As CreditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth)
			'Adding the CreditMemo
			Dim added As CreditMemo = Helper.Add(Of CreditMemo)(qboContextoAuth, creditMemo)
			'Change the data of added entity
			Dim changed As CreditMemo = QBOHelper.UpdateCreditMemoSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As CreditMemo = Helper.Update(Of CreditMemo)(qboContextoAuth, changed)

		End Sub

		#End Region


		#Region "Delete Operations"


		Public Sub CreditMemoDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the CreditMemo for Adding
			Dim creditMemo As CreditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth)
			'Adding the CreditMemo
			Dim added As CreditMemo = Helper.Add(Of CreditMemo)(qboContextoAuth, creditMemo)
			'Delete the returned entity
			Try

				Dim deleted As CreditMemo = Helper.Delete(Of CreditMemo)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub


		#Region "CDC Operations"


		Public Sub CreditMemoCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CreditMemoAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the CreditMemo using CDC
			Dim entities As List(Of CreditMemo) = Helper.CDC(qboContextoAuth, New CreditMemo(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub CreditMemoBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As CreditMemo = Helper.FindOrAdd(qboContextoAuth, New CreditMemo())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateCreditMemo(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateCreditMemo(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from CreditMemo")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of CreditMemo)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub CreditMemoQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of CreditMemo)(qboContextoAuth)
			Dim existing As CreditMemo = Helper.FindOrAdd(Of CreditMemo)(qboContextoAuth, New CreditMemo())
			Dim test As List(Of CreditMemo) = entityQuery.ExecuteIdsQuery("SELECT * FROM CreditMemo where Id='" + existing.Id + "'").ToList() '(Of CreditMemo)()
		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub CreditMemoAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the CreditMemo for Add
			Dim entity As CreditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth)

			Dim added As CreditMemo = Helper.AddAsync(Of CreditMemo)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub CreditMemoRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			CreditMemoAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the CreditMemo using FindAll
			Helper.FindAllAsync(Of CreditMemo)(qboContextoAuth, New CreditMemo())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub CreditMemoFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the CreditMemo for Adding
			Dim entity As CreditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth)
			'Adding the CreditMemo
			Dim added As CreditMemo = Helper.Add(Of CreditMemo)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of CreditMemo)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub CreditMemoUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the CreditMemo for Adding
			Dim entity As CreditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth)
			'Adding the CreditMemo
			Dim added As CreditMemo = Helper.Add(Of CreditMemo)(qboContextoAuth, entity)

			'Update the CreditMemo
			Dim updated As CreditMemo = QBOHelper.UpdateCreditMemo(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As CreditMemo = Helper.UpdateAsync(Of CreditMemo)(qboContextoAuth, updated)

		End Sub


		Public Sub CreditMemoSparseUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the CreditMemo for Adding
			Dim entity As CreditMemo = QBOHelper.CreateCreditMemo(qboContextoAuth)
			'Adding the CreditMemo
			Dim added As CreditMemo = Helper.Add(Of CreditMemo)(qboContextoAuth, entity)

			'Update the CreditMemo
			Dim updated As CreditMemo = QBOHelper.UpdateCreditMemoSparse(qboContextoAuth, added.Id, added.SyncToken)
			'Call the service
			Dim updatedReturned As CreditMemo = Helper.UpdateAsync(Of CreditMemo)(qboContextoAuth, updated)

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

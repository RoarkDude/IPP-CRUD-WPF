
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq


	Public Class EstimateCRUD
		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub EstimateAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Estimate for Add
			Dim estimate As Estimate = QBOHelper.CreateEstimate(qboContextoAuth)
			'Adding the Estimate
			Dim added As Estimate = Helper.Add(Of Estimate)(qboContextoAuth, estimate)

		End Sub

		#End Region

		#Region "FindAll Operations"


		Public Sub EstimateFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			EstimateAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Estimate using FindAll
			Dim estimates As List(Of Estimate) = Helper.FindAll(Of Estimate)(qboContextoAuth, New Estimate(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub EstimateFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Estimate for Adding
			Dim estimate As Estimate = QBOHelper.CreateEstimate(qboContextoAuth)
			'Adding the Estimate
			Dim added As Estimate = Helper.Add(Of Estimate)(qboContextoAuth, estimate)
			Dim found As Estimate = Helper.FindById(Of Estimate)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub EstimateUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Estimate for Adding
			Dim estimate As Estimate = QBOHelper.CreateEstimate(qboContextoAuth)
			'Adding the Estimate
			Dim added As Estimate = Helper.Add(Of Estimate)(qboContextoAuth, estimate)
			'Change the data of added entity
			Dim changed As Estimate = QBOHelper.UpdateEstimate(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Estimate = Helper.Update(Of Estimate)(qboContextoAuth, changed)
			'Verify the updated Estimate
		End Sub


		Public Sub EstimateSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Estimate for Adding
			Dim estimate As Estimate = QBOHelper.CreateEstimate(qboContextoAuth)
			'Adding the Estimate
			Dim added As Estimate = Helper.Add(Of Estimate)(qboContextoAuth, estimate)
			'Change the data of added entity
			Dim changed As Estimate = QBOHelper.SparseUpdateEstimate(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As Estimate = Helper.Update(Of Estimate)(qboContextoAuth, changed)
			'Verify the updated Estimate
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub EstimateDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Estimate for Adding
			Dim estimate As Estimate = QBOHelper.CreateEstimate(qboContextoAuth)
			'Adding the Estimate
			Dim added As Estimate = Helper.Add(Of Estimate)(qboContextoAuth, estimate)
			'Delete the returned entity
			Try

				Dim deleted As Estimate = Helper.Delete(Of Estimate)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub



		#End Region

		#Region "CDC Operations"


		Public Sub EstimateCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			EstimateAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Estimate using FindAll
			Dim estimates As List(Of Estimate) = Helper.CDC(qboContextoAuth, New Estimate(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub EstimateBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Estimate = Helper.FindOrAdd(qboContextoAuth, New Estimate())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateEstimate(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateEstimate(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Estimate")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Estimate)(qboContextoAuth, batchEntries)

		End Sub

		#End Region

		#Region "Query"

		Public Sub EstimateQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of Estimate)(qboContextoAuth)
			Dim existing As Estimate = Helper.FindOrAdd(Of Estimate)(qboContextoAuth, New Estimate())
			Dim es As List(Of Estimate) = entityQuery.ExecuteIdsQuery("SELECT * FROM Estimate where Id='" + existing.Id + "'").ToList() '(Of Estimate)()

		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub EstimateAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Estimate for Add
			Dim entity As Estimate = QBOHelper.CreateEstimate(qboContextoAuth)

			Dim added As Estimate = Helper.AddAsync(Of Estimate)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub EstimateRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			EstimateAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Estimate using FindAll
			Helper.FindAllAsync(Of Estimate)(qboContextoAuth, New Estimate())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub EstimateFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Estimate for Adding
			Dim entity As Estimate = QBOHelper.CreateEstimate(qboContextoAuth)
			'Adding the Estimate
			Dim added As Estimate = Helper.Add(Of Estimate)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of Estimate)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub EstimateUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Estimate for Adding
			Dim entity As Estimate = QBOHelper.CreateEstimate(qboContextoAuth)
			'Adding the Estimate
			Dim added As Estimate = Helper.Add(Of Estimate)(qboContextoAuth, entity)

			'Update the Estimate
			Dim updated As Estimate = QBOHelper.UpdateEstimate(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Estimate = Helper.UpdateAsync(Of Estimate)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"


		Public Sub EstimateDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Estimate for Adding
			Dim entity As Estimate = QBOHelper.CreateEstimate(qboContextoAuth)
			'Adding the Estimate
			Dim added As Estimate = Helper.Add(Of Estimate)(qboContextoAuth, entity)

			Helper.DeleteAsync(Of Estimate)(qboContextoAuth, added)
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

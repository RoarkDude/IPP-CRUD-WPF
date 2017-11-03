
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq



	Public Class VendorCreditCRUD

		#Region "Sync Methods"

		#Region "Add Operations"


		Public Sub VendorCreditAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the VendorCredit for Add
			Dim vendorCredit As VendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth)
			'Adding the VendorCredit
			Dim added As VendorCredit = Helper.Add(Of VendorCredit)(qboContextoAuth, vendorCredit)

		End Sub

		#End Region


		#Region "FindbyId Operations"


		Public Sub VendorCreditFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the VendorCredit for Adding
			Dim vendorCredit As VendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth)
			'Adding the VendorCredit
			Dim added As VendorCredit = Helper.Add(Of VendorCredit)(qboContextoAuth, vendorCredit)
			Dim found As VendorCredit = Helper.FindById(Of VendorCredit)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub VendorCreditUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the VendorCredit for Adding
			Dim vendorCredit As VendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth)
			'Adding the VendorCredit
			Dim added As VendorCredit = Helper.Add(Of VendorCredit)(qboContextoAuth, vendorCredit)
			'Change the data of added entity
			Dim changed As VendorCredit = QBOHelper.UpdateVendorCredit(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As VendorCredit = Helper.Update(Of VendorCredit)(qboContextoAuth, changed)
			'Verify the updated VendorCredit
		End Sub


		Public Sub VendorCreditSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the VendorCredit for Adding
			Dim vendorCredit As VendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth)
			'Adding the VendorCredit
			Dim added As VendorCredit = Helper.Add(Of VendorCredit)(qboContextoAuth, vendorCredit)
			'Change the data of added entity
			Dim changed As VendorCredit = QBOHelper.UpdateVendorCreditSparse(qboContextoAuth, added.Id, added.SyncToken, added.VendorRef)
			'Update the returned entity data
			Dim updated As VendorCredit = Helper.Update(Of VendorCredit)(qboContextoAuth, changed)
			'Verify the updated VendorCredit
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub VendorCreditDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the VendorCredit for Adding
			Dim vendorCredit As VendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth)
			'Adding the VendorCredit
			Dim added As VendorCredit = Helper.Add(Of VendorCredit)(qboContextoAuth, vendorCredit)
			'Delete the returned entity
			Try

				Dim deleted As VendorCredit = Helper.Delete(Of VendorCredit)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub



		#End Region

		#Region "CDC Operations"


		Public Sub VendorCreditCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			VendorCreditAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the VendorCredit using CDC
			Dim entities As List(Of VendorCredit) = Helper.CDC(qboContextoAuth, New VendorCredit(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub VendorCreditBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			'VendorCredit existing = Helper.FindOrAdd(qboContextoAuth, new VendorCredit());

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateVendorCredit(qboContextoAuth))

			'batchEntries.Add(OperationEnum.update, QBOHelper.UpdateVendorCredit(qboContextoAuth, existing));

			'batchEntries.Add(OperationEnum.query, "select * from VendorCredit");

			'batchEntries.Add(OperationEnum.delete, existing);

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of VendorCredit)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub VendorCreditQueryUsingoAuth(qboContextoAuth As ServiceContext)
			Dim entityQuery As New QueryService(Of VendorCredit)(qboContextoAuth)
			Dim existing As VendorCredit = Helper.FindOrAdd(Of VendorCredit)(qboContextoAuth, New VendorCredit())
			Dim test As List(Of VendorCredit) = entityQuery.ExecuteIdsQuery("SELECT * FROM VendorCredit where Id='" + existing.Id + "'").ToList() '(Of VendorCredit)()

		End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub VendorCreditAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the VendorCredit for Add
			Dim entity As VendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth)

			Dim added As VendorCredit = Helper.AddAsync(Of VendorCredit)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"

		'[Ignore]  //IgnoreReason:  Not Supported
		Public Sub VendorCreditRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			VendorCreditAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the VendorCredit using FindAll
			Helper.FindAllAsync(Of VendorCredit)(qboContextoAuth, New VendorCredit())
		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub VendorCreditFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the VendorCredit for Adding
			Dim entity As VendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth)
			'Adding the VendorCredit
			Dim added As VendorCredit = Helper.Add(Of VendorCredit)(qboContextoAuth, entity)

			'FindById and verify
			Helper.FindByIdAsync(Of VendorCredit)(qboContextoAuth, added)
		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub VendorCreditUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the VendorCredit for Adding
			Dim entity As VendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth)
			'Adding the VendorCredit
			Dim added As VendorCredit = Helper.Add(Of VendorCredit)(qboContextoAuth, entity)

			'Update the VendorCredit
			Dim updated As VendorCredit = QBOHelper.UpdateVendorCredit(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As VendorCredit = Helper.UpdateAsync(Of VendorCredit)(qboContextoAuth, updated)
		End Sub

		#End Region

		#Region "Delete Operation"


		Public Sub VendorCreditDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the VendorCredit for Adding
			Dim entity As VendorCredit = QBOHelper.CreateVendorCredit(qboContextoAuth)
			'Adding the VendorCredit
			Dim added As VendorCredit = Helper.Add(Of VendorCredit)(qboContextoAuth, entity)

			Helper.DeleteAsync(Of VendorCredit)(qboContextoAuth, added)
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

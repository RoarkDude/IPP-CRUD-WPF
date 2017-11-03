
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.IO


	Public Class AttachableCRUD

		#Region "Sync Methods"

		#Region "Add Operations"

		'This attachable endpoint is used to add a note
		Public Sub AttachableAddTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Attachable for Add
			Dim attachable As Attachable = QBOHelper.CreateAttachable(qboContextoAuth)
			'Adding the Attachable
			Dim added As Attachable = Helper.Add(Of Attachable)(qboContextoAuth, attachable)
			'Verify the added Attachable

		End Sub


		'This is the endpoint for actual uppload of any attachments pdf/images/xls etc
		Public Sub AttachableUploadDownloadAddTestUsingoAuth(qboContextoAuth As ServiceContext)


			Dim imagePath As String = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "\", "Resource\invoice.pdf")

			Dim file As New System.IO.FileInfo(imagePath)
			Dim attachable As Attachable = QBOHelper.CreateAttachableUpload(qboContextoAuth)
			Using fs As System.IO.FileStream = file.OpenRead()
				'attachable.ContentType = "image/jpeg";
				attachable.ContentType = "application/pdf"
				attachable.FileName = file.Name
				attachable = Helper.Upload(qboContextoAuth, attachable, fs)
			End Using
			'Upload attachment
			Dim uploadedByte As Byte() = Nothing
			Using fs As System.IO.FileStream = file.OpenRead()
				Using binaryReader As New BinaryReader(fs)
					uploadedByte = binaryReader.ReadBytes(CInt(fs.Length))
				End Using
			End Using
			'To read online file
			'using (MemoryStream fs1 = new MemoryStream())
			'{
			'    using (BinaryReader binaryReader = new BinaryReader(fs1))
			'    {
			'        uploadedByte = binaryReader.ReadBytes((int)fs1.Length);
			'    }
			'}

			'Dowload Attachment
			Dim responseByte As Byte() = Helper.Download(qboContextoAuth, attachable)


		End Sub
		#End Region

		#Region "FindAll Operations"


		Public Sub AttachableFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			AttachableAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Attachable using FindAll
			Dim attachables As List(Of Attachable) = Helper.FindAll(Of Attachable)(qboContextoAuth, New Attachable(), 1, 500)

		End Sub

		#End Region

		#Region "FindbyId Operations"


		Public Sub AttachableFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Attachable for Adding
			Dim attachable As Attachable = QBOHelper.CreateAttachable(qboContextoAuth)
			'Adding the Attachable
			Dim added As Attachable = Helper.Add(Of Attachable)(qboContextoAuth, attachable)
			Dim found As Attachable = Helper.FindById(Of Attachable)(qboContextoAuth, added)

		End Sub

		#End Region

		#Region "Update Operations"


		Public Sub AttachableUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Attachable for Adding
			Dim attachable As Attachable = QBOHelper.CreateAttachable(qboContextoAuth)
			'Adding the Attachable
			Dim added As Attachable = Helper.Add(Of Attachable)(qboContextoAuth, attachable)
			'Change the data of added entity
			Dim changed As Attachable = QBOHelper.UpdateAttachable(qboContextoAuth, added)
			'Update the returned entity data
			Dim updated As Attachable = Helper.Update(Of Attachable)(qboContextoAuth, changed)
			'Verify the updated Attachable
		End Sub


		Public Sub AttachableSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Attachable for Adding
			Dim attachable As Attachable = QBOHelper.CreateAttachable(qboContextoAuth)
			'Adding the Attachable
			Dim added As Attachable = Helper.Add(Of Attachable)(qboContextoAuth, attachable)
			'Change the data of added entity
			Dim changed As Attachable = QBOHelper.SparseUpdateAttachable(qboContextoAuth, added.Id, added.SyncToken)
			'Update the returned entity data
			Dim updated As Attachable = Helper.Update(Of Attachable)(qboContextoAuth, changed)
			'Verify the updated Attachable
		End Sub

		#End Region

		#Region "Delete Operations"


		Public Sub AttachableDeleteTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Attachable for Adding
			Dim attachable As Attachable = QBOHelper.CreateAttachable(qboContextoAuth)
			'Adding the Attachable
			Dim added As Attachable = Helper.Add(Of Attachable)(qboContextoAuth, attachable)
			'Delete the returned entity
			Try

				Dim deleted As Attachable = Helper.Delete(Of Attachable)(qboContextoAuth, added)

			Catch ex As IdsException
			End Try
		End Sub




		#End Region

		#Region "CDC Operations"


		Public Sub AttachableCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			AttachableAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Attachable using CDC
			Dim entities As List(Of Attachable) = Helper.CDC(qboContextoAuth, New Attachable(), DateTime.Today.AddDays(-1))

		End Sub

		#End Region

		#Region "Batch"


		Public Sub AttachableBatchUsingoAuth(qboContextoAuth As ServiceContext)
			Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

			Dim existing As Attachable = Helper.FindOrAdd(qboContextoAuth, New Attachable())

			batchEntries.Add(OperationEnum.create, QBOHelper.CreateAttachable(qboContextoAuth))

			batchEntries.Add(OperationEnum.update, QBOHelper.UpdateAttachable(qboContextoAuth, existing))

			batchEntries.Add(OperationEnum.query, "select * from Attachable")

			batchEntries.Add(OperationEnum.delete, existing)

			Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Attachable)(qboContextoAuth, batchEntries)


		End Sub

		#End Region

		#Region "Query"

		Public Sub AttachableQueryUsingoAuth(qboContextoAuth As ServiceContext)
		'Nimisha verify
			Dim entityQuery As New QueryService(Of Attachable)(qboContextoAuth)
			Dim existing As Attachable = Helper.FindOrAdd(Of Attachable)(qboContextoAuth, New Attachable())
        Dim pref As List(Of Attachable) = entityQuery.ExecuteIdsQuery("SELECT * FROM Attachable where Id='" + existing.Id + "'").ToList() '(Of Attachable)()

    End Sub

		#End Region

		#End Region

		#Region "ASync Methods"

		#Region "Add Operation"


		Public Sub AttachableAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Attachable for Add
			Dim entity As Attachable = QBOHelper.CreateAttachable(qboContextoAuth)

			Dim added As Attachable = Helper.AddAsync(Of Attachable)(qboContextoAuth, entity)

		End Sub

		#End Region

		#Region "FindAll Operation"


		Public Sub AttachableRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Making sure that at least one entity is already present
			AttachableAddTestUsingoAuth(qboContextoAuth)

			'Retrieving the Attachable using FindAll

		End Sub

		#End Region

		#Region "FindById Operation"


		Public Sub AttachableFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Attachable for Adding
			Dim entity As Attachable = QBOHelper.CreateAttachable(qboContextoAuth)
			'Adding the Attachable
			Dim added As Attachable = Helper.Add(Of Attachable)(qboContextoAuth, entity)


		End Sub

		#End Region

		#Region "Update Operation"


		Public Sub AttachableUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Attachable for Adding
			Dim entity As Attachable = QBOHelper.CreateAttachable(qboContextoAuth)
			'Adding the Attachable
			Dim added As Attachable = Helper.Add(Of Attachable)(qboContextoAuth, entity)

			'Update the Attachable
			Dim updated As Attachable = QBOHelper.UpdateAttachable(qboContextoAuth, added)
			'Call the service
			Dim updatedReturned As Attachable = Helper.UpdateAsync(Of Attachable)(qboContextoAuth, updated)

		End Sub

		#End Region

		#Region "Delete Operation"


		Public Sub AttachableDeleteAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
			'Creating the Attachable for Adding
			Dim entity As Attachable = QBOHelper.CreateAttachable(qboContextoAuth)
			'Adding the Attachable
			Dim added As Attachable = Helper.Add(Of Attachable)(qboContextoAuth, entity)

			Helper.DeleteAsync(Of Attachable)(qboContextoAuth, added)
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

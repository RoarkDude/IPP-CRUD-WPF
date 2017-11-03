
Imports System.Collections.Generic
Imports System.Linq
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Reflection
Imports System.Threading
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.ReportService

Public Class Helper

    Private Shared WithEvents _service As DataService
    Private Shared WithEvents _reportservice As ReportService

    Friend Shared Function Add(Of T As IEntity)(context As ServiceContext, entity As T) As T
        'Initializing the Dataservice object with ServiceContext
        'Dim service As New DataService(context)
        _service = New DataService(context)
        'Adding the Bill using Dataservice object

        Dim added As T = _service.Add(Of T)(entity)

        Return added

    End Function

    Friend Shared Function FindAll(Of T As IEntity)(context As ServiceContext, entity As T, Optional startPosition As Integer = 1, Optional maxResults As Integer = 100) As List(Of T)
        Dim service As New DataService(context)

        Dim entityList As ReadOnlyCollection(Of T) = service.FindAll(entity, startPosition, maxResults)

        Return entityList.ToList '(Of T)()?
    End Function

    Friend Shared Function FindById(Of T As IEntity)(context As ServiceContext, entity As T) As T
        Dim service As New DataService(context)
        Dim foundEntity As T = service.FindById(entity)

        Return foundEntity
    End Function

    Friend Shared Function Update(Of T As IEntity)(context As ServiceContext, entity As T) As T
        'initializing the dataservice object with servicecontext
        Dim service As New DataService(context)

        'updating the entity
        Dim updated As T = service.Update(Of T)(entity)

        Return updated
    End Function





    Friend Shared Function SparseUpdate(Of T As IEntity)(context As ServiceContext, entity As T) As T
        'initializing the dataservice object with servicecontext
        Dim service As New DataService(context)

        'updating the entity
        Dim updated As T = service.Update(Of T)(entity)

        Return updated
    End Function

    Friend Shared Function Delete(Of T As IEntity)(context As ServiceContext, entity As T) As T
        'Initializing the Dataservice object with ServiceContext
        Dim service As New DataService(context)

        'Deleting the Bill using the service
        Dim deleted As T = service.Delete(Of T)(entity)

        Return deleted
    End Function


    Friend Shared Function Void(Of T As IEntity)(context As ServiceContext, entity As T) As T
        'Initializing the Dataservice object with ServiceContext
        Dim service As New DataService(context)

        'Voiding the entity using the service
        service.Void(Of T)(entity)

        Try
            'Retrieving the voided entity
            Dim found As T = service.FindById(Of T)(entity)

            Return found
        Catch generatedExceptionName As IdsException
        End Try

        Return entity
    End Function

    Friend Shared Function CDC(Of T As IEntity)(context As ServiceContext, entity As T, changedSince As DateTime) As List(Of T)
        'Initializing the Dataservice object with ServiceContext
        Dim service As New DataService(context)

        Dim entityList As New List(Of IEntity)()
        entityList.Add(entity)

        Dim response As IntuitCDCResponse = service.CDC(entityList, changedSince)
        If response.entities.Count = 0 Then
            Return Nothing
        End If
        'Retrieving the entity List
        Dim found As List(Of T) = response.getEntity(entity.[GetType]().Name).Cast(Of T)().ToList()

        Return found
    End Function

    Friend Shared Function Upload(context As ServiceContext, attachable As Attachable, stream As System.IO.Stream) As Attachable
        'Initializing the Dataservice object with ServiceContext
        Dim service As New DataService(context)

        Dim uploaded As Attachable = service.Upload(attachable, stream)
        Return uploaded
    End Function

    Friend Shared Function Download(context As ServiceContext, entity As Attachable) As Byte()
        'Initializing the Dataservice object with ServiceContext
        Dim service As New DataService(context)

        Return service.Download(entity)
    End Function

    Friend Shared Function Batch(Of T As IEntity)(context As ServiceContext, operationDictionary As Dictionary(Of OperationEnum, Object)) As ReadOnlyCollection(Of IntuitBatchResponse)
        Dim service As New DataService(context)
        Dim addedList As New List(Of T)()
        Dim newList As New List(Of T)()


        Dim entityContext As New QueryService(Of T)(context)

        Dim batch__1 As Batch = service.CreateNewBatch()

        For Each entry As KeyValuePair(Of OperationEnum, Object) In operationDictionary
            If entry.Value.[GetType]().Name.Equals(GetType(T).Name) Then
                batch__1.Add(TryCast(entry.Value, IEntity), entry.Key.ToString() + entry.Value.[GetType]().Name, entry.Key)
            Else
                batch__1.Add(TryCast(entry.Value, String), "Query" + GetType(T).Name)
            End If
        Next



        batch__1.Execute()

        Return batch__1.IntuitBatchItemResponses
    End Function


    Friend Shared Function CheckEqual(expected As [Object], actual As [Object]) As [Boolean]
        Return True
    End Function

    Friend Shared Function GetGuid() As [String]
        Return Guid.NewGuid().ToString("N")
    End Function

    Friend Shared Function GetReportAsync(context As ServiceContext, reportName As String) As Report
        'Initializing the Dataservice object with ServiceContext
        Dim service As New ReportService(context)
        _reportservice = New ReportService(context)
        Dim exp As IdsException = Nothing
        Dim reportReturned As [Boolean] = False
        Dim actual As Report = Nothing

        ' Used to signal the waiting test thread that a async operation have completed.    
        Dim manualEvent As New ManualResetEvent(False)

        ' Async callback events are anonomous and are in the same scope as the test code,    
        ' and therefore have access to the manualEvent variable.   

        service.OnExecuteReportAsyncCompleted = Sub(sender As Object, e As ReportCallCompletedEventArgs(Of Report))
                                                    manualEvent.Set()

                                                    If e.[Error] IsNot Nothing Then
                                                        exp = e.[Error]
                                                    End If
                                                    If exp Is Nothing Then
                                                        If e.Report IsNot Nothing Then
                                                            reportReturned = True
                                                            actual = e.Report
                                                        End If
                                                    End If
                                                End Sub

        ' Call the service method
        service.ExecuteReportAsync(reportName)

        manualEvent.WaitOne(30000, False)
        Thread.Sleep(10000)

        If exp IsNot Nothing Then
            Throw exp
        End If

        ' Check if we completed the async call   
        'return null; Nimisha
        If Not reportReturned Then
        End If

        ' Set the event to non-signaled before making next async call.    
        manualEvent.Reset()
        Return actual

    End Function

    Friend Shared Function AddAsync(Of T As IEntity)(context As ServiceContext, entity As T) As T
        'Initializing the Dataservice object with ServiceContext
        Dim service As New DataService(context)

        Dim isAdded As Boolean = False

        Dim exp As IdsException = Nothing

        Dim actual As T = DirectCast(Activator.CreateInstance(entity.[GetType]()), T)
        ' Used to signal the waiting test thread that a async operation have completed.    
        Dim manualEvent As New ManualResetEvent(False)

        ' Async callback events are anonomous and are in the same scope as the test code,    
        ' and therefore have access to the manualEvent variable.    
        service.OnAddAsyncCompleted = Sub(sender, e)
                                          isAdded = True
                                          manualEvent.[Set]()
                                          If e.[Error] IsNot Nothing Then
                                              exp = e.[Error]
                                          End If
                                          If exp Is Nothing Then
                                              If e.Entity IsNot Nothing Then
                                                  actual = DirectCast(e.Entity, T)
                                              End If
                                          End If
                                      End Sub

        ' Call the service method
        service.AddAsync(entity)

        manualEvent.WaitOne(30000, False)
        Thread.Sleep(10000)

        If exp IsNot Nothing Then
            Throw exp
        End If

        ' Check if we completed the async call, or fail the test if we timed out.    
        'return null;
        If Not isAdded Then
        End If

        ' Set the event to non-signaled before making next async call.    
        manualEvent.Reset()

        Return actual

    End Function

    Friend Shared Function FindAllAsync(Of T As IEntity)(context As ServiceContext, entity As T, Optional startPosition As Integer = 1, Optional maxResults As Integer = 500) As List(Of T)
        'Initializing the Dataservice object with ServiceContext
        Dim service As New DataService(context)

        Dim isFindAll As Boolean = False

        Dim exp As IdsException = Nothing

        ' Used to signal the waiting test thread that a async operation have completed.    
        Dim manualEvent As New ManualResetEvent(False)

        Dim entities As New List(Of T)()

        ' Async callback events are anonomous and are in the same scope as the test code,    
        ' and therefore have access to the manualEvent variable.    
        service.OnFindAllAsyncCompleted = Sub(sender, e)
                                              isFindAll = True
                                              manualEvent.[Set]()
                                              If e.[Error] IsNot Nothing Then
                                                  exp = e.[Error]
                                              End If
                                              If exp Is Nothing Then
                                                  If e.Entities IsNot Nothing Then
                                                      For Each en As IEntity In e.Entities
                                                          entities.Add(DirectCast(en, T))
                                                      Next
                                                  End If
                                              End If
                                          End Sub

        ' Call the service method
        service.FindAllAsync(Of T)(entity, 1, 10)

        manualEvent.WaitOne(60000, False)
        Thread.Sleep(10000)


        '''/ Check if we completed the async call, or fail the test if we timed out.    
        'if (!isFindAll)
        '{
        '    return null;
        '}

        If exp IsNot Nothing Then
            Throw exp
        End If

        'if (entities != null)
        '{
        '    Assert.IsTrue(entities.Count >= 0);
        '}

        ' Set the event to non-signaled before making next async call.    
        manualEvent.Reset()
        Return entities
    End Function

    Friend Shared Function FindByIdAsync(Of T As IEntity)(context As ServiceContext, entity As T) As T
        'Initializing the Dataservice object with ServiceContext
        Dim service As New DataService(context)

        Dim isFindById As Boolean = False

        Dim exp As IdsException = Nothing

        ' Used to signal the waiting test thread that a async operation have completed.    
        Dim manualEvent As New ManualResetEvent(False)

        Dim returnedEntity As T = Nothing

        ' Async callback events are anonomous and are in the same scope as the test code,    
        ' and therefore have access to the manualEvent variable.    
        service.OnFindByIdAsyncCompleted = Sub(sender, e)

                                               manualEvent.[Set]()
                                               isFindById = True
                                               returnedEntity = DirectCast(e.Entity, T)

                                           End Sub

        ' Call the service method
        service.FindByIdAsync(Of T)(entity)
        manualEvent.WaitOne(60000, False)
        Thread.Sleep(10000)

        '''/ Check if we completed the async call, or fail the test if we timed out.    
        'if (!isFindById)
        '{
        '    //return null;
        '}

        If exp IsNot Nothing Then
            Throw exp
        End If

        ' Set the event to non-signaled before making next async call.    
        manualEvent.Reset()
        Return returnedEntity
    End Function

    Friend Shared Function UpdateAsync(Of T As IEntity)(context As ServiceContext, entity As T) As T
        'Initializing the Dataservice object with ServiceContext
        Dim service As New DataService(context)

        Dim isUpdated As Boolean = False

        ' Used to signal the waiting test thread that a async operation have completed.    
        Dim manualEvent As New ManualResetEvent(False)

        Dim exp As IdsException = Nothing

        Dim returnedEntity As T = entity
        ' Async callback events are anonomous and are in the same scope as the test code,    
        ' and therefore have access to the manualEvent variable.    
        service.OnUpdateAsyncCompleted = Sub(sender, e)

                                             isUpdated = True
                                             manualEvent.[Set]()
                                             If e.[Error] IsNot Nothing Then
                                                 exp = e.[Error]
                                             Else
                                                 If e.Entity IsNot Nothing Then
                                                     returnedEntity = DirectCast(e.Entity, T)
                                                 End If
                                             End If

                                         End Sub

        ' Call the service method
        service.UpdateAsync(entity)

        manualEvent.WaitOne(30000, False)
        Thread.Sleep(10000)

        If exp IsNot Nothing Then
            Throw exp
        End If
        ' Check if we completed the async call, or fail the test if we timed out.    
        'return null
        If Not isUpdated Then
        End If


        ' Set the event to non-signaled before making next async call.    
        manualEvent.Reset()

        Return returnedEntity
    End Function




    Friend Shared Function DeleteAsync(Of T As IEntity)(context As ServiceContext, entity As T) As T
        'Initializing the Dataservice object with ServiceContext
        Dim service As New DataService(context)

        Dim isDeleted As Boolean = False

        ' Used to signal the waiting test thread that a async operation have completed.    
        Dim manualEvent As New ManualResetEvent(False)

        Dim exp As IdsException = Nothing
        ' Async callback events are anonomous and are in the same scope as the test code,    
        ' and therefore have access to the manualEvent variable.    
        Dim returnedEntity As T = entity
        service.OnDeleteAsyncCompleted = Sub(sender, e)
                                             isDeleted = True
                                             manualEvent.[Set]()
                                             If e.[Error] IsNot Nothing Then
                                                 exp = e.[Error]
                                             Else
                                                 If e.Entity IsNot Nothing Then
                                                     returnedEntity = DirectCast(e.Entity, T)
                                                 End If
                                             End If

                                         End Sub

        ' Call the service method
        service.DeleteAsync(entity)

        manualEvent.WaitOne(30000, False)
        Thread.Sleep(10000)

        If exp IsNot Nothing Then
            Throw exp
        End If
        ' Check if we completed the async call, or fail the test if we timed out.    
        'if (!isDeleted)
        '{
        '   //return null;
        '}

        ' Set the event to non-signaled before making next async call.    
        manualEvent.Reset()

        Return returnedEntity
    End Function

    Friend Shared Sub VoidAsync(Of T As IEntity)(context As ServiceContext, entity As T)
        'Initializing the Dataservice object with ServiceContext
        Dim service As New DataService(context)

        Dim isVoided As Boolean = False

        ' Used to signal the waiting test thread that a async operation have completed.    
        Dim manualEvent As New ManualResetEvent(False)

        Dim exp As IdsException = Nothing
        ' Async callback events are anonomous and are in the same scope as the test code,    
        ' and therefore have access to the manualEvent variable.    
        service.OnVoidAsyncCompleted = Sub(sender, e)
                                           isVoided = True
                                           manualEvent.[Set]()
                                           If e.[Error] IsNot Nothing Then
                                               exp = e.[Error]

                                           End If

                                       End Sub

        ' Call the service method
        service.VoidAsync(entity)

        manualEvent.WaitOne(30000, False)
        Thread.Sleep(10000)

        If exp IsNot Nothing Then
            Throw exp
        End If
        '''/ Check if we completed the async call, or fail the test if we timed out.    
        'if (!isVoided)
        '{
        '    return null;
        '}

        ' Set the event to non-signaled before making next async call.    
        manualEvent.Reset()
    End Sub

    Friend Shared Function FindOrAdd(Of T As IEntity)(context As ServiceContext, entity As T) As T
        Dim returnedEntities As List(Of T) = FindAll(Of T)(context, entity, 1, 500)
        Dim count As Integer = 0
        For Each en As T In returnedEntities
            If TryCast(returnedEntities(count), IntuitEntity).status <> EntityStatusEnum.SyncError Then
                Return returnedEntities(count)
            End If
            count += 1
        Next


        Dim bindingFlags__1 As BindingFlags = BindingFlags.NonPublic Or BindingFlags.[Static]
        Dim types As Type() = Assembly.GetExecutingAssembly().GetTypes()

        For Each type As Type In types
            If context.ServiceType = IntuitServicesType.QBO AndAlso type.Name = "QBOHelper" Then
                Dim methodName As [String] = "Create" + entity.[GetType]().Name
                Dim method As MethodInfo = type.GetMethod("Create" + entity.[GetType]().Name, bindingFlags__1)
                entity = DirectCast(method.Invoke(Nothing, New Object() {context}), T)
                Dim returnEntity As T = Add(context, entity)
                Return returnEntity
            End If
        Next
        Throw New System.ApplicationException("Could not find QBOHelper")
    End Function

    Friend Shared Function FindOrAddAccount(context As ServiceContext, accountType As AccountTypeEnum, classification As AccountClassificationEnum) As Account
        Dim typeOfAccount As Account = Nothing
        Dim listOfAccount As List(Of Account) = FindAll(Of Account)(context, New Account(), 1, 500)
        If listOfAccount.Count > 0 Then
            For Each acc As Account In listOfAccount
                If acc.AccountType = accountType AndAlso acc.Classification = classification AndAlso acc.status <> EntityStatusEnum.SyncError Then
                    typeOfAccount = acc
                    Exit For
                End If
            Next
        End If

        If typeOfAccount Is Nothing Then
            Dim service As New DataService(context)
            Dim account As Account

            account = QBOHelper.CreateAccount(context, accountType, classification)
            account.Classification = classification
            account.AccountType = accountType
            Dim createdAccount As Account = service.Add(Of Account)(account)


            typeOfAccount = createdAccount
        End If

        Return typeOfAccount
    End Function

    Friend Shared Function FindOrAddPurchase(context As ServiceContext, paymentType As PaymentTypeEnum) As Purchase
        Dim typeOfPurchase As Purchase = Nothing
        Dim listOfPurchase As List(Of Purchase) = FindAll(Of Purchase)(context, New Purchase(), 1, 10).Where(Function(p) p.status <> EntityStatusEnum.SyncError).ToList()
        If listOfPurchase.Count > 0 Then
            If context.ServiceType = IntuitServicesType.QBO Then

                For Each payment As Purchase In listOfPurchase
                    If payment.PaymentType = paymentType Then
                        typeOfPurchase = payment
                        Exit For
                    End If
                Next

                If typeOfPurchase Is Nothing Then
                    'create a new purchase account
                    Dim service As New DataService(context)
                    Dim purchase As Purchase
                    purchase = QBOHelper.CreatePurchase(context, PaymentTypeEnum.Cash)

                    Dim createdPurchase As Purchase = service.Add(Of Purchase)(purchase)
                    typeOfPurchase = createdPurchase
                End If

            End If
        End If

        Return typeOfPurchase
    End Function


    Friend Shared Function FindOrAddPaymentMethod(context As ServiceContext, paymentType As String) As PaymentMethod
        Dim typeOfPayment As PaymentMethod = Nothing
        Dim listOfPayment As List(Of PaymentMethod) = FindAll(Of PaymentMethod)(context, New PaymentMethod(), 1, 10).Where(Function(p) p.status <> EntityStatusEnum.SyncError).ToList()
        If listOfPayment.Count > 0 Then
            If context.ServiceType = IntuitServicesType.QBO Then

                For Each payment As PaymentMethod In listOfPayment
                    If payment.Type = paymentType Then
                        typeOfPayment = payment
                        Exit For
                    End If
                Next

                If typeOfPayment Is Nothing Then
                    'Create a new purchase account
                    Dim service As New DataService(context)
                    Dim payment As PaymentMethod
                    payment = QBOHelper.CreatePaymentMethod(context)
                    Dim createdPurchase As PaymentMethod = service.Add(Of PaymentMethod)(payment)
                    typeOfPayment = createdPurchase
                End If

            End If
        End If

        Return typeOfPayment
    End Function

    Friend Shared Function FindOrAddItem(context As ServiceContext, type As ItemTypeEnum) As Item
        Dim typeOfItem As Item = Nothing
        Dim listOfItem As List(Of Item) = FindAll(Of Item)(context, New Item(), 1, 500).Where(Function(i) i.status <> EntityStatusEnum.SyncError).ToList()
        If listOfItem.Count > 0 Then
            For Each item As Item In listOfItem
                If item.Type = type Then
                    typeOfItem = item
                    Exit For
                End If
            Next
        End If

        If typeOfItem Is Nothing Then
            Dim service As New DataService(context)
            Dim item As Item

            item = QBOHelper.CreateItem(context)
            Dim createdItem As Item = service.Add(Of Item)(item)


            typeOfItem = createdItem
        End If

        Return typeOfItem
    End Function


End Class

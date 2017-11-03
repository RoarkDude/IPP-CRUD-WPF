
Imports System.Collections.Generic
Imports Intuit.Ipp.Core
Imports Intuit.Ipp.Data
Imports Intuit.Ipp.QueryFilter
Imports Intuit.Ipp.DataService
Imports Intuit.Ipp.Exception
Imports System.Collections.ObjectModel
Imports System.Linq

Public Class AccountCRUD
#Region "Sync Methods"

#Region "Add Operations"


    Public Sub AddBankAccountTestUsingoAuth(qboContextoAuth As ServiceContext)
        'Creating the Account for Add
        Dim account As Account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        'Adding the Account
        Dim added As Account = Helper.Add(Of Account)(qboContextoAuth, account)
        'Verify the added Account

    End Sub



    Public Sub AddCreditCardAccountTestUsingoAuth(qboContextoAuth As ServiceContext)
        'Creating the Account for Add
        Dim account As Account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.CreditCard, AccountClassificationEnum.Liability)
        'Adding the Account
        Dim added As Account = Helper.Add(Of Account)(qboContextoAuth, account)


    End Sub



    Public Sub AddExpenseAccountTestUsingoAuth(qboContextoAuth As ServiceContext)
        'Creating the Account for Add
        Dim account As Account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Expense, AccountClassificationEnum.Expense)
        'Adding the Account
        Dim added As Account = Helper.Add(Of Account)(qboContextoAuth, account)
        'Verify the added Account

    End Sub

#End Region

#Region "FindAll Operations"


    Public Sub AccountFindAllTestUsingoAuth(qboContextoAuth As ServiceContext)
        'Making sure that at least one entity is already present
        AddBankAccountTestUsingoAuth(qboContextoAuth)

        'Retrieving the Account using FindAll
        Dim accounts As List(Of Account) = Helper.FindAll(Of Account)(qboContextoAuth, New Account(), 1, 500)

    End Sub

#End Region

#Region "FindbyId Operations"


    Public Sub AccountFindbyIdTestUsingoAuth(qboContextoAuth As ServiceContext)
        'Creating the Account for Adding
        Dim account As Account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        'Adding the Account
        Dim added As Account = Helper.Add(Of Account)(qboContextoAuth, account)
        Dim found As Account = Helper.FindById(Of Account)(qboContextoAuth, added)

    End Sub



#End Region

#Region "Update Operations"


    Public Sub AccountUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
        'Creating the Account for Adding
        Dim account As Account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        'Adding the Account
        Dim added As Account = Helper.Add(Of Account)(qboContextoAuth, account)
        'Change the data of added entity
        Dim changed As Account = QBOHelper.UpdateAccount(qboContextoAuth, added)
        'Update the returned entity data
        Dim updated As Account = Helper.Update(Of Account)(qboContextoAuth, changed)
        'Verify the updated Account
    End Sub


    Public Sub AccountSparseUpdateTestUsingoAuth(qboContextoAuth As ServiceContext)
        'Creating the Account for Adding
        Dim account As Account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Asset)
        'Adding the Account
        Dim added As Account = Helper.Add(Of Account)(qboContextoAuth, account)
        'Change the data of added entity
        Dim changed As Account = QBOHelper.SparseUpdateAccount(qboContextoAuth, added.Id, added.SyncToken)
        'Update the returned entity data
        Dim updated As Account = Helper.Update(Of Account)(qboContextoAuth, changed)
        'Verify the updated Account
    End Sub

#End Region

#Region "Delete Operations"



#End Region

#Region "CDC Operations"


    Public Sub AccountCDCTestUsingoAuth(qboContextoAuth As ServiceContext)
        'Making sure that at least one entity is already present
        AddBankAccountTestUsingoAuth(qboContextoAuth)

        'Retrieving the Entity using FindAll
        Dim entities As List(Of Account) = Helper.CDC(qboContextoAuth, New Account(), DateTime.Today.AddDays(-1))

    End Sub

#End Region

#Region "Batch"


    Public Sub AccountBatchUsingoAuth(qboContextoAuth As ServiceContext)
        Dim batchEntries As New Dictionary(Of OperationEnum, Object)()

        Dim existing As Account = Helper.FindOrAdd(qboContextoAuth, New Account())

        batchEntries.Add(OperationEnum.create, QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Asset))

        batchEntries.Add(OperationEnum.update, QBOHelper.UpdateAccount(qboContextoAuth, existing))

        batchEntries.Add(OperationEnum.query, "select * from Account")



        Dim batchResponses As ReadOnlyCollection(Of IntuitBatchResponse) = Helper.Batch(Of Account)(qboContextoAuth, batchEntries)


    End Sub

#End Region

#Region "Query"

    Public Sub AccountQueryUsingoAuth(qboContextoAuth As ServiceContext)
        Dim entityQuery As New QueryService(Of Account)(qboContextoAuth)
        Dim existing As Account = Helper.FindOrAddAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Expense)

        Dim test As List(Of Account) = entityQuery.ExecuteIdsQuery("SELECT * FROM Account where Id='" + existing.Id + "'").ToList '(of Account) ?
    End Sub

#End Region

#End Region

#Region "ASync Methods"

#Region "Test Cases for Add Operation"


    Public Sub AccountAddAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
        'Creating the Account for Add
        Dim entity As Account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Expense)

        Dim added As Account = Helper.AddAsync(Of Account)(qboContextoAuth, entity)

    End Sub

#End Region

#Region "Test Cases for FindAll Operation"


    Public Sub AccountRetrieveAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
        'Making sure that at least one entity is already present
        AddBankAccountTestUsingoAuth(qboContextoAuth)

        'Retrieving the Account using FindAll
        Helper.FindAllAsync(Of Account)(qboContextoAuth, New Account())
    End Sub

#End Region

#Region "Test Cases for FindById Operation"


    Public Sub AccountFindByIdAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
        'Creating the Account for Adding
        Dim entity As Account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Expense)
        'Adding the Account
        Dim added As Account = Helper.Add(Of Account)(qboContextoAuth, entity)

        'FindById and verify
        Helper.FindByIdAsync(Of Account)(qboContextoAuth, added)
    End Sub

#End Region

#Region "Test Cases for Update Operation"

    Public Sub AccountUpdatedAsyncTestsUsingoAuth(qboContextoAuth As ServiceContext)
        'Creating the Account for Adding
        Dim entity As Account = QBOHelper.CreateAccount(qboContextoAuth, AccountTypeEnum.Bank, AccountClassificationEnum.Expense)
        'Adding the Account
        Dim added As Account = Helper.Add(Of Account)(qboContextoAuth, entity)

        'Update the Account
        Dim updated As Account = QBOHelper.UpdateAccount(qboContextoAuth, added)
        'Call the service
        Dim updatedReturned As Account = Helper.UpdateAsync(Of Account)(qboContextoAuth, updated)

    End Sub



#End Region

#End Region


End Class

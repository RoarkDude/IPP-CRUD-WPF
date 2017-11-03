
Imports Intuit.Ipp.Core

Public NotInheritable Class TestQBOCalls
    Private Sub New()
    End Sub


    Public Shared Sub allqbocalls(qboContextoAuth As ServiceContext)
        '#Region "all calls"
        'For each request use a unique RequestId so that server diff between diff requests and does not creates duplicates
        'qboContextoAuth.RequestId = Helper.GetGuid();


        'To use minorversion which depicts latest schema used by service
        'Check docs on developer.intuit.com to use latest minorversion

        'qboContextoAuth.IppConfiguration.MinorVersion.Qbo = "12";

        'To enable logging in text files 
        'qboContextoAuth.IppConfiguration.Logger.RequestLog.EnableRequestResponseLogging = true;
        'qboContextoAuth.IppConfiguration.Logger.RequestLog.ServiceRequestLoggingLocation = @"C:\IdsLogs";
        'OR
        'To check request/response logs along with url and headers, use Fiddler tool- https://www.telerik.com/download/fiddler
        'Download fiddler from google.Run it alongside your code to log raw request and response along with url and headers.
        'When you download fiddler> open it->just go to Tools->Fiddler Option->Enable(Tick Mark) Capture HTTPS connects->Enable Decrypt Https trafficThat is it.No other setting needs to be done.Dotnet localhost is by default captured in fiddler.So, after you enabled https traffic in fiddler.Just run your code.(Fiddler should be open)You will see request response getting logged in Fiddler.
        'You should 'decode the raw request body' by clicking on the yellow bar in fiddle.Then go to File menu on top->Save all session-> Save the fiddler session. A.saz file is created.Zip that.saz file and attach to this ticket


        '#Region "DataService and QueryService tests"

        '#Region "Name list entities sample tests"


        '#Region "account tests"

        '#Region "sync tests"
        Dim accountTest As New AccountCRUD()

        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        accountTest.AddBankAccountTestUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        accountTest.AccountFindbyIdTestUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        accountTest.AccountUpdateTestUsingoAuth(qboContextoAuth)


        'Sparse Update 
        qboContextoAuth.RequestId = Helper.GetGuid()
        accountTest.AccountSparseUpdateTestUsingoAuth(qboContextoAuth)

        'Change Data Capture(Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        accountTest.AccountCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        accountTest.AccountBatchUsingoAuth(qboContextoAuth)

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        accountTest.AccountQueryUsingoAuth(qboContextoAuth)


        'Delete is soft delete- Update with Active=false
        '#End Region

        '#Region "async tests"




        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        accountTest.AccountAddAsyncTestsUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        accountTest.AccountFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        accountTest.AccountUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region



        '#End Region

        '#Region "budget tests"

        '#Region "sync tests"
        Dim budgetTest As New BudgetCRUD()


        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        budgetTest.BudgetQueryUsingoAuth(qboContextoAuth)


        'Delete is soft delete- Update with Active=false
        '#End Region

        '#End Region

        '#Region "class tests"

        '#Region "sync tests"
        Dim classTest As New ClassCRUD()

        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        classTest.ClassAddTestUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        classTest.ClassFindbyIdTestUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        classTest.ClassUpdateTestUsingoAuth(qboContextoAuth)


        'Sparse Update 
        qboContextoAuth.RequestId = Helper.GetGuid()
        classTest.ClassSparseUpdateTestUsingoAuth(qboContextoAuth)

        'Change Data Capture(Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        classTest.ClassCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        classTest.ClassBatchUsingoAuth(qboContextoAuth)

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        classTest.ClassQueryUsingoAuth(qboContextoAuth)


        'Delete is soft delete- Update with Active=false
        '#End Region

        '#Region "async tests"




        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        classTest.ClassAddAsyncTestsUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        classTest.ClassFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        classTest.ClassUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "department tests"

        '#Region "sync tests"
        Dim departmentTest As New DepartmentCRUD()

        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        departmentTest.DepartmentAddTestUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        departmentTest.DepartmentFindbyIdTestUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        departmentTest.DepartmentUpdateTestUsingoAuth(qboContextoAuth)


        'Sparse Update 
        qboContextoAuth.RequestId = Helper.GetGuid()
        departmentTest.DepartmentSparseUpdateTestUsingoAuth(qboContextoAuth)

        'Change Data Capture(Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        departmentTest.DepartmentCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        departmentTest.DepartmentBatchUsingoAuth(qboContextoAuth)

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        departmentTest.DepartmentQueryUsingoAuth(qboContextoAuth)


        'Delete is soft delete- Update with Active=false
        '#End Region

        '#Region "async tests"




        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        departmentTest.DepartmentAddAsyncTestsUsingoAuth(qboContextoAuth)


        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        departmentTest.DepartmentUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "customer tests"

        '#Region "sync tests"
        Dim customerTest As New CustomerCRUD()

        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        customerTest.CustomerAddTestUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        customerTest.CustomerFindbyIdTestUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        customerTest.CustomerUpdateTestUsingoAuth(qboContextoAuth)


        'Sparse Update 
        qboContextoAuth.RequestId = Helper.GetGuid()
        customerTest.CustomerSparseUpdateTestUsingoAuth(qboContextoAuth)

        'Change Data Capture(Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        customerTest.CustomerCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        customerTest.CustomerBatchUsingoAuth(qboContextoAuth)

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        customerTest.CustomerQueryUsingoAuth(qboContextoAuth)


        'Delete is soft delete- Update with Active=false
        '#End Region

        '#Region "async tests"




        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        customerTest.CustomerAddAsyncTestsUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        customerTest.CustomerFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        customerTest.CustomerUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "employee tests"

        '#Region "sync tests"
        Dim employeeTest As New EmployeeCRUD()

        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        employeeTest.EmployeeAddTestUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        employeeTest.EmployeeFindbyIdTestUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        employeeTest.EmployeeUpdateTestUsingoAuth(qboContextoAuth)


        'Sparse Update 
        qboContextoAuth.RequestId = Helper.GetGuid()
        employeeTest.EmployeeSparseUpdateTestUsingoAuth(qboContextoAuth)

        'Change Data Capture(Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        employeeTest.EmployeeCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        employeeTest.EmployeeBatchUsingoAuth(qboContextoAuth)

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        employeeTest.EmployeeQueryUsingoAuth(qboContextoAuth)


        'Delete is soft delete- Update with Active=false
        '#End Region

        '#Region "async tests"




        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        employeeTest.EmployeeAddAsyncTestsUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        employeeTest.EmployeeFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        employeeTest.EmployeeUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region







        '#End Region

        '#Region "item tests"

        '#Region "sync tests"
        Dim itemTest As New ItemCRUD()

        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        itemTest.ItemAddTestUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        itemTest.ItemFindbyIdTestUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        itemTest.ItemUpdateTestUsingoAuth(qboContextoAuth)


        'Sparse Update 
        qboContextoAuth.RequestId = Helper.GetGuid()
        itemTest.ItemSparseUpdateTestUsingoAuth(qboContextoAuth)

        'Change Data Capture(Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        itemTest.ItemCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        itemTest.ItemBatchUsingoAuth(qboContextoAuth)

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        itemTest.ItemQueryUsingoAuth(qboContextoAuth)


        'Delete is soft delete- Update with Active=false
        '#End Region

        '#Region "async tests"




        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        itemTest.ItemAddAsyncTestsUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        itemTest.ItemFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        itemTest.ItemUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "journalCode tests for FR only"

        '#Region "sync tests"
        Dim journalCodeTest As New JournalCodeCRUD()


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalCodeTest.JournalCodeFindbyIdTestUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalCodeTest.JournalCodeUpdateTestUsingoAuth(qboContextoAuth)


        'Sparse Update 
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalCodeTest.JournalCodeSparseUpdateTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalCodeTest.JournalCodeBatchUsingoAuth(qboContextoAuth)

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalCodeTest.JournalCodeQueryUsingoAuth(qboContextoAuth)


        'Delete is soft delete- Update with Active=false
        '#End Region

        '#Region "async tests"




        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalCodeTest.JournalCodeAddAsyncTestsUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalCodeTest.JournalCodeFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalCodeTest.JournalCodeUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "paymentMethod tests"

        '#Region "sync tests"
        Dim paymentMethodTest As New PaymentMethodCRUD()

        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentMethodTest.PaymentMethodAddTestUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentMethodTest.PaymentMethodFindbyIdTestUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentMethodTest.PaymentMethodUpdateTestUsingoAuth(qboContextoAuth)


        'Sparse Update 
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentMethodTest.PaymentMethodSparseUpdateTestUsingoAuth(qboContextoAuth)

        'Change Data Capture(Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentMethodTest.PaymentMethodCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentMethodTest.PaymentMethodBatchUsingoAuth(qboContextoAuth)

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentMethodTest.PaymentMethodQueryUsingoAuth(qboContextoAuth)


        'Delete is soft delete- Update with Active=false
        '#End Region

        '#Region "async tests"




        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentMethodTest.PaymentMethodAddAsyncTestsUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentMethodTest.PaymentMethodFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentMethodTest.PaymentMethodUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region
        '#End Region

        '#Region "taxAgency tests"

        '#Region "sync tests"
        Dim taxAgencyTest As New TaxAgencyCRUD()

        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        taxAgencyTest.TaxAgencyAddTestUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        taxAgencyTest.TaxAgencyFindbyIdTestUsingoAuth(qboContextoAuth)



        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        taxAgencyTest.TaxAgencyQueryUsingoAuth(qboContextoAuth)



        '#End Region


        '#End Region

        '#Region "taxRate tests"

        '#Region "sync tests"
        Dim taxRateTest As New TaxRateCRUD()

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        taxRateTest.TaxRateQueryUsingoAuth(qboContextoAuth)



        '#End Region




        '#End Region

        '#Region "taxCode tests"

        '#Region "sync tests"
        Dim taxCodeTest As New TaxCodeCRUD()

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        taxCodeTest.TaxCodeQueryUsingoAuth(qboContextoAuth)



        '#End Region




        '#End Region

        '#Region "term tests"

        '#Region "sync tests"
        Dim termTest As New TermCRUD()

        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        termTest.TermAddTestUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        termTest.TermFindbyIdTestUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        termTest.TermUpdateTestUsingoAuth(qboContextoAuth)


        'Sparse Update 
        qboContextoAuth.RequestId = Helper.GetGuid()
        termTest.TermSparseUpdateTestUsingoAuth(qboContextoAuth)

        'Change Data Capture(Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        termTest.TermCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        termTest.TermBatchUsingoAuth(qboContextoAuth)

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        termTest.TermQueryUsingoAuth(qboContextoAuth)


        'Delete is soft delete- Update with Active=false
        '#End Region

        '#Region "async tests"




        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        termTest.TermAddAsyncTestsUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        termTest.TermFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        termTest.TermUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region
        '#End Region

        '#Region "vendor tests"

        '#Region "sync tests"
        Dim vendorTest As New VendorCRUD()

        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorTest.VendorAddTestUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorTest.VendorFindbyIdTestUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorTest.VendorUpdateTestUsingoAuth(qboContextoAuth)


        'Sparse Update 
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorTest.VendorSparseUpdateTestUsingoAuth(qboContextoAuth)

        'Change Data Capture(Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorTest.VendorCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorTest.VendorBatchUsingoAuth(qboContextoAuth)

        'Query
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorTest.VendorQueryUsingoAuth(qboContextoAuth)


        'Delete is soft delete- Update with Active=false
        '#End Region

        '#Region "async tests"




        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorTest.VendorAddAsyncTestsUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorTest.VendorFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Full Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorTest.VendorUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region
        '#End Region


        '#End Region

        '#Region "Transaction entities sample tests"

        '#Region "bill tests"

        '#Region "sync tests"

        Dim billTest As New BillCRUD()

        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillUpdateTestUsingoAuth(qboContextoAuth)

        'Sparse Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillSparseUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillDeleteTestUsingoAuth(qboContextoAuth)


        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'Sparse Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillSparseUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        'FindAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        billTest.BillRetrieveAsyncTestsUsingoAuth(qboContextoAuth)
        '#End Region

        '#End Region

        '#Region "billPayment tests"

        '#Region "sync tests"

        Dim billpaymentTest As New BillPaymentCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentCheckAddTestUsingoAuth(qboContextoAuth)
        billpaymentTest.BillPaymentCreditCardAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentDeleteTestUsingoAuth(qboContextoAuth)

        'Void
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentVoidTestUsingoAuth(qboContextoAuth)

        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        billpaymentTest.BillPaymentRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "creditMemo tests"

        '#Region "sync tests"

        Dim creditMemoTest As New CreditMemoCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        creditMemoTest.CreditMemoAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        creditMemoTest.CreditMemoFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        creditMemoTest.CreditMemoUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        creditMemoTest.CreditMemoCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        creditMemoTest.CreditMemoBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        creditMemoTest.CreditMemoQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        creditMemoTest.CreditMemoDeleteTestUsingoAuth(qboContextoAuth)


        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        creditMemoTest.CreditMemoAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        creditMemoTest.CreditMemoFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        creditMemoTest.CreditMemoUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        creditMemoTest.CreditMemoRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "deposit tests"

        '#Region "sync tests"

        Dim depositTest As New DepositCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        depositTest.DepositAddTestUsingoAuth(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        depositTest.DepositFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        depositTest.DepositUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        depositTest.DepositCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        depositTest.DepositBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        depositTest.DepositQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        depositTest.DepositDeleteTestUsingoAuth(qboContextoAuth)


        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        depositTest.DepositAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        depositTest.DepositFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        depositTest.DepositUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        depositTest.DepositRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "estimate tests"

        '#Region "sync tests"

        Dim estimateTest As New EstimateCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateDeleteTestUsingoAuth(qboContextoAuth)


        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateUpdatedAsyncTestsUsingoAuth(qboContextoAuth)

        'Delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateDeleteAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        estimateTest.EstimateRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "invoice tests"

        '#Region "sync tests"

        Dim invoiceTest As New InvoiceCRUD()

        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceUpdateTestUsingoAuth(qboContextoAuth)

        'Sparse Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceSparseUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceQueryTestUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceDeleteTestUsingoAuth(qboContextoAuth)

        'Void
        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceVoidTestUsingoAuth(qboContextoAuth)

        '''/Linked Payment to Invoice
        '#End Region

        '#Region "async tests"



        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceUpdateAsyncTestsUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        invoiceTest.InvoiceDeleteAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "journalEntry tests"

        '#Region "sync tests"

        Dim journalEntryTest As New JournalEntryCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalEntryTest.JournalEntryAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalEntryTest.JournalEntryFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalEntryTest.JournalEntryUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalEntryTest.JournalEntryCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalEntryTest.JournalEntryBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalEntryTest.JournalEntryQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalEntryTest.JournalEntryDeleteTestUsingoAuth(qboContextoAuth)

        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalEntryTest.JournalEntryAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalEntryTest.JournalEntryFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalEntryTest.JournalEntryUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        journalEntryTest.JournalEntryRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "payment tests"

        '#Region "sync tests"

        Dim paymentTest As New PaymentCRUD()

        'Link Payment to Invoice. Check sample code in PaymentCRUD class

        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentAddTestUsingCheck(qboContextoAuth)
        paymentTest.PaymentAddTestUsingCreditCard(qboContextoAuth)


        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentUpdateTestUsingoAuth(qboContextoAuth)

        'Sparse Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentSparseUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentDeleteTestUsingoAuth(qboContextoAuth)

        'Void
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentVoidTestUsingoAuth(qboContextoAuth)

        '''/Linked Payment to Invoice
        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentDeleteAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'Find All(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        paymentTest.PaymentRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "purchase tests"

        '#Region "sync tests"

        Dim purchaseTest As New PurchaseCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseTest.CashPurchaseAddTestUsingoAuth(qboContextoAuth)
        purchaseTest.CreditCardPurchaseAddTestUsingoAuth(qboContextoAuth)
        purchaseTest.CheckPurchaseAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseTest.CashPurchaseFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseTest.CashPurchaseUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseTest.CashPurchaseCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseTest.PurchaseBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseTest.CashPurchaseQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseTest.CashPurchaseDeleteTestUsingoAuth(qboContextoAuth)



        '#End Region



        '#End Region

        '#Region "purchaseOrder tests"

        '#Region "sync tests"

        Dim purchaseOrderTest As New PurchaseOrderCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseOrderTest.PurchaseOrderAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseOrderTest.PurchaseOrderFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseOrderTest.PurchaseOrderUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseOrderTest.PurchaseOrderCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseOrderTest.PurchaseOrderBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseOrderTest.PurchaseOrderQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseOrderTest.PurchaseOrderDeleteTestUsingoAuth(qboContextoAuth)



        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseOrderTest.PurchaseOrderAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseOrderTest.PurchaseOrderFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseOrderTest.PurchaseOrderUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        purchaseOrderTest.PurchaseOrderRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "refundReceipt tests"

        '#Region "sync tests"

        Dim refundReceiptTest As New RefundReceiptCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        refundReceiptTest.RefundReceiptAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        refundReceiptTest.RefundReceiptFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        refundReceiptTest.RefundReceiptUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        refundReceiptTest.RefundReceiptCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        refundReceiptTest.RefundReceiptBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        refundReceiptTest.RefundReceiptQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        refundReceiptTest.RefundReceiptDeleteTestUsingoAuth(qboContextoAuth)



        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        refundReceiptTest.RefundReceiptAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        refundReceiptTest.RefundReceiptFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        refundReceiptTest.RefundReceiptUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        refundReceiptTest.RefundReceiptRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "salesReceipt tests"

        '#Region "sync tests"

        Dim salesReceiptTest As New SalesReceiptCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        salesReceiptTest.SalesReceiptAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        salesReceiptTest.SalesReceiptFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        salesReceiptTest.SalesReceiptUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        salesReceiptTest.SalesReceiptCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        salesReceiptTest.SalesReceiptBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        salesReceiptTest.SalesReceiptQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        salesReceiptTest.SalesReceiptDeleteTestUsingoAuth(qboContextoAuth)



        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        salesReceiptTest.SalesReceiptAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        salesReceiptTest.SalesReceiptFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        salesReceiptTest.SalesReceiptUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        salesReceiptTest.SalesReceiptRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "timeActivity tests"

        '#Region "sync tests"

        Dim timeActivityTest As New TimeActivityCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        timeActivityTest.TimeActivityAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        timeActivityTest.TimeActivityFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        timeActivityTest.TimeActivityUpdateTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        timeActivityTest.TimeActivityBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        timeActivityTest.TimeActivityQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        timeActivityTest.TimeActivityDeleteTestUsingoAuth(qboContextoAuth)



        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        timeActivityTest.TimeActivityAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        timeActivityTest.TimeActivityFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        timeActivityTest.TimeActivityUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        timeActivityTest.TimeActivityRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "transfer tests"

        '#Region "sync tests"

        Dim transferTest As New TransferCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        transferTest.TransferAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        transferTest.TransferFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        transferTest.TransferUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        transferTest.TransferCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        transferTest.TransferBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        transferTest.TransferQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        transferTest.TransferDeleteTestUsingoAuth(qboContextoAuth)



        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        transferTest.TransferAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        transferTest.TransferFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        transferTest.TransferUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        transferTest.TransferRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "vendorCredit tests"

        '#Region "sync tests"

        Dim vendorCreditTest As New VendorCreditCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorCreditTest.VendorCreditAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorCreditTest.VendorCreditFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorCreditTest.VendorCreditUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorCreditTest.VendorCreditCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorCreditTest.VendorCreditBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorCreditTest.VendorCreditQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorCreditTest.VendorCreditDeleteTestUsingoAuth(qboContextoAuth)



        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorCreditTest.VendorCreditAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorCreditTest.VendorCreditFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorCreditTest.VendorCreditUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        vendorCreditTest.VendorCreditRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region


        '#End Region

        '#Region "Supporting Entities"

        '#Region "Attachable tests"


        '#Region "sync tests"

        Dim attachableTest As New AttachableCRUD()
        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableAddTestUsingoAuth(qboContextoAuth)

        'Upload
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableUploadDownloadAddTestUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableFindbyIdTestUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableUpdateTestUsingoAuth(qboContextoAuth)


        'Change Data Capture (Consider using Webhooks instead)
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableCDCTestUsingoAuth(qboContextoAuth)

        'Batch
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableBatchUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableQueryUsingoAuth(qboContextoAuth)


        'Delete is Hard delete
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableDeleteTestUsingoAuth(qboContextoAuth)



        '#End Region

        '#Region "async tests"


        'Add
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableAddAsyncTestsUsingoAuth(qboContextoAuth)

        'Find By Id
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableFindByIdAsyncTestsUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        attachableTest.AttachableRetrieveAsyncTestsUsingoAuth(qboContextoAuth)

        '#End Region

        '#End Region

        '#Region "CompanyInfo tests"


        '#Region "sync tests"

        Dim companyInfoTest As New CompanyInfoCRUD()

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        companyInfoTest.CompanyInfoQueryUsingoAuth(qboContextoAuth)


        '#End Region




        '#End Region

        '#Region "Preferences tests"

        '#Region "sync tests"

        Dim preferencesTest As New PreferencesCRUD()


        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        preferencesTest.PreferencesUpdateTestUsingoAuth(qboContextoAuth)


        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        preferencesTest.PreferencesQueryUsingoAuth(qboContextoAuth)






        '#End Region

        '#Region "async tests"


        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        preferencesTest.PreferencesUpdatedAsyncTestsUsingoAuth(qboContextoAuth)


        'FindAll(internally uses Query)
        qboContextoAuth.RequestId = Helper.GetGuid()
        preferencesTest.PreferencesRetrieveAsyncTestsUsingoAuth(qboContextoAuth)



        '#End Region


        '#End Region

        '#Region "CompanyCurrency tests"


        'MultiCurrency should be enabled in Company Settings->Advanced Settings for this to work
        Dim companyCurrencyTest As New CompanyCurrencyCRUD()

        'Add a currency to the active currency list
        qboContextoAuth.RequestId = Helper.GetGuid()
        companyCurrencyTest.CompanyCurrencyAddTestUsingoAuth(qboContextoAuth)

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        companyCurrencyTest.CompanyCurrencyQueryUsingoAuth(qboContextoAuth)

        'Delete is Update with Active=false
        qboContextoAuth.RequestId = Helper.GetGuid()
        companyCurrencyTest.CompanyCurrencyUpdateTestUsingoAuth(qboContextoAuth)




        '#End Region

        '#Region "ExchangeRate tests"


        '#Region "sync tests"

        Dim exchangRateTest As New ExchangeRateCRUD()

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        exchangRateTest.ExchangeRateQueryUsingoAuth(qboContextoAuth)

        'Update
        qboContextoAuth.RequestId = Helper.GetGuid()
        exchangRateTest.ExchangeRateUpdateTestUsingoAuth(qboContextoAuth)

        '#End Region


        '#End Region

        '#End Region


        '#End Region

        '#Region "GlobalTaxService tests"

        'DataService TaxCode and TaxRate entities can used only for Read/Query. 
        'Use GlobalTaxService(TaxService endpoint) for creating TaxCodes/TaxRates

        Dim globalTaxServiceTest As New GlobalTaxServiceCRUD()

        'Query solves same purpose as ReadAll
        qboContextoAuth.RequestId = Helper.GetGuid()
        globalTaxServiceTest.TaxCodeAddTestUsingoAuth(qboContextoAuth)



        '#End Region

        '#Region "ReportService tests"
        Dim reportTest As New ReportGeneralLedgerTest()
        reportTest.ReportGeneralLedgerTestUsingoAuth(qboContextoAuth)

        '#End Region

        '#Region "WebhooksService tests"

        'Refer sample app for Webhooks here- https://github.com/IntuitDeveloper

        '#End Region

        '#End Region
    End Sub
End Class

Imports System.Configuration
Imports Vendita.MAS
Imports Vendita.MAS.Models

Class MainWindow

    Private Property Api As IApi

    Private Async Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim url As String = ConfigurationManager.AppSettings("Vendita.MAS.Server")
        Api = New Api(url)
        DataContext = Await api.ListInvocationsAsync(365)
    End Sub

    Private Async Sub ShowInvocationOutputs(sender As Object, e As MouseEventArgs)
        Dim row As DataGridRow = sender
        Dim item = TryCast(row.Item, Invocation)
        If item Is Nothing Then
            Exit Sub
        End If
        Dim win = New OutputWindow()
        win.DataContext = Await Api.ListInvocationOutputsAsync(item.UUID)
        win.Show()
    End Sub

End Class

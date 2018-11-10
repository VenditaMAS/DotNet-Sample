Imports System.Configuration
Imports Vendita.MAS

Class MainWindow

    Private Async Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim url As String = ConfigurationManager.AppSettings("Vendita.MAS.Server")
        Dim api As IApi = New Api(url)
        DataContext = Await api.ListProcessesAsync()
    End Sub

End Class

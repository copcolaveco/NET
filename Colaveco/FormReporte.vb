Public Class FormReporte
    Private Sub FormReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d As New dDepartamento
        Dim lista As New ArrayList
        lista = d.listar
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each d In lista
                 
                Next
            End If
        End If

        Me.ReportViewer1.RefreshReport()
    End Sub


End Class
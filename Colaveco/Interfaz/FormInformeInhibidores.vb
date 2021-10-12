Public Class FormInformeInhibidores

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonListar.Click
        Dim inh As New dInhibidores
        Dim lista As New ArrayList
        Dim ficha As Long = TextFicha.Text.Trim
        lista = inh.listarporsolicitud(ficha)
        ListInhibidores.Items.Clear()
        If Not lista Is Nothing Then
            If lista.Count > 0 Then
                For Each inh In lista
                    Dim resultado As String
                    If inh.RESULTADO = 0 Then
                        resultado = "Negativo"
                    Else
                        resultado = "Positivo"
                    End If
                    ListInhibidores().Items.Add(inh.MUESTRA & Chr(9) & resultado)
                Next
            End If
        Else
            ListInhibidores().Items.Add("No se ha procesado esa muestra")
        End If
    End Sub
End Class
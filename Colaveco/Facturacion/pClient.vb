Public Class pClient
    Inherits Conectoras.ConexionMySQL_facturacion

    Public Function buscarxcli(ByVal o As Object) As dClient
        Dim obj As dClient = CType(o, dClient)
        Dim l As New dClient
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT clicod, clisct FROM client WHERE clicod = " & obj.CLICOD & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.CLICOD = CType(unaFila.Item(0), Long)
                l.CLISCT = CType(unaFila.Item(1), Long)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class

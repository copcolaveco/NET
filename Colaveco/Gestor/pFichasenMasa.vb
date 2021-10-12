Public Class pFichasenMasa
    Inherits Conectoras.ConexionMySQL
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dFichasenMasa = CType(o, dFichasenMasa)
        Dim sql As String = "DELETE FROM fichasenmasa WHERE ficha = " & obj.FICHA & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT ficha FROM fichasenmasa ORDER by ficha asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dFichasenMasa
                    l.ficha = CType(unaFila.Item(0), Long)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
